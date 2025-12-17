using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BankingServiceApp
{
    internal abstract class BankAccount
    {
        //Properties
        public decimal Balance { get; protected set; }
        public int CustomerID { get; protected set; }
        public int EmployeeID { get; protected set; }

        public Stack<BankTransaction> HistoryOfTransactions { get; protected set; }
        //Constructor
        protected BankAccount(decimal balance, int customerId, int employeeId)
        {
            this.Balance = balance;
            this.CustomerID = customerId;
            this.EmployeeID = employeeId;
            this.HistoryOfTransactions = new Stack<BankTransaction>();

        }


        //Methods
        public abstract void Deposit(decimal amount);
        public virtual void Withdraw(decimal amount)
        {
            this.Balance -= amount;
            this.HistoryOfTransactions.Push(
                    new BankTransaction()
                    {
                        Amount = amount,
                        BalanceAfterTransaction = this.Balance,
                        TransactionDate = DateTime.Now,
                        TransactionType = TransactionType.Withdraw
                    });
        }


        public virtual BankTransaction GetLastTransaction()
        {
            return this.HistoryOfTransactions.Peek();
        }

    }

    internal class SavingAccount : BankAccount
    {
        // properties
        public decimal IntrestRate { get; set; }

        //constructor
        public SavingAccount(decimal balance, int customerId, int employeeId, decimal intrestRate)
            : base(balance, customerId, employeeId)
        {
            this.IntrestRate = intrestRate;

        }

        public override void Deposit(decimal amount)
        {
            this.Balance += amount;
            this.HistoryOfTransactions.Push(
                                            new BankTransaction()
                                            {
                                                Amount = amount,
                                                BalanceAfterTransaction = this.Balance,
                                                TransactionDate = DateTime.Now,
                                                TransactionType = TransactionType.Deposit
                                            });
        }
        public override void Withdraw(decimal amount)
        {
            this.Balance -= amount;
            this.HistoryOfTransactions.Push(
                                            new BankTransaction()
                                            {
                                                Amount = amount,
                                                BalanceAfterTransaction = this.Balance,
                                                TransactionDate = DateTime.Now,
                                                TransactionType = TransactionType.Withdraw
                                            });
        }
        public decimal GetMonthlyProfit()
        {
            return (this.Balance * this.IntrestRate) / 100;
        }
    }

    internal class CurrentAccount : BankAccount
    {
        // properties
        public bool CanRequestLoan { get; set; }

        //constructor
        public CurrentAccount(decimal balance, int customerId, int employeeId)
            : base(balance, customerId, employeeId)
        {
            this.CanRequestLoan = this.Balance >= 10000.0m ? true : false;

        }

        public override void Deposit(decimal amount)
        {
            this.Balance += amount;
            this.CanRequestLoan = this.Balance >= 10000.0m ? true : false;
            this.HistoryOfTransactions.Push(
                                        new BankTransaction()
                                        {
                                            Amount = amount,
                                            BalanceAfterTransaction = this.Balance,
                                            TransactionDate = DateTime.Now,
                                            TransactionType = TransactionType.Deposit
                                        });
        }
        public override void Withdraw(decimal amount)
        {
            Console.WriteLine("Current Account Child class Withdraw");
            this.Balance -= amount;
            this.CanRequestLoan = this.Balance >= 10000.0m ? true : false;
            this.HistoryOfTransactions.Push(
                                        new BankTransaction()
                                        {
                                            Amount = amount,
                                            BalanceAfterTransaction = this.Balance,
                                            TransactionDate = DateTime.Now,
                                            TransactionType = TransactionType.Withdraw
                                        });
        }
    }

    internal enum TransactionType { Deposit, Withdraw }

    internal class BankTransaction
    {
        //Properties
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfterTransaction { get; set; }

    }

}
