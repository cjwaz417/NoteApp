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


        public MessageModel CreateMessage (MessageModel model)
        {
            List<MessageModel> message = MessageFile.FullFilePath().LoadFile().ConvertToMessageModel();

            int currentId = 1;

            if (message.Count > 0)
            {
                currentId = message.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            message.Add (model);

            message.SaveToMessageFile(MessageFile);

            return model;
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

        public void EncryptMesage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
