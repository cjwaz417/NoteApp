namespace NoteApp
{
    partial class NoteForm
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
            MessageTextBox = new RichTextBox();
            TitleTextBox = new TextBox();
            TitleLabel = new Label();
            SaveMessageButton = new Button();
            StoredMessagesListBox = new ListBox();
            LoadMessagesButton = new Button();
            DeleteMessagesButton = new Button();
            ClearButton = new Button();
            EncryptButton = new Button();
            DecryptButton = new Button();
            SendEmailButton = new Button();
            SuspendLayout();
            // 
            // MessageTextBox
            // 
            MessageTextBox.Location = new Point(12, 106);
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.Size = new Size(408, 332);
            MessageTextBox.TabIndex = 0;
            MessageTextBox.Text = "";
            MessageTextBox.TextChanged += MessageTextBox_TextChanged;
            // 
            // TitleTextBox
            // 
            TitleTextBox.Location = new Point(72, 52);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(348, 36);
            TitleTextBox.TabIndex = 1;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(12, 52);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(54, 30);
            TitleLabel.TabIndex = 2;
            TitleLabel.Text = "Title";
            // 
            // SaveMessageButton
            // 
            SaveMessageButton.Location = new Point(12, 447);
            SaveMessageButton.Name = "SaveMessageButton";
            SaveMessageButton.Size = new Size(89, 48);
            SaveMessageButton.TabIndex = 3;
            SaveMessageButton.Text = "Save";
            SaveMessageButton.UseVisualStyleBackColor = true;
            SaveMessageButton.Click += SaveMessageButton_Click;
            // 
            // StoredMessagesListBox
            // 
            StoredMessagesListBox.FormattingEnabled = true;
            StoredMessagesListBox.ItemHeight = 30;
            StoredMessagesListBox.Location = new Point(460, 49);
            StoredMessagesListBox.Name = "StoredMessagesListBox";
            StoredMessagesListBox.Size = new Size(245, 394);
            StoredMessagesListBox.TabIndex = 4;
            // 
            // LoadMessagesButton
            // 
            LoadMessagesButton.Location = new Point(460, 451);
            LoadMessagesButton.Name = "LoadMessagesButton";
            LoadMessagesButton.Size = new Size(104, 41);
            LoadMessagesButton.TabIndex = 5;
            LoadMessagesButton.Text = "Load";
            LoadMessagesButton.UseVisualStyleBackColor = true;
            LoadMessagesButton.Click += LoadMessagesButton_Click;
            // 
            // DeleteMessagesButton
            // 
            DeleteMessagesButton.Location = new Point(602, 451);
            DeleteMessagesButton.Name = "DeleteMessagesButton";
            DeleteMessagesButton.Size = new Size(103, 41);
            DeleteMessagesButton.TabIndex = 6;
            DeleteMessagesButton.Text = "Delete";
            DeleteMessagesButton.UseVisualStyleBackColor = true;
            DeleteMessagesButton.Click += DeleteMessagesButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(107, 447);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(101, 48);
            ClearButton.TabIndex = 7;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += button1_Click;
            // 
            // EncryptButton
            // 
            EncryptButton.Location = new Point(214, 447);
            EncryptButton.Name = "EncryptButton";
            EncryptButton.Size = new Size(102, 48);
            EncryptButton.TabIndex = 8;
            EncryptButton.Text = "Encrypt";
            EncryptButton.UseVisualStyleBackColor = true;
            EncryptButton.Click += EncryptButton_Click;
            // 
            // DecryptButton
            // 
            DecryptButton.Location = new Point(322, 447);
            DecryptButton.Name = "DecryptButton";
            DecryptButton.Size = new Size(98, 48);
            DecryptButton.TabIndex = 9;
            DecryptButton.Text = "Decrypt";
            DecryptButton.UseVisualStyleBackColor = true;
            DecryptButton.Click += DecryptButton_Click;
            // 
            // SendEmailButton
            // 
            SendEmailButton.Location = new Point(12, 516);
            SendEmailButton.Name = "SendEmailButton";
            SendEmailButton.Size = new Size(196, 48);
            SendEmailButton.TabIndex = 10;
            SendEmailButton.Text = "Send";
            SendEmailButton.UseVisualStyleBackColor = true;
            SendEmailButton.Click += SendEmailButton_Click;
            // 
            // NoteForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 576);
            Controls.Add(SendEmailButton);
            Controls.Add(DecryptButton);
            Controls.Add(EncryptButton);
            Controls.Add(ClearButton);
            Controls.Add(DeleteMessagesButton);
            Controls.Add(LoadMessagesButton);
            Controls.Add(StoredMessagesListBox);
            Controls.Add(SaveMessageButton);
            Controls.Add(TitleLabel);
            Controls.Add(TitleTextBox);
            Controls.Add(MessageTextBox);
            Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 6, 5, 6);
            Name = "NoteForm";
            Text = "Notes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox MessageTextBox;
        private TextBox TitleTextBox;
        private Label TitleLabel;
        private Button SaveMessageButton;
        private ListBox StoredMessagesListBox;
        private Button LoadMessagesButton;
        private Button DeleteMessagesButton;
        private Button ClearButton;
        private Button EncryptButton;
        private Button DecryptButton;
        private Button SendEmailButton;
    }
}