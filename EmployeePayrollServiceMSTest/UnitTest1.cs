using EmployeePayrollServiceMultithreading;
using System.Diagnostics;

namespace EmployeePayrollServiceMSTest
{
    [TestClass]
    public class UnitTest1
    {
        EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();

        [TestMethod]
        public List<EmployeeDetails> AddingDataToList()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();

            employeeDetails.Add(new EmployeeDetails(EmployeeID: 71, EmployeeName: "Lokesh", PhoneNumber: "9999999999", Address: "Warje", Department: "IT", Gender: 'M', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "Pune", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 72, EmployeeName: "Mohak", PhoneNumber: "8888888888", Address: "Andheri", Department: "Marketing", Gender: 'M', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "Mumbai", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 73, EmployeeName: "John", PhoneNumber: "9999999988", Address: "Hennur", Department: "IT", Gender: 'M', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "Bengaluru", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 74, EmployeeName: "Connor", PhoneNumber: "9999988999", Address: "Kothrud", Department: "Marketing", Gender: 'M', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "Pune", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 75, EmployeeName: "Mangal", PhoneNumber: "9998899999", Address: "South", Department: "Testing", Gender: 'F', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "Dehli", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 76, EmployeeName: "Sia", PhoneNumber: "9988999999", Address: "North", Department: "Testing", Gender: 'F', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "Dehli", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 77, EmployeeName: "Alex", PhoneNumber: "9988899999", Address: "Andheri", Department: "Cloud", Gender: 'M', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "Mumbai", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 78, EmployeeName: "Ahan", PhoneNumber: "9999888999", Address: "Karve Nagar", Department: "Cloud", Gender: 'M', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "Pune", Country: "India"));

            return employeeDetails;
        }

        [TestMethod]
        public void Given8Employee_WhenAddedToList_ShouldMatchEmployeeEntries()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();

            employeeDetails = AddingDataToList();
            
            DateTime starttime = DateTime.Now;
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            employeePayrollOperations.AddEmployeeToPayroll(employeeDetails);
            DateTime endtime = DateTime.Now;
        }

        [TestMethod]
        public void Given8Employee_WhenAddedToDataBAse_ShouldMatchEmployeeEntries()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();

            employeeDetails = AddingDataToList();

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            DateTime starttime = DateTime.Now;
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            employeePayrollOperations.AddEmployeeToPayrollDataBase(employeeDetails);
            DateTime endtime = DateTime.Now;
            stopwatch1.Stop();
            Console.WriteLine("Total time for operation" + stopwatch1.ElapsedMilliseconds);
            Console.WriteLine("Total time: {0}", starttime - endtime);
        }

        [TestMethod]
        public void GivenListOfEmployee_AddedIntoEmployeePayRollList_UsingThreading()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime1 = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayrollWithThread(employeeDetails);
            DateTime endtime1 = DateTime.Now;
            Console.WriteLine("Total time with thread: {0}", starttime1 - endtime1);
        }

        [TestMethod]
        public void AddingDataintoDataBaseUsingThreading()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime1 = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayrollDataBaseWithThread(employeeDetails);
            DateTime endtime1 = DateTime.Now;
            Console.WriteLine("Total time for operation with thread: {0}", starttime1 - endtime1);
        }
    }
}