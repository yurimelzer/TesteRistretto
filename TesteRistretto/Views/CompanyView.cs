using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteRistretto.Views
{
    public partial class CompanyView : Form, ICompanyView
    {
        private bool isSucessful;

        public CompanyView()
        {
            InitializeComponent();

            WireViewEvents();
        }

        public void WireViewEvents()
        {
            btnAdd.Click += delegate { AddEvent?.Invoke(this, EventArgs.Empty); };
            btnEdit.Click += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };
            btnDelete.Click += delegate { DeleteEvent?.Invoke(this, EventArgs.Empty); };
        }

        public int GridCompanyCount { get => grdCompanies.RowCount; }

        public bool IsSuccessful 
        {
            get
            {
                return isSucessful;
            }
            set
            {
                lblMessage.ForeColor = value ? Color.Green : Color.Red;
                isSucessful = value;
            }
        }
        public string Message { get => lblMessage.Text; set => lblMessage.Text = value; }

        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;

        public void RefreshGrid()
        {
            grdCompanies.Refresh();
        }

        public void SetCompaniesListBindingSource(BindingSource bindingSource)
        {
            grdCompanies.DataSource = bindingSource;
        }
    }
}
