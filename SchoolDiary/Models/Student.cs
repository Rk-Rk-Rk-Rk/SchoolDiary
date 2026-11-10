namespace SchoolDiary.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ClassGrade { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public override string ToString() => $"{FullName} [{ClassGrade}]";
    }
}
