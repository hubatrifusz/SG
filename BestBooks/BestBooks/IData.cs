using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks
{
    public interface IData
    {
        public Book Create(Book névjegy);
        public List<Book> ReadDatabase();
        public Book Update(Book névjegy);
        public Book Delete(Book névjegy);
    }
}
