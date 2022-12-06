namespace LearnMate
{
    partial class frmContainer
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
            this.components = new System.ComponentModel.Container();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnLink = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblLinked = new System.Windows.Forms.Label();
            this.btnCollapse = new System.Windows.Forms.PictureBox();
            this.btnLogOutOfContainer = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserType = new System.Windows.Forms.Label();
            this.pnlForms = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mainPanel2 = new System.Windows.Forms.Panel();
            this.lblDivider = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.menuTimer = new System.Windows.Forms.Timer(this.components);
            this.titlePanel.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCollapse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.White;
            this.titlePanel.Controls.Add(this.btnReturn);
            this.titlePanel.Controls.Add(this.btnLink);
            this.titlePanel.Controls.Add(this.lblTitle);
            this.titlePanel.Controls.Add(this.lblLogo);
            this.titlePanel.Controls.Add(this.pnlMenu);
            this.titlePanel.Controls.Add(this.mainPanel2);
            this.titlePanel.Controls.Add(this.lblDivider);
            this.titlePanel.Controls.Add(this.mainPanel);
            this.titlePanel.Controls.Add(this.btnMenu);
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(1051, 617);
            this.titlePanel.TabIndex = 1;
            this.titlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlePanel_MouseDown);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReturn.ForeColor = System.Drawing.Color.Gray;
            this.btnReturn.Location = new System.Drawing.Point(261, 15);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(250, 43);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "Return to login";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Visible = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnLink
            // 
            this.btnLink.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLink.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLink.Location = new System.Drawing.Point(414, 15);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(250, 43);
            this.btnLink.TabIndex = 9;
            this.btnLink.Text = "Link to school";
            this.btnLink.UseVisualStyleBackColor = false;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblTitle.Location = new System.Drawing.Point(172, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(42, 19);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "TITLE";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogo.ForeColor = System.Drawing.Color.DimGray;
            this.lblLogo.Location = new System.Drawing.Point(26, 23);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(117, 25);
            this.lblLogo.TabIndex = 3;
            this.lblLogo.Text = "learnmate";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlMenu.Controls.Add(this.lblLinked);
            this.pnlMenu.Controls.Add(this.btnCollapse);
            this.pnlMenu.Controls.Add(this.btnLogOutOfContainer);
            this.pnlMenu.Controls.Add(this.pictureBox1);
            this.pnlMenu.Controls.Add(this.lblUserType);
            this.pnlMenu.Controls.Add(this.pnlForms);
            this.pnlMenu.Controls.Add(this.lblName);
            this.pnlMenu.Controls.Add(this.label4);
            this.pnlMenu.Controls.Add(this.label3);
            this.pnlMenu.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlMenu.Location = new System.Drawing.Point(706, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(302, 612);
            this.pnlMenu.TabIndex = 5;
            // 
            // lblLinked
            // 
            this.lblLinked.AutoSize = true;
            this.lblLinked.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblLinked.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLinked.Location = new System.Drawing.Point(31, 468);
            this.lblLinked.Name = "lblLinked";
            this.lblLinked.Size = new System.Drawing.Size(66, 17);
            this.lblLinked.TabIndex = 8;
            this.lblLinked.Text = "LINKED TO";
            this.lblLinked.Visible = false;
            // 
            // btnCollapse
            // 
            this.btnCollapse.BackgroundImage = global::LearnMate.Properties.Resources.collapse;
            this.btnCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCollapse.Image = global::LearnMate.Properties.Resources.expand;
            this.btnCollapse.Location = new System.Drawing.Point(225, 20);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(31, 29);
            this.btnCollapse.TabIndex = 7;
            this.btnCollapse.TabStop = false;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnLogOutOfContainer
            // 
            this.btnLogOutOfContainer.ForeColor = System.Drawing.Color.IndianRed;
            this.btnLogOutOfContainer.Location = new System.Drawing.Point(181, 563);
            this.btnLogOutOfContainer.Name = "btnLogOutOfContainer";
            this.btnLogOutOfContainer.Size = new System.Drawing.Size(75, 23);
            this.btnLogOutOfContainer.TabIndex = 7;
            this.btnLogOutOfContainer.Text = "Logout";
            this.btnLogOutOfContainer.UseVisualStyleBackColor = true;
            this.btnLogOutOfContainer.Click += new System.EventHandler(this.btnLogOutOfContainer_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::LearnMate.Properties.Resources.profileIcon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::LearnMate.Properties.Resources.profileIcon;
            this.pictureBox1.Location = new System.Drawing.Point(29, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 57);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserType.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUserType.Location = new System.Drawing.Point(98, 52);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(69, 17);
            this.lblUserType.TabIndex = 7;
            this.lblUserType.Text = "[usertype]";
            // 
            // pnlForms
            // 
            this.pnlForms.Location = new System.Drawing.Point(41, 154);
            this.pnlForms.Name = "pnlForms";
            this.pnlForms.Size = new System.Drawing.Size(215, 258);
            this.pnlForms.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblName.Location = new System.Drawing.Point(97, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(97, 19);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "[Username]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(31, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "MY ACCOUNT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(29, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "learnmate";
            // 
            // mainPanel2
            // 
            this.mainPanel2.BackColor = System.Drawing.Color.AliceBlue;
            this.mainPanel2.BackgroundImage = global::LearnMate.Properties.Resources.LoadingScreen;
            this.mainPanel2.Location = new System.Drawing.Point(0, 64);
            this.mainPanel2.Name = "mainPanel2";
            this.mainPanel2.Size = new System.Drawing.Size(999, 548);
            this.mainPanel2.TabIndex = 2;
            this.mainPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel2_Paint);
            // 
            // lblDivider
            // 
            this.lblDivider.AutoSize = true;
            this.lblDivider.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDivider.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblDivider.Location = new System.Drawing.Point(146, 16);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(20, 32);
            this.lblDivider.TabIndex = 4;
            this.lblDivider.Text = "|";
            // 
            // mainPanel
            // 
            this.mainPanel.BackgroundImage = global::LearnMate.Properties.Resources.LoadingScreen;
            this.mainPanel.Location = new System.Drawing.Point(4, 64);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(738, 401);
            this.mainPanel.TabIndex = 2;
            // 
            // btnMenu
            // 
            this.btnMenu.BackgroundImage = global::LearnMate.Properties.Resources.expand;
            this.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMenu.Image = global::LearnMate.Properties.Resources.expand;
            this.btnMenu.Location = new System.Drawing.Point(933, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(31, 42);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // menuTimer
            // 
            this.menuTimer.Tick += new System.EventHandler(this.menuTimer_Tick);
            // 
            // frmContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(995, 608);
            this.Controls.Add(this.titlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmContainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main";
            this.Shown += new System.EventHandler(this.frmContainer_Shown);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCollapse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Label lblLogo;
        private Label lblDivider;
        public Panel titlePanel;
        public Panel mainPanel2;
        public Label lblTitle;
        public Panel mainPanel;
        private Panel pnlMenu;
        private Panel pnlForms;
        private Label lblName;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private Label lblUserType;
        private System.Windows.Forms.Timer menuTimer;
        private Button btnLogOutOfContainer;
        private PictureBox btnCollapse;
        private Label lblLinked;
        public PictureBox btnMenu;
        private Button btnLink;
        private Button btnReturn;
    }
}