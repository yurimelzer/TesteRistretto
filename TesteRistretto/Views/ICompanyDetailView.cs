using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteRistretto.Views
{
    public interface ICompanyDetailView
    {
        int CompanyId { get; set; }
        string CompanyName { get; set; }
        string ContactNumber { get; set; }
        string CompanyUrl { get; set; }

        bool IsSuccessful { get; set; }
        string Message { get; set; }

        event EventHandler AddEmployeeEvent;
        event EventHandler EditEmployeeEvent;
        event EventHandler DeleteEmployeeEvent;

        event EventHandler SaveEvent;

        void SetEmployeeBindingSource(BindingSource employeeBindingSource);
        void RefreshGrid();
        DialogResult ShowDialog();
        void Close();
    }
}
