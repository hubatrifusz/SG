using BestBooks;
using Moq;
using System.Xml.Linq;

namespace BestBooksTest
{
    public class Tests
    {
        IData? adat_forr�s;
        Mock<IData>? adatforr�s_mock;

        dataQuery lek�rdez�;
        List<Book> books;
        Book book;

        [SetUp]
        public void Setup()
        {
            book = new Book() { Title = "TitleName", Author = "Friderikusz", RealYears = "1564", Year = 1560, Country = "B�bolna", Language = "Hungarian", Pages = 1, imageName = "bazinga", WikipediaLink = "vanenet.hu"};
            books = new List<Book>();

            adatforr�s_mock = new Mock<IData>();
            adat_forr�s = adatforr�s_mock.Object;

            lek�rdez� = new dataQuery();

        }

        [Test]
        public void Test1()
        {

            books.Add(book);
            adatforr�s_mock.Setup(x => x.Create(It.IsAny<Book>())).Returns(book);
            adatforr�s_mock.Setup(x => x.ReadDatabase()).Returns(books);

            var eredm�ny = lek�rdez�.Create(adat_forr�s, book);
            var adat_lista = lek�rdez�.Olvas�(adat_forr�s);

            Assert.AreEqual(adat_lista[adat_lista.Count - 1].Title, "TitleName");
        }
    }
}