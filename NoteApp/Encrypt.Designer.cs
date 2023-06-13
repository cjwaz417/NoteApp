namespace NoteApp
{
    partial class EncryptForm
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
            KeyLabel = new Label();
            KeyValue = new TextBox();
            EncryptKeyButton = new Button();
            SuspendLayout();
            // 
            // KeyLabel
            // 
            KeyLabel.AutoSize = true;
            KeyLabel.Location = new Point(23, 24);
            KeyLabel.Margin = new Padding(5, 0, 5, 0);
            KeyLabel.Name = "KeyLabel";
            KeyLabel.Size = new Size(110, 30);
            KeyLabel.TabIndex = 0;
            KeyLabel.Text = "Enter Key:";
            // 
            // KeyValue
            // 
            KeyValue.Location = new Point(141, 21);
            KeyValue.Name = "KeyValue";
            KeyValue.Size = new Size(229, 36);
            KeyValue.TabIndex = 1;
            KeyValue.TextChanged += KeyValue_TextChanged;
            // 
            // EncryptKeyButton
            // 
            EncryptKeyButton.Location = new Point(174, 63);
            EncryptKeyButton.Name = "EncryptKeyButton";
            EncryptKeyButton.Size = new Size(145, 50);
            EncryptKeyButton.TabIndex = 2;
            EncryptKeyButton.Text = "Encrypt!";
            EncryptKeyButton.UseVisualStyleBackColor = true;
            EncryptKeyButton.Click += EncryptKeyButton_Click;
            // 
            // EncryptForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 125);
            Controls.Add(EncryptKeyButton);
            Controls.Add(KeyValue);
            Controls.Add(KeyLabel);
            Cursor = Cursors.IBeam;
            Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 6, 5, 6);
            Name = "EncryptForm";
            Text = "Encrypt";
            Load += EncryptForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label KeyLabel;
        private TextBox KeyValue;
        private Button EncryptKeyButton;
    }
}