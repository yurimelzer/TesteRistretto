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
    public class CompanyPresenter
    {
        private ICompanyView view;
        private ICompanyRepository repository;

        private BindingSource companyBindingSource;
        private IEnumerable<Company> companyList;

        public CompanyPresenter(ICompanyView view, ICompanyRepository repository)
        {
            this.view = view;
            this.repository = repository;

            this.companyBindingSource = new BindingSource();

            this.view.AddEvent += AddCompany;
            this.view.EditEvent += EditCompany;
            this.view.DeleteEvent += DeleteCompany;

            this.view.SetCompaniesListBindingSource(this.companyBindingSource);

            LoadCompanies();
        }

        private void LoadCompanies()
        {
            companyList = repository.GetAllCompanies();
            companyBindingSource.DataSource = companyList;
        }

        private void AddCompany(object sender, EventArgs e)
        {
            ICompanyDetailView view = new CompanyDetailView();
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            new CompanyDetailPresenter(view, this.repository, employeeRepository, new Company());

            LoadCompanies();

            this.view.RefreshGrid();
        }

        private void EditCompany(object sender, EventArgs e)
        {
            ICompanyDetailView view = new CompanyDetailView();
            IEmployeeRepository employeeRepository = new EmployeeRepository();

            Company company = (Company)companyBindingSource.Current;

            new CompanyDetailPresenter(view, this.repository, employeeRepository, company);

            LoadCompanies();

            this.view.RefreshGrid();
        }

        private void DeleteCompany(object sender, EventArgs e)
        {
            Company company = (Company)companyBindingSource.Current;

            repository.DeleteCompany(company.CompanyId);

            LoadCompanies();

            this.view.RefreshGrid();
        }
    }
}
