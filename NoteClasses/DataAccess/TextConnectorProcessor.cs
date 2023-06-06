using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace NoteClasses.DataAccess
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filepath"]}\\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<MessageModel> ConvertToMessageModel(this List<string> lines)
        {
            List<MessageModel> output = new List<MessageModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MessageModel m = new MessageModel();
                m.Id = int.Parse(cols[0]);
                m.Title = cols[1];
                m.Message = cols[2];
                output.Add(m);
            }

            return output;
        }

        public static void SaveToMessageFile(this List<MessageModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (MessageModel m in models)
            {
                lines.Add($"{m.Id}, {m.Title}, {m.Message}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void DeleteFromMessageFile(this List<MessageModel> model, string fileName)
        {
            string[] lines = File.ReadAllLines(fileName.FullFilePath());
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
                    
                    
                    //model.RemoveAt(m.Id -= 1);
                    List<MessageModel> modelsd = new List<MessageModel>();

                    foreach (MessageModel md in lineList.ConvertToMessageModel())
                    {
                        if (md.Id > m1.Id)
                        {
                            modelsd.Add(md);
                            
                        }
                    }
                    

                    

                    File.WriteAllLines(fileName.FullFilePath(), lines);
                    modelsd.DecreaseIds(MessageFile);
                    
                    
                }

            }


        }

        public static List<string> DecreaseIds(this List<MessageModel> m, string FileName)
        {
            string[] lines = File.ReadAllLines(FileName.FullFilePath());

            List<string> updatedLines = new List<string>();

            

            for (int i = 0; i < lines.Length; i++) 
            { 
                MessageModel m1 = ConvertLineToMessageModel(lines[i]);

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

            File.WriteAllLines(FileName.FullFilePath(), lines);
            return updatedLines;
        }

        public static string LoadMessageFromFile(this  MessageModel messageModel, string FileName)
        {
            const string MessageFile = "MessageFile.csv";
            List<MessageModel> messages = MessageFile.FullFilePath().LoadFile().ConvertToMessageModel();
            MessageModel fetchedMessage = messages.FirstOrDefault(m => m.Id == messageModel.Id);

            if(fetchedMessage != null) 
            {
                return messageModel.Message = fetchedMessage.Message;
                
            }
            else
            {
                throw new Exception("Message not found");
            }
        }

        private static MessageModel ConvertLineToMessageModel(string line)
        {
            string[] cols = line.Split(',');

            MessageModel m = new MessageModel();
            m.Id = int.Parse(cols[0].Trim());
            m.Title = cols.Length > 1 ? cols[1].Trim() : null;
            m.Message = cols.Length > 2 ? cols[2].Trim() : null;


            return m;
            
        }

        private static string EncryptMessageMethod(string message, string key) 
        {
            byte[] encryptedBytes;

            using (Aes aes = Aes.Create()) 
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.GenerateIV();

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                using (var encryptedStream = new System.IO.MemoryStream()) 
                {
                    using (var cryptoStream = new CryptoStream(encryptedStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(messageBytes, 0, messageBytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    encryptedBytes = encryptedStream.ToArray();

                }

                return Convert.ToBase64String(encryptedBytes);
            }
        
        }
    }
}
