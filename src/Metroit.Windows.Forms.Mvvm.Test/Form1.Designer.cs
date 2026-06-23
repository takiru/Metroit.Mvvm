namespace Metroit.Windows.Forms.Mvvm.Extensions.Test
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
            metTextBox1 = new MetTextBox();
            label1 = new Label();
            metDateTimePicker1 = new MetDateTimePicker();
            metToggleSwitch1 = new MetToggleSwitch();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)metTextBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)metDateTimePicker1).BeginInit();
            SuspendLayout();
            // 
            // metTextBox1
            // 
            // 
            // 
            // 
            metTextBox1.CustomAutoCompleteBox.CompareOptions.Add(System.Globalization.CompareOptions.IgnoreCase);
            metTextBox1.CustomAutoCompleteBox.CompareOptions.Add(System.Globalization.CompareOptions.IgnoreWidth);
            metTextBox1.CustomAutoCompleteBox.MatchPattern = MatchPatternType.Partial;
            metTextBox1.CustomAutoCompleteBox.TargetControl = metTextBox1;
            metTextBox1.CustomAutoCompleteKeys.Add(MetKeys.Control | MetKeys.Enter);
            metTextBox1.CustomAutoCompleteMode = CustomAutoCompleteMode.KeysSuggest;
            metTextBox1.Location = new Point(144, 39);
            metTextBox1.Name = "metTextBox1";
            metTextBox1.Size = new Size(100, 23);
            metTextBox1.TabIndex = 0;
            metTextBox1.CandidateSelected += metTextBox1_CandidateSelected;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 21);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 1;
            label1.Text = "Selected Value";
            // 
            // metDateTimePicker1
            // 
            metDateTimePicker1.Location = new Point(144, 75);
            metDateTimePicker1.Name = "metDateTimePicker1";
            metDateTimePicker1.Size = new Size(123, 23);
            metDateTimePicker1.TabIndex = 2;
            // 
            // metToggleSwitch1
            // 
            metToggleSwitch1.Location = new Point(144, 104);
            metToggleSwitch1.Name = "metToggleSwitch1";
            metToggleSwitch1.Size = new Size(43, 26);
            metToggleSwitch1.TabIndex = 3;
            metToggleSwitch1.Text = "metToggleSwitch1";
            // 
            // button1
            // 
            button1.Location = new Point(144, 136);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 160);
            Controls.Add(button1);
            Controls.Add(metToggleSwitch1);
            Controls.Add(metDateTimePicker1);
            Controls.Add(label1);
            Controls.Add(metTextBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)metTextBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)metDateTimePicker1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetTextBox metTextBox1;
        private Label label1;
        private MetDateTimePicker metDateTimePicker1;
        private MetToggleSwitch metToggleSwitch1;
        private Button button1;
    }
}
