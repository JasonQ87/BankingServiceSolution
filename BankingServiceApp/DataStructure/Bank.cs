using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankingServiceApp
{
    internal class Bank
    {

        #region Properties (State)
        // Memory Based Database
        private List<Customer> Customers { get; set; }
        private List<Employee> Employees { get; set; }
        private List<BankAccount> BankAccounts { get; set; }
        private LinkedList<Appointment> Appointments { get; set; }

        private PriorityQueue<LoanRequest, decimal> LoanRequests { get; set; }
        #endregion

        #region  Constructor
        public Bank()
        {
            this.Customers = new List<Customer>();
            this.Employees = new List<Employee>();
            this.BankAccounts = new List<BankAccount>();
            this.Appointments = new LinkedList<Appointment>();

            // object in qeueu sorted desc.
            Comparer<decimal> BalanceComparer = Comparer<decimal>.Create((x, y) => y.CompareTo(x));
            this.LoanRequests = new PriorityQueue<LoanRequest, decimal>(BalanceComparer);


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
        #endregion // End of BankACcount Operations

        #region Appointment Operations
        public void AddAppointment(Appointment appointment)
        {
            if (this.Appointments.Count == 0)
            {
                this.Appointments.AddFirst(appointment);
            }
            else
            {
                this.Appointments.AddLast(appointment);
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            //generating List<Appointent> from the LinkedList<Appointment>
            return this.Appointments.ToList();
        }
        #endregion

        #region LoadRequest Operations
        public void AddLoanRequest(LoanRequest request)
        {
            this.LoanRequests.Enqueue(request, request.CurrentAccount.Balance);

        }

        public List<LoanRequest> GetloanRequests()
        {
            List<LoanRequest> requests = new List<LoanRequest>();

            while (true)
            {
                if (this.LoanRequests.Count > 0)
                    requests.Add(this.LoanRequests.Dequeue());
                else
                    break;
            }

            return requests;
        }
        #endregion

    }
}
