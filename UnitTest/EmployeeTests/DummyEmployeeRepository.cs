using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRistretto.Models;
using TesteRistretto.Repositories;

namespace UnitTest.EmployeeTests
{
    internal class DummyEmployeeRepository : IEmployeeRepository
    {
        List<Employee> _employeeList = new List<Employee>() { new Employee()};

        public int AddEmployee(Employee employee)
        {
            return 1;
        }

        public bool DeleteEmployee(int emplyeeId)
        {
            if(_employeeList.Count == 0)
                return false;

            _employeeList.RemoveAt(0);

            return true;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public List<Employee> GetAllEmployeesByCompany(int companyId)
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(int emplyeeId)
        {
            return new Employee();
        }

        public int UpdateEmployee(Employee employee)
        {
            return 1;
        }
    }
}
