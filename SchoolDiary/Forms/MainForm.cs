using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SchoolDiary.Models;

namespace SchoolDiary.Forms
{
    public partial class MainForm : Form
    {
        private User _currentUser = new User
        {
            UserID = 1,
            Username = "admin",
            FullName = "Администратор системы",
            Role = "Администратор"
        };

        private DataTable? _gradesTable;
        private DataTable? _studentsTable;
        private bool _isLoading = true;

        /// <summary>
        /// Конструктор по умолчанию (необходим для визуального дизайнера Visual Studio)
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            pnlTop.Resize += (s, e) => pnlTop.Invalidate();
        }

        /// <summary>
        /// Основной конструктор с передачей авторизованного пользователя
        /// </summary>
        public MainForm(User? currentUser) : this()
        {
            if (currentUser != null)
            {
                _currentUser = currentUser;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _isLoading = true;
                ApplyUserContext();
                LoadFilterCombos();
                _isLoading = false;

                LoadGrades();
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при инициализации программы:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void tabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabGrades)
            {
                FormatGradesColumns();
            }
            else if (tabControl.SelectedTab == tabStudents)
            {
                FormatStudentsColumns();
            }
        }

        private void ApplyUserContext()
        {
            lblUserInfo.Text = $"Пользователь: {_currentUser.FullName} | Роль: {_currentUser.Role}";

            bool isStudent = string.Equals(_currentUser.Role, "Ученик", StringComparison.OrdinalIgnoreCase);

            if (isStudent)
            {
                btnAddGrade.Visible = false;
                btnEditGrade.Visible = false;
                btnDeleteGrade.Visible = false;

                btnAddStudent.Visible = false;
                btnEditStudent.Visible = false;
                btnDeleteStudent.Visible = false;
            }
            else
            {
                btnAddGrade.Visible = true;
                btnEditGrade.Visible = true;
                btnDeleteGrade.Visible = true;

                btnAddStudent.Visible = true;
                btnEditStudent.Visible = true;
                btnDeleteStudent.Visible = true;
            }
        }

        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            using var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK && loginForm.AuthenticatedUser != null)
            {
                _currentUser = loginForm.AuthenticatedUser;
                _isLoading = true;
                ApplyUserContext();
                LoadFilterCombos();
                _isLoading = false;
                LoadGrades();
                LoadStudents();
                this.Show();
            }
            else
            {
                this.Show();
            }
        }

        private void btnExitApp_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        // ==================== HELPER COLUMN FORMATTING ====================

        private static void SetColumnWidthIfExists(DataGridView dgv, string colName, int width, string? headerText = null)
        {
            if (dgv == null || dgv.Columns == null || dgv.Columns.Count == 0) return;
            if (dgv.Columns.Contains(colName))
            {
                var col = dgv.Columns[colName];
                if (col != null)
                {
                    if (width > 0) col.Width = width;
                    if (headerText != null) col.HeaderText = headerText;
                }
            }
        }

        private void FormatGradesColumns()
        {
            SetColumnWidthIfExists(dgvGrades, "ID", 50, "№");
            SetColumnWidthIfExists(dgvGrades, "Ученик", 240);
            SetColumnWidthIfExists(dgvGrades, "Класс", 80);
            SetColumnWidthIfExists(dgvGrades, "Предмет", 220);
            SetColumnWidthIfExists(dgvGrades, "Дата", 100);

            if (dgvGrades.Columns != null && dgvGrades.Columns.Contains("Оценка"))
            {
                var col = dgvGrades.Columns["Оценка"];
                if (col != null)
                {
                    col.Width = 80;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                }
            }
            if (dgvGrades.Columns != null && dgvGrades.Columns.Contains("StudentID"))
            {
                var col = dgvGrades.Columns["StudentID"];
                if (col != null) col.Visible = false;
            }
            if (dgvGrades.Columns != null && dgvGrades.Columns.Contains("SubjectID"))
            {
                var col = dgvGrades.Columns["SubjectID"];
                if (col != null) col.Visible = false;
            }
        }

        private void FormatStudentsColumns()
        {
            SetColumnWidthIfExists(dgvStudents, "Код", 60);
            SetColumnWidthIfExists(dgvStudents, "ФИО ученика", 320);
            SetColumnWidthIfExists(dgvStudents, "Класс", 100);
            SetColumnWidthIfExists(dgvStudents, "Телефон", 180);
        }

        // ==================== GRADES LOGIC ====================

        private void LoadFilterCombos()
        {
            try
            {
                // Students filter
                var students = DatabaseHelper.GetStudentsList();
                cmbFilterStudent.Items.Clear();
                cmbFilterStudent.Items.Add(new ComboBoxItem { Text = "— Все ученики —", Value = 0 });
                int selectIdx = 0;
                for (int i = 0; i < students.Count; i++)
                {
                    cmbFilterStudent.Items.Add(new ComboBoxItem { Text = students[i].FullName, Value = students[i].StudentID });
                    if (string.Equals(_currentUser.Role, "Ученик", StringComparison.OrdinalIgnoreCase) &&
                        _currentUser.FullName.Contains(students[i].FullName, StringComparison.OrdinalIgnoreCase))
                    {
                        selectIdx = i + 1;
                    }
                }
                cmbFilterStudent.SelectedIndex = selectIdx;

                // Subjects filter
                var subjects = DatabaseHelper.GetSubjectsList();
                cmbFilterSubject.Items.Clear();
                cmbFilterSubject.Items.Add(new ComboBoxItem { Text = "— Все предметы —", Value = 0 });
                foreach (var s in subjects)
                {
                    cmbFilterSubject.Items.Add(new ComboBoxItem { Text = s.SubjectName, Value = s.SubjectID });
                }
                cmbFilterSubject.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при заполнении фильтров:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGrades()
        {
            try
            {
                int studentId = 0;
                if (cmbFilterStudent.SelectedItem is ComboBoxItem itemStudent)
                    studentId = itemStudent.Value;

                int subjectId = 0;
                if (cmbFilterSubject.SelectedItem is ComboBoxItem itemSubject)
                    subjectId = itemSubject.Value;

                _gradesTable = DatabaseHelper.GetGradesTable(
                    studentId > 0 ? studentId : null,
                    subjectId > 0 ? subjectId : null
                );

                dgvGrades.BindingContext = this.BindingContext;
                dgvGrades.DataSource = _gradesTable;

                FormatGradesColumns();

                if (_gradesTable != null)
                    lblGradesCount.Text = $"Всего оценок: {_gradesTable.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки оценок из БД:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGrades_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e == null || e.CellStyle == null || e.Value == null || e.Value == DBNull.Value)
                    return;
                if (dgvGrades.Columns == null || e.ColumnIndex < 0 || e.ColumnIndex >= dgvGrades.Columns.Count)
                    return;

                var col = dgvGrades.Columns[e.ColumnIndex];
                if (col == null || col.Name != "Оценка")
                    return;

                // Строгий черно-белый стиль
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            }
            catch
            {
                // Подавление ошибок форматирования ячеек
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            LoadGrades();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            _isLoading = true;
            cmbFilterStudent.SelectedIndex = 0;
            cmbFilterSubject.SelectedIndex = 0;
            _isLoading = false;
            LoadGrades();
        }

        private void btnRefreshGrades_Click(object sender, EventArgs e)
        {
            LoadGrades();
        }

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            int preStudent = 0;
            if (cmbFilterStudent.SelectedItem is ComboBoxItem s) preStudent = s.Value;
            int preSubject = 0;
            if (cmbFilterSubject.SelectedItem is ComboBoxItem sub) preSubject = sub.Value;

            using var form = new GradeEditForm(null, preStudent, preSubject);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadGrades();
            }
        }

        private void btnEditGrade_Click(object sender, EventArgs e)
        {
            if (string.Equals(_currentUser.Role, "Ученик", StringComparison.OrdinalIgnoreCase))
                return;

            if (dgvGrades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите оценку для редактирования!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvGrades.SelectedRows[0];
            int gradeId = Convert.ToInt32(row.Cells["ID"].Value);
            int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);
            int subjectId = Convert.ToInt32(row.Cells["SubjectID"].Value);
            DateTime date = Convert.ToDateTime(row.Cells["Дата"].Value);
            int gradeValue = Convert.ToInt32(row.Cells["Оценка"].Value);
            string comment = row.Cells["Примечание"].Value?.ToString() ?? string.Empty;

            var grade = new Grade
            {
                GradeID = gradeId,
                StudentID = studentId,
                SubjectID = subjectId,
                LessonDate = date,
                GradeValue = gradeValue,
                Comment = comment
            };

            using var form = new GradeEditForm(grade);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadGrades();
            }
        }

        private void btnDeleteGrade_Click(object sender, EventArgs e)
        {
            if (dgvGrades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите оценку для удаления!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvGrades.SelectedRows[0];
            int gradeId = Convert.ToInt32(row.Cells["ID"].Value);
            string student = row.Cells["Ученик"].Value?.ToString() ?? string.Empty;
            string subject = row.Cells["Предмет"].Value?.ToString() ?? string.Empty;
            string val = row.Cells["Оценка"].Value?.ToString() ?? string.Empty;

            var confirm = MessageBox.Show(
                $"Вы действительно хотите удалить оценку '{val}' по предмету '{subject}' ученика '{student}' из базы данных?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.DeleteGrade(gradeId);
                    LoadGrades();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении оценки из БД:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== STUDENTS LOGIC ====================

        private void LoadStudents()
        {
            try
            {
                _studentsTable = DatabaseHelper.GetStudentsTable();
                dgvStudents.BindingContext = this.BindingContext;
                dgvStudents.DataSource = _studentsTable;

                FormatStudentsColumns();

                if (_studentsTable != null)
                    lblStudentsCount.Text = $"Всего учеников: {_studentsTable.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки списка учеников:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchStudent_TextChanged(object sender, EventArgs e)
        {
            if (_studentsTable == null) return;
            string filter = txtSearchStudent.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(filter))
            {
                _studentsTable.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                _studentsTable.DefaultView.RowFilter = $"[ФИО ученика] LIKE '%{filter}%' OR [Класс] LIKE '%{filter}%'";
            }
            lblStudentsCount.Text = $"Найдено учеников: {_studentsTable.DefaultView.Count}";
        }

        private void btnRefreshStudents_Click(object sender, EventArgs e)
        {
            txtSearchStudent.Clear();
            LoadStudents();
            LoadFilterCombos();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            using var form = new StudentEditForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadStudents();
                LoadFilterCombos();
            }
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            if (string.Equals(_currentUser.Role, "Ученик", StringComparison.OrdinalIgnoreCase))
                return;

            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите ученика для редактирования!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvStudents.SelectedRows[0];
            int studentId = Convert.ToInt32(row.Cells["Код"].Value);
            string fullName = row.Cells["ФИО ученика"].Value?.ToString() ?? string.Empty;
            string classGrade = row.Cells["Класс"].Value?.ToString() ?? string.Empty;
            string phone = row.Cells["Телефон"].Value?.ToString() ?? string.Empty;

            var student = new Student
            {
                StudentID = studentId,
                FullName = fullName,
                ClassGrade = classGrade,
                Phone = phone
            };

            using var form = new StudentEditForm(student);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadStudents();
                LoadFilterCombos();
                LoadGrades();
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите ученика для удаления!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvStudents.SelectedRows[0];
            int studentId = Convert.ToInt32(row.Cells["Код"].Value);
            string fullName = row.Cells["ФИО ученика"].Value?.ToString() ?? string.Empty;

            var confirm = MessageBox.Show(
                $"Внимание! Удаление ученика '{fullName}' также удалит все выставленные ему оценки из базы данных.\n\nПродолжить?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.DeleteStudent(studentId);
                    LoadStudents();
                    LoadFilterCombos();
                    LoadGrades();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении ученика:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pnlTop_Paint(object? sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(220, 220, 220));
            e.Graphics.DrawLine(pen, 0, pnlTop.Height - 1, pnlTop.Width, pnlTop.Height - 1);
        }

        private class ComboBoxItem
        {
            public string Text { get; set; } = string.Empty;
            public int Value { get; set; }
            public override string ToString() => Text;
        }
    }
}
