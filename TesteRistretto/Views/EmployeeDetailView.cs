using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteRistretto.Models;

namespace TesteRistretto.Views
{
    public partial class EmployeeDetailView : Form, IEmployeeDetailView
    {
        private bool isSucessful;

        public EmployeeDetailView()
        {
            InitializeComponent();

            WireViewEvents();

            cmbSituation.DataSource = Enum.GetValues(typeof(Situation));
        }

        public void WireViewEvents()
        {
            btnSave.Click += delegate { SaveEvent?.Invoke(this, EventArgs.Empty); };
        }


        public int CompanyId { get => cmbCompany.SelectedValue == null ? 0 : (int)cmbCompany.SelectedValue; set => cmbCompany.SelectedValue = value; }
        public int EmployeeId { get => Convert.ToInt32(txtEmployeeId.Text); set => txtEmployeeId.Text = value.ToString(); }
        public string EmployeeName { get => txtEmployeeName.Text; set => txtEmployeeName.Text = value; }
        public string Email { get => txtEmail.Text; set => txtEmail.Text = value; }
        public string CompanyPosition { get => txtCompanyPosition.Text; set => txtCompanyPosition.Text = value; }
        public string Login { get => txtLogin.Text; set => txtLogin.Text = value; }
        public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }
        public string ConfirmationPassword { get => txtConfirmationPassword.Text; set => txtConfirmationPassword.Text = value; }
        public Situation Situation { get => (Situation)cmbSituation.SelectedIndex; set => cmbSituation.SelectedIndex = (int)value; }

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

        public event EventHandler SaveEvent;

        public void SetCompaniesListDataSource(IEnumerable<Company> companiesList)
        {
            cmbCompany.ValueMember = "CompanyId";
            cmbCompany.DisplayMember = "CompanyName";
            cmbCompany.DataSource = companiesList;
        }
    }
}
