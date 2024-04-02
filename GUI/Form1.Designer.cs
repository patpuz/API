using System.Globalization;

namespace GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            calendar = new MonthCalendar();
            buttonDownload = new Button();
            label1 = new Label();
            textBoxCurrency = new TextBox();
            textBoxDate = new TextBox();
            listBoxCurrencyInfo = new ListBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // calendar
            // 
            calendar.Location = new Point(43, 18);
            calendar.Name = "calendar";
            calendar.TabIndex = 0;
            // 
            // buttonDownload
            // 
            buttonDownload.Location = new Point(278, 245);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(94, 29);
            buttonDownload.TabIndex = 2;
            buttonDownload.Text = "Download";
            buttonDownload.UseVisualStyleBackColor = true;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 245);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 3;
            label1.Text = "Enter the Currency";
            // 
            // textBoxCurrency
            // 
            textBoxCurrency.Location = new Point(147, 245);
            textBoxCurrency.Name = "textBoxCurrency";
            textBoxCurrency.Size = new Size(125, 27);
            textBoxCurrency.TabIndex = 4;
            // 
            // textBoxDate
            // 
            textBoxDate.Font = new Font("Segoe UI", 20F);
            textBoxDate.Location = new Point(513, 18);
            textBoxDate.Multiline = true;
            textBoxDate.Name = "textBoxDate";
            textBoxDate.Size = new Size(386, 49);
            textBoxDate.TabIndex = 5;
            textBoxDate.TextAlign = HorizontalAlignment.Center;
            // 
            // listBoxCurrencyInfo
            // 
            listBoxCurrencyInfo.FormattingEnabled = true;
            listBoxCurrencyInfo.Location = new Point(513, 82);
            listBoxCurrencyInfo.Name = "listBoxCurrencyInfo";
            listBoxCurrencyInfo.Size = new Size(386, 304);
            listBoxCurrencyInfo.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(12, 297);
            button1.Name = "button1";
            button1.Size = new Size(221, 59);
            button1.TabIndex = 7;
            button1.Text = "Download from database";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonDownloadFromDatabase_Click;
            // 
            // button2
            // 
            button2.Location = new Point(378, 245);
            button2.Name = "button2";
            button2.Size = new Size(107, 29);
            button2.TabIndex = 9;
            button2.Text = "Add to base";
            button2.UseVisualStyleBackColor = true;
            button2.Click += AddToBase;
            // 
            // button3
            // 
            button3.Location = new Point(396, 297);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 10;
            button3.Text = "Sort";
            button3.UseVisualStyleBackColor = true;
            button3.Click += SortButton;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(239, 297);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 477);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBoxCurrencyInfo);
            Controls.Add(textBoxDate);
            Controls.Add(textBoxCurrency);
            Controls.Add(label1);
            Controls.Add(buttonDownload);
            Controls.Add(calendar);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar calendar;
        private Button buttonDownload;
        private Label label1;
        private TextBox textBoxCurrency;
        private TextBox textBoxDate;
        private ListBox listBoxCurrencyInfo;
        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox comboBox1;
    }
}
