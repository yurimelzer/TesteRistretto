using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRistretto.Models;
using TesteRistretto.Views;

namespace UnitTests.CompanyTest
{
    public class DummyCompanyView : ICompanyView
    {
        public int GridCompanyCount { get; set; }

        public bool IsEdit { get; set; }
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

        public void SetCompaniesListBindingSource(object bindingSource)
        {
            return;
        }
    }
}
