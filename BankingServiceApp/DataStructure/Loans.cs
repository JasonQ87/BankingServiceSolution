using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingServiceApp
{
    internal class LoanRequest
    {
        //Properties
        public int RequestID { get; private set; }
        public Customer Customer { get; set; }
        public CurrentAccount CurrentAccount { get; set; }
        public decimal RequestedAmount { get; set; }
        public DateTime RequestDate { get; set; }

        //Constructor
        public LoanRequest(int requestId)
        {
            this.RequestID = requestId;
        }
    }
}
