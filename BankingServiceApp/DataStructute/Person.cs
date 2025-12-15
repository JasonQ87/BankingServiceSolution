using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingServiceApp.DataStructute
{
    internal class Person
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public bool IsMarrid { get; set; }
        public DateTime BirthDate { get; set; }


    }
}
