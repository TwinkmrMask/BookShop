using System;
using System.Xml;

namespace task_14._04
{
    class Handler : IDisposable
    {
        public void Dispose() { }

        public void SetData(string links, string database)
        {
            XmlDocument document = new XmlDocument();
            document.Load(getPath());
            XmlElement root = document.DocumentElement;
            foreach (XmlElement book in root)
            {
                if ((root != null) && (root.HasChildNodes))
                {
                    using(PlatformDataBase dataBase = new PlatformDataBase(links, database))    
                        dataBase.AddBooks(
                            book.Attributes["id"].Value, 
                            book.Attributes["author"].Value, 
                            book.Attributes["title"].Value, 
                            book.Attributes["year"].Value
                            );
                }
            }
        }
        private string getPath()
        {
            Microsoft.Win32.OpenFileDialog openDialog = new Microsoft.Win32.OpenFileDialog();
            openDialog.Filter = "Файл с книгами|*.xml";
            openDialog.ShowDialog();
            return openDialog.FileName;
        }
    }
}