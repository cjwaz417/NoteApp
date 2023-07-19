using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace NoteClasses.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string MessageFile = "MessageFile.csv";
        MessageModel delM = new MessageModel();


        public MessageModel CreateMessage(MessageModel model)
        {
            var messages = LoadMessagesFromFile();

            int newId = GetNewId(messages);
            model.Id = newId;

            bool messageExists = UpdateMessageIfExists(messages, model);

            if (!messageExists)
            {
                messages.Add(model);
            }

            SaveMessagesToFile(messages);

            return model;
        }
        private List<MessageModel> LoadMessagesFromFile()
        {
            return MessageFile.FullFilePath().LoadFile().ConvertToMessageModel();
        }

        public int GetNewId(List<MessageModel> messages)
        {
            if (messages.Count == 0)
            {
                return 1;
            }
            else
            {
                return messages.Max(m => m.Id) + 1;
            }
        }

        private bool UpdateMessageIfExists(List<MessageModel> messages, MessageModel model)
        {
            var existingMessage = messages.FirstOrDefault(m => m.Title == model.Title);
            if (existingMessage != null)
            {
                existingMessage.Message = model.Message;
                return true;
            }

            return false;
        }

        private void SaveMessagesToFile(List<MessageModel> messages)
        {
            messages.SaveToMessageFile(MessageFile);
        }


        void IDataConnection.DeleteMessage (MessageModel model) 
        {
            //List<MessageModel> message = MessageFile.FullFilePath().LoadFile().ConvertToMessageModel();
            //message.DeleteFromMessageFile(MessageFile);
            List<MessageModel> message = new List<MessageModel>();
            message.Add (model);
            message.DeleteFromMessageFile(MessageFile);
            
            
        }

        public List<MessageModel> GetMessages() 
        {
            return MessageFile.FullFilePath().LoadFile().ConvertToMessageModel();
        }

        public void DecreaseMessageIds(List<MessageModel> model)
        {
            List<MessageModel> message = new List<MessageModel> ();
            message.AddRange(model);
            message.DecreaseIds(MessageFile);
        }

        public void LoadMessage(MessageModel message)
        {
            message.LoadMessageFromFile(MessageFile);
        }

        public string EncryptMesage(string message, string key)
        {
            return message.EncryptMessageMethod(key);
        }

        public string DecryptMessage(string key, string message)
        {
            return message.DecryptMessageMethod(key);
        }
    }
}
