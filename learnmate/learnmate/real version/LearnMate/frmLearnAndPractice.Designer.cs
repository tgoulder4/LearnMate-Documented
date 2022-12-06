namespace LearnMate
{
    partial class frmLearnAndPractice
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
            this.lblSaysMySubjects = new System.Windows.Forms.Label();
            this.pnlSubjects = new System.Windows.Forms.Panel();
            this.btnBegin = new System.Windows.Forms.Button();
            this.lblRemoveDistractions = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlNotification = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlNotification.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSaysMySubjects
            // 
            this.lblSaysMySubjects.AutoSize = true;
            this.lblSaysMySubjects.BackColor = System.Drawing.Color.White;
            this.lblSaysMySubjects.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSaysMySubjects.ForeColor = System.Drawing.Color.Silver;
            this.lblSaysMySubjects.Location = new System.Drawing.Point(67, 110);
            this.lblSaysMySubjects.Name = "lblSaysMySubjects";
            this.lblSaysMySubjects.Size = new System.Drawing.Size(184, 36);
            this.lblSaysMySubjects.TabIndex = 8;
            this.lblSaysMySubjects.Text = "my subjects";
            // 
            // pnlSubjects
            // 
            this.pnlSubjects.BackColor = System.Drawing.Color.Transparent;
            this.pnlSubjects.Location = new System.Drawing.Point(103, 186);
            this.pnlSubjects.Name = "pnlSubjects";
            this.pnlSubjects.Size = new System.Drawing.Size(787, 254);
            this.pnlSubjects.TabIndex = 9;
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(25, 107);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(155, 48);
            this.btnBegin.TabIndex = 10;
            this.btnBegin.Text = "Begin session!";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // lblRemoveDistractions
            // 
            this.lblRemoveDistractions.BackColor = System.Drawing.Color.Transparent;
            this.lblRemoveDistractions.Font = new System.Drawing.Font("Darker Grotesque", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblRemoveDistractions.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRemoveDistractions.Location = new System.Drawing.Point(57, 3);
            this.lblRemoveDistractions.Name = "lblRemoveDistractions";
            this.lblRemoveDistractions.Size = new System.Drawing.Size(139, 88);
            this.lblRemoveDistractions.TabIndex = 10;
            this.lblRemoveDistractions.Text = "Please remove any distractions before starting to unlock your full potential! ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::LearnMate.Properties.Resources._2info;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 37);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pnlNotification
            // 
            this.pnlNotification.BackColor = System.Drawing.Color.Transparent;
            this.pnlNotification.Controls.Add(this.btnBegin);
            this.pnlNotification.Controls.Add(this.lblRemoveDistractions);
            this.pnlNotification.Controls.Add(this.pictureBox1);
            this.pnlNotification.Location = new System.Drawing.Point(817, 129);
            this.pnlNotification.Name = "pnlNotification";
            this.pnlNotification.Size = new System.Drawing.Size(201, 158);
            this.pnlNotification.TabIndex = 10;
            this.pnlNotification.Visible = false;
            // 
            // frmLearnAndPractice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LearnMate.Properties.Resources.learnpageLANDING;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1005, 548);
            this.Controls.Add(this.pnlNotification);
            this.Controls.Add(this.pnlSubjects);
            this.Controls.Add(this.lblSaysMySubjects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLearnAndPractice";
            this.Text = "learnOrPractice";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlNotification.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblSaysMySubjects;
        private Panel pnlSubjects;
        private Button btnBegin;
        private Label lblRemoveDistractions;
        private PictureBox pictureBox1;
        private Panel pnlNotification;
    }
}