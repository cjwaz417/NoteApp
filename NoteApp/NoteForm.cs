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
using System.Configuration;
using NoteClasses.DataAccess;
using System.Runtime.CompilerServices;

namespace NoteApp
{
    public partial class NoteForm : Form
    {
        private List<MessageModel> savedMessages;


        

        public NoteForm()
        {
            InitializeComponent();
            

            WireUpLists();
        }

        private void WireUpLists()
        {
            try
            {
                savedMessages = GlobalConfig.Connection.GetMessages();
            }
            catch
            {
                savedMessages = new List<MessageModel>();
            }
            
            StoredMessagesListBox.DataSource = null;
            StoredMessagesListBox.DataSource = savedMessages;
            StoredMessagesListBox.DisplayMember = "Title";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveMessageButton_Click(object sender, EventArgs e)
        {
            MessageModel m = new MessageModel();
            m.Title = TitleTextBox.Text;
            m.Message = MessageTextBox.Text;
            GlobalConfig.Connection.CreateMessage(m);
            MessageTextBox.Text = "";
            WireUpLists();

        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteMessagesButton_Click(object sender, EventArgs e)
        {
            MessageModel m1 = (MessageModel)StoredMessagesListBox.SelectedItem;
            GlobalConfig.Connection.DeleteMessage(m1);
            WireUpLists();
        }

    }
}