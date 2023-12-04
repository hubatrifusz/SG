using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks
{
    internal class SQLiteData
    {
        List<Book> contacts;
        string currentDirectory = Directory.GetCurrentDirectory();
        
        public Book Create(Book book)
        {
            string databasePath = System.IO.Path.Combine(currentDirectory, "things\\books.db");
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.CreateTable<Book>();
                connection.Insert(book);
            }
            return book;
        }

        public List<Book> ReadDatabase()
        {
            string databasePath = System.IO.Path.Combine(currentDirectory, "things\\books.db");
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                List<Book> books = connection.Table<Book>().ToList();
                return books;
            }
        }

        public Book Update(Book book)
        {
            string databasePath = System.IO.Path.Combine(currentDirectory, "things\\books.db");
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.CreateTable<Book>();
                connection.Update(book);
            }
            return book;
        }
        public Book Delete(Book book)
        {
            string databasePath = System.IO.Path.Combine(currentDirectory, "things\\books.db");
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.CreateTable<Book>();
                connection.Delete(book);
            }
            return book;
        }
    }
}
