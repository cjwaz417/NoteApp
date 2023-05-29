﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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


            foreach (MessageModel m in model)
            {
                if (m.Id > 0)
                {
                    var tempList = new List<string>(lines);
                    tempList.RemoveAt(m.Id -= 1);
                    lines = tempList.ToArray();

                    File.WriteAllLines(fileName.FullFilePath(), lines);
                }

            }


        }

        public static void DecreaseIds(this List<MessageModel> m, string FileName)
        {
            string[] lines = File.ReadAllLines(FileName.FullFilePath());

            List<string> updatedLines = new List<string>();

            for (int i = 0; i <lines.Length; i++) 
            { 
                MessageModel m1 = ConvertLineToMessageModel(lines[i]);

                m1.Id = Math.Max(m1.Id - 1, 0);
                updatedLines.Add(m1.ToString());
            
            }

            File.WriteAllLines(FileName.FullFilePath(), updatedLines);
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
    }
}
