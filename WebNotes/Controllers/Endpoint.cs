using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using NoteClasses;
using NoteClasses.DataAccess;
using System.Reflection;


namespace WebNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Endpoint : ControllerBase
    {
        private const string MessageFile = "MessageFile.csv";

        [HttpPost]
        public IActionResult Post([FromBody] MessageDto message)
        {
            var filePath = "C:\\Data\\NoteApp\\";
            //var textToWrite = $"Title: {message.Title}\nMessage: {message.Text}\n---\n";
            //System.IO.File.AppendAllText(filePath, textToWrite);

            WebMessages processor = new WebMessages();
            var messages = processor.LoadMessagesFromFile();
            int newid = processor.GetNewId(messages);
            message.ID = newid;
            var lines = processor.MessageDtoToStringList(message);
            var webMessages = lines.ConvertToMessageModel();
            webMessages.WebSaveToMessageFile(MessageFile, filePath);
            
            
            return Ok();
        }
    }
    public class MessageDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }


}
