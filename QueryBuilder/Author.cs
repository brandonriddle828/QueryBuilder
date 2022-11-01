using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    internal class Author: IClassModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }


        public override string ToString()
        {
            return $"Author: {Id} {FirstName} {Surname}";
        }

        public Author()
        {

        }

        public Author(int Id, string FirstName, string Surname)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.Surname = Surname;

        }
    }
}
