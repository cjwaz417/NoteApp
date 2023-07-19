using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using NoteClasses;
using NoteClasses.DataAccess;
using System.Reflection;


namespace WebNotes
{
    [ApiController]
    [Route("[controller]")]
    public class Endpoint : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] MessageDto message)
        {
            var filePath = "C:\\Data\\message.txt";
            var textToWrite = $"Title: {message.Title}\nMessage: {message.Text}\n---\n";
            System.IO.File.AppendAllText(filePath, textToWrite);

            WebMessages processor = new WebMessages();
            var lines = processor.MessageDtoToStringList(message);
            var webMessages = lines.ConvertWebToMessageModel();
            return Ok();
        }
    }
    public class MessageDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }


}
