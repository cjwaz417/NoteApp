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
            SuspendLayout();
            // 
            // MessageTextBox
            // 
            MessageTextBox.Location = new Point(81, 106);
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.Size = new Size(339, 330);
            MessageTextBox.TabIndex = 0;
            MessageTextBox.Text = "";
            MessageTextBox.TextChanged += MessageTextBox_TextChanged;
            // 
            // TitleTextBox
            // 
            TitleTextBox.Location = new Point(166, 49);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(254, 36);
            TitleTextBox.TabIndex = 1;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(81, 49);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(54, 30);
            TitleLabel.TabIndex = 2;
            TitleLabel.Text = "Title";
            // 
            // SaveMessageButton
            // 
            SaveMessageButton.Location = new Point(83, 444);
            SaveMessageButton.Name = "SaveMessageButton";
            SaveMessageButton.Size = new Size(104, 48);
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
            // 
            // DeleteMessagesButton
            // 
            DeleteMessagesButton.Location = new Point(602, 451);
            DeleteMessagesButton.Name = "DeleteMessagesButton";
            DeleteMessagesButton.Size = new Size(103, 41);
            DeleteMessagesButton.TabIndex = 6;
            DeleteMessagesButton.Text = "Delete";
            DeleteMessagesButton.UseVisualStyleBackColor = true;
            // 
            // NoteForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 548);
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
    }
}