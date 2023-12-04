using BestBooks;
using Moq;
using System.Xml.Linq;

namespace BestBooksTest
{
    public class Tests
    {
        IData? adat_forrás;
        Mock<IData>? adatforrás_mock;

        dataQuery lekérdezõ;
        List<Book> books;
        Book book;

        [SetUp]
        public void Setup()
        {
            book = new Book() { Title = "TitleName", Author = "Friderikusz", RealYears = "1564", Year = 1560, Country = "Bábolna", Language = "Hungarian", Pages = 1, imageName = "bazinga", WikipediaLink = "vanenet.hu"};
            books = new List<Book>();

            adatforrás_mock = new Mock<IData>();
            adat_forrás = adatforrás_mock.Object;

            lekérdezõ = new dataQuery();

        }

        [Test]
        public void Test1()
        {

            books.Add(book);
            adatforrás_mock.Setup(x => x.Create(It.IsAny<Book>())).Returns(book);
            adatforrás_mock.Setup(x => x.ReadDatabase()).Returns(books);

            var eredmény = lekérdezõ.Create(adat_forrás, book);
            var adat_lista = lekérdezõ.Olvasó(adat_forrás);

            Assert.AreEqual(adat_lista[adat_lista.Count - 1].Title, "TitleName");
        }
    }
}