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
            ((System.ComponentModel.ISupportInitialize)metTextBox1).BeginInit();
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
            metTextBox1.Location = new Point(144, 72);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 160);
            Controls.Add(label1);
            Controls.Add(metTextBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)metTextBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetTextBox metTextBox1;
        private Label label1;
    }
}
