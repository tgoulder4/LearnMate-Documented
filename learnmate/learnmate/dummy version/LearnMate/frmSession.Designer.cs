namespace LearnMate
{
    partial class frmSession
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
            this.pnlControls = new System.Windows.Forms.Panel();
            this.pctSkip = new System.Windows.Forms.PictureBox();
            this.pctPlayPause = new System.Windows.Forms.PictureBox();
            this.lblVideoTitle = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Panel();
            this.lblSubmit = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.PictureBox();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSkip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPlayPause)).BeginInit();
            this.btnSubmit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.Transparent;
            this.pnlControls.Controls.Add(this.pctSkip);
            this.pnlControls.Controls.Add(this.pctPlayPause);
            this.pnlControls.Location = new System.Drawing.Point(449, 484);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(113, 51);
            this.pnlControls.TabIndex = 0;
            // 
            // pctSkip
            // 
            this.pctSkip.BackgroundImage = global::LearnMate.Properties.Resources.btnSkip;
            this.pctSkip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctSkip.Location = new System.Drawing.Point(57, 3);
            this.pctSkip.Name = "pctSkip";
            this.pctSkip.Size = new System.Drawing.Size(45, 45);
            this.pctSkip.TabIndex = 1;
            this.pctSkip.TabStop = false;
            this.pctSkip.Click += new System.EventHandler(this.pctSkip_Click);
            // 
            // pctPlayPause
            // 
            this.pctPlayPause.BackgroundImage = global::LearnMate.Properties.Resources.btnPause;
            this.pctPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctPlayPause.Location = new System.Drawing.Point(9, 3);
            this.pctPlayPause.Name = "pctPlayPause";
            this.pctPlayPause.Size = new System.Drawing.Size(45, 45);
            this.pctPlayPause.TabIndex = 1;
            this.pctPlayPause.TabStop = false;
            // 
            // lblVideoTitle
            // 
            this.lblVideoTitle.AutoSize = true;
            this.lblVideoTitle.BackColor = System.Drawing.Color.White;
            this.lblVideoTitle.Font = new System.Drawing.Font("Darker Grotesque SemiBold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVideoTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblVideoTitle.Location = new System.Drawing.Point(30, 18);
            this.lblVideoTitle.Name = "lblVideoTitle";
            this.lblVideoTitle.Size = new System.Drawing.Size(167, 47);
            this.lblVideoTitle.TabIndex = 4;
            this.lblVideoTitle.Text = "[video title]";
            // 
            // lblQuestion
            // 
            this.lblQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblQuestion.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestion.Font = new System.Drawing.Font("Darker Grotesque SemiBold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblQuestion.Location = new System.Drawing.Point(159, 178);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(687, 51);
            this.lblQuestion.TabIndex = 6;
            this.lblQuestion.Text = "[Question]";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtAnswer
            // 
            this.txtAnswer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAnswer.ForeColor = System.Drawing.Color.Black;
            this.txtAnswer.Location = new System.Drawing.Point(159, 249);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(687, 33);
            this.txtAnswer.TabIndex = 7;
            // 
            // lblAnswer
            // 
            this.lblAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblAnswer.BackColor = System.Drawing.Color.Transparent;
            this.lblAnswer.Font = new System.Drawing.Font("Darker Grotesque", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAnswer.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblAnswer.Location = new System.Drawing.Point(159, 326);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(687, 55);
            this.lblAnswer.TabIndex = 8;
            this.lblAnswer.Text = "label1";
            this.lblAnswer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.Controls.Add(this.lblSubmit);
            this.btnSubmit.Location = new System.Drawing.Point(427, 407);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(155, 74);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblSubmit
            // 
            this.lblSubmit.AutoSize = true;
            this.lblSubmit.Font = new System.Drawing.Font("Darker Grotesque", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSubmit.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSubmit.Location = new System.Drawing.Point(35, 17);
            this.lblSubmit.Name = "lblSubmit";
            this.lblSubmit.Size = new System.Drawing.Size(89, 37);
            this.lblSubmit.TabIndex = 0;
            this.lblSubmit.Text = "Submit";
            this.lblSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BackgroundImage = global::LearnMate.Properties.Resources.btnStop;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.Location = new System.Drawing.Point(930, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(63, 57);
            this.btnStop.TabIndex = 11;
            this.btnStop.TabStop = false;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LearnMate.Properties.Resources._video_LMsessionBkg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1005, 548);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblVideoTitle);
            this.Controls.Add(this.pnlControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSession";
            this.Text = "frmSession";
            this.pnlControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctSkip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPlayPause)).EndInit();
            this.btnSubmit.ResumeLayout(false);
            this.btnSubmit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlControls;
        private PictureBox pctSkip;
        private PictureBox pctPlayPause;
        private Label lblVideoTitle;
        private Label lblQuestion;
        private TextBox txtAnswer;
        private Label lblAnswer;
        private Panel btnSubmit;
        private Label lblSubmit;
        private PictureBox btnStop;
    }
}