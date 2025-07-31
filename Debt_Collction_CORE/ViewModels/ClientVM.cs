using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.ViewModels
{
    public class ClientVM
    {
        public int Id { get; set; } // Unique identifier for the client
        public string? Name { get; set; }
        public string? InvoiceContact { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public decimal? RegularEmployeeRate { get; set; }
        public decimal? ProfessionalEmployeeRate { get; set; }
        public bool? PaysBreaks { get; set; }
        public bool? IsActive { get; set; }
        public decimal? PaymentForecast { get; set; }
        public decimal? AgentRate { get; set; }


        public string? AgentName { get; set; }
        public int? AgentId { get; set; }

        public ICollection<SiteForClientVM>? Sites { get; set; }
    }
}
