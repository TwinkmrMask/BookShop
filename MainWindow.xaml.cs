using System.Collections.Generic;
using System.Windows;
using System.Linq;
namespace task_14._04
{
    public partial class MainWindow
    {

        List<Books> books;
        public MainWindow()
        {
            InitializeComponent();

            using(DataBase data =  new DataBase())
                books = data.GetData();
            insert(ref books);
        }

        void insert(ref List<Books> books) => ListOfBooks.ItemsSource = books.OrderBy(x => x.id);
        private void delete(ref List<Books> books, Books book)
        {
            books.Remove(book);
            ListOfBooks.ItemsSource = books;
            ListOfBooks.Items.Refresh();
        }
        private void buy_Click(object sender, RoutedEventArgs e)
        {
            Books book = ListOfBooks.SelectedItem as Books;
            delete(ref books, book);
        }

        //selecting a key for sorting
        private void id_Selected(object sender, RoutedEventArgs e) => ListOfBooks.ItemsSource = books.OrderBy(x => x.id);
        private void author_Selected(object sender, RoutedEventArgs e) => ListOfBooks.ItemsSource = books.OrderBy(x => x.author);
        private void title_Selected(object sender, RoutedEventArgs e) => ListOfBooks.ItemsSource = books.OrderBy(x => x.title);
        private void year_Selected(object sender, RoutedEventArgs e) => ListOfBooks.ItemsSource = books.OrderBy(x => x.year);
    }
    class Books
    {
        public int id { get; set; }
        public string author { get; set; }  
        public string title { get; set; }
        public int year { get; set; }
    }
}
