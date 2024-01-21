using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteRistretto.Views;

namespace UnitTests.CompanyTest
{
    internal class DummyCompanyDetailView : ICompanyDetailView
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ContactNumber { get; set; }
        public string CompanyUrl { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        public event EventHandler AddEmployeeEvent;
        public event EventHandler EditEmployeeEvent;
        public event EventHandler DeleteEmployeeEvent;
        public event EventHandler SaveEvent;

        public void EditEmployee() => EditEmployeeEvent?.Invoke(this, EventArgs.Empty);
        public void DeleteEmployee() => DeleteEmployeeEvent?.Invoke(this, EventArgs.Empty);
        public void Save() => SaveEvent?.Invoke(this, EventArgs.Empty);

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
            return;
        }

        public DialogResult ShowDialog()
        {
            return DialogResult.OK;
        }
    }
}
