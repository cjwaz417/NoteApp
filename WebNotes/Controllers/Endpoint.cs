using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using NoteClasses;
using NoteClasses.DataAccess;
using System.Drawing.Text;
using System.Reflection;


namespace WebNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Endpoint : ControllerBase
    {
        private const string MessageFile = "MessageFile.csv";
        string filePath = "C:\\Data\\NoteApp\\";
        private readonly WebMessages _webMessages;

        public Endpoint (WebMessages webMessages)
        {
            _webMessages = webMessages;
        }

        [HttpPost]
        public IActionResult Post([FromBody] MessageDto message)
        {
            

            //IConfiguration configuration =
            var messages = _webMessages.LoadMessagesFromFile(filePath);
            int newid = _webMessages.GetNewId(messages);
            message.ID = newid;

            
            var m = _webMessages.MessageDtoToStringList(message);
            var webMessagesModel = m.ConvertToMessageModel();

            messages.Add(webMessagesModel[0]);
            messages.WebSaveToMessageFile(MessageFile, filePath);


            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            string filePath = "C:\\Data\\NoteApp\\MessageFile.csv";


                var data = System.IO.File.ReadAllLines(filePath).ToList();
                List<string> messageTitle = new List<string>();
                foreach (string line in data)
                {
                    string[] cols = line.Split(',');
                    int ID = int.Parse(cols[0]);
                    string title = cols[1];
                    string message = cols[2];
                    messageTitle.Add(title);
                }


                return Ok(new { message = messageTitle });



        }

        [HttpGet("GetMessages")]
        public IActionResult GetMessages()
        {
            
            var messages = _webMessages.LoadMessagesFromFile(filePath);

            return Ok(new {messages = messages });
        }

        [HttpPost ("DeleteMessages")]
        public IActionResult DeleteMessages([FromBody] MessageDto message)
        {
            string fileName = "MessageFile.csv";
            string filePath = "C:\\Data\\NoteApp\\";
            

            
            var m = _webMessages.MessageDtoToStringList(message);
            var webMessageModel = m.ConvertToMessageModel();
            _webMessages.DeleteMessagesFromFile(webMessageModel, fileName, filePath);

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
