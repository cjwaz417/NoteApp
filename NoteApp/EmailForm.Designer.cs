namespace NoteApp
{
    partial class EmailForm
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
            ToLabel = new Label();
            ToTextBox = new TextBox();
            SendButton = new Button();
            SuspendLayout();
            // 
            // ToLabel
            // 
            ToLabel.AutoSize = true;
            ToLabel.Location = new Point(34, 47);
            ToLabel.Name = "ToLabel";
            ToLabel.Size = new Size(41, 30);
            ToLabel.TabIndex = 0;
            ToLabel.Text = "To:";
            ToLabel.Click += label1_Click;
            // 
            // ToTextBox
            // 
            ToTextBox.Location = new Point(81, 44);
            ToTextBox.Name = "ToTextBox";
            ToTextBox.Size = new Size(274, 36);
            ToTextBox.TabIndex = 1;
            ToTextBox.TextChanged += ToTextBox_TextChanged;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(134, 86);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(146, 49);
            SendButton.TabIndex = 2;
            SendButton.Text = "$end";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // EmailForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 167);
            Controls.Add(SendButton);
            Controls.Add(ToTextBox);
            Controls.Add(ToLabel);
            Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 6, 5, 6);
            Name = "EmailForm";
            Text = "EmailForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ToLabel;
        private TextBox ToTextBox;
        private Button SendButton;
    }
}