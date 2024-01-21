using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRistretto.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string CompanyPosition { get; set; }
        public string Login { get; set; }
        public byte Password { get; set; } 
        public int CompanyId { get; set; }
        public Situation Situation { get; set; }
    }
}
