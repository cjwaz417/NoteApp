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
            var messages = processor.LoadMessagesFromFile(filePath);
            int newid = processor.GetNewId(messages);
            message.ID = newid;

            //create MessageModel from message
            var m = processor.MessageDtoToStringList(message);
            var webMessagesModel = m.ConvertToMessageModel();

            messages.Add(webMessagesModel[0]);
            messages.WebSaveToMessageFile(MessageFile, filePath);
            
            
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
