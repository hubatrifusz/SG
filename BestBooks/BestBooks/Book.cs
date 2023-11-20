using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBooks
{
    [SQLite.Table("books")]
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string RealYears { get; set; }
        public double Year { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public string imageName { get; set; }
        public string WikipeiaLink { get; set; }

    }
}
