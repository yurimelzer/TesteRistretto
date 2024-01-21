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

        }
    }
}
