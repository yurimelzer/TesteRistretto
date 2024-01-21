using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteRistretto.Models;

namespace TesteRistretto.Views
{
    public interface IEmployeeDetailView
    {
        int CompanyId { get; set; }
        int EmployeeId { get; set; }
        string EmployeeName { get; set; }
        string Email { get; set; }
        string CompanyPosition { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string ConfirmationPassword { get; set; }
        Situation Situation { get; set; }

        bool IsSuccessful { get; set; }
        string Message { get; set; }

        event EventHandler SaveEvent;

        void SetCompaniesListDataSource(IEnumerable<Company> companiesList);
        DialogResult ShowDialog();
        void Close();
    }
}
