namespace LearnMate
{
    partial class frmHomepage
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
            this.pnlActions = new System.Windows.Forms.Panel();
            this.lblCurrentView = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlActions
            // 
            this.pnlActions.AutoScrollMargin = new System.Drawing.Size(0, 100);
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.Location = new System.Drawing.Point(72, 147);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(941, 309);
            this.pnlActions.TabIndex = 7;
            // 
            // lblCurrentView
            // 
            this.lblCurrentView.AutoSize = true;
            this.lblCurrentView.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentView.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentView.ForeColor = System.Drawing.Color.Silver;
            this.lblCurrentView.Location = new System.Drawing.Point(45, 83);
            this.lblCurrentView.Name = "lblCurrentView";
            this.lblCurrentView.Size = new System.Drawing.Size(159, 36);
            this.lblCurrentView.TabIndex = 8;
            this.lblCurrentView.Text = "I want to...";
            // 
            // frmHomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LearnMate.Properties.Resources._3frmhomepagebkg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(997, 548);
            this.Controls.Add(this.lblCurrentView);
            this.Controls.Add(this.pnlActions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHomepage";
            this.Text = "StudentHomepage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel pnlActions;
        private Label lblCurrentView;
    }
}