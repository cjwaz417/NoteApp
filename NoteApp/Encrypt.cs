using NoteClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteApp
{
    public partial class EncryptForm : Form
    {
        NoteForm encryptKey;
        public string message { get; set; }
        public EncryptForm(NoteForm form, string message)
        {
            InitializeComponent();
            this.encryptKey = form;
            this.message = message;
        }

        private void KeyValue_TextChanged(object sender, EventArgs e)
        {
            this.encryptKey.Key = KeyValue.Text;
        }

        private void EncryptForm_Load(object sender, EventArgs e)
        {

        }

        private void EncryptKeyButton_Click(object sender, EventArgs e)
        {
            string encryptedMessage = GlobalConfig.Connection.EncryptMesage(this.message, this.encryptKey.Key);
            this.encryptKey.SetEncryptedMessage(encryptedMessage);
            this.Close();
        }
    }
}
