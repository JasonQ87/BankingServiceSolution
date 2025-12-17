using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingServiceApp
{
    internal class Employee : Person
    {

        // Data Members (State)

        public decimal Salary { get; set; }
        public string Title { get; set; }


        //Constructor
        public Employee(int employeeId)
        {
            this.Id = employeeId;
        }

        // Methods (Behavior)

    }
}
