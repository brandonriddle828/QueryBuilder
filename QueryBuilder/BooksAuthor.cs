using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    internal class BooksAuthor: IClassModel
    {
        public int BooksID { get; set; }
        public int AuthorId { get; set; }
        public int Id { get; set; }
    }
}
