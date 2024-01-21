using TesteRistretto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRistretto.Repositories
{
    public interface ICompanyRepository
    {
         List<Company> GetAllCompanies();

         Company GetCompanyById(int companyId);

         int AddCompany(Company company);

         int UpdateCompany(Company company);

         bool DeleteCompany(int companyId);
    }
}
