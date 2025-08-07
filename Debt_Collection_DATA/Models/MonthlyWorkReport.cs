using System;

namespace Debt_Collection_DATA.Models
{
    public class MonthlyWorkReport
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public int SiteId { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        public int NumOfWorkers { get; set; }

        public decimal TotalRegularHours { get; set; }
        public decimal TotalExtraHours { get; set; }

        public string? EmployeeType { get; set; } // "רגיל" / "מקצועי"
        public decimal HourlyRate { get; set; }

        public decimal AmountBeforeVAT { get; set; }
        public decimal AmountWithVAT => AmountBeforeVAT * 1.18M;

        public string? ApprovalStatus { get; set; }
        public string? InvoiceSignatureStatus { get; set; }

        public string? Notes { get; set; }


        public Client? Client { get; set; }
        public Site? Site { get; set; }

    }
}