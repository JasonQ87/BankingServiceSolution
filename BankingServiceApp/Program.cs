using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Globalization;

namespace BankingServiceApp
{
    internal class Program
    {
        #region  Global Static Data Members
        static List<Customer> customers = new List<Customer>();
        static List<Employee> employees = new List<Employee>();
        static List<BankAccount> accounts = new List<BankAccount>();
        
        #endregion

        static string ToTitleCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.Trim().ToLower());
        }

        #region  Application Entry Point (Main Menu)
        static void Main(string[] args)
        {
            //Main Menu
            string welcomeMessage = "Welcome to the Mo Money Banking System";
            string decorativeLine = new string('*', welcomeMessage.Length);
            //Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                Console.WriteLine(decorativeLine);
                Console.WriteLine(welcomeMessage);
                Console.WriteLine(decorativeLine);
                Console.WriteLine("1. Add New Customer");
                Console.WriteLine("2. Update Customer");
                Console.WriteLine("3. Display All Customers");
                Console.WriteLine(decorativeLine);
                Console.WriteLine("4. Add New Employee");
                Console.WriteLine("5. Update Employee");
                Console.WriteLine("6. Display All Employees");
                Console.WriteLine(decorativeLine);
                Console.WriteLine("7. Add New Checking Account");
                Console.WriteLine("8. Update Checking Account");
                Console.WriteLine("9. Display Checking Account");
                Console.WriteLine(decorativeLine);
                Console.WriteLine("10. Add New Saving Account");
                Console.WriteLine("11. Update Saving Account");
                Console.WriteLine("12. Display Saving Account");
                Console.WriteLine(decorativeLine);
                Console.WriteLine("13. Display All Accounts");
                Console.WriteLine(decorativeLine);
                Console.WriteLine("14. Exit");
                Console.Write("Please select an option (1-14): ");
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddCustomer();
                            break;
                        case 2:
                            UpdateCustomer();
                            break;
                        case 3:
                            DisplayCustomer();
                            break;
                        case 4:
                            AddEmployee();
                            break;
                        case 5:
                            UpdateEmployee();
                            break;
                        case 6:
                            DisplayEmployee();
                            break;
                        case 7:
                            AddChecking();
                            break;
                        case 8:
                            UpdateChecking();
                            break;
                        case 9:
                            DisplayChecking();
                            break;
                        case 10:
                            AddSaving();
                            break;
                        case 11:
                            UpdateSaving();
                            break;
                        case 12:
                            DisplaySaving();
                            break;
                        case 13:
                            DisplayAllAccounts();
                            break;
                        case 14:
                            Console.WriteLine("Thank you for using the Customer Resource Manager app! Please press any key to exit. Goodbye!");
                            Console.ReadLine();
                            Environment.Exit(0);
                            //Need this to update to close when button is pressed.                            
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option (1-14).");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input format is incorrect...Please make sure to type only numbers.");
                }

                catch (OverflowException)
                {
                    Console.WriteLine("The number you have entered is too large or too small. Please enter a valid number.");
                }

                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index you have entered is out of range. Please enter a valid index.");
                }

                catch (Exception ex)
                {
                    //Catch any exception that occurs and display the Technical error message
                    Console.WriteLine($"Error:  " + ex.Message);
                }

                Console.WriteLine("Pess enter to continue ...");
                Console.ReadLine();
                Console.Clear();

            } while (true);
        }
        #endregion

        #region Customer CRUD
        static void AddCustomer()
        {

        }

        static void UpdateCustomer()
        {

        }

        static void DisplayCustomer()
        {

        }
        #endregion

        #region Employee CRUD
        static void AddEmployee()
        {

        }

        static void UpdateEmployee()
        {

        }

        static void DisplayEmployee()
        {

        }
        #endregion

        #region Checking Account CRUD
        static void AddChecking()
        {

        }

        static void UpdateChecking()
        {

        }

        static void DisplayChecking()
        {

        }
        #endregion

        #region Saving Account CRUD
        static void AddSaving()
        {

        }

        static void UpdateSaving()
        {

        }

        static void DisplaySaving()
        {

        }
        #endregion

        #region All Accounts
        static void DisplayAllAccounts()
        {

        }
        #endregion
        

        //SavingAccount sv = new SavingAccount();
        //    sv.Deposit(1000);

        //    CurrentAccount ca = new CurrentAccount();
        //    ca.Deposit(1000);

        //    accounts.Add(sv);
        //    accounts.Add(ca);

        //    foreach (BankAccount account in accounts)

        //    {

        //        account.Withdraw(500);

        //    }

    }
}
