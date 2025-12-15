using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingServiceApp
{
    public enum IScore { Bad, Good, Excellent }
    public enum Tier {Blue, Silver, Gold}
    static void Main(string[] args);
    internal class Customer
    {
        //Data Members (State)
        private string name;
        public string phone;
        public string address;
        public int age;
        public bool isMarried;
        public DateTime birthDate;

        public IScore iscore;
        public Tier tier;

        //Methods (Behavior)
        public string GetName()
        {
            return this.name;
        }
        public string name
        {

        }
    }
}
