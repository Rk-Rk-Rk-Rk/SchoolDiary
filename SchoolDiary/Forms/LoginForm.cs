using System;
using System.Windows.Forms;
using SchoolDiary.Models;

namespace SchoolDiary.Forms
{
    public partial class LoginForm : Form
    {
        public User? AuthenticatedUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void DoLogin()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                lblStatus.ForeColor = System.Drawing.Color.FromArgb(180, 20, 20);
                lblStatus.Text = "Введите логин пользователя!";
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblStatus.ForeColor = System.Drawing.Color.FromArgb(180, 20, 20);
                lblStatus.Text = "Введите пароль!";
                txtPassword.Focus();
                return;
            }

            try
            {
                lblStatus.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
                lblStatus.Text = "Проверка данных...";
                Application.DoEvents();

                User? user = DatabaseHelper.AuthenticateUser(username, password);
                if (user != null)
                {
                    AuthenticatedUser = user;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(180, 20, 20);
                    lblStatus.Text = "Неверный логин или пароль!";
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = System.Drawing.Color.FromArgb(180, 20, 20);
                lblStatus.Text = "Ошибка подключения к БД:\n" + ex.Message;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }
    }
}
