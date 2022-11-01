using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    internal class Users:IClassModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserAddress { get; set; }
        public int OtherUserDetails { get; set; }
        public double AmountOfFine { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"Users: {Id} {UserName} {UserAddress} {OtherUserDetails} {AmountOfFine} {Email} {PhoneNumber}";
        }
    }
}
