namespace SchoolDiary.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnExitApp = new System.Windows.Forms.Button();
            this.btnSwitchUser = new System.Windows.Forms.Button();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGrades = new System.Windows.Forms.TabPage();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.pnlGradesBottom = new System.Windows.Forms.Panel();
            this.lblGradesCount = new System.Windows.Forms.Label();
            this.btnDeleteGrade = new System.Windows.Forms.Button();
            this.btnEditGrade = new System.Windows.Forms.Button();
            this.btnAddGrade = new System.Windows.Forms.Button();
            this.pnlGradesFilter = new System.Windows.Forms.Panel();
            this.btnRefreshGrades = new System.Windows.Forms.Button();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.cmbFilterSubject = new System.Windows.Forms.ComboBox();
            this.lblFilterSubject = new System.Windows.Forms.Label();
            this.cmbFilterStudent = new System.Windows.Forms.ComboBox();
            this.lblFilterStudent = new System.Windows.Forms.Label();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.pnlStudentsBottom = new System.Windows.Forms.Panel();
            this.lblStudentsCount = new System.Windows.Forms.Label();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.btnEditStudent = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.pnlStudentsSearch = new System.Windows.Forms.Panel();
            this.btnRefreshStudents = new System.Windows.Forms.Button();
            this.txtSearchStudent = new System.Windows.Forms.TextBox();
            this.lblSearchStudent = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabGrades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.pnlGradesBottom.SuspendLayout();
            this.pnlGradesFilter.SuspendLayout();
            this.tabStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.pnlStudentsBottom.SuspendLayout();
            this.pnlStudentsSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnExitApp);
            this.pnlTop.Controls.Add(this.btnSwitchUser);
            this.pnlTop.Controls.Add(this.lblUserInfo);
            this.pnlTop.Controls.Add(this.lblAppTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1000, 52);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            // 
            // btnExitApp
            // 
            this.btnExitApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitApp.BackColor = System.Drawing.Color.White;
            this.btnExitApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExitApp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExitApp.ForeColor = System.Drawing.Color.Black;
            this.btnExitApp.Location = new System.Drawing.Point(895, 10);
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(95, 32);
            this.btnExitApp.TabIndex = 3;
            this.btnExitApp.Text = "Выход";
            this.btnExitApp.UseVisualStyleBackColor = true;
            this.btnExitApp.Click += new System.EventHandler(this.btnExitApp_Click);
            // 
            // btnSwitchUser
            // 
            this.btnSwitchUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwitchUser.BackColor = System.Drawing.Color.White;
            this.btnSwitchUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwitchUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSwitchUser.ForeColor = System.Drawing.Color.Black;
            this.btnSwitchUser.Location = new System.Drawing.Point(745, 10);
            this.btnSwitchUser.Name = "btnSwitchUser";
            this.btnSwitchUser.Size = new System.Drawing.Size(140, 32);
            this.btnSwitchUser.TabIndex = 2;
            this.btnSwitchUser.Text = "Сменить вход";
            this.btnSwitchUser.UseVisualStyleBackColor = true;
            this.btnSwitchUser.Click += new System.EventHandler(this.btnSwitchUser_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblUserInfo.Location = new System.Drawing.Point(380, 15);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(350, 23);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Пользователь: Загрузка...";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAppTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAppTitle.Location = new System.Drawing.Point(15, 13);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(225, 28);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "Электронный дневник";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGrades);
            this.tabControl.Controls.Add(this.tabStudents);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl.Location = new System.Drawing.Point(0, 52);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 628);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabGrades
            // 
            this.tabGrades.Controls.Add(this.dgvGrades);
            this.tabGrades.Controls.Add(this.pnlGradesBottom);
            this.tabGrades.Controls.Add(this.pnlGradesFilter);
            this.tabGrades.Location = new System.Drawing.Point(4, 30);
            this.tabGrades.Name = "tabGrades";
            this.tabGrades.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrades.Size = new System.Drawing.Size(992, 594);
            this.tabGrades.TabIndex = 0;
            this.tabGrades.Text = " Дневник и оценки ";
            this.tabGrades.UseVisualStyleBackColor = true;
            // 
            // dgvGrades
            // 
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.AllowUserToDeleteRows = false;
            this.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrades.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrades.ColumnHeadersHeight = 34;
            this.dgvGrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrades.EnableHeadersVisualStyles = false;
            this.dgvGrades.Location = new System.Drawing.Point(3, 53);
            this.dgvGrades.MultiSelect = false;
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.ReadOnly = true;
            this.dgvGrades.RowHeadersVisible = false;
            this.dgvGrades.RowHeadersWidth = 51;
            this.dgvGrades.RowTemplate.Height = 30;
            this.dgvGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrades.Size = new System.Drawing.Size(986, 491);
            this.dgvGrades.TabIndex = 1;
            this.dgvGrades.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGrades_CellFormatting);
            this.dgvGrades.DoubleClick += new System.EventHandler(this.btnEditGrade_Click);
            // 
            // pnlGradesBottom
            // 
            this.pnlGradesBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlGradesBottom.Controls.Add(this.lblGradesCount);
            this.pnlGradesBottom.Controls.Add(this.btnDeleteGrade);
            this.pnlGradesBottom.Controls.Add(this.btnEditGrade);
            this.pnlGradesBottom.Controls.Add(this.btnAddGrade);
            this.pnlGradesBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGradesBottom.Location = new System.Drawing.Point(3, 544);
            this.pnlGradesBottom.Name = "pnlGradesBottom";
            this.pnlGradesBottom.Size = new System.Drawing.Size(986, 47);
            this.pnlGradesBottom.TabIndex = 2;
            // 
            // lblGradesCount
            // 
            this.lblGradesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGradesCount.AutoSize = true;
            this.lblGradesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblGradesCount.Location = new System.Drawing.Point(790, 14);
            this.lblGradesCount.Name = "lblGradesCount";
            this.lblGradesCount.Size = new System.Drawing.Size(123, 21);
            this.lblGradesCount.TabIndex = 3;
            this.lblGradesCount.Text = "Всего оценок: 0";
            // 
            // btnDeleteGrade
            // 
            this.btnDeleteGrade.BackColor = System.Drawing.Color.White;
            this.btnDeleteGrade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteGrade.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteGrade.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteGrade.Location = new System.Drawing.Point(335, 7);
            this.btnDeleteGrade.Name = "btnDeleteGrade";
            this.btnDeleteGrade.Size = new System.Drawing.Size(145, 34);
            this.btnDeleteGrade.TabIndex = 2;
            this.btnDeleteGrade.Text = "Удалить из БД";
            this.btnDeleteGrade.UseVisualStyleBackColor = true;
            this.btnDeleteGrade.Click += new System.EventHandler(this.btnDeleteGrade_Click);
            // 
            // btnEditGrade
            // 
            this.btnEditGrade.BackColor = System.Drawing.Color.White;
            this.btnEditGrade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditGrade.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditGrade.ForeColor = System.Drawing.Color.Black;
            this.btnEditGrade.Location = new System.Drawing.Point(180, 7);
            this.btnEditGrade.Name = "btnEditGrade";
            this.btnEditGrade.Size = new System.Drawing.Size(145, 34);
            this.btnEditGrade.TabIndex = 1;
            this.btnEditGrade.Text = "Редактировать";
            this.btnEditGrade.UseVisualStyleBackColor = true;
            this.btnEditGrade.Click += new System.EventHandler(this.btnEditGrade_Click);
            // 
            // btnAddGrade
            // 
            this.btnAddGrade.BackColor = System.Drawing.Color.White;
            this.btnAddGrade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGrade.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddGrade.ForeColor = System.Drawing.Color.Black;
            this.btnAddGrade.Location = new System.Drawing.Point(12, 7);
            this.btnAddGrade.Name = "btnAddGrade";
            this.btnAddGrade.Size = new System.Drawing.Size(160, 34);
            this.btnAddGrade.TabIndex = 0;
            this.btnAddGrade.Text = "+ Поставить оценку";
            this.btnAddGrade.UseVisualStyleBackColor = true;
            this.btnAddGrade.Click += new System.EventHandler(this.btnAddGrade_Click);
            // 
            // pnlGradesFilter
            // 
            this.pnlGradesFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlGradesFilter.Controls.Add(this.btnRefreshGrades);
            this.pnlGradesFilter.Controls.Add(this.btnResetFilter);
            this.pnlGradesFilter.Controls.Add(this.cmbFilterSubject);
            this.pnlGradesFilter.Controls.Add(this.lblFilterSubject);
            this.pnlGradesFilter.Controls.Add(this.cmbFilterStudent);
            this.pnlGradesFilter.Controls.Add(this.lblFilterStudent);
            this.pnlGradesFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGradesFilter.Location = new System.Drawing.Point(3, 3);
            this.pnlGradesFilter.Name = "pnlGradesFilter";
            this.pnlGradesFilter.Size = new System.Drawing.Size(986, 50);
            this.pnlGradesFilter.TabIndex = 0;
            // 
            // btnRefreshGrades
            // 
            this.btnRefreshGrades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshGrades.BackColor = System.Drawing.Color.White;
            this.btnRefreshGrades.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshGrades.Location = new System.Drawing.Point(850, 9);
            this.btnRefreshGrades.Name = "btnRefreshGrades";
            this.btnRefreshGrades.Size = new System.Drawing.Size(125, 32);
            this.btnRefreshGrades.TabIndex = 5;
            this.btnRefreshGrades.Text = "Обновить БД";
            this.btnRefreshGrades.UseVisualStyleBackColor = true;
            this.btnRefreshGrades.Click += new System.EventHandler(this.btnRefreshGrades_Click);
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.BackColor = System.Drawing.Color.White;
            this.btnResetFilter.ForeColor = System.Drawing.Color.Black;
            this.btnResetFilter.Location = new System.Drawing.Point(670, 9);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(95, 32);
            this.btnResetFilter.TabIndex = 4;
            this.btnResetFilter.Text = "Сброс";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // cmbFilterSubject
            // 
            this.cmbFilterSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterSubject.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbFilterSubject.FormattingEnabled = true;
            this.cmbFilterSubject.Location = new System.Drawing.Point(440, 11);
            this.cmbFilterSubject.Name = "cmbFilterSubject";
            this.cmbFilterSubject.Size = new System.Drawing.Size(220, 29);
            this.cmbFilterSubject.TabIndex = 3;
            this.cmbFilterSubject.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // lblFilterSubject
            // 
            this.lblFilterSubject.AutoSize = true;
            this.lblFilterSubject.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFilterSubject.ForeColor = System.Drawing.Color.Black;
            this.lblFilterSubject.Location = new System.Drawing.Point(360, 14);
            this.lblFilterSubject.Name = "lblFilterSubject";
            this.lblFilterSubject.Size = new System.Drawing.Size(76, 21);
            this.lblFilterSubject.TabIndex = 2;
            this.lblFilterSubject.Text = "Предмет:";
            // 
            // cmbFilterStudent
            // 
            this.cmbFilterStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbFilterStudent.FormattingEnabled = true;
            this.cmbFilterStudent.Location = new System.Drawing.Point(85, 11);
            this.cmbFilterStudent.Name = "cmbFilterStudent";
            this.cmbFilterStudent.Size = new System.Drawing.Size(260, 29);
            this.cmbFilterStudent.TabIndex = 1;
            this.cmbFilterStudent.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // lblFilterStudent
            // 
            this.lblFilterStudent.AutoSize = true;
            this.lblFilterStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFilterStudent.ForeColor = System.Drawing.Color.Black;
            this.lblFilterStudent.Location = new System.Drawing.Point(12, 14);
            this.lblFilterStudent.Name = "lblFilterStudent";
            this.lblFilterStudent.Size = new System.Drawing.Size(65, 21);
            this.lblFilterStudent.TabIndex = 0;
            this.lblFilterStudent.Text = "Ученик:";
            // 
            // tabStudents
            // 
            this.tabStudents.Controls.Add(this.dgvStudents);
            this.tabStudents.Controls.Add(this.pnlStudentsBottom);
            this.tabStudents.Controls.Add(this.pnlStudentsSearch);
            this.tabStudents.Location = new System.Drawing.Point(4, 30);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabStudents.Size = new System.Drawing.Size(992, 594);
            this.tabStudents.TabIndex = 1;
            this.tabStudents.Text = " Список учащихся ";
            this.tabStudents.UseVisualStyleBackColor = true;
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStudents.ColumnHeadersHeight = 34;
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.Location = new System.Drawing.Point(3, 53);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.RowHeadersWidth = 51;
            this.dgvStudents.RowTemplate.Height = 30;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(986, 491);
            this.dgvStudents.TabIndex = 1;
            this.dgvStudents.DoubleClick += new System.EventHandler(this.btnEditStudent_Click);
            // 
            // pnlStudentsBottom
            // 
            this.pnlStudentsBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlStudentsBottom.Controls.Add(this.lblStudentsCount);
            this.pnlStudentsBottom.Controls.Add(this.btnDeleteStudent);
            this.pnlStudentsBottom.Controls.Add(this.btnEditStudent);
            this.pnlStudentsBottom.Controls.Add(this.btnAddStudent);
            this.pnlStudentsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStudentsBottom.Location = new System.Drawing.Point(3, 544);
            this.pnlStudentsBottom.Name = "pnlStudentsBottom";
            this.pnlStudentsBottom.Size = new System.Drawing.Size(986, 47);
            this.pnlStudentsBottom.TabIndex = 2;
            // 
            // lblStudentsCount
            // 
            this.lblStudentsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStudentsCount.AutoSize = true;
            this.lblStudentsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblStudentsCount.Location = new System.Drawing.Point(790, 14);
            this.lblStudentsCount.Name = "lblStudentsCount";
            this.lblStudentsCount.Size = new System.Drawing.Size(139, 21);
            this.lblStudentsCount.TabIndex = 3;
            this.lblStudentsCount.Text = "Всего учеников: 0";
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.BackColor = System.Drawing.Color.White;
            this.btnDeleteStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteStudent.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteStudent.Location = new System.Drawing.Point(340, 7);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(145, 34);
            this.btnDeleteStudent.TabIndex = 2;
            this.btnDeleteStudent.Text = "Удалить из БД";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // btnEditStudent
            // 
            this.btnEditStudent.BackColor = System.Drawing.Color.White;
            this.btnEditStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditStudent.ForeColor = System.Drawing.Color.Black;
            this.btnEditStudent.Location = new System.Drawing.Point(185, 7);
            this.btnEditStudent.Name = "btnEditStudent";
            this.btnEditStudent.Size = new System.Drawing.Size(145, 34);
            this.btnEditStudent.TabIndex = 1;
            this.btnEditStudent.Text = "Редактировать";
            this.btnEditStudent.UseVisualStyleBackColor = true;
            this.btnEditStudent.Click += new System.EventHandler(this.btnEditStudent_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackColor = System.Drawing.Color.White;
            this.btnAddStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddStudent.ForeColor = System.Drawing.Color.Black;
            this.btnAddStudent.Location = new System.Drawing.Point(12, 7);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(165, 34);
            this.btnAddStudent.TabIndex = 0;
            this.btnAddStudent.Text = "+ Новый ученик";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // pnlStudentsSearch
            // 
            this.pnlStudentsSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlStudentsSearch.Controls.Add(this.btnRefreshStudents);
            this.pnlStudentsSearch.Controls.Add(this.txtSearchStudent);
            this.pnlStudentsSearch.Controls.Add(this.lblSearchStudent);
            this.pnlStudentsSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStudentsSearch.Location = new System.Drawing.Point(3, 3);
            this.pnlStudentsSearch.Name = "pnlStudentsSearch";
            this.pnlStudentsSearch.Size = new System.Drawing.Size(986, 50);
            this.pnlStudentsSearch.TabIndex = 0;
            // 
            // btnRefreshStudents
            // 
            this.btnRefreshStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshStudents.BackColor = System.Drawing.Color.White;
            this.btnRefreshStudents.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshStudents.Location = new System.Drawing.Point(850, 9);
            this.btnRefreshStudents.Name = "btnRefreshStudents";
            this.btnRefreshStudents.Size = new System.Drawing.Size(125, 32);
            this.btnRefreshStudents.TabIndex = 2;
            this.btnRefreshStudents.Text = "Обновить БД";
            this.btnRefreshStudents.UseVisualStyleBackColor = true;
            this.btnRefreshStudents.Click += new System.EventHandler(this.btnRefreshStudents_Click);
            // 
            // txtSearchStudent
            // 
            this.txtSearchStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchStudent.Location = new System.Drawing.Point(145, 11);
            this.txtSearchStudent.Name = "txtSearchStudent";
            this.txtSearchStudent.PlaceholderText = "Введите фамилию или имя для фильтрации...";
            this.txtSearchStudent.Size = new System.Drawing.Size(350, 29);
            this.txtSearchStudent.TabIndex = 1;
            this.txtSearchStudent.TextChanged += new System.EventHandler(this.txtSearchStudent_TextChanged);
            // 
            // lblSearchStudent
            // 
            this.lblSearchStudent.AutoSize = true;
            this.lblSearchStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSearchStudent.ForeColor = System.Drawing.Color.Black;
            this.lblSearchStudent.Location = new System.Drawing.Point(12, 14);
            this.lblSearchStudent.Name = "lblSearchStudent";
            this.lblSearchStudent.Size = new System.Drawing.Size(126, 21);
            this.lblSearchStudent.TabIndex = 0;
            this.lblSearchStudent.Text = "Поиск ученика:";


            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Электронный дневник";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabGrades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.pnlGradesBottom.ResumeLayout(false);
            this.pnlGradesBottom.PerformLayout();
            this.pnlGradesFilter.ResumeLayout(false);
            this.pnlGradesFilter.PerformLayout();
            this.tabStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.pnlStudentsBottom.ResumeLayout(false);
            this.pnlStudentsBottom.PerformLayout();
            this.pnlStudentsSearch.ResumeLayout(false);
            this.pnlStudentsSearch.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnSwitchUser;
        private System.Windows.Forms.Button btnExitApp;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGrades;
        private System.Windows.Forms.Panel pnlGradesFilter;
        private System.Windows.Forms.Label lblFilterStudent;
        private System.Windows.Forms.ComboBox cmbFilterStudent;
        private System.Windows.Forms.Label lblFilterSubject;
        private System.Windows.Forms.ComboBox cmbFilterSubject;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.Button btnRefreshGrades;
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.Panel pnlGradesBottom;
        private System.Windows.Forms.Button btnAddGrade;
        private System.Windows.Forms.Button btnEditGrade;
        private System.Windows.Forms.Button btnDeleteGrade;
        private System.Windows.Forms.Label lblGradesCount;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.Panel pnlStudentsSearch;
        private System.Windows.Forms.Label lblSearchStudent;
        private System.Windows.Forms.TextBox txtSearchStudent;
        private System.Windows.Forms.Button btnRefreshStudents;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Panel pnlStudentsBottom;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnEditStudent;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.Label lblStudentsCount;
    }
}
