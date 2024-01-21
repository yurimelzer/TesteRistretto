using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteRistretto.Views;

namespace UnitTest.CompanyTests
{
    internal class DummyCompanyDetailView : ICompanyDetailView
    {
        private BindingSource employeeBindingSource;

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ContactNumber { get; set; }
        public string CompanyUrl { get; set; }

        public int GridEmployeeCount => employeeBindingSource.Count;

        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        public event EventHandler AddEmployeeEvent;
        public event EventHandler EditEmployeeEvent;
        public event EventHandler DeleteEmployeeEvent;
        public event EventHandler SaveEvent;

        public void EditEmployee() => EditEmployeeEvent?.Invoke(this, EventArgs.Empty);
        public void DeleteEmployee() => DeleteEmployeeEvent?.Invoke(this, EventArgs.Empty);
        public void SaveCompany() => SaveEvent?.Invoke(this, EventArgs.Empty);

        public void Close()
        {
            return;
        }

        public void RefreshGrid()
        {
            return;
        }

        public void SetEmployeeBindingSource(BindingSource employeeBindingSource)
        {
            this.employeeBindingSource = employeeBindingSource;
        }

        public DialogResult ShowDialog()
        {
            return DialogResult.OK;
        }
    }
}
