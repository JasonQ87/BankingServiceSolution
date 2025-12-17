using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankingServiceApp
{
    public enum IScore { Bad, Good, Excellent }
    public enum Tier { Blue, Silver, Gold }
    internal class Customer : Person
    {


        // Data Members (State)
        public IScore Iscore { get; set; }
        public Tier Tier { get; set; }



        //Constructor
        public Customer(int customerId)
        {
            this.Id = customerId;
        }


        // Methods (Behavior)


    }
}
