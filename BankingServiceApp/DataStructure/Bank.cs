using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankingServiceApp.BankAccount;

namespace BankingServiceApp
{
    internal class Bank
    {

        #region Properties (State)
        // Memory Based Database
        private List<Customer> Customers { get; set; }
        private List<Employee> Employees { get; set; }
        private List<BankAccount> BankAccounts { get; set; }
        #endregion

        #region  Constructor
        public Bank()
        {
            this.Customers = new List<Customer>();
            this.Employees = new List<Employee>();
            this.BankAccounts = new List<BankAccount>();
        }
        #endregion


        #region Customers Operations
        public void AddCustomer(Customer customer)
        {
            this.Customers.Add(customer);
        }
        public List<Customer> GetCustomers()
        {
            return this.Customers;
        }
        #endregion // End of Customer Operations

        #region Employees Operations
        public void AddEmployee(Employee employee)
        {
            this.Employees.Add(employee);
        }
        public List<Employee> GetEmployees()
        {
            return this.Employees;
        }
        #endregion // End of Employees Operations

        #region BankACcount Operations
        public void AddSavingAccount(SavingAccount savAccount)
        {
            this.BankAccounts.Add(savAccount);
        }
        public void AddCurrentAccount(CurrentAccount curAccount)
        {
            this.BankAccounts.Add(curAccount);
        }
        public List<BankAccount> GetBankAccounts()
        {
            return this.BankAccounts;
        }
        #endregion // End of BankAccount Operations



    }
}
