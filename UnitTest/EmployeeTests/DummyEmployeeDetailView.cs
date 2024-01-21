using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteRistretto.Models;
using TesteRistretto.Views;

namespace UnitTest.EmployeeTests
{
    internal class DummyEmployeeDetailView : IEmployeeDetailView
    {
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string CompanyPosition { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
        public Situation Situation { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        public event EventHandler SaveEvent;

        public void SaveCompany() => SaveEvent?.Invoke(this, EventArgs.Empty);

        public void SetCompaniesListDataSource(IEnumerable<Company> companiesList)
        {
            return;
        }

        public DialogResult ShowDialog()
        {
            return DialogResult.OK;
        }

        public void Close()
        {
            return;
        }
    }
}
