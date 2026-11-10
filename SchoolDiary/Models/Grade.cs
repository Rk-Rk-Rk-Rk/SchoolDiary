using System;

namespace SchoolDiary.Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public DateTime LessonDate { get; set; } = DateTime.Today;
        public int GradeValue { get; set; } = 5;
        public string Comment { get; set; } = string.Empty;

        // Joined helper fields
        public string StudentName { get; set; } = string.Empty;
        public string ClassGrade { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
    }
}
