using Microsoft.VisualBasic;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace BestBooks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> books = new List<Book>();
        List<Book> search = new List<Book>();
        public MainWindow()
        {
            InitializeComponent();
            books = ReadDatabase();
            CreateComboBox();
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
            foreach (string language in uniqueLanguages)
            {
                LanguageComboBox.Items.Add(language);
            }
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = LanguageComboBox.SelectedItem.ToString();
            var selectedBooks = books.Where(book => book.Language == selectedItem).ToList();
            search = selectedBooks;
            bookList.ItemsSource = search;
        }

        private void bookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bookList.SelectedItem != null)
            {
                Book selectedBook = bookList.SelectedItem as Book;
                ShowBookDetails(selectedBook);
            }
        }

        private void ShowBookDetails(Book book)
        {
            szerzo.Text = book.Author;
            cim.Text = book.Title;
            nyelv.Text = book.Language;
            orszag.Text = book.Country;
            megjelenes.Text = book.Year.ToString();
            string source = "things\\images\\" + book.imageName;

            // Kép forrásának beállítása
            image.Source = new BitmapImage(new Uri(source, UriKind.RelativeOrAbsolute));

            if (book.WikipediaLink != null && book.WikipediaLink != "")
            {
                string wikiLink = book.WikipediaLink; 
                Uri uri = new Uri(wikiLink);
                LinkRun.Text = "Wikipédia link";
                link.NavigateUri = uri;
            }
            else
            {
                LinkRun.Text = "";
            }
        }

        private void HL_wiki_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
        }

        private void bookList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
