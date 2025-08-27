using System;

namespace Debt_Collection_DATA.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        // Relations
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public int SiteId { get; set; }
        public Site? Site { get; set; }

        // Period & multi-invoice support
        public int Month { get; set; }  // 1..12
        public int Year { get; set; }   // e.g. 2025
        public int Sequence { get; set; } = 1; // Allows multiple invoices for same (Client,Site,Month,Year)

        // Work summary (monthly)
        public decimal TotalRegularHours { get; set; }
        public decimal TotalExtraHours { get; set; }
        public string? EmployeeType { get; set; } // "Regular" / "Professional" or mixed policy note
        public decimal HourlyRate { get; set; }

        // Amounts
        public decimal AmountBeforeVAT { get; set; }
        public decimal AmountWithVAT { get; set; }

        // Approvals & statuses
        public string? ApprovalStatus { get; set; } // Pending / Approved / Rejected
        public string? InvoiceStatus { get; set; }  // Sent / Signed / Pending

        // Payments (normalize later if you need many payments)
        public decimal? PaidAmount1 { get; set; }
        public DateTime? PaidDate1 { get; set; }
        public decimal? PaidAmount2 { get; set; }
        public DateTime? PaidDate2 { get; set; }

        // Computed summary (read-only so PatchHelper won't try to set)
        public decimal TotalPaid => (PaidAmount1 ?? 0) + (PaidAmount2 ?? 0);
        public decimal Difference => AmountWithVAT - TotalPaid;

        // Notes
        public string? Notes { get; set; }
    }
}
