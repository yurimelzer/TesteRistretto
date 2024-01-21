using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteRistretto.Views
{
    public partial class CompanyDetailView : Form, ICompanyDetailView
    {
        private bool isSucessful;
        private string message;

        public CompanyDetailView()
        {
            InitializeComponent();

            WireViewEvents();
        }

        public void WireViewEvents()
        {
            btnAddEmployee.Click += delegate { AddEmployeeEvent?.Invoke(this, EventArgs.Empty); };
            btnEditEmployee.Click += delegate { EditEmployeeEvent?.Invoke(this, EventArgs.Empty); };
            btnDeleteEmployee.Click += delegate { DeleteEmployeeEvent?.Invoke(this, EventArgs.Empty); };

            btnSave.Click += delegate { SaveEvent?.Invoke(this, EventArgs.Empty); };
        }

        int ICompanyDetailView.CompanyId { get => Convert.ToInt32(txtCompanyId.Text); set => txtCompanyId.Text = value.ToString(); }
        string ICompanyDetailView.CompanyName { get => txtCompanyName.Text; set => txtCompanyName.Text = value; }
        string ICompanyDetailView.ContactNumber { get => txtContactNumber.Text; set => txtContactNumber.Text = value; }
        string ICompanyDetailView.CompanyUrl { get => txtUrl.Text; set => txtUrl.Text = value; }

        public bool IsSuccessful { get => isSucessful; set => isSucessful = value; }
        public string Message { get => message; set => message = value; }

        public event EventHandler AddEmployeeEvent;
        public event EventHandler EditEmployeeEvent;
        public event EventHandler DeleteEmployeeEvent;

        public event EventHandler SaveEvent;

        public void SetEmployeeBindingSource(BindingSource employeeBindingSource)
        {
            grdEmployees.DataSource = employeeBindingSource;
        }

        public void RefreshGrid()
        {
            grdEmployees.Refresh();
        }
    }
}
