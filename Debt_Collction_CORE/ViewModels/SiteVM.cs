using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.ViewModels
{
    public class SiteVM
    {
        public int Id { get; set; } // Unique identifier for the site
        public string? Name { get; set; }
        public string? WorkHoursContact { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }

        public string? ClientName { get; set; }
    }
}
