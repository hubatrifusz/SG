using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks
{
    public class dataQuery
    {
        public Book Create(IData adatForrás, Book névjegy)
        {
            return adatForrás.Create(névjegy);
        }
        public List<Book> Olvasó(IData adatForrás)
        {
            return adatForrás.ReadDatabase();
        }
    }
}
