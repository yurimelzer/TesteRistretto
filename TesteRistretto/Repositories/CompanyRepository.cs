﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRistretto.Models;

namespace TesteRistretto.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public List<Company> GetAllCompanies()
        {
            string query = "SELECT CompanyId, CompanyName, ContactNumber, CompanyUrl "
                         + " FROM Company ";

            return GetAll(query);
        }

        public Company GetCompanyById(int companyId)
        {
            string query = "SELECT CompanyId, CompanyName, ContactNumber, CompanyUrl "
                         + " FROM Company "
                         + " WHERE CompanyId = @companyId";

            SqlParameter sqlParameter = new SqlParameter("companyId", companyId);

            return GetById(query, companyId, sqlParameter);
        }

        public int AddCompany(Company company)
        {
            string query = "INSERT INTO Company "
                         + " ( CompanyName, ContactNumber, CompanyUrl) "
                         + " Values "
                         + " ( @companyName, @contactNumber, @companyUrl) ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("companyName", company.CompanyName),
                new SqlParameter("contactNumber", company.ContactNumber),
                new SqlParameter("companyUrl", company.CompanyUrl)
            };

            return Add(query, company, sqlParameters);
        }

        public int UpdateCompany(Company company)
        {
            string query = "Update Company set CompanyName = @companyName, " 
                         + " ContactNumber = @contactNumber, CompanyUrl = @companyUrl "
                         + " where CompanyId = @companyId";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("companyId", company.CompanyId),
                new SqlParameter("companyName", company.CompanyName),
                new SqlParameter("contactNumber", company.ContactNumber),
                new SqlParameter("companyUrl", company.CompanyUrl)
            };

            return Update(query, company, sqlParameters);
        }

        public bool DeleteCompany(int companyId)
        {
            string query = "Delete from Company where CompanyId = @companyId";

            SqlParameter sqlParameter = new SqlParameter("companyId", companyId);

            return Delete(query, companyId, sqlParameter);
        }

        protected override Company ReaderToEntity(SqlDataReader reader)
        {
            int companyIdOrdinal = reader.GetOrdinal("CompanyId");
            int companyNameOrdinal = reader.GetOrdinal("CompanyName");
            int contactNumberOrdinal = reader.GetOrdinal("ContactNumber");
            int companyUrlOrdinal = reader.GetOrdinal("CompanyUrl");

            Company company = new Company()
            {
                CompanyId = reader[companyIdOrdinal] is DBNull ? default(int) : reader.GetInt32(companyIdOrdinal),
                CompanyName = reader[companyIdOrdinal] is DBNull ? string.Empty : reader.GetString(companyNameOrdinal),
                ContactNumber = reader[companyIdOrdinal] is DBNull ? string.Empty : reader.GetString(contactNumberOrdinal),
                CompanyUrl = reader[companyIdOrdinal] is DBNull ? string.Empty : reader.GetString(companyUrlOrdinal),
            };

            return company;
        }
    }
}
