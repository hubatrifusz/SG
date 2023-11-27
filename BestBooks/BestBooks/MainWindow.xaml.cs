using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Reflection.Metadata.BlobBuilder;

namespace BestBooks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> books = new List<Book>();
        public MainWindow()
        {
            InitializeComponent();
            books = ReadDatabase();
            CreateComboBox();
            bookList.ItemsSource = books;
        }
        private List<Book> ReadDatabase()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string ConnectionString = System.IO.Path.Combine(currentDirectory, "things\\books.db");
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                List<Book> books = connection.Table<Book>().ToList();
                return books;
            }
        }
        private void CreateComboBox()
        {
            List<string> uniqueLanguages = books.Select(book => book.Language).Distinct().ToList();
            UwU.Content = uniqueLanguages.Count();
            foreach (string language in uniqueLanguages)
            {
                LanguageComboBox.Items.Add(language);
                UwU.Content = language;
            }
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = LanguageComboBox.SelectedItem.ToString();
            UwU.Content = selectedItem;
        }
    }
}
