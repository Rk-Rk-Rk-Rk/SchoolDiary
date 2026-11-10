using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolDiary.Models;

namespace SchoolDiary.Forms
{
    public partial class GradeEditForm : Form
    {
        private Grade? _grade;
        private List<Student> _students = new();
        private List<Subject> _subjects = new();

        public GradeEditForm(Grade? grade = null, int? preselectedStudentId = null, int? preselectedSubjectId = null)
        {
            InitializeComponent();
            _grade = grade;

            LoadData();

            if (_grade != null)
            {
                this.Text = "Редактирование оценки";
                lblHeader.Text = "Изменение оценки в БД";
                SelectStudent(_grade.StudentID);
                SelectSubject(_grade.SubjectID);
                dtpDate.Value = _grade.LessonDate;
                SetGradeValueCombo(_grade.GradeValue);
                txtComment.Text = _grade.Comment;
            }
            else
            {
                this.Text = "Выставление оценки";
                lblHeader.Text = "Новая запись в дневник";
                cmbGrade.SelectedIndex = 0; // 5 (Отлично)
                if (preselectedStudentId.HasValue && preselectedStudentId > 0)
                    SelectStudent(preselectedStudentId.Value);
                if (preselectedSubjectId.HasValue && preselectedSubjectId > 0)
                    SelectSubject(preselectedSubjectId.Value);
            }
        }

        private void LoadData()
        {
            try
            {
                _students = DatabaseHelper.GetStudentsList();
                cmbStudent.DataSource = _students;
                cmbStudent.DisplayMember = "FullName";
                cmbStudent.ValueMember = "StudentID";

                _subjects = DatabaseHelper.GetSubjectsList();
                cmbSubject.DataSource = _subjects;
                cmbSubject.DisplayMember = "SubjectName";
                cmbSubject.ValueMember = "SubjectID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки списков из БД:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectStudent(int studentId)
        {
            for (int i = 0; i < cmbStudent.Items.Count; i++)
            {
                if (cmbStudent.Items[i] is Student s && s.StudentID == studentId)
                {
                    cmbStudent.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SelectSubject(int subjectId)
        {
            for (int i = 0; i < cmbSubject.Items.Count; i++)
            {
                if (cmbSubject.Items[i] is Subject sub && sub.SubjectID == subjectId)
                {
                    cmbSubject.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SetGradeValueCombo(int value)
        {
            switch (value)
            {
                case 5: cmbGrade.SelectedIndex = 0; break;
                case 4: cmbGrade.SelectedIndex = 1; break;
                case 3: cmbGrade.SelectedIndex = 2; break;
                case 2: cmbGrade.SelectedIndex = 3; break;
                default: cmbGrade.SelectedIndex = 0; break;
            }
        }

        private int GetSelectedGradeValue()
        {
            return cmbGrade.SelectedIndex switch
            {
                0 => 5,
                1 => 4,
                2 => 3,
                3 => 2,
                _ => 5
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedValue == null)
            {
                MessageBox.Show("Выберите ученика!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSubject.SelectedValue == null)
            {
                MessageBox.Show("Выберите предмет!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentId = Convert.ToInt32(cmbStudent.SelectedValue);
            int subjectId = Convert.ToInt32(cmbSubject.SelectedValue);
            DateTime lessonDate = dtpDate.Value.Date;
            int gradeValue = GetSelectedGradeValue();
            string comment = txtComment.Text.Trim();

            try
            {
                if (_grade == null)
                {
                    // Add new
                    var newGrade = new Grade
                    {
                        StudentID = studentId,
                        SubjectID = subjectId,
                        LessonDate = lessonDate,
                        GradeValue = gradeValue,
                        Comment = comment
                    };
                    DatabaseHelper.AddGrade(newGrade);
                }
                else
                {
                    // Update existing
                    _grade.StudentID = studentId;
                    _grade.SubjectID = subjectId;
                    _grade.LessonDate = lessonDate;
                    _grade.GradeValue = gradeValue;
                    _grade.Comment = comment;
                    DatabaseHelper.UpdateGrade(_grade);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения оценки в БД:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
