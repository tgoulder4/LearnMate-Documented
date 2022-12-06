namespace LearnMate
{
    partial class frmTimeOrganiser
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
            this.pnlMonday = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlTuesday = new System.Windows.Forms.Panel();
            this.pnlWednesday = new System.Windows.Forms.Panel();
            this.pnlThursday = new System.Windows.Forms.Panel();
            this.pnlFriday = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCurrentView = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemoveEvent = new System.Windows.Forms.Button();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.lblMondayDate = new System.Windows.Forms.Label();
            this.lblTuesdayDate = new System.Windows.Forms.Label();
            this.lblThursdayDate = new System.Windows.Forms.Label();
            this.lblWednesdayDate = new System.Windows.Forms.Label();
            this.lblFridayDate = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlMonday
            // 
            this.pnlMonday.Location = new System.Drawing.Point(271, 131);
            this.pnlMonday.Name = "pnlMonday";
            this.pnlMonday.Size = new System.Drawing.Size(128, 288);
            this.pnlMonday.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Darker Grotesque", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(234, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "6:00";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Darker Grotesque", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(228, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "12:00";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Darker Grotesque", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(225, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "22:00";
            this.label5.Click += new System.EventHandler(this.label2_Click);
            // 
            // pnlTuesday
            // 
            this.pnlTuesday.Location = new System.Drawing.Point(405, 131);
            this.pnlTuesday.Name = "pnlTuesday";
            this.pnlTuesday.Size = new System.Drawing.Size(130, 288);
            this.pnlTuesday.TabIndex = 1;
            // 
            // pnlWednesday
            // 
            this.pnlWednesday.Location = new System.Drawing.Point(541, 131);
            this.pnlWednesday.Name = "pnlWednesday";
            this.pnlWednesday.Size = new System.Drawing.Size(132, 288);
            this.pnlWednesday.TabIndex = 1;
            // 
            // pnlThursday
            // 
            this.pnlThursday.Location = new System.Drawing.Point(679, 131);
            this.pnlThursday.Name = "pnlThursday";
            this.pnlThursday.Size = new System.Drawing.Size(127, 288);
            this.pnlThursday.TabIndex = 1;
            // 
            // pnlFriday
            // 
            this.pnlFriday.Location = new System.Drawing.Point(812, 131);
            this.pnlFriday.Name = "pnlFriday";
            this.pnlFriday.Size = new System.Drawing.Size(127, 288);
            this.pnlFriday.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(307, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Monday";
            // 
            // lblCurrentView
            // 
            this.lblCurrentView.AutoSize = true;
            this.lblCurrentView.BackColor = System.Drawing.Color.White;
            this.lblCurrentView.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentView.ForeColor = System.Drawing.Color.Silver;
            this.lblCurrentView.Location = new System.Drawing.Point(39, 74);
            this.lblCurrentView.Name = "lblCurrentView";
            this.lblCurrentView.Size = new System.Drawing.Size(216, 36);
            this.lblCurrentView.TabIndex = 4;
            this.lblCurrentView.Text = "your organiser";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(438, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tuesday";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(566, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Wednesday";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(707, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Thursday";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(852, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "Friday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Darker Grotesque", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(228, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "18:00";
            // 
            // btnRemoveEvent
            // 
            this.btnRemoveEvent.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRemoveEvent.Enabled = false;
            this.btnRemoveEvent.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveEvent.Location = new System.Drawing.Point(307, 473);
            this.btnRemoveEvent.Name = "btnRemoveEvent";
            this.btnRemoveEvent.Size = new System.Drawing.Size(123, 29);
            this.btnRemoveEvent.TabIndex = 11;
            this.btnRemoveEvent.Text = "Remove Event";
            this.btnRemoveEvent.UseVisualStyleBackColor = false;
            this.btnRemoveEvent.Click += new System.EventHandler(this.btnRemoveEvent_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.BackColor = System.Drawing.Color.Tan;
            this.btnAddEvent.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddEvent.Location = new System.Drawing.Point(582, 473);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(123, 29);
            this.btnAddEvent.TabIndex = 11;
            this.btnAddEvent.Text = "Add Event";
            this.btnAddEvent.UseVisualStyleBackColor = false;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // lblMondayDate
            // 
            this.lblMondayDate.AutoSize = true;
            this.lblMondayDate.BackColor = System.Drawing.Color.Transparent;
            this.lblMondayDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMondayDate.ForeColor = System.Drawing.Color.BurlyWood;
            this.lblMondayDate.Location = new System.Drawing.Point(307, 87);
            this.lblMondayDate.Name = "lblMondayDate";
            this.lblMondayDate.Size = new System.Drawing.Size(58, 21);
            this.lblMondayDate.TabIndex = 14;
            this.lblMondayDate.Text = "[DATE]";
            // 
            // lblTuesdayDate
            // 
            this.lblTuesdayDate.AutoSize = true;
            this.lblTuesdayDate.BackColor = System.Drawing.Color.Transparent;
            this.lblTuesdayDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTuesdayDate.ForeColor = System.Drawing.Color.BurlyWood;
            this.lblTuesdayDate.Location = new System.Drawing.Point(444, 87);
            this.lblTuesdayDate.Name = "lblTuesdayDate";
            this.lblTuesdayDate.Size = new System.Drawing.Size(58, 21);
            this.lblTuesdayDate.TabIndex = 15;
            this.lblTuesdayDate.Text = "[DATE]";
            // 
            // lblThursdayDate
            // 
            this.lblThursdayDate.AutoSize = true;
            this.lblThursdayDate.BackColor = System.Drawing.Color.Transparent;
            this.lblThursdayDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblThursdayDate.ForeColor = System.Drawing.Color.BurlyWood;
            this.lblThursdayDate.Location = new System.Drawing.Point(716, 87);
            this.lblThursdayDate.Name = "lblThursdayDate";
            this.lblThursdayDate.Size = new System.Drawing.Size(58, 21);
            this.lblThursdayDate.TabIndex = 17;
            this.lblThursdayDate.Text = "[DATE]";
            // 
            // lblWednesdayDate
            // 
            this.lblWednesdayDate.AutoSize = true;
            this.lblWednesdayDate.BackColor = System.Drawing.Color.Transparent;
            this.lblWednesdayDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWednesdayDate.ForeColor = System.Drawing.Color.BurlyWood;
            this.lblWednesdayDate.Location = new System.Drawing.Point(582, 87);
            this.lblWednesdayDate.Name = "lblWednesdayDate";
            this.lblWednesdayDate.Size = new System.Drawing.Size(58, 21);
            this.lblWednesdayDate.TabIndex = 16;
            this.lblWednesdayDate.Text = "[DATE]";
            // 
            // lblFridayDate
            // 
            this.lblFridayDate.AutoSize = true;
            this.lblFridayDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFridayDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFridayDate.ForeColor = System.Drawing.Color.BurlyWood;
            this.lblFridayDate.Location = new System.Drawing.Point(848, 87);
            this.lblFridayDate.Name = "lblFridayDate";
            this.lblFridayDate.Size = new System.Drawing.Size(58, 21);
            this.lblFridayDate.TabIndex = 18;
            this.lblFridayDate.Text = "[DATE]";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 166);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 253);
            this.textBox1.TabIndex = 19;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Darker Grotesque SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(75, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = " Notes";
            // 
            // frmTimeOrganiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LearnMate.Properties.Resources.to;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1005, 548);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblFridayDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblThursdayDate);
            this.Controls.Add(this.lblWednesdayDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTuesdayDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMondayDate);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.btnRemoveEvent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCurrentView);
            this.Controls.Add(this.pnlFriday);
            this.Controls.Add(this.pnlThursday);
            this.Controls.Add(this.pnlWednesday);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlMonday);
            this.Controls.Add(this.pnlTuesday);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTimeOrganiser";
            this.Text = "timeOrganiser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlMonday;
        private Label label1;
        private Label label2;
        private Label label5;
        private Panel pnlTuesday;
        private Panel pnlWednesday;
        private Panel pnlThursday;
        private Panel pnlFriday;
        private Label label6;
        private Label lblCurrentView;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label3;
        private Button btnRemoveEvent;
        private Button btnAddEvent;
        private Label lblMondayDate;
        private Label lblTuesdayDate;
        private Label lblThursdayDate;
        private Label lblWednesdayDate;
        private Label lblFridayDate;
        private TextBox textBox1;
        private Label label11;
    }
}