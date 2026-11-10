using System;
using System.Windows.Forms;
using SchoolDiary.Models;

namespace SchoolDiary.Forms
{
    public partial class StudentEditForm : Form
    {
        private Student? _student;

        public StudentEditForm(Student? student = null)
        {
            InitializeComponent();
            _student = student;

            if (_student != null)
            {
                this.Text = "Редактирование ученика";
                lblHeader.Text = "Редактирование данных";
                txtFullName.Text = _student.FullName;
                txtClass.Text = _student.ClassGrade;
                txtPhone.Text = _student.Phone;
            }
            else
            {
                this.Text = "Добавление нового ученика";
                lblHeader.Text = "Новый ученик / студент";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string classGrade = txtClass.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Пожалуйста, укажите ФИО ученика!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            try
            {
                if (_student == null)
                {
                    // Add new
                    var newStudent = new Student
                    {
                        FullName = fullName,
                        ClassGrade = classGrade,
                        Phone = phone
                    };
                    DatabaseHelper.AddStudent(newStudent);
                }
                else
                {
                    // Update existing
                    _student.FullName = fullName;
                    _student.ClassGrade = classGrade;
                    _student.Phone = phone;
                    DatabaseHelper.UpdateStudent(_student);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения в базу данных:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
