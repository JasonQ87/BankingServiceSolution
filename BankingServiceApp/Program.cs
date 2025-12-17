
using ConsoleTables;
using System.Runtime.CompilerServices;

namespace BankingServiceApp
{
    internal class Program
    {
        #region Global Static Data Members
        static Bank bankService = new Bank();
        #endregion

        static void Main(string[] args)
        {
            #region Application EntryPoint (Main Menue)

            //Build BankingService Menu
            // Build Menu System
            string welcomeMessage = "Welcome to the Banking Service System";
            string decorativeLine = new string('*', welcomeMessage.Length);
            //Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                Console.WriteLine(decorativeLine);
                Console.WriteLine(welcomeMessage);
                Console.WriteLine(decorativeLine);
                Console.WriteLine("1. Add New Customer");
                Console.WriteLine("2. Display All Customers");
                Console.WriteLine(decorativeLine);
                Console.WriteLine("3. Add New Employee");
                Console.WriteLine("4. Display All Employees");
                Console.WriteLine(decorativeLine);
                Console.WriteLine("5. Add Saving Account");
                Console.WriteLine("6. Add Current Account");
                Console.WriteLine("7. Display All Accounts");
                Console.WriteLine("8. Display All Transactions");
                Console.WriteLine(decorativeLine);
                Console.WriteLine("9. Add New Appointment");
                Console.WriteLine("10. ServeNextAppointment");
                Console.WriteLine("11. Display All Appointments");
                Console.WriteLine(decorativeLine);
                Console.WriteLine("12. Add New Loan Request");
                Console.WriteLine("13. Display All Loan Requests");
                Console.WriteLine(decorativeLine);
                Console.WriteLine("14. Exit");
                Console.Write("Please select an option (1-14): ");
                try
                {
                    /////for demonstration purpose only
                    //int choice; //Decare choice variable
                    //bool isValidChoice = int.TryParse(Console.ReadLine(),out choice); //Try to parse user input
                    ///////////////////////
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddNewCustomer();
                            break;
                        case 2:
                            DisplayCutomers();
                            break;
                        case 3:
                            AddNewEmployee();
                            break;
                        case 4:
                            DisplayEmployees();
                            break;
                        case 5:
                            AddSavingAccount();
                            break;
                        case 6:
                            AddCurrentAccount();
                            break;
                        case 7:
                            DisplayAccounts();
                            break;
                        case 8:
                            DispalyAllTransactions();
                            break;
                        case 9:
                            AddNewAppointment();
                            break;
                        case 10:
                            ServeNextAppointment();
                            break;
                        case 11:
                            GetAllAppointments();
                            break;
                        case 12:
                            AddNewLoanRequest();
                            break;
                        case 13:
                            DisplayLoanRequests();
                            break;
                        case 14:

                            Console.WriteLine("Goodbye!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option (1-8).");
                            break;


                    }
                }
                catch (FormatException)  //Specific Exception Handler
                {
                    //Catch Format Exception and display user friendly message
                    Console.WriteLine("Input format is incorrect..Please make sure to type onlty digits");
                }
                catch (OverflowException)  //Specific Exception Handler
                {
                    //Catch Overflow Exception and display user friendly message
                    Console.WriteLine("Input number is too large or too small. ");
                }
                catch (IndexOutOfRangeException)
                {

                }
                catch (Exception ex)  //General Exception Handler
                {
                    //Cahtch any exception that occurs and display the Technical error message
                    // Laster we'll learn how to log this error to a file
                    Console.WriteLine("Error: " + ex.Message);
                }


                Console.WriteLine("Pess enter to continue ...");
                Console.ReadLine();

                Console.Clear();

            } while (true);



            #endregion

        }





        #region Customers Operations
        private static void AddNewCustomer()
        {
            int countOfCustomers = bankService.GetCustomers().Count;

            Console.Write("Enter customer Name: ");
            string custName = Console.ReadLine();

            Console.Write("Enter customer age: ");
            int age = int.Parse(Console.ReadLine());

            Customer custObj = new(countOfCustomers + 1)
            {
                Name = custName,
                Age = age,
                Iscore = IScore.Excellent,
                Tier = Tier.Blue
            };
            bankService.AddCustomer(custObj);
            Console.WriteLine("Done Adding Customer!");

        }
        private static void DisplayCutomers()
        {
            Console.WriteLine("Customer List:");
            #region Third Party Table Version
            var table = new ConsoleTable("Id", "Name", "Age", "IScore", "Tier");

            foreach (Customer cust in bankService.GetCustomers())
            {
                table.AddRow(cust.Id, cust.Name, cust.Age, cust.Iscore, cust.Tier);
            }

            table.Write();
            #endregion
        }
        #endregion

        #region Employees Operations
        private static void AddNewEmployee()
        {
            int countOfEmployees = bankService.GetEmployees().Count;

            Console.Write("Enter Employee Name: ");
            string empName = Console.ReadLine();

            Console.Write("Enter Employee age: ");
            int age = int.Parse(Console.ReadLine());

            Employee empObj = new(countOfEmployees + 1)
            {
                Name = empName,
                Age = age,
                Salary = 1000,
                Title = "CRM Agent"
            };
            bankService.AddEmployee(empObj);
            Console.WriteLine("Done Adding Employee!");
        }
        private static void DisplayEmployees()
        {
            Console.WriteLine("Employee List:");
            #region Third Party Table Version
            var table = new ConsoleTable("Id", "Name", "Age", "Salary", "Title");

            foreach (Employee emp in bankService.GetEmployees())
            {
                table.AddRow(emp.Id, emp.Name, emp.Age, emp.Salary, emp.Title);
            }

            table.Write();
            #endregion
        }
        #endregion


        #region BankAccount Operations
        private static void AddSavingAccount()
        {
            Console.Write("Enter Employee ID: ");
            int empID = int.Parse(Console.ReadLine());

            Console.Write("Enter Customer ID: ");
            int custID = int.Parse(Console.ReadLine());

            Console.Write("Enter Balance Value: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Intrest Rate Value: ");
            decimal rate = decimal.Parse(Console.ReadLine());

            SavingAccount saObj = new SavingAccount(balance, custID, empID, rate);

            bankService.AddSavingAccount(saObj);

            Console.WriteLine("Done Adding New Account!");
        }

        private static void AddCurrentAccount()
        {
            Console.Write("Enter Employee ID: ");
            int empID = int.Parse(Console.ReadLine());

            Console.Write("Enter Customer ID: ");
            int custID = int.Parse(Console.ReadLine());

            Console.Write("Enter Balance Value: ");
            decimal balance = decimal.Parse(Console.ReadLine());


            CurrentAccount caObj = new CurrentAccount(balance, custID, empID);

            bankService.AddCurrentAccount(caObj);

            Console.WriteLine("Done Adding New Account!");
        }
        private static void DisplayAccounts()
        {
            //Use Polymorphism to display all bank accounts
            Console.WriteLine("Bank Account List:");
            #region Third Party Table Version
            var table = new ConsoleTable("Account Type", "Customer Id", "Employee ID", "Balance", "Profit/Month", "Can Request Loan");

            foreach (BankAccount bankaccount in bankService.GetBankAccounts())
            {
                if (bankaccount is SavingAccount)
                {
                    table.AddRow("Saving Account",
                                   bankaccount.CustomerID,
                                   bankaccount.EmployeeID,
                                   bankaccount.Balance,
                                   ((SavingAccount)bankaccount).GetMonthlyProfit(),  //Get Profit/Month
                                   "N/A"
                                 );
                }
                else if (bankaccount is CurrentAccount)
                {
                    table.AddRow("Current Account",
                                   bankaccount.CustomerID,
                                   bankaccount.EmployeeID,
                                   bankaccount.Balance,
                                   "N/A",
                                   ((CurrentAccount)bankaccount).CanRequestLoan  //Get Can Request Loan
                                );
                }



            }

            table.Write();
            #endregion

        }


        private static void DispalyAllTransactions()
        {
            //Display Transactions for First BankAccount
            BankAccount ba = bankService.GetBankAccounts()[0];
            ba.Deposit(200);
            ba.Withdraw(300);
            ba.Deposit(100);

            // foreach enumerate a stack without modifying it. it does not pop elements.
            foreach (BankTransaction tran in ba.HistoryOfTransactions)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine($"Transaction Type: {tran.TransactionType}");
                Console.WriteLine($"Transaction Date: {tran.TransactionDate}");
                Console.WriteLine($"Transaction Amount: {tran.Amount}");
                Console.WriteLine($"Balance After Transaction: {tran.BalanceAfterTransaction}");
                Console.WriteLine("=====================================");
            }

        }

        #endregion

        #region Appointment Operations
        private static void AddNewAppointment()
        {


            //TODO: Ask user for Customer Name/ID
            //TODO: Ask user for Employee Name/ID

            Console.Write("Enter Appointment Purpose: ");
            string purpose = Console.ReadLine();

            Console.Write("Please Enter Date (yyyy-mm-dd): ");
            string appDate = Console.ReadLine();

            Console.Write("Please Enter Time  (HH:mm): ");
            string appTime = Console.ReadLine();


            Appointment newAppointment =
                new(bankService.GetAllAppointments().Count + 1)
                {
                    Customer = new Customer(1) { Name = "Emad" },
                    Employee = new Employee(1) { Name = "Bill" },
                    AppointmentDate = DateTime.Parse($"{appDate} {appTime}"),
                    Purpose = purpose,
                    Status = AppointmentStatus.Opened
                };

            bankService.AddAppointment(newAppointment);

            Console.WriteLine("Done Adding New Appointment");

        }
        private static void GetAllAppointments()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Appointment List");
            Console.WriteLine("===========================================");
            foreach (Appointment app in bankService.GetAllAppointments())
            {

                Console.WriteLine($"Appointment ID: {app.AppointmentID}");
                Console.WriteLine($"Appointment Date: {app.AppointmentDate}");
                Console.WriteLine($"Customer Name: {app.Customer.Name}");
                Console.WriteLine($"Employee Name: {app.Employee.Name}");
                Console.WriteLine($"Purpose: {app.Purpose}");
                Console.WriteLine($"Appointment Status: {app.Status}");
                Console.WriteLine("=====================================");
            }

        }

        private static void ServeNextAppointment()
        {
            throw new NotImplementedException();
        }


        #endregion



        #region Loan Request Operations


        private static void AddNewLoanRequest()
        {
            //ask user for customer ID, search for customer , get customer object
            //ask user for customer ID, search for CurrentAccount , get CurrentAccount object

            LoanRequest request1 = new LoanRequest(1)
            {
                CurrentAccount = new CurrentAccount(1000, 1, 1),
                Customer = new Customer(1),
                RequestDate = DateTime.Now,
                RequestedAmount = 500,
            };
            Console.WriteLine("Done Adding First Request");

            LoanRequest request2 = new LoanRequest(2)
            {
                CurrentAccount = new CurrentAccount(2000, 1, 1),
                Customer = new Customer(1),
                RequestDate = DateTime.Now.AddHours(1),
                RequestedAmount = 300,

            };
            Console.WriteLine("Done Adding Second Request");

            bankService.AddLoanRequest(request1);
            bankService.AddLoanRequest(request2);
        }
        private static void DisplayLoanRequests()
        {

            Console.WriteLine("===========================================");
            Console.WriteLine("Loand Request List");
            Console.WriteLine("===========================================");
            foreach (LoanRequest request in bankService.GetloanRequests())

            {

                Console.WriteLine($"Request ID: {request.RequestID}");
                Console.WriteLine($"Current Account Balance: {request.CurrentAccount.Balance}");
                Console.WriteLine($"Customer Name: {request.Customer.Name}");
                Console.WriteLine($"Requested Date: {request.RequestDate}");
                Console.WriteLine($"Requested Amount: {request.RequestedAmount}");
                Console.WriteLine("=====================================");
            }

        }
        #endregion  





    }
}
