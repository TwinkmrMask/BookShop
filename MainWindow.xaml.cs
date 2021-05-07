using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace task_14._04
{
    public partial class MainWindow : IDefaultSettings
    {   
        List<Book> books = default;
        public MainWindow()
        {
            InitializeComponent();
            using (PlatformDataBase dataBase = new PlatformDataBase(
                ((IDefaultSettings)this).path + ((IDefaultSettings)this).data.links,
                ((IDefaultSettings)this).path + ((IDefaultSettings)this).data.data))
                this.books = dataBase.EachBooks(books = new List<Book>());
            insert(ref books);
            
        }

        void insert(ref List<Book> books) => ListOfBooks.ItemsSource = books.OrderBy(x => x.id);
        private void delete(ref List<Book> books, Book book)
        {
            books.Remove(book);
            ListOfBooks.ItemsSource = books;
            ListOfBooks.Items.Refresh();
        }
        private void buy_Click(object sender, RoutedEventArgs e)
        {
            Book book = ListOfBooks.SelectedItem as Book;
            delete(ref books, book);
        }

        //selecting a key for sorting
        private void id_Selected(object sender, RoutedEventArgs e) => ListOfBooks.ItemsSource = books.OrderBy(x => x.id);
        private void author_Selected(object sender, RoutedEventArgs e) => ListOfBooks.ItemsSource = books.OrderBy(x => x.author);
        private void title_Selected(object sender, RoutedEventArgs e) => ListOfBooks.ItemsSource = books.OrderBy(x => x.title);
        private void year_Selected(object sender, RoutedEventArgs e) => ListOfBooks.ItemsSource = books.OrderBy(x => x.year);
        private void setData(string links, string database)
        {
            using(Handler xml = new Handler())
                xml.SetData(links, database);
        }


        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            setData(
                ((IDefaultSettings)this).path + ((IDefaultSettings)this).data.links,
                ((IDefaultSettings)this).path + ((IDefaultSettings)this).data.data);

            using (PlatformDataBase dataBase = new PlatformDataBase((
                (IDefaultSettings)this).path + ((IDefaultSettings)this).data.links,
                ((IDefaultSettings)this).path + ((IDefaultSettings)this).data.data))
                books =  dataBase.EachBooks(books);
        }
    }
    public class Book
    {
        public int id { get; set; }
        public string author { get; set; }  
        public string title { get; set; }
        public int year { get; set; }
    }
}
