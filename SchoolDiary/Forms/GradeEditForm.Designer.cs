namespace SchoolDiary.Forms
{
    partial class GradeEditForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblGrade = new System.Windows.Forms.Label();
            this.cmbGrade = new System.Windows.Forms.ComboBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(22, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(225, 28);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Выставление оценки";
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.ForeColor = System.Drawing.Color.Black;
            this.lblStudent.Location = new System.Drawing.Point(22, 65);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(86, 20);
            this.lblStudent.TabIndex = 1;
            this.lblStudent.Text = "Учащийся:";
            // 
            // cmbStudent
            // 
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(22, 90);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(430, 29);
            this.cmbStudent.TabIndex = 2;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.ForeColor = System.Drawing.Color.Black;
            this.lblSubject.Location = new System.Drawing.Point(22, 130);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(167, 20);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "Дисциплина / Предмет:";
            // 
            // cmbSubject
            // 
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(22, 155);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(430, 29);
            this.cmbSubject.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(22, 195);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(87, 20);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Дата урока:";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(22, 220);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(190, 29);
            this.dtpDate.TabIndex = 6;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.ForeColor = System.Drawing.Color.Black;
            this.lblGrade.Location = new System.Drawing.Point(240, 195);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(65, 20);
            this.lblGrade.TabIndex = 7;
            this.lblGrade.Text = "Оценка:";
            // 
            // cmbGrade
            // 
            this.cmbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrade.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbGrade.FormattingEnabled = true;
            this.cmbGrade.Items.AddRange(new object[] {
            "5 (Отлично)",
            "4 (Хорошо)",
            "3 (Удовлетворительно)",
            "2 (Неудовлетворительно)"});
            this.cmbGrade.Location = new System.Drawing.Point(240, 220);
            this.cmbGrade.Name = "cmbGrade";
            this.cmbGrade.Size = new System.Drawing.Size(212, 31);
            this.cmbGrade.TabIndex = 8;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.ForeColor = System.Drawing.Color.Black;
            this.lblComment.Location = new System.Drawing.Point(22, 260);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(193, 20);
            this.lblComment.TabIndex = 9;
            this.lblComment.Text = "Тема / Тип работы (комм.):";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtComment.Location = new System.Drawing.Point(22, 285);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(430, 29);
            this.txtComment.TabIndex = 10;
            this.txtComment.Text = "Практическая работа";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(192, 335);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Сохранить в БД";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(352, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // GradeEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(475, 395);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.cmbGrade);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.cmbStudent);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GradeEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Оценка";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.ComboBox cmbGrade;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
