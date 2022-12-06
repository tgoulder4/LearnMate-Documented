namespace LearnMate
{
    partial class frmEnrol
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
            this.pnlSubjects = new System.Windows.Forms.Panel();
            this.lblCurrentView = new System.Windows.Forms.Label();
            this.btnCompleteSetup = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlSubjects
            // 
            this.pnlSubjects.BackColor = System.Drawing.Color.Transparent;
            this.pnlSubjects.Location = new System.Drawing.Point(65, 155);
            this.pnlSubjects.Name = "pnlSubjects";
            this.pnlSubjects.Size = new System.Drawing.Size(893, 324);
            this.pnlSubjects.TabIndex = 0;
            // 
            // lblCurrentView
            // 
            this.lblCurrentView.AutoSize = true;
            this.lblCurrentView.BackColor = System.Drawing.Color.White;
            this.lblCurrentView.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentView.ForeColor = System.Drawing.Color.Silver;
            this.lblCurrentView.Location = new System.Drawing.Point(42, 112);
            this.lblCurrentView.Name = "lblCurrentView";
            this.lblCurrentView.Size = new System.Drawing.Size(25, 30);
            this.lblCurrentView.TabIndex = 5;
            this.lblCurrentView.Text = "x";
            // 
            // btnCompleteSetup
            // 
            this.btnCompleteSetup.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCompleteSetup.Location = new System.Drawing.Point(807, 485);
            this.btnCompleteSetup.Name = "btnCompleteSetup";
            this.btnCompleteSetup.Size = new System.Drawing.Size(133, 36);
            this.btnCompleteSetup.TabIndex = 6;
            this.btnCompleteSetup.Text = "Complete setup";
            this.btnCompleteSetup.UseVisualStyleBackColor = true;
            this.btnCompleteSetup.Click += new System.EventHandler(this.btnCompleteSetup_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.White;
            this.lblWelcome.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.ForeColor = System.Drawing.Color.Silver;
            this.lblWelcome.Location = new System.Drawing.Point(43, 107);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(31, 36);
            this.lblWelcome.TabIndex = 7;
            this.lblWelcome.Text = "x";
            // 
            // frmEnrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LearnMate.Properties.Resources.frmEnrolbkg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1005, 548);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnCompleteSetup);
            this.Controls.Add(this.lblCurrentView);
            this.Controls.Add(this.pnlSubjects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEnrol";
            this.Text = "frmEnrol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlSubjects;
        private Label lblCurrentView;
        private Button btnCompleteSetup;
        private Label lblWelcome;
    }
}