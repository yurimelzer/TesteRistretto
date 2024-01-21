using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteRistretto.Models;
using TesteRistretto.Repositories;
using TesteRistretto.Views;

namespace TesteRistretto.Presenters
{
    public class EmployeeDetailPresenter
    {
        private IEmployeeDetailView view;

        private IEmployeeRepository employeeRepository;
        private ICompanyRepository companyRepository;

        private Employee employee;

        private IEnumerable<Company> companiesList;

        public EmployeeDetailPresenter(IEmployeeDetailView view, IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, Employee employee)
        {
            this.view = view;

            this.employeeRepository = employeeRepository;
            this.companyRepository = companyRepository;

            this.employee = employee;

            this.view.SaveEvent += SaveEmployee;

            this.view.SetCompaniesListDataSource(companyRepository.GetAllCompanies());

            LoadEmployeeInfo();

            this.view.ShowDialog();
        }

        private void LoadEmployeeInfo()
        {
            this.view.EmployeeId = employee.EmployeeId;
            this.view.EmployeeName = employee.EmployeeName;
            this.view.Email = employee.Email;
            this.view.CompanyPosition = employee.CompanyPosition;
            this.view.Login = employee.Login;
            this.view.CompanyId = employee.CompanyId;
            this.view.Situation = employee.Situation;
        }

        private void SaveEmployee(object sender, EventArgs e)
        {
            this.view.IsSuccessful = true;
            this.view.Message = string.Empty;

            if(String.IsNullOrWhiteSpace(this.view.EmployeeName))
            {
                this.view.IsSuccessful = false;
                this.view.Message += "\nInforme o nome!";
            }

            if(String.IsNullOrWhiteSpace(this.view.Email))
            {
                this.view.IsSuccessful = false;
                this.view.Message += "\nInforme o E-mail!";
            }

            if(String.IsNullOrWhiteSpace(this.view.CompanyPosition))
            {
                this.view.IsSuccessful = false;
                this.view.Message += "\nInforme o Cargo!";
            }

            if (String.IsNullOrWhiteSpace(this.view.Login))
            {
                this.view.IsSuccessful = false;
                this.view.Message += "\nInforme o Login!";
            }

            if (this.view.EmployeeId == 0 && String.IsNullOrWhiteSpace(this.view.Password))
            {
                this.view.IsSuccessful = false;
                this.view.Message += "\nInforme a Senha!";
            }

            if((this.view.EmployeeId == 0 || !String.IsNullOrWhiteSpace(this.view.Password)) && this.view.Password != this.view.ConfirmationPassword)
            {
                this.view.IsSuccessful = false;
                this.view.Message += "\nA confirmação da senha está diferente da senha!";
            }

            if (this.view.CompanyId == 0)
            {
                this.view.IsSuccessful = false;
                this.view.Message += "\nSelecione a empresa!";
            }

            if (!this.view.IsSuccessful) return;

            employee.EmployeeId = this.view.EmployeeId;
            employee.EmployeeName = this.view.EmployeeName;
            employee.Email = this.view.Email;
            employee.CompanyPosition = this.view.CompanyPosition;
            employee.Situation = this.view.Situation;
            employee.Login = this.view.Login;

            if(String.IsNullOrWhiteSpace(this.view.Password) == false)
                employee.Password = Sha256Hash(this.view.Password);

            employee.CompanyId = this.view.CompanyId;

            if (employee.EmployeeId == 0)
                employeeRepository.AddEmployee(employee);
            else
                employeeRepository.UpdateEmployee(employee);

            this.view.Close();
        }

        private string Sha256Hash(string value)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
