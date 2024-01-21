using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteRistretto.Models;
using TesteRistretto.Repositories;
using TesteRistretto.Views;

namespace TesteRistretto.Presenters
{
    public class CompanyDetailPresenter
    {
        private ICompanyDetailView view;

        private ICompanyRepository companyRepository;
        private IEmployeeRepository employeeRepository;

        private Company company;

        private BindingSource employeeBindingSource;
        private IEnumerable<Employee> employeesList;

        public CompanyDetailPresenter(ICompanyDetailView view, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository, Company company)
        {
            this.view = view;

            this.companyRepository = companyRepository;
            this.employeeRepository = employeeRepository;

            this.company = company;

            this.employeeBindingSource = new BindingSource();

            this.view.AddEmployeeEvent += AddEmployee;
            this.view.EditEmployeeEvent+= EditEmployee;
            this.view.DeleteEmployeeEvent += DeleteEmployee;

            this.view.SaveEvent += SaveCompany;

            LoadCompanyInfo();
            LoadEmployees();

            this.view.ShowDialog();
        }

        private void LoadCompanyInfo()
        {
            this.view.CompanyId = company.CompanyId;
            this.view.CompanyName = company.CompanyName;
            this.view.ContactNumber = company.ContactNumber;
            this.view.CompanyUrl = company.CompanyUrl;
        }

        private void LoadEmployees()
        {
            employeesList = employeeRepository.GetAllEmployeesByCompany(this.view.CompanyId);
            employeeBindingSource.DataSource = employeesList;
        }

        private bool ValidatePhoneNumber(out string contactNumber)
        {
            contactNumber = string.Empty;

            if (this.view.ContactNumber == null) return false;

            contactNumber = Regex.Replace(this.view.ContactNumber, @"[^\d]", "");

            return contactNumber.Length == 11;
        }

        private void AddEmployee(object sender, EventArgs e)
        {
            IEmployeeDetailView view = new EmployeeDetailView();
            new EmployeeDetailPresenter(view, employeeRepository, companyRepository, new Employee());
        }

        private void EditEmployee(object sender, EventArgs e)
        {
            Employee employee = (Employee)employeeBindingSource.Current;

            if (employee is null)
            {
                this.view.IsSuccessful = false;
                this.view.Message = "Não há registros a serem editados!";
                return;
            };

            IEmployeeDetailView view = new EmployeeDetailView();
            new EmployeeDetailPresenter(view, employeeRepository, companyRepository, employee);

            LoadEmployees();

            this.view.IsSuccessful = true;
        }

        private void DeleteEmployee(object sender, EventArgs e)
        {
            Employee employee = (Employee)employeeBindingSource.Current;

            if(employee is null)
                employee = new Employee();

            this.view.IsSuccessful = employeeRepository.DeleteEmployee(employee.EmployeeId);

            if (!this.view.IsSuccessful)
            {
                this.view.Message = "Funcionário não foi deletado!";
                return;
            }

            LoadEmployees();
        }

        private void SaveCompany(object sender, EventArgs e)
        {
            this.view.IsSuccessful = true;
            this.view.Message = string.Empty;

            if (String.IsNullOrWhiteSpace(this.view.CompanyName))
            {
                this.view.IsSuccessful = false;
                this.view.Message += "\nNome não deve ser vazio!";
            }

            if(!ValidatePhoneNumber(out string contactNumber))
            {
                this.view.IsSuccessful = false;
                this.view.Message += "\nTelefone inválido!";
            }

            if (!this.view.IsSuccessful) return;

            company.CompanyName = this.view.CompanyName;
            company.ContactNumber = contactNumber;
            company.CompanyUrl = this.view.CompanyUrl;

            if (company.CompanyId == 0)
                companyRepository.AddCompany(company);
            else
                companyRepository.UpdateCompany(company);


            this.view.Close();
        }
    }
}
