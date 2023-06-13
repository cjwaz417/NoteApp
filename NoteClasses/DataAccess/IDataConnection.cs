using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteClasses.DataAccess
{
    public interface IDataConnection
    {
        MessageModel CreateMessage (MessageModel message);

        List<MessageModel> GetMessages();

        void DeleteMessage (MessageModel message);

        void DecreaseMessageIds (List<MessageModel> message);

        void LoadMessage (MessageModel message);

        string EncryptMesage (string message, string key);

        string DecryptMessage (string message, string key);


    }
}
