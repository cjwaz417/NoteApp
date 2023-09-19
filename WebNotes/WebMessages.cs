using Microsoft.AspNetCore.Mvc;
using NoteClasses;
using NoteClasses.DataAccess;
using System.Runtime.CompilerServices;
using WebNotes.Controllers;

namespace WebNotes
{
    public  class WebMessages
    {
        private const string MessageFile = "MessageFile.csv";
        private readonly IConfiguration _configuration;
        private string FilePath { get; set; }

        public WebMessages(IConfiguration configuration)
        {
             _configuration = configuration;
             FilePath = _configuration.GetValue<string>("FilePath");
        }

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
        public List<string> DecreaseWebIds(List<MessageModel> m, string FileName)
        {
            string filePath = _configuration.GetValue<string>("AppSettings:filePath");
            string fullFilePath = $"{FilePath}\\{FileName}";
            string[] lines = File.ReadAllLines(fullFilePath);

            List<string> updatedLines = new List<string>();



            for (int i = 0; i < lines.Length; i++)
            {
                MessageModel m1 = TextConnectorProcessor.ConvertLineToMessageModel(lines[i]);

                if (m.Any(model => model.Id == m1.Id))
                {
                    m1.Id = Math.Max(m1.Id - 1, 0);
                    updatedLines.Add(m1.ToString());

                }
                else
                {
                    updatedLines.Add(lines[i]);
                }


            }

            lines = updatedLines.ToArray();

            File.WriteAllLines(fullFilePath, lines);
            return updatedLines;
        }

        public void DeleteMessagesFromFile (List<MessageModel> model, string FileName, string FilePath)
        {
            string FullFilePath = $"{FilePath}{FileName}";
            string[] lines = File.ReadAllLines(FullFilePath);
            List<string> lineList = new List<string>(lines);
            const string MessageFile = "MessageFile.csv";
            List<MessageModel> modelCopy = new List<MessageModel>(model);

            foreach (MessageModel m in modelCopy)
            {
                if (m.Id > 0)
                {
                    var tempList = new List<string>(lines);
                    tempList.RemoveAt(m.Id -= 1);
                    MessageModel m1 = new MessageModel();
                    m1.Id = m.Id;
                    lines = tempList.ToArray();
                    lineList = tempList;

                    List<MessageModel> modelsd = new List<MessageModel>();

                    foreach (MessageModel md in lineList.ConvertToMessageModel())
                    {
                        if (md.Id > m1.Id)
                        {
                            modelsd.Add(md);
                        }
                    }

                    
                    File.WriteAllLines(FullFilePath, lines);
                    //FileName.FullFilePath()
                    DecreaseWebIds(modelsd, MessageFile);

                }
            }
        }



       


    }
}
