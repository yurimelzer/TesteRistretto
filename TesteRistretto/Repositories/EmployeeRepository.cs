using TesteRistretto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRistretto.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public List<Employee> GetAllEmployees()
        {
            string query = "SELECT EmployeeId, EmployeeName, Email, CompanyPosition "
                         + " Login, Password, CompanyId, Situation "
                         + " FROM Employee ";

            return GetAll(query);
        }

        public List<Employee> GetAllEmployeesByCompany(int companyId)
        {
            string query = "SELECT EmployeeId, EmployeeName, Email, CompanyPosition "
                         + " Login, Password, CompanyId, Situation "
                         + " FROM Employee "
                         + " WHERE CompanyId = @companyId";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("companyId", companyId)
            };

            return GetAll(query, sqlParameters);
        }

        public Employee GetEmployeeById(int employeeId)
        {
            string query = "SELECT EmployeeId, EmployeeName, Email, CompanyPosition "
                         + " Login, Password, CompanyId, Situation "
                         + " FROM Employee "
                         + " Where EmployeeId = @employeeId";

            SqlParameter sqlParameter = new SqlParameter("employeeId", employeeId);

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

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("employeeName", employee.EmployeeName),
                new SqlParameter("email", employee.Email),
                new SqlParameter("companyPosition", employee.CompanyPosition),
                new SqlParameter("login", employee.Login),
                new SqlParameter("password", employee.Password),
                new SqlParameter("companyId", employee.CompanyId),
                new SqlParameter("situation", employee.Situation)
            };

            return Add(query, employee, sqlParameters);
        }

        public int UpdateEmployee(Employee employee)
        {
            string query = "Update Employee set EmployeeName = @employeeName, "
                         + " Email = @email, CompanyPosition = @companyPosition "
                         + " Login = @login, Password = @password, CompanyId = @companyId "
                         + " Situation = @situation "
                         + " where EmployeeId = @employeeId";


            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("employeeId", employee.EmployeeId),
                new SqlParameter("employeeName", employee.EmployeeName),
                new SqlParameter("email", employee.Email),
                new SqlParameter("companyPosition", employee.CompanyPosition),
                new SqlParameter("login", employee.Login),
                new SqlParameter("password", employee.Password),
                new SqlParameter("companyId", employee.CompanyId),
                new SqlParameter("situation", employee.Situation)
            };

            return Update(query, employee, sqlParameters);
        }

        public bool DeleteEmployee(int employeeId)
        {
            string query = "Delete from Employee where EmployeeId = @employeeId";

            SqlParameter sqlParameter = new SqlParameter("employeeId", employeeId);

            return Delete(query, employeeId, sqlParameter);
        }

        protected override Employee ReaderToEntity(SqlDataReader reader)
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
                Password = reader[passwordOrdinal] is DBNull ? default(byte) : reader.GetByte(passwordOrdinal),
                CompanyId = reader[companyIdOrdinal] is DBNull ? default(int) : reader.GetInt32(companyIdOrdinal),
                Situation = reader[situationOrdinal] is DBNull ? default(Situation) : (Situation)reader.GetInt16(situationOrdinal),
            };

            return employee;
        }
    }
}
