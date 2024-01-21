using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteRistretto.Views
{
    public interface ICompanyView
    {
        int GridCompanyCount { get; }

        bool IsSuccessful { get; set; }
        string Message { get; set; }

        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;

        void SetCompaniesListBindingSource(BindingSource bindingSource);
        void RefreshGrid();
    }
}
