using TesteRistretto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TesteRistretto.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public List<Employee> GetAllEmployees()
        {
            string query = "SELECT EmployeeId, EmployeeName, Email, CompanyPosition, "
                         + " Login, Password, CompanyId, Situation "
                         + " FROM Employee ";

            return GetAll(query);
        }

        public List<Employee> GetAllEmployeesByCompany(int companyId)
        {
            string query = "SELECT EmployeeId, EmployeeName, Email, CompanyPosition, "
                         + " Login, Password, CompanyId, Situation "
                         + " FROM Employee "
                         + " WHERE CompanyId = @companyId";

            SQLiteParameter[] sqlParameters = new SQLiteParameter[]
            {
                new SQLiteParameter("companyId", companyId)
            };

            return GetAll(query, sqlParameters);
        }

        public Employee GetEmployeeById(int employeeId)
        {
            string query = "SELECT EmployeeId, EmployeeName, Email, CompanyPosition, "
                         + " Login, Password, CompanyId, Situation "
                         + " FROM Employee "
                         + " Where EmployeeId = @employeeId";

            SQLiteParameter sqlParameter = new SQLiteParameter("employeeId", employeeId);

            return GetById(query, employeeId, sqlParameter);
        }

        public int AddEmployee(Employee employee)
        {
            string query = "INSERT INTO Employee "
                         + " ( EmployeeName, Email, CompanyPosition, " 
                         + " Login, Password, CompanyId, Situation) "
                         + " Values "
                         + " ( @employeeName, @email, @companyPosition, " 
                         + " @login, @password, @companyId, @situation) ";

            SQLiteParameter[] sqlParameters = new SQLiteParameter[]
            {
                new SQLiteParameter("employeeName", employee.EmployeeName),
                new SQLiteParameter("email", employee.Email),
                new SQLiteParameter("companyPosition", employee.CompanyPosition),
                new SQLiteParameter("login", employee.Login),
                new SQLiteParameter("password", employee.Password),
                new SQLiteParameter("companyId", employee.CompanyId),
                new SQLiteParameter("situation", employee.Situation)
            };

            return Add(query, employee, sqlParameters);
        }

        public int UpdateEmployee(Employee employee)
        {
            string query = "Update Employee set EmployeeName = @employeeName, "
                         + " Email = @email, CompanyPosition = @companyPosition, "
                         + " Login = @login, Password = @password, CompanyId = @companyId, "
                         + " Situation = @situation "
                         + " where EmployeeId = @employeeId";


            SQLiteParameter[] sqlParameters = new SQLiteParameter[]
            {
                new SQLiteParameter("employeeId", employee.EmployeeId),
                new SQLiteParameter("employeeName", employee.EmployeeName),
                new SQLiteParameter("email", employee.Email),
                new SQLiteParameter("companyPosition", employee.CompanyPosition),
                new SQLiteParameter("login", employee.Login),
                new SQLiteParameter("password", employee.Password),
                new SQLiteParameter("companyId", employee.CompanyId),
                new SQLiteParameter("situation", employee.Situation)
            };

            return Update(query, employee, sqlParameters);
        }

        public bool DeleteEmployee(int employeeId)
        {
            string query = "Delete from Employee where EmployeeId = @employeeId";

            SQLiteParameter sqlParameter = new SQLiteParameter("employeeId", employeeId);

            return Delete(query, employeeId, sqlParameter);
        }

        protected override Employee ReaderToEntity(SQLiteDataReader reader)
        {
            int employeeIdOrdinal = reader.GetOrdinal("EmployeeId");
            int employeeNameOrdinal = reader.GetOrdinal("EmployeeName");
            int emailOrdinal = reader.GetOrdinal("Email");
            int companyPositionOrdinal = reader.GetOrdinal("CompanyPosition");
            int loginOrdinal = reader.GetOrdinal("Login");
            int passwordOrdinal = reader.GetOrdinal("Password");
            int companyIdOrdinal = reader.GetOrdinal("CompanyId");
            int situationOrdinal = reader.GetOrdinal("Situation");

            Employee employee = new Employee()
            {
                EmployeeId = reader[employeeIdOrdinal] is DBNull ? default(int) : reader.GetInt32(employeeIdOrdinal),
                EmployeeName = reader[employeeNameOrdinal] is DBNull ? string.Empty : reader.GetString(employeeNameOrdinal),
                Email = reader[emailOrdinal] is DBNull ? string.Empty : reader.GetString(emailOrdinal),
                CompanyPosition = reader[companyPositionOrdinal] is DBNull ? string.Empty : reader.GetString(companyPositionOrdinal),
                Login = reader[loginOrdinal] is DBNull ? string.Empty : reader.GetString(loginOrdinal),
                Password = reader[passwordOrdinal] is DBNull ? string.Empty : reader.GetString(passwordOrdinal),
                CompanyId = reader[companyIdOrdinal] is DBNull ? default(int) : reader.GetInt32(companyIdOrdinal),
                Situation = reader[situationOrdinal] is DBNull ? default(Situation) : (Situation)Convert.ToInt16(reader.GetValue(situationOrdinal))
            };

            return employee;
        }
    }
}
