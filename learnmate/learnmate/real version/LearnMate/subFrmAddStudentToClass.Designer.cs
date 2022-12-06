namespace LearnMate
{
    partial class subFrmAddStudentToClass
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
            this.lblDirectory = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlStudents = new System.Windows.Forms.Panel();
            this.lblSaysStudents = new System.Windows.Forms.Label();
            this.btnMoveToThisClass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(26, 22);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(131, 15);
            this.lblDirectory.TabIndex = 0;
            this.lblDirectory.Text = "Directory [schoolname]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search student name";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(28, 71);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ReadOnly = true;
            this.txtSearch.Size = new System.Drawing.Size(686, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // pnlStudents
            // 
            this.pnlStudents.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlStudents.Location = new System.Drawing.Point(28, 146);
            this.pnlStudents.Name = "pnlStudents";
            this.pnlStudents.Size = new System.Drawing.Size(686, 314);
            this.pnlStudents.TabIndex = 2;
            // 
            // lblSaysStudents
            // 
            this.lblSaysStudents.AutoSize = true;
            this.lblSaysStudents.Location = new System.Drawing.Point(26, 128);
            this.lblSaysStudents.Name = "lblSaysStudents";
            this.lblSaysStudents.Size = new System.Drawing.Size(53, 15);
            this.lblSaysStudents.TabIndex = 0;
            this.lblSaysStudents.Text = "Students";
            // 
            // btnMoveToThisClass
            // 
            this.btnMoveToThisClass.Location = new System.Drawing.Point(186, 489);
            this.btnMoveToThisClass.Name = "btnMoveToThisClass";
            this.btnMoveToThisClass.Size = new System.Drawing.Size(372, 39);
            this.btnMoveToThisClass.TabIndex = 3;
            this.btnMoveToThisClass.Text = "x";
            this.btnMoveToThisClass.UseVisualStyleBackColor = true;
            this.btnMoveToThisClass.Click += new System.EventHandler(this.btnMoveToThisClass_Click);
            // 
            // subFrmAddStudentToClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 554);
            this.Controls.Add(this.btnMoveToThisClass);
            this.Controls.Add(this.pnlStudents);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSaysStudents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDirectory);
            this.Name = "subFrmAddStudentToClass";
            this.Text = "subFrmAddStudentToClass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblDirectory;
        private Label label2;
        private TextBox txtSearch;
        private Panel pnlStudents;
        private Label lblSaysStudents;
        private Button btnMoveToThisClass;
    }
}