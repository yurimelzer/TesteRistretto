using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteRistretto.Views;

namespace UnitTest.CompanyTests
{
    public class DummyCompanyView : ICompanyView
    {
        private BindingSource _bindingSource;

        public int GridCompanyCount => _bindingSource.Count;

        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;

        public void EditCompany() => EditEvent?.Invoke(this, EventArgs.Empty);
        public void DeleteCompany() => DeleteEvent?.Invoke(this, EventArgs.Empty);

        public void RefreshGrid()
        {
            return;
        }

        public void SetCompaniesListBindingSource(BindingSource bindingSource)
        {
            _bindingSource = bindingSource;
        }
    }
}
