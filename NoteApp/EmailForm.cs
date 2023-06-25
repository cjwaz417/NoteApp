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
    public partial class EmailForm : Form
    {
        NoteForm email;
        public string message { get; set; }


        public EmailForm(NoteForm email, string message)
        {
            InitializeComponent();
            this.email = email;
            this.message = message;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ToTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string server = Environment.GetEnvironmentVariable("SMTP_SERVER");
            string username = Environment.GetEnvironmentVariable("SMTP_USERNAME");
            string password = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
            int port = 25;
            var emailSender = new Email(server, port, username, password);

            string title = email.GetTitle();
            string toAdd = ToTextBox.Text;
            emailSender.SendEmail("chriswasielewski09@gmail.com", toAdd, title, message);
            this.Close();


        }
    }
}
