using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRistretto.Repositories;
using TesteRistretto.Models;
namespace UnitTests.CompanyTest
{
    public class DummyCompanyRepository : ICompanyRepository
    {
        private List<Company> companies = new List<Company>() { new Company() };

        public int AddCompany(Company company)
        {
            return 1;
        }

        public bool DeleteCompany(int companyId)
        {
            if (companies.Count == 0)
                return false;

            companies.RemoveAt(0);

            return true;
        }

        public List<Company> GetAllCompanies()
        {
            return companies;
        }

        public Company GetCompanyById(int companyId)
        {
            return new Company();
        }

        public int UpdateCompany(Company company)
        {
            return 1;
        }
    }
}
