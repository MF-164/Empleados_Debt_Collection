using System;

namespace Debt_Collection_CORE.ViewModels
{
    public class InvoiceVM
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public string? ClientName { get; set; }

        public int SiteId { get; set; }
        public string? SiteName { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public int Sequence { get; set; }

        public decimal TotalRegularHours { get; set; }
        public decimal TotalExtraHours { get; set; }
        public string? EmployeeType { get; set; }
        public decimal HourlyRate { get; set; }

        public decimal AmountBeforeVAT { get; set; }
        public decimal AmountWithVAT { get; set; }

        public string? ApprovalStatus { get; set; }
        public string? InvoiceStatus { get; set; }

        public decimal? PaidAmount1 { get; set; }
        public DateTime? PaidDate1 { get; set; }
        public decimal? PaidAmount2 { get; set; }
        public DateTime? PaidDate2 { get; set; }

        public decimal TotalPaid => (PaidAmount1 ?? 0) + (PaidAmount2 ?? 0);
        public decimal Difference => AmountWithVAT - TotalPaid;

        public string? Notes { get; set; }
    }
}
