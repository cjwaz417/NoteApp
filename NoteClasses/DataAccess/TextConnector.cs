using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteClasses.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string MessageFile = "MessageFile.csv";

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

        public List<MessageModel> GetMessages() 
        {
            return MessageFile.FullFilePath().LoadFile().ConvertToMessageModel();
        }
    }
}
