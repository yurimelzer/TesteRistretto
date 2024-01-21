using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            this.view.CompanyId = company.CompanyId;
            this.view.CompanyName = company.CompanyName;
            this.view.ContactNumber = company.ContactNumber;
            this.view.CompanyUrl = company.CompanyUrl;

            this.view.AddEmployeeEvent += AddEmployee;
            this.view.EditEmployeeEvent+= EditEmployee;
            this.view.DeleteEmployeeEvent += DeleteEmployee;

            this.view.SaveEvent += SaveCompany;

            LoadEmployees();

            this.view.ShowDialog();
        }

        private void LoadEmployees()
        {
            employeesList = employeeRepository.GetAllEmployeesByCompany(this.view.CompanyId);
            employeeBindingSource.DataSource = employeesList;
        }

        private void AddEmployee(object sender, EventArgs e)
        {

        }

        private void EditEmployee(object sender, EventArgs e)
        {

        }

        private void DeleteEmployee(object sender, EventArgs e)
        {

        }

        private void SaveCompany(object sender, EventArgs e)
        {
            company.CompanyName = this.view.CompanyName;
            company.ContactNumber = this.view.ContactNumber;
            company.CompanyUrl = this.view.CompanyUrl;

            if (company.CompanyId == 0)
                companyRepository.AddCompany(company);
            else
                companyRepository.UpdateCompany(company);

            this.view.Close();
        }
    }
}
