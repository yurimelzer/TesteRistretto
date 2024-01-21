using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRistretto.Models;
using TesteRistretto.Repositories;

namespace UnitTest.CompanyTests
{
    internal class DummyCompanyRepository : ICompanyRepository
    {
        private List<Company> _companyList = new List<Company>() { new Company() };

        public int AddCompany(Company company)
        {
            return 1;
        }

        public bool DeleteCompany(int companyId)
        {
            if (_companyList.Count() == 0)
                return false;

            _companyList.RemoveAt(0);

            return true;
        }

        public List<Company> GetAllCompanies()
        {
            return _companyList;
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
