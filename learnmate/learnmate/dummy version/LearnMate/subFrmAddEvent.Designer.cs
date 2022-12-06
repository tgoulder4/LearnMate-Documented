namespace LearnMate
{
    partial class subFrmAddEvent
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbEventType = new System.Windows.Forms.ComboBox();
            this.chkRecurring = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbStartTimeh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStartTimem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEndTimeh = new System.Windows.Forms.ComboBox();
            this.cmbEndTimem = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Darker Grotesque", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add event";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(31, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(264, 23);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Event name";
            this.txtName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cmbEventType
            // 
            this.cmbEventType.FormattingEnabled = true;
            this.cmbEventType.Location = new System.Drawing.Point(31, 104);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(121, 23);
            this.cmbEventType.TabIndex = 2;
            this.cmbEventType.Text = "Event Type";
            // 
            // chkRecurring
            // 
            this.chkRecurring.AutoSize = true;
            this.chkRecurring.Location = new System.Drawing.Point(163, 106);
            this.chkRecurring.Name = "chkRecurring";
            this.chkRecurring.Size = new System.Drawing.Size(150, 19);
            this.chkRecurring.TabIndex = 3;
            this.chkRecurring.Text = "This is a recurring event";
            this.chkRecurring.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(34, 307);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(264, 70);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Text = "Event Description";
            this.txtDescription.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cmbStartTimeh
            // 
            this.cmbStartTimeh.FormattingEnabled = true;
            this.cmbStartTimeh.Items.AddRange(new object[] {
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22"});
            this.cmbStartTimeh.Location = new System.Drawing.Point(31, 159);
            this.cmbStartTimeh.Name = "cmbStartTimeh";
            this.cmbStartTimeh.Size = new System.Drawing.Size(121, 23);
            this.cmbStartTimeh.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Start time";
            // 
            // cmbStartTimem
            // 
            this.cmbStartTimem.FormattingEnabled = true;
            this.cmbStartTimem.Items.AddRange(new object[] {
            "00",
            "30"});
            this.cmbStartTimem.Location = new System.Drawing.Point(174, 159);
            this.cmbStartTimem.Name = "cmbStartTimem";
            this.cmbStartTimem.Size = new System.Drawing.Size(121, 23);
            this.cmbStartTimem.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "End Time";
            // 
            // cmbEndTimeh
            // 
            this.cmbEndTimeh.FormattingEnabled = true;
            this.cmbEndTimeh.Items.AddRange(new object[] {
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22"});
            this.cmbEndTimeh.Location = new System.Drawing.Point(31, 205);
            this.cmbEndTimeh.Name = "cmbEndTimeh";
            this.cmbEndTimeh.Size = new System.Drawing.Size(121, 23);
            this.cmbEndTimeh.TabIndex = 2;
            // 
            // cmbEndTimem
            // 
            this.cmbEndTimem.FormattingEnabled = true;
            this.cmbEndTimem.Items.AddRange(new object[] {
            "00",
            "30"});
            this.cmbEndTimem.Location = new System.Drawing.Point(174, 205);
            this.cmbEndTimem.Name = "cmbEndTimem";
            this.cmbEndTimem.Size = new System.Drawing.Size(121, 23);
            this.cmbEndTimem.TabIndex = 2;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(95, 383);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(146, 51);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create Event";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dtPicker
            // 
            this.dtPicker.Location = new System.Drawing.Point(34, 259);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(264, 23);
            this.dtPicker.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Day";
            // 
            // subFrmAddEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 446);
            this.Controls.Add(this.dtPicker);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.chkRecurring);
            this.Controls.Add(this.cmbEndTimem);
            this.Controls.Add(this.cmbStartTimem);
            this.Controls.Add(this.cmbEndTimeh);
            this.Controls.Add(this.cmbStartTimeh);
            this.Controls.Add(this.cmbEventType);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "subFrmAddEvent";
            this.Text = "subFrmAddEvent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private ComboBox cmbEventType;
        private CheckBox chkRecurring;
        private TextBox txtDescription;
        private ComboBox cmbStartTimeh;
        private Label label2;
        private Label label3;
        private ComboBox cmbStartTimem;
        private Label label4;
        private Label label5;
        private ComboBox cmbEndTimeh;
        private ComboBox cmbEndTimem;
        private Button btnCreate;
        private DateTimePicker dtPicker;
        private Label label6;
    }
}