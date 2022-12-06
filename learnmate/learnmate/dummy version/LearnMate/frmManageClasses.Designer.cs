namespace LearnMate
{
    partial class frmManageClasses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlClass = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveClass = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.lblCurrentView = new System.Windows.Forms.Label();
            this.btnEditStudents = new System.Windows.Forms.Button();
            this.lblClassName = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Label();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnMoveStudent = new System.Windows.Forms.Button();
            this.btnRemoveStudent = new System.Windows.Forms.Button();
            this.btnBan = new System.Windows.Forms.Button();
            this.btnKick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlClass
            // 
            this.pnlClass.BackColor = System.Drawing.Color.Transparent;
            this.pnlClass.Location = new System.Drawing.Point(94, 178);
            this.pnlClass.Name = "pnlClass";
            this.pnlClass.Size = new System.Drawing.Size(470, 253);
            this.pnlClass.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(551, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 0;
            // 
            // btnRemoveClass
            // 
            this.btnRemoveClass.BackColor = System.Drawing.Color.IndianRed;
            this.btnRemoveClass.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnRemoveClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveClass.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveClass.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveClass.Location = new System.Drawing.Point(723, 289);
            this.btnRemoveClass.Name = "btnRemoveClass";
            this.btnRemoveClass.Size = new System.Drawing.Size(191, 25);
            this.btnRemoveClass.TabIndex = 1;
            this.btnRemoveClass.Text = "Remove this class";
            this.btnRemoveClass.UseVisualStyleBackColor = false;
            this.btnRemoveClass.Click += new System.EventHandler(this.btnRemoveClass_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddClass.Location = new System.Drawing.Point(723, 392);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(191, 29);
            this.btnAddClass.TabIndex = 1;
            this.btnAddClass.Text = "Create classes";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // lblCurrentView
            // 
            this.lblCurrentView.AutoSize = true;
            this.lblCurrentView.BackColor = System.Drawing.Color.White;
            this.lblCurrentView.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentView.ForeColor = System.Drawing.Color.Silver;
            this.lblCurrentView.Location = new System.Drawing.Point(63, 113);
            this.lblCurrentView.Name = "lblCurrentView";
            this.lblCurrentView.Size = new System.Drawing.Size(309, 36);
            this.lblCurrentView.TabIndex = 3;
            this.lblCurrentView.Text = "your school\'s classes";
            // 
            // btnEditStudents
            // 
            this.btnEditStudents.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditStudents.Location = new System.Drawing.Point(723, 230);
            this.btnEditStudents.Name = "btnEditStudents";
            this.btnEditStudents.Size = new System.Drawing.Size(191, 37);
            this.btnEditStudents.TabIndex = 1;
            this.btnEditStudents.Text = "Edit students in this class";
            this.btnEditStudents.UseVisualStyleBackColor = true;
            this.btnEditStudents.Click += new System.EventHandler(this.btnEditStudents_Click);
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.BackColor = System.Drawing.Color.White;
            this.lblClassName.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblClassName.ForeColor = System.Drawing.Color.Silver;
            this.lblClassName.Location = new System.Drawing.Point(701, 169);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(171, 28);
            this.lblClassName.TabIndex = 9;
            this.lblClassName.Text = "Select a class";
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBack.ForeColor = System.Drawing.Color.Silver;
            this.btnBack.Location = new System.Drawing.Point(67, 469);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(154, 19);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "< Back to overview";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddStudent.Location = new System.Drawing.Point(723, 392);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(191, 29);
            this.btnAddStudent.TabIndex = 12;
            this.btnAddStudent.Text = "Add students";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Visible = false;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnMoveStudent
            // 
            this.btnMoveStudent.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMoveStudent.Location = new System.Drawing.Point(723, 218);
            this.btnMoveStudent.Name = "btnMoveStudent";
            this.btnMoveStudent.Size = new System.Drawing.Size(191, 34);
            this.btnMoveStudent.TabIndex = 13;
            this.btnMoveStudent.Text = "Add to other classes";
            this.btnMoveStudent.UseVisualStyleBackColor = true;
            this.btnMoveStudent.Visible = false;
            this.btnMoveStudent.Click += new System.EventHandler(this.btnMoveStudent_Click);
            // 
            // btnRemoveStudent
            // 
            this.btnRemoveStudent.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRemoveStudent.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnRemoveStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveStudent.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveStudent.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveStudent.Location = new System.Drawing.Point(723, 262);
            this.btnRemoveStudent.Name = "btnRemoveStudent";
            this.btnRemoveStudent.Size = new System.Drawing.Size(191, 25);
            this.btnRemoveStudent.TabIndex = 14;
            this.btnRemoveStudent.Text = "Remove from this class";
            this.btnRemoveStudent.UseVisualStyleBackColor = false;
            this.btnRemoveStudent.Visible = false;
            this.btnRemoveStudent.Click += new System.EventHandler(this.btnRemoveStudent_Click);
            // 
            // btnBan
            // 
            this.btnBan.BackColor = System.Drawing.Color.RosyBrown;
            this.btnBan.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBan.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBan.ForeColor = System.Drawing.Color.Black;
            this.btnBan.Location = new System.Drawing.Point(393, 466);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(171, 31);
            this.btnBan.TabIndex = 14;
            this.btnBan.Text = "Ban from school";
            this.btnBan.UseVisualStyleBackColor = false;
            this.btnBan.Visible = false;
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click);
            // 
            // btnKick
            // 
            this.btnKick.BackColor = System.Drawing.Color.IndianRed;
            this.btnKick.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnKick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKick.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKick.ForeColor = System.Drawing.Color.Black;
            this.btnKick.Location = new System.Drawing.Point(723, 296);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(191, 25);
            this.btnKick.TabIndex = 15;
            this.btnKick.Text = "Remove from school";
            this.btnKick.UseVisualStyleBackColor = false;
            this.btnKick.Visible = false;
            this.btnKick.Click += new System.EventHandler(this.btnKick_Click);
            // 
            // frmManageClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LearnMate.Properties.Resources._2manageclass;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1005, 548);
            this.Controls.Add(this.btnKick);
            this.Controls.Add(this.btnBan);
            this.Controls.Add(this.btnRemoveStudent);
            this.Controls.Add(this.btnMoveStudent);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.lblCurrentView);
            this.Controls.Add(this.btnRemoveClass);
            this.Controls.Add(this.btnEditStudents);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlClass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageClasses";
            this.Text = "manageClasses";
            this.Shown += new System.EventHandler(this.frmManageClasses_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Button btnRemoveClass;
        private Button btnAddClass;
        private Label lblCurrentView;
        private Button btnEditStudents;
        private Label lblClassName;
        public Panel pnlClass;
        private Label btnBack;
        private Button btnAddStudent;
        private Button btnMoveStudent;
        private Button btnRemoveStudent;
        private Button btnBan;
        private Button btnKick;
    }
}