using Microsoft.AspNetCore.Mvc;
using NoteClasses;
using NoteClasses.DataAccess;
using WebNotes.Controllers;

namespace WebNotes
{
    public class WebMessages
    {
        private const string MessageFile = "MessageFile.csv";
        private readonly IConfiguration _configuration;
        private string FilePath { get; set; }

        //public WebMessages(IConfiguration configuration)
        // {
        //     _configuration = configuration;
        //     FilePath = _configuration.GetValue<string>("FilePath");
        // }

        public List<MessageModel> LoadMessagesFromFile(string FilePath)
        {
            string FullFilePath = $"{FilePath}{MessageFile}";

            return FullFilePath.LoadFile().ConvertToMessageModel();
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

        public List<string> MessageDtoToStringList(MessageDto message)
        {
        
        var output = new List<string>
            {
                $"{message.ID},{message.Title},{message.Text}"
            };

            return output;
        }

        //public MessageModel Message(MessageDto message)
        //{
        //    var m = ToList(message);
        //    List<MessageModel> messages = m.ConvertWebToMessageModel();

        //}
    }
}
