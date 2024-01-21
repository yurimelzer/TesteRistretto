using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteRistretto.Presenters;
using TesteRistretto.Repositories;
using TesteRistretto.Views;

namespace TesteRistretto
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ICompanyView companyView = new CompanyView();
            ICompanyRepository companyRepository = new CompanyRepository();
            new CompanyPresenter(companyView, companyRepository);

            Application.Run((Form)companyView);
        }
    }
}
