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

        [HttpGet]
        public IActionResult Get()
        {
            string filePath = "C:\\Data\\NoteApp\\MessageFile.csv";

            //if (System.IO.File.Exists(filePath))
            //{
                var data = System.IO.File.ReadAllLines(filePath).ToList();
                string messageTitle = string.Empty;
                foreach (string line in data)
                {
                    string[] cols = line.Split(',');
                    int ID = int.Parse(cols[0]);
                    string title = cols[1];
                    string message = cols[2];
                    messageTitle = title;
                }


                return Ok(new { message = messageTitle });
            //}


        }
    }


    public class MessageDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }


}
