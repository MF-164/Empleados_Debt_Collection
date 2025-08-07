using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.ViewModels
{
    public class MonthlyWorkReportVM
    {
        public int Id { get; set; }


        public int ClientId { get; set; }
        public int SiteId { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        public int NumOfWorkers { get; set; }

        public decimal TotalRegularHours { get; set; }
        public decimal TotalExtraHours { get; set; }

        public string? EmployeeType { get; set; } // "Regular" / "Professional"
        public decimal HourlyRate { get; set; }

        public decimal AmountBeforeVAT { get; set; }
        public decimal AmountWithVAT => AmountBeforeVAT * 1.18M;

        public string? ApprovalStatus { get; set; } // Pending / Approved / Rejected
        public string? InvoiceSignatureStatus { get; set; } // Signed / Not signed

        public string? Notes { get; set; }

        // Optional for UI display purposes only
        public string? ClientName { get; set; }
        public string? SiteName { get; set; }
    }

}
