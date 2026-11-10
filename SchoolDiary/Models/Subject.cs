namespace SchoolDiary.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;

        public override string ToString() => SubjectName;
    }
}
