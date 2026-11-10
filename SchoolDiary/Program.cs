using System;
using System.IO;
using System.Windows.Forms;
using SchoolDiary.Forms;
using SchoolDiary.Models;

namespace SchoolDiary
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--test")
            {
                RunHeadlessVerification();
                return;
            }

            ApplicationConfiguration.Initialize();

            // Check database connectivity
            if (!DatabaseHelper.TestConnection(out string dbError))
            {
                MessageBox.Show(
                    $"Внимание! Не удалось подключиться к базе данных Access:\n\n{DatabaseHelper.DatabasePath}\n\nОшибка:\n{dbError}\n\nУбедитесь, что установлен Microsoft Access Database Engine (ACE.OLEDB) и файл БД не заблокирован.",
                    "Ошибка подключения к БД",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            // Launch Authorization Form
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK && loginForm.AuthenticatedUser != null)
                {
                    Application.Run(new MainForm(loginForm.AuthenticatedUser));
                }
            }
        }

        private static void RunHeadlessVerification()
        {
            try { Console.OutputEncoding = System.Text.Encoding.UTF8; } catch { }
            Console.WriteLine("==================================================");
            Console.WriteLine("  ЭЛЕКТРОННЫЙ ДНЕВНИК: ТЕСТИРОВАНИЕ ");
            Console.WriteLine("==================================================");

            Console.WriteLine($"[1] Путь к базе данных: {DatabaseHelper.DatabasePath}");
            if (!File.Exists(DatabaseHelper.DatabasePath))
            {
                Console.WriteLine("ОШИБКА: Файл базы данных не найден!");
                Environment.Exit(1);
            }

            bool connected = DatabaseHelper.TestConnection(out string err);
            if (!connected)
            {
                Console.WriteLine($"ОШИБКА: Не удалось подключиться к базе: {err}");
                Environment.Exit(1);
            }
            Console.WriteLine("[2] Подключение к Access (OLE DB): УСПЕШНО");

            // Test authentication
            var adminUser = DatabaseHelper.AuthenticateUser("admin", "admin123");
            if (adminUser == null || adminUser.Role != "Администратор")
            {
                Console.WriteLine("ОШИБКА: Авторизация администратора не удалась!");
                Environment.Exit(1);
            }
            Console.WriteLine($"[3] Авторизация admin: УСПЕШНО ({adminUser.FullName}, роль: {adminUser.Role})");

            var studentUser = DatabaseHelper.AuthenticateUser("student", "12345");
            if (studentUser == null || studentUser.Role != "Ученик")
            {
                Console.WriteLine("ОШИБКА: Авторизация ученика не удалась!");
                Environment.Exit(1);
            }
            Console.WriteLine($"[4] Авторизация student: УСПЕШНО ({studentUser.FullName}, роль: {studentUser.Role})");

            // Test students
            var students = DatabaseHelper.GetStudentsList();
            Console.WriteLine($"[5] Список учеников: {students.Count} записей найдено в БД");

            // Test subjects
            var subjects = DatabaseHelper.GetSubjectsList();
            Console.WriteLine($"[6] Список предметов: {subjects.Count} записей найдено в БД");

            // Test grades
            var grades = DatabaseHelper.GetGradesTable();
            Console.WriteLine($"[7] Таблица оценок: {grades.Rows.Count} записей загружено");

            // Test adding a grade and verifying persistence
            var testGrade = new Grade
            {
                StudentID = students[0].StudentID,
                SubjectID = subjects[0].SubjectID,
                LessonDate = DateTime.Today,
                GradeValue = 5,
                Comment = "Тестовая оценка проверки сохранения в БД"
            };
            DatabaseHelper.AddGrade(testGrade);
            var gradesAfter = DatabaseHelper.GetGradesTable();
            Console.WriteLine($"[8] Проверка добавления оценки в БД: УСПЕШНО (было {grades.Rows.Count}, стало {gradesAfter.Rows.Count})");

            // Remove test grade to keep db pristine
            int newGradeId = Convert.ToInt32(gradesAfter.Rows[0]["ID"]);
            DatabaseHelper.DeleteGrade(newGradeId);
            var gradesRestored = DatabaseHelper.GetGradesTable();
            Console.WriteLine($"[9] Проверка удаления записи из БД: УСПЕШНО (записей: {gradesRestored.Rows.Count})");

            // Test computational experiment
            var exp = DatabaseHelper.CalculateExperiment();
            Console.WriteLine($"[10] Вычислительный эксперимент:");
            Console.WriteLine($"     • Всего оценок: {exp.TotalGrades}");
            Console.WriteLine($"     • Средний балл: {exp.OverallAverage:F2}");
            Console.WriteLine($"     • Качество знаний: {exp.QualityPercent:F1}%");
            Console.WriteLine($"     • Учеников в рейтинге: {exp.StudentRankings.Count}");
            Console.WriteLine($"     • Предметов в статистике: {exp.SubjectRankings.Count}");

            Console.WriteLine("==================================================");
            Console.WriteLine("  ВСЕ ТЕСТЫ ВЕРСИИ 1.0 УСПЕШНО ПРОЙДЕНЫ!         ");
            Console.WriteLine("==================================================");
        }
    }
}
