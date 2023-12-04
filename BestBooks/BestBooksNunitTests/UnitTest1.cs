using BestBooks;
using System.Windows.Media.Imaging;
using static System.Reflection.Metadata.BlobBuilder;

namespace BestBooksNunitTests
{
    [Apartment(ApartmentState.STA)]
    public class Tests
    {
        List<Book> books = new List<Book>();
        [SetUp]
        public void Setup()
        {

            Book book1 = new Book();
            book1.Language = "English";
            book1.Title = "EnglishBook";
            books.Add(book1);

            Book book2 = new Book();
            book2.Language = "Hungary";
            book2.Title = "HungaryBook";
            books.Add(book2);

            Book book3 = new Book();
            book3.Language = "English";
            book3.Title = "AnotherEnglishBook";
            books.Add(book3);

            Book book4 = new Book();
            book4.Language = "Hungary";
            book4.Title = "AnotherHungaryBook";
            books.Add(book4);

            Book book5 = new Book();
            book5.Language = "English";
            book5.Title = "YetAnotherEnglishBook";
            books.Add(book5);
        }

        [Test]
        public void BookFilterWithLanguageTest()
        {
            string SearchLanguage = "English";
            MainWindow window = new MainWindow();
            List<Book> filteredBooks = window.BookFilterWithLanguage(SearchLanguage);
            foreach (Book book in filteredBooks)
            {
                Assert.That(book.Language, Is.EqualTo(SearchLanguage));
            }
        }

        [Test]
        public void BookImageCreateTest()
        {
            MainWindow window = new MainWindow();
            string imageName = "test.png";
            BitmapImage image = window.createImage(imageName);

            Assert.IsNotNull(image, "A létrehozott kép nem lehet null.");
            Assert.AreEqual("things\\images\\test.png", image.UriSource.OriginalString, "A kép forrása nem megfelelõ.");
        }
    }
}