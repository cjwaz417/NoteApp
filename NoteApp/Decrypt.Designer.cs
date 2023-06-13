namespace NoteApp
{
    partial class Decrypt
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
            DecryptKeyButton = new Button();
            DKeyValue = new TextBox();
            DKeyLabel = new Label();
            SuspendLayout();
            // 
            // DecryptKeyButton
            // 
            DecryptKeyButton.Location = new Point(163, 75);
            DecryptKeyButton.Name = "DecryptKeyButton";
            DecryptKeyButton.Size = new Size(145, 50);
            DecryptKeyButton.TabIndex = 5;
            DecryptKeyButton.Text = "Decrypt!!!";
            DecryptKeyButton.UseVisualStyleBackColor = true;
            DecryptKeyButton.Click += DecryptKeyButton_Click;
            // 
            // DKeyValue
            // 
            DKeyValue.Location = new Point(139, 33);
            DKeyValue.Name = "DKeyValue";
            DKeyValue.Size = new Size(229, 36);
            DKeyValue.TabIndex = 4;
            DKeyValue.TextChanged += DKeyValue_TextChanged;
            // 
            // DKeyLabel
            // 
            DKeyLabel.AutoSize = true;
            DKeyLabel.Location = new Point(32, 36);
            DKeyLabel.Margin = new Padding(5, 0, 5, 0);
            DKeyLabel.Name = "DKeyLabel";
            DKeyLabel.Size = new Size(110, 30);
            DKeyLabel.TabIndex = 3;
            DKeyLabel.Text = "Enter Key:";
            // 
            // Decrypt
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 153);
            Controls.Add(DecryptKeyButton);
            Controls.Add(DKeyValue);
            Controls.Add(DKeyLabel);
            Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Decrypt";
            Text = "Decrypt";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DecryptKeyButton;
        private TextBox DKeyValue;
        private Label DKeyLabel;
    }
}