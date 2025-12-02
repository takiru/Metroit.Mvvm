namespace Metroit.Mvvm.WinForms.Test
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
            MessageButton = new Button();
            DialogShowButton = new Button();
            DialogShowWithRequestButton = new Button();
            DialogShowDialogWithResponseButton = new Button();
            DialogShowDialogWithRequestAndResponseButton = new Button();
            DialogShowDialogButton = new Button();
            DialogShowDialogWithRequestButton = new Button();
            SuspendLayout();
            // 
            // MessageButton
            // 
            MessageButton.Location = new Point(12, 12);
            MessageButton.Name = "MessageButton";
            MessageButton.Size = new Size(90, 23);
            MessageButton.TabIndex = 0;
            MessageButton.Text = "MessageTest";
            MessageButton.UseVisualStyleBackColor = true;
            MessageButton.Click += MessageButton_Click;
            // 
            // DialogShowButton
            // 
            DialogShowButton.Location = new Point(283, 12);
            DialogShowButton.Name = "DialogShowButton";
            DialogShowButton.Size = new Size(102, 23);
            DialogShowButton.TabIndex = 2;
            DialogShowButton.Text = "Dialog Show";
            DialogShowButton.UseVisualStyleBackColor = true;
            DialogShowButton.Click += DialogShowButton_Click;
            // 
            // DialogShowWithRequestButton
            // 
            DialogShowWithRequestButton.Location = new Point(233, 41);
            DialogShowWithRequestButton.Name = "DialogShowWithRequestButton";
            DialogShowWithRequestButton.Size = new Size(152, 23);
            DialogShowWithRequestButton.TabIndex = 3;
            DialogShowWithRequestButton.Text = "Dialog ShowWithRequest";
            DialogShowWithRequestButton.UseVisualStyleBackColor = true;
            DialogShowWithRequestButton.Click += DialogShowWithRequestButton_Click;
            // 
            // DialogShowDialogWithResponseButton
            // 
            DialogShowDialogWithResponseButton.Location = new Point(185, 128);
            DialogShowDialogWithResponseButton.Name = "DialogShowDialogWithResponseButton";
            DialogShowDialogWithResponseButton.Size = new Size(200, 23);
            DialogShowDialogWithResponseButton.TabIndex = 4;
            DialogShowDialogWithResponseButton.Text = "Dialog ShowDialogWithResponse";
            DialogShowDialogWithResponseButton.UseVisualStyleBackColor = true;
            DialogShowDialogWithResponseButton.Click += DialogShowDialogWithResponseButton_Click;
            // 
            // DialogShowDialogWithRequestAndResponseButton
            // 
            DialogShowDialogWithRequestAndResponseButton.Location = new Point(112, 157);
            DialogShowDialogWithRequestAndResponseButton.Name = "DialogShowDialogWithRequestAndResponseButton";
            DialogShowDialogWithRequestAndResponseButton.Size = new Size(273, 23);
            DialogShowDialogWithRequestAndResponseButton.TabIndex = 5;
            DialogShowDialogWithRequestAndResponseButton.Text = "Dialog ShowDialogWithRequestAndResponse";
            DialogShowDialogWithRequestAndResponseButton.UseVisualStyleBackColor = true;
            DialogShowDialogWithRequestAndResponseButton.Click += DialogShowDialogWithRequestAndResponseButton_Click;
            // 
            // DialogShowDialogButton
            // 
            DialogShowDialogButton.Location = new Point(258, 70);
            DialogShowDialogButton.Name = "DialogShowDialogButton";
            DialogShowDialogButton.Size = new Size(127, 23);
            DialogShowDialogButton.TabIndex = 7;
            DialogShowDialogButton.Text = "Dialog ShowDialog";
            DialogShowDialogButton.UseVisualStyleBackColor = true;
            DialogShowDialogButton.Click += DialogShowDialogButton_Click;
            // 
            // DialogShowDialogWithRequestButton
            // 
            DialogShowDialogWithRequestButton.Location = new Point(185, 99);
            DialogShowDialogWithRequestButton.Name = "DialogShowDialogWithRequestButton";
            DialogShowDialogWithRequestButton.Size = new Size(200, 23);
            DialogShowDialogWithRequestButton.TabIndex = 8;
            DialogShowDialogWithRequestButton.Text = "Dialog ShowDialogWithRequest";
            DialogShowDialogWithRequestButton.UseVisualStyleBackColor = true;
            DialogShowDialogWithRequestButton.Click += DialogShowDialogWithRequestButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 247);
            Controls.Add(DialogShowDialogWithRequestButton);
            Controls.Add(DialogShowDialogButton);
            Controls.Add(DialogShowDialogWithRequestAndResponseButton);
            Controls.Add(DialogShowDialogWithResponseButton);
            Controls.Add(DialogShowWithRequestButton);
            Controls.Add(DialogShowButton);
            Controls.Add(MessageButton);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button MessageButton;
        private Button DialogShowButton;
        private Button DialogShowWithRequestButton;
        private Button DialogShowDialogWithResponseButton;
        private Button DialogShowDialogWithRequestAndResponseButton;
        private Button DialogShowDialogButton;
        private Button DialogShowDialogWithRequestButton;
    }
}