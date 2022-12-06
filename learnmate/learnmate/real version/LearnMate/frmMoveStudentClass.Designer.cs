namespace LearnMate
{
    partial class frmMoveStudentClass
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
            this.btnMoveToNewClass = new System.Windows.Forms.Button();
            this.pnlClasses = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMoveToNewClass
            // 
            this.btnMoveToNewClass.Location = new System.Drawing.Point(191, 496);
            this.btnMoveToNewClass.Name = "btnMoveToNewClass";
            this.btnMoveToNewClass.Size = new System.Drawing.Size(372, 39);
            this.btnMoveToNewClass.TabIndex = 8;
            this.btnMoveToNewClass.Text = "Move student";
            this.btnMoveToNewClass.UseVisualStyleBackColor = true;
            this.btnMoveToNewClass.Click += new System.EventHandler(this.btnMoveToNewClass_Click);
            // 
            // pnlClasses
            // 
            this.pnlClasses.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlClasses.Location = new System.Drawing.Point(33, 165);
            this.pnlClasses.Name = "pnlClasses";
            this.pnlClasses.Size = new System.Drawing.Size(686, 302);
            this.pnlClasses.TabIndex = 7;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(33, 78);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ReadOnly = true;
            this.txtSearch.Size = new System.Drawing.Size(686, 23);
            this.txtSearch.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search student name";
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(31, 29);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(131, 15);
            this.lblDirectory.TabIndex = 5;
            this.lblDirectory.Text = "Directory [schoolname]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Classes";
            // 
            // frmMoveStudentClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 595);
            this.Controls.Add(this.btnMoveToNewClass);
            this.Controls.Add(this.pnlClasses);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDirectory);
            this.Name = "frmMoveStudentClass";
            this.Text = "frmMoveStudentClass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnMoveToNewClass;
        private Panel pnlClasses;
        private TextBox txtSearch;
        private Label label2;
        private Label lblDirectory;
        private Label label1;
    }
}