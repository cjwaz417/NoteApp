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
    public partial class Decrypt : Form
    {
        NoteForm encryptKey;
        public string message { get; set; }
        public Decrypt(NoteForm form, string message)
        {
            InitializeComponent();
            this.encryptKey = form;
            this.message = message;
        }

        private void DecryptKeyButton_Click(object sender, EventArgs e)
        {
            string encryptedMessage = GlobalConfig.Connection.DecryptMessage(this.encryptKey.Key, this.message);
            this.encryptKey.SetEncryptedMessage(encryptedMessage);
            this.Close();

        }

        private void DKeyValue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
