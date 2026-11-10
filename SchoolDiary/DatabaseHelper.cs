using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using SchoolDiary.Models;

namespace SchoolDiary
{
    public static class DatabaseHelper
    {
        private static string _dbPath = string.Empty;
        private static string _provider = "Microsoft.ACE.OLEDB.12.0";

        public static string DatabasePath
        {
            get
            {
                if (string.IsNullOrEmpty(_dbPath) || !File.Exists(_dbPath))
                {
                    _dbPath = FindDatabasePath();
                }
                return _dbPath;
            }
        }

        private static string FindDatabasePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string[] candidates = new[]
            {
                Path.Combine(baseDir, "SchoolDiary.accdb"),
                Path.Combine(baseDir, "Database", "SchoolDiary.accdb"),
                Path.Combine(baseDir, "..", "Database", "SchoolDiary.accdb"),
                Path.Combine(baseDir, "..", "..", "Database", "SchoolDiary.accdb"),
                Path.Combine(baseDir, "..", "..", "..", "Database", "SchoolDiary.accdb"),
                Path.Combine(baseDir, "..", "..", "..", "..", "Database", "SchoolDiary.accdb"),
                @"C:\Users\xipwl\OneDrive\Desktop\PM03\Database\SchoolDiary.accdb"
            };

            foreach (var candidate in candidates)
            {
                try
                {
                    string full = Path.GetFullPath(candidate);
                    if (File.Exists(full))
                    {
                        return full;
                    }
                }
                catch { }
            }

            // Fallback default
            return Path.Combine(baseDir, "SchoolDiary.accdb");
        }

        public static string GetConnectionString()
        {
            return $"Provider={_provider};Data Source={DatabasePath};Persist Security Info=False;";
        }

        public static OleDbConnection GetOpenConnection()
        {
            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            try
            {
                conn.Open();
                return conn;
            }
            catch
            {
                // Try fallback to ACE.OLEDB.16.0 if 12.0 failed
                if (_provider == "Microsoft.ACE.OLEDB.12.0")
                {
                    _provider = "Microsoft.ACE.OLEDB.16.0";
                    conn = new OleDbConnection(GetConnectionString());
                    conn.Open();
                    return conn;
                }
                throw;
            }
        }

        public static bool TestConnection(out string errorMessage)
        {
            try
            {
                using var conn = GetOpenConnection();
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        // ==================== AUTHENTICATION ====================

        public static User? AuthenticateUser(string username, string password)
        {
            using var conn = GetOpenConnection();
            string query = "SELECT [UserID], [Username], [Password], [FullName], [Role] FROM [Users] WHERE [Username] = ? AND [Password] = ?";
            using var cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("?", username.Trim());
            cmd.Parameters.AddWithValue("?", password.Trim());

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    UserID = Convert.ToInt32(reader["UserID"]),
                    Username = reader["Username"].ToString() ?? string.Empty,
                    Password = reader["Password"].ToString() ?? string.Empty,
                    FullName = reader["FullName"].ToString() ?? string.Empty,
                    Role = reader["Role"].ToString() ?? string.Empty
                };
            }
            return null;
        }

        // ==================== STUDENTS ====================

        public static DataTable GetStudentsTable()
        {
            using var conn = GetOpenConnection();
            string query = "SELECT [StudentID] AS [Код], [FullName] AS [ФИО ученика], [ClassGrade] AS [Класс], [Phone] AS [Телефон] FROM [Students] ORDER BY [FullName]";
            using var adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static List<Student> GetStudentsList()
        {
            var list = new List<Student>();
            using var conn = GetOpenConnection();
            string query = "SELECT [StudentID], [FullName], [ClassGrade], [Phone] FROM [Students] ORDER BY [FullName]";
            using var cmd = new OleDbCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Student
                {
                    StudentID = Convert.ToInt32(reader["StudentID"]),
                    FullName = reader["FullName"].ToString() ?? string.Empty,
                    ClassGrade = reader["ClassGrade"].ToString() ?? string.Empty,
                    Phone = reader["Phone"].ToString() ?? string.Empty
                });
            }
            return list;
        }

        public static void AddStudent(Student student)
        {
            using var conn = GetOpenConnection();
            string query = "INSERT INTO [Students] ([FullName], [ClassGrade], [Phone]) VALUES (?, ?, ?)";
            using var cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("?", student.FullName);
            cmd.Parameters.AddWithValue("?", student.ClassGrade);
            cmd.Parameters.AddWithValue("?", student.Phone);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateStudent(Student student)
        {
            using var conn = GetOpenConnection();
            string query = "UPDATE [Students] SET [FullName] = ?, [ClassGrade] = ?, [Phone] = ? WHERE [StudentID] = ?";
            using var cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("?", student.FullName);
            cmd.Parameters.AddWithValue("?", student.ClassGrade);
            cmd.Parameters.AddWithValue("?", student.Phone);
            cmd.Parameters.AddWithValue("?", student.StudentID);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteStudent(int studentId)
        {
            using var conn = GetOpenConnection();
            // Delete student's grades first
            using (var cmdGrades = new OleDbCommand("DELETE FROM [Grades] WHERE [StudentID] = ?", conn))
            {
                cmdGrades.Parameters.AddWithValue("?", studentId);
                cmdGrades.ExecuteNonQuery();
            }
            // Delete student
            using (var cmdStudent = new OleDbCommand("DELETE FROM [Students] WHERE [StudentID] = ?", conn))
            {
                cmdStudent.Parameters.AddWithValue("?", studentId);
                cmdStudent.ExecuteNonQuery();
            }
        }

        // ==================== SUBJECTS ====================

        public static List<Subject> GetSubjectsList()
        {
            var list = new List<Subject>();
            using var conn = GetOpenConnection();
            string query = "SELECT [SubjectID], [SubjectName], [TeacherName] FROM [Subjects] ORDER BY [SubjectName]";
            using var cmd = new OleDbCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Subject
                {
                    SubjectID = Convert.ToInt32(reader["SubjectID"]),
                    SubjectName = reader["SubjectName"].ToString() ?? string.Empty,
                    TeacherName = reader["TeacherName"].ToString() ?? string.Empty
                });
            }
            return list;
        }

        // ==================== GRADES ====================

        public static DataTable GetGradesTable(int? studentId = null, int? subjectId = null)
        {
            using var conn = GetOpenConnection();
            string query = @"SELECT 
                                g.[GradeID] AS [ID],
                                g.[StudentID],
                                s.[FullName] AS [Ученик],
                                s.[ClassGrade] AS [Класс],
                                g.[SubjectID],
                                sub.[SubjectName] AS [Предмет],
                                g.[LessonDate] AS [Дата],
                                g.[GradeValue] AS [Оценка],
                                g.[Comment] AS [Примечание]
                             FROM ([Grades] g
                             INNER JOIN [Students] s ON g.[StudentID] = s.[StudentID])
                             INNER JOIN [Subjects] sub ON g.[SubjectID] = sub.[SubjectID]
                             WHERE 1=1 ";

            if (studentId.HasValue && studentId.Value > 0)
                query += " AND g.[StudentID] = ? ";
            if (subjectId.HasValue && subjectId.Value > 0)
                query += " AND g.[SubjectID] = ? ";

            query += " ORDER BY g.[LessonDate] DESC, g.[GradeID] DESC";

            using var cmd = new OleDbCommand(query, conn);
            if (studentId.HasValue && studentId.Value > 0)
                cmd.Parameters.AddWithValue("?", studentId.Value);
            if (subjectId.HasValue && subjectId.Value > 0)
                cmd.Parameters.AddWithValue("?", subjectId.Value);

            using var adapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static void AddGrade(Grade grade)
        {
            using var conn = GetOpenConnection();
            string query = "INSERT INTO [Grades] ([StudentID], [SubjectID], [LessonDate], [GradeValue], [Comment]) VALUES (?, ?, ?, ?, ?)";
            using var cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("?", grade.StudentID);
            cmd.Parameters.AddWithValue("?", grade.SubjectID);
            cmd.Parameters.AddWithValue("?", grade.LessonDate.Date);
            cmd.Parameters.AddWithValue("?", grade.GradeValue);
            cmd.Parameters.AddWithValue("?", grade.Comment ?? string.Empty);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateGrade(Grade grade)
        {
            using var conn = GetOpenConnection();
            string query = "UPDATE [Grades] SET [StudentID] = ?, [SubjectID] = ?, [LessonDate] = ?, [GradeValue] = ?, [Comment] = ? WHERE [GradeID] = ?";
            using var cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("?", grade.StudentID);
            cmd.Parameters.AddWithValue("?", grade.SubjectID);
            cmd.Parameters.AddWithValue("?", grade.LessonDate.Date);
            cmd.Parameters.AddWithValue("?", grade.GradeValue);
            cmd.Parameters.AddWithValue("?", grade.Comment ?? string.Empty);
            cmd.Parameters.AddWithValue("?", grade.GradeID);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteGrade(int gradeId)
        {
            using var conn = GetOpenConnection();
            string query = "DELETE FROM [Grades] WHERE [GradeID] = ?";
            using var cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("?", gradeId);
            cmd.ExecuteNonQuery();
        }

        // ==================== COMPUTATIONAL EXPERIMENT ====================

        public class StudentStats
        {
            public int StudentID { get; set; }
            public string FullName { get; set; } = string.Empty;
            public string ClassGrade { get; set; } = string.Empty;
            public int GradesCount { get; set; }
            public double AverageGrade { get; set; }
            public string Category { get; set; } = string.Empty;
        }

        public class SubjectStats
        {
            public string SubjectName { get; set; } = string.Empty;
            public int GradesCount { get; set; }
            public double AverageGrade { get; set; }
        }

        public class ExperimentResult
        {
            public int TotalGrades { get; set; }
            public double OverallAverage { get; set; }
            public int Count5 { get; set; }
            public int Count4 { get; set; }
            public int Count3 { get; set; }
            public int Count2 { get; set; }
            public double QualityPercent { get; set; } // % of 4 and 5
            public double SuccessPercent { get; set; } // % without 2
            public List<StudentStats> StudentRankings { get; set; } = new();
            public List<SubjectStats> SubjectRankings { get; set; } = new();
        }

        public static ExperimentResult CalculateExperiment()
        {
            var result = new ExperimentResult();
            using var conn = GetOpenConnection();

            // 1. Overall grades stats
            string queryGrades = "SELECT [GradeValue] FROM [Grades]";
            using (var cmd = new OleDbCommand(queryGrades, conn))
            using (var reader = cmd.ExecuteReader())
            {
                int sum = 0;
                while (reader.Read())
                {
                    int val = Convert.ToInt32(reader["GradeValue"]);
                    result.TotalGrades++;
                    sum += val;
                    if (val == 5) result.Count5++;
                    else if (val == 4) result.Count4++;
                    else if (val == 3) result.Count3++;
                    else if (val == 2) result.Count2++;
                }
                if (result.TotalGrades > 0)
                {
                    result.OverallAverage = Math.Round((double)sum / result.TotalGrades, 2);
                    result.QualityPercent = Math.Round((double)(result.Count5 + result.Count4) / result.TotalGrades * 100.0, 1);
                    result.SuccessPercent = Math.Round((double)(result.TotalGrades - result.Count2) / result.TotalGrades * 100.0, 1);
                }
            }

            // 2. Student performance calculation
            string queryStudents = @"SELECT 
                                        s.[StudentID],
                                        s.[FullName],
                                        s.[ClassGrade],
                                        COUNT(g.[GradeID]) AS [Cnt],
                                        AVG(g.[GradeValue]) AS [AvgVal],
                                        MIN(g.[GradeValue]) AS [MinVal]
                                     FROM [Students] s
                                     LEFT JOIN [Grades] g ON s.[StudentID] = g.[StudentID]
                                     GROUP BY s.[StudentID], s.[FullName], s.[ClassGrade]
                                     ORDER BY AVG(g.[GradeValue]) DESC, s.[FullName]";

            using (var cmd = new OleDbCommand(queryStudents, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int cnt = reader["Cnt"] != DBNull.Value ? Convert.ToInt32(reader["Cnt"]) : 0;
                    double avg = reader["AvgVal"] != DBNull.Value ? Math.Round(Convert.ToDouble(reader["AvgVal"]), 2) : 0.0;
                    int min = reader["MinVal"] != DBNull.Value ? Convert.ToInt32(reader["MinVal"]) : 0;

                    string category = "Нет оценок";
                    if (cnt > 0)
                    {
                        if (min == 5) category = "Отличник (5.0)";
                        else if (min >= 4) category = "Хорошист (4-5)";
                        else if (min >= 3) category = "Успевающий (3-5)";
                        else category = "Требуется помощь (есть 2)";
                    }

                    result.StudentRankings.Add(new StudentStats
                    {
                        StudentID = Convert.ToInt32(reader["StudentID"]),
                        FullName = reader["FullName"].ToString() ?? string.Empty,
                        ClassGrade = reader["ClassGrade"].ToString() ?? string.Empty,
                        GradesCount = cnt,
                        AverageGrade = avg,
                        Category = category
                    });
                }
            }

            // 3. Subject stats
            string querySubjects = @"SELECT 
                                        sub.[SubjectName],
                                        COUNT(g.[GradeID]) AS [Cnt],
                                        AVG(g.[GradeValue]) AS [AvgVal]
                                     FROM [Subjects] sub
                                     LEFT JOIN [Grades] g ON sub.[SubjectID] = g.[SubjectID]
                                     GROUP BY sub.[SubjectName]
                                     ORDER BY AVG(g.[GradeValue]) DESC, sub.[SubjectName]";

            using (var cmd = new OleDbCommand(querySubjects, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int cnt = reader["Cnt"] != DBNull.Value ? Convert.ToInt32(reader["Cnt"]) : 0;
                    double avg = reader["AvgVal"] != DBNull.Value ? Math.Round(Convert.ToDouble(reader["AvgVal"]), 2) : 0.0;

                    result.SubjectRankings.Add(new SubjectStats
                    {
                        SubjectName = reader["SubjectName"].ToString() ?? string.Empty,
                        GradesCount = cnt,
                        AverageGrade = avg
                    });
                }
            }

            return result;
        }
    }
}
