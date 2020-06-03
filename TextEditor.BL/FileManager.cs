using System.Text;
using System.IO;

namespace TextEditor.BL
{
    public interface iFileManager
    {
        bool FileExist(string filepach);
        string GetContent(string filepatch, Encoding encoding);
        string GetContent(string filepatch);
        void SaveContent(string filepatch, string content, Encoding encoding);
        void SaveContent(string filepatch, string Content);
        int GetSymbolCount(string content);
    }
    public class FileManager:iFileManager
    {

        public bool FileExist(string filepach)
        {
            bool isExist = File.Exists(filepach);
            return isExist;
        }
        public string GetContent (string filepatch, Encoding encoding)
        {
            string content = File.ReadAllText(filepatch, encoding);
            return content;
        }

        private readonly Encoding defauldEncoding = Encoding.GetEncoding(1251);
        public string GetContent(string filepatch)
        {
            string content = File.ReadAllText(filepatch, defauldEncoding);
            return content;
        }


        public void SaveContent (string filepatch, string content,  Encoding encoding)
        {
            File.WriteAllText(filepatch, content, encoding);
           // File.Create("C:\\222.txt");
           // File.WriteAllText("C:\\222.txt", "1111", encoding);
        }
         
        public void SaveContent( string filepatch, string Content)
        {
            SaveContent(filepatch, Content, defauldEncoding);

        }

        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;
        }

        
    }
}
