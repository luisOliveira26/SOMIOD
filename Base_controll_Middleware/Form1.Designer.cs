namespace Base_controll_Middleware
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxXml = new System.Windows.Forms.TextBox();
            this.labelXml = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAppNameMqqt = new System.Windows.Forms.TextBox();
            this.textBoxContainerNameMqtt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSubscrive = new System.Windows.Forms.Button();
            this.textBoxContainerName = new System.Windows.Forms.TextBox();
            this.textBoxAppName = new System.Windows.Forms.TextBox();
            this.labelContainerName = new System.Windows.Forms.Label();
            this.labelAppName = new System.Windows.Forms.Label();
            this.textBoxNotificationName = new System.Windows.Forms.TextBox();
            this.labelNotificationName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelAtualChannel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonExamples = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxHttp = new System.Windows.Forms.CheckBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.textBoxRecord = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(664, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(404, 525);
            this.dataGridView1.TabIndex = 4;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(20, 169);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(152, 89);
            this.checkedListBox1.TabIndex = 6;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(17, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Method";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "SOMIOD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(17, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Resource";
            // 
            // textBoxXml
            // 
            this.textBoxXml.Location = new System.Drawing.Point(17, 339);
            this.textBoxXml.Multiline = true;
            this.textBoxXml.Name = "textBoxXml";
            this.textBoxXml.Size = new System.Drawing.Size(600, 324);
            this.textBoxXml.TabIndex = 10;
            // 
            // labelXml
            // 
            this.labelXml.AutoSize = true;
            this.labelXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.labelXml.Location = new System.Drawing.Point(17, 297);
            this.labelXml.Name = "labelXml";
            this.labelXml.Size = new System.Drawing.Size(213, 18);
            this.labelXml.TabIndex = 11;
            this.labelXml.Text = "XML REQUEST / RECEIVE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(661, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Notifications (Http/Mqtt)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(719, 672);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "App Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(919, 672);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Container Name";
            // 
            // textBoxAppNameMqqt
            // 
            this.textBoxAppNameMqqt.Location = new System.Drawing.Point(681, 691);
            this.textBoxAppNameMqqt.Name = "textBoxAppNameMqqt";
            this.textBoxAppNameMqqt.Size = new System.Drawing.Size(166, 22);
            this.textBoxAppNameMqqt.TabIndex = 15;
            // 
            // textBoxContainerNameMqtt
            // 
            this.textBoxContainerNameMqtt.Location = new System.Drawing.Point(889, 691);
            this.textBoxContainerNameMqtt.Name = "textBoxContainerNameMqtt";
            this.textBoxContainerNameMqtt.Size = new System.Drawing.Size(166, 22);
            this.textBoxContainerNameMqtt.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(664, 587);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mqtt Channel:";
            // 
            // buttonSubscrive
            // 
            this.buttonSubscrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.buttonSubscrive.Location = new System.Drawing.Point(681, 629);
            this.buttonSubscrive.Name = "buttonSubscrive";
            this.buttonSubscrive.Size = new System.Drawing.Size(112, 34);
            this.buttonSubscrive.TabIndex = 18;
            this.buttonSubscrive.Text = "Subscrive";
            this.buttonSubscrive.UseVisualStyleBackColor = true;
            this.buttonSubscrive.Click += new System.EventHandler(this.buttonSubscrive_Click);
            // 
            // textBoxContainerName
            // 
            this.textBoxContainerName.Location = new System.Drawing.Point(354, 188);
            this.textBoxContainerName.Name = "textBoxContainerName";
            this.textBoxContainerName.Size = new System.Drawing.Size(166, 22);
            this.textBoxContainerName.TabIndex = 22;
            this.textBoxContainerName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxAppName
            // 
            this.textBoxAppName.Location = new System.Drawing.Point(354, 118);
            this.textBoxAppName.Name = "textBoxAppName";
            this.textBoxAppName.Size = new System.Drawing.Size(166, 22);
            this.textBoxAppName.TabIndex = 21;
            this.textBoxAppName.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // labelContainerName
            // 
            this.labelContainerName.AutoSize = true;
            this.labelContainerName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelContainerName.Location = new System.Drawing.Point(384, 169);
            this.labelContainerName.Name = "labelContainerName";
            this.labelContainerName.Size = new System.Drawing.Size(104, 16);
            this.labelContainerName.TabIndex = 20;
            this.labelContainerName.Text = "Container Name";
            this.labelContainerName.Click += new System.EventHandler(this.label9_Click);
            // 
            // labelAppName
            // 
            this.labelAppName.AutoSize = true;
            this.labelAppName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelAppName.Location = new System.Drawing.Point(392, 99);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(72, 16);
            this.labelAppName.TabIndex = 19;
            this.labelAppName.Text = "App Name";
            this.labelAppName.Click += new System.EventHandler(this.label10_Click);
            // 
            // textBoxNotificationName
            // 
            this.textBoxNotificationName.Location = new System.Drawing.Point(354, 254);
            this.textBoxNotificationName.Name = "textBoxNotificationName";
            this.textBoxNotificationName.Size = new System.Drawing.Size(166, 22);
            this.textBoxNotificationName.TabIndex = 25;
            // 
            // labelNotificationName
            // 
            this.labelNotificationName.AutoSize = true;
            this.labelNotificationName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelNotificationName.Location = new System.Drawing.Point(375, 235);
            this.labelNotificationName.Name = "labelNotificationName";
            this.labelNotificationName.Size = new System.Drawing.Size(113, 16);
            this.labelNotificationName.TabIndex = 23;
            this.labelNotificationName.Text = "Notification Name";
            this.labelNotificationName.Click += new System.EventHandler(this.label12_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(17, 679);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 34);
            this.button1.TabIndex = 26;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelAtualChannel
            // 
            this.labelAtualChannel.AutoSize = true;
            this.labelAtualChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.labelAtualChannel.Location = new System.Drawing.Point(836, 587);
            this.labelAtualChannel.Name = "labelAtualChannel";
            this.labelAtualChannel.Size = new System.Drawing.Size(14, 18);
            this.labelAtualChannel.TabIndex = 27;
            this.labelAtualChannel.Text = "-";
            this.labelAtualChannel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(782, 569);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "http://localhost:5000/test/api/notification";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(687, 569);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 18);
            this.label9.TabIndex = 29;
            this.label9.Text = "HTTP URI:";
            this.label9.Click += new System.EventHandler(this.label9_Click_1);
            // 
            // buttonExamples
            // 
            this.buttonExamples.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.buttonExamples.Location = new System.Drawing.Point(522, 672);
            this.buttonExamples.Name = "buttonExamples";
            this.buttonExamples.Size = new System.Drawing.Size(95, 34);
            this.buttonExamples.TabIndex = 30;
            this.buttonExamples.Text = "Example";
            this.buttonExamples.UseVisualStyleBackColor = true;
            this.buttonExamples.Click += new System.EventHandler(this.buttonExamples_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(531, 709);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 16);
            this.label10.TabIndex = 31;
            this.label10.Text = "(Defaul Data)";
            // 
            // checkBoxHttp
            // 
            this.checkBoxHttp.AutoSize = true;
            this.checkBoxHttp.Location = new System.Drawing.Point(1050, 570);
            this.checkBoxHttp.Name = "checkBoxHttp";
            this.checkBoxHttp.Size = new System.Drawing.Size(18, 17);
            this.checkBoxHttp.TabIndex = 32;
            this.checkBoxHttp.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.buttonClear.Location = new System.Drawing.Point(135, 679);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(95, 34);
            this.buttonClear.TabIndex = 33;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.FormattingEnabled = true;
            this.comboBoxMethod.Location = new System.Drawing.Point(20, 91);
            this.comboBoxMethod.Name = "comboBoxMethod";
            this.comboBoxMethod.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMethod.TabIndex = 34;
            this.comboBoxMethod.Text = "Locate";
            this.comboBoxMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxMethod_SelectedIndexChanged);
            // 
            // textBoxRecord
            // 
            this.textBoxRecord.Location = new System.Drawing.Point(354, 254);
            this.textBoxRecord.Name = "textBoxRecord";
            this.textBoxRecord.Size = new System.Drawing.Size(166, 22);
            this.textBoxRecord.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 728);
            this.Controls.Add(this.textBoxRecord);
            this.Controls.Add(this.comboBoxMethod);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.checkBoxHttp);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonExamples);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelAtualChannel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxNotificationName);
            this.Controls.Add(this.labelNotificationName);
            this.Controls.Add(this.textBoxContainerName);
            this.Controls.Add(this.textBoxAppName);
            this.Controls.Add(this.labelContainerName);
            this.Controls.Add(this.labelAppName);
            this.Controls.Add(this.buttonSubscrive);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxContainerNameMqtt);
            this.Controls.Add(this.textBoxAppNameMqqt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelXml);
            this.Controls.Add(this.textBoxXml);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxXml;
        private System.Windows.Forms.Label labelXml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAppNameMqqt;
        private System.Windows.Forms.TextBox textBoxContainerNameMqtt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSubscrive;
        private System.Windows.Forms.TextBox textBoxContainerName;
        private System.Windows.Forms.TextBox textBoxAppName;
        private System.Windows.Forms.Label labelContainerName;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.TextBox textBoxNotificationName;
        private System.Windows.Forms.Label labelNotificationName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelAtualChannel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonExamples;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxHttp;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ComboBox comboBoxMethod;
        private System.Windows.Forms.TextBox textBoxRecord;
    }
}

