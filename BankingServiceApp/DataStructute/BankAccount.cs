using BankingServiceApp.DataStructute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingServiceApp
{
    internal abstract class BankAccount
    {
        protected decimal Balance { get; set; }
        protected int CustomerID { get; set; }
        protected int EmployeeID { get; set; }


        public abstract void Deposit(decimal amount);
        public virtual void Withdraw(decimal amount)
        {
            Console.WriteLine("Parent class Withdraw");
            this.Balance -= amount;
        }
    }

    internal class SavingAccount : BankAccount
    {
        public override void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
        public override void Withdraw(decimal amount)
        {
            Console.WriteLine("Saving Account Child class Withdraw");
            this.Balance -= amount;
        }
    }

    internal class CurrentAccount : BankAccount
    {
        public override void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
        public override void Withdraw(decimal amount)
        {
            Console.WriteLine("Current Account Child class Withdraw");
            this.Balance -= amount;
        }
    }
}