using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml;

namespace task_14._04
{
    class DataBase : IDisposable
    {
        public void Dispose() { }

        public List<Books> GetData()
        {
            List<Books> books = new List<Books>();

            XmlDocument document = new XmlDocument();
            document.Load(getPath());
            XmlElement root = document.DocumentElement;
            MessageBox.Show(root.Name);
            foreach (XmlElement book in root)
            {
                if ((root != null) && (root.HasChildNodes))
                {
                    books.Add(new Books
                    {
                        id = int.Parse(book.Attributes["id"].Value),
                        author = book.Attributes["author"].Value,
                        title = book.Attributes["title"].Value,
                        year = int.Parse(book.Attributes["year"].Value)
                    });
                }
            }

            return books;
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