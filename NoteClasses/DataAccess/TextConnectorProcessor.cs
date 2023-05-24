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
            string[] lines = File.ReadAllLines(fileName);


            foreach (MessageModel m in model)
            {
                if (m.Id > 0)
                {
                    var tempList = lines.Where(item => Convert.ToInt32(item.Split(',')[0]) != m.Id).ToList();
                    lines = tempList.ToArray();

                    File.WriteAllLines(fileName.FullFilePath(), lines);
                }


            }
        }
    }
}
