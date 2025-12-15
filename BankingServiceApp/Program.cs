namespace BankingServiceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Main Menu
            //Add Customer
            //Display Customers
            //Add Employee
            //Display Employees
            //Add Saving Account
            //Add Current Account
            //Display All Accounts
            List<BankAccount> accounts = new List<BankAccount>();

            SavingAccount sv = new SavingAccount();

            sv.Deposit(1000);

            CurrentAccount ca = new CurrentAccount();

            ca.Deposit(1000);

            accounts.Add(sv);

            accounts.Add(ca);

            foreach (BankAccount account in accounts)

            {

                account.Withdraw(500);

            }

        }
    }
}
