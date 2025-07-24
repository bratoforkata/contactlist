using ConsoleApp1.Interfaces;
using ConsoleApp1.Lessons;
using System.Runtime;

namespace ConsoleApp1.Services
{
    public class FileService : IFileService
    {
        private static readonly string
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SavedFiles");

        public void SaveFile(string fileName, string data, bool append)
        {
            try
            {
                var fullPath = Path.Combine(filePath, fileName);
                using var writer = new StreamWriter(fullPath, append);
                writer.WriteLine(data);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }

        public string[] LoadFile(string fileName)
        {
            try
            {
                var fullPath = Path.Combine(filePath, fileName);
                using var reader = new StreamReader(fullPath);

                List<string> lines = new List<string>();

                while (reader.EndOfStream == false)
                {
                    var line = reader.ReadLine();

                    if (line != null)
                    {
                        lines.Add(line);
                    }
                }
                reader.Close();

                return lines.ToArray();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            return [];
        }
    }
}