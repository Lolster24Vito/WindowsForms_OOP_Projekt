using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.REPO
{
    public class FileRepo
    {
        public static async void SaveToFile(List<string> lines,string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                if(lines.Count==0)
                {
                    await writer.WriteLineAsync("");
                    return;

                }
                foreach (string line in lines)
                {
                    await writer.WriteLineAsync(line);

                }
            }
        }
        public static async void SaveToFileAtEnd(string line, string path)
        {
            using (StreamWriter writer = new StreamWriter(path,true))
            {
                
                   await writer.WriteLineAsync(line);
                
            }
        }
        public static async void SaveToFileAtEnd(List<string> lines, string path)
        {
            using (StreamWriter writer = new StreamWriter(path,true))
            {
                if (lines.Count == 0)
                {
                    await writer.WriteLineAsync("");
                    return;

                }
                foreach (string line in lines)
                {
                    await writer.WriteLineAsync(line);

                }
            }
        }
        public static async void SaveToFile(string line, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {

                await writer.WriteLineAsync(line);

            }
        }

        public static async Task<List<string>> ReadFromFileList(string path)
        {
            List<string> lines=new List<string>();
            if (!CheckIfExists(path))
            {
                return lines;
            }
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(await reader.ReadLineAsync());
                }
            }
            return lines;
        }
        public static async Task<string> ReadFromFile(string path)
        {
            string lines = "";
            string fullPath = Path.GetFullPath(path);
            string directoryPath = Path.GetDirectoryName(fullPath);

            if (!CheckIfExists(path))
            {
                return lines;
            }
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string readLine=await reader.ReadLineAsync();
                    lines+= readLine+Environment.NewLine;
                }
            }
            return lines;
        }
        public static bool CheckIfExists(string path)
        {
            bool exists = true;
            string fullPath = Path.GetFullPath(path);
            string directoryPath = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);

                exists = false;
            }
            if (!File.Exists(fullPath))
            {
                exists = false;
            }
            return exists;
        }
    }
}
