using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRistretto.Models;

namespace TesteRistretto.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        List<Employee> GetAllEmployeesByCompany(int companyId);
        Employee GetEmployeeById(int emplyeeId);
        int AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        bool DeleteEmployee(int emplyeeId);

    }
}
