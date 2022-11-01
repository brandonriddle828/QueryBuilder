using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    internal class BooksOutOnLoan: IClassModel
    {
        public int Id { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
    }
}
