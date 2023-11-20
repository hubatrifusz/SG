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

namespace BestBooks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();

        }
        private void ReadDatabase()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string ConnectionString = System.IO.Path.Combine(currentDirectory, "things\\books.db");
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                List<Book> books = connection.Table<Book>().ToList();
                UwU.Content = books.Count;
            }
        }
    }
}
