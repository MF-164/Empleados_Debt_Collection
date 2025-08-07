namespace Debt_Collection_DATA.Models
{
    public class InvoiceRecord
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public Site Site { get; set; }
        public DateTime IssueDate { get; set; } //	תאריך ההנפקה של החשבונית (מתי היא נוצרה)
        public DateTime DueDate { get; set; } // תאריך היעד לתשלום (מתי הלקוח צריך לשלם)
        public decimal Amount { get; set; }
        public decimal? PaidAmount { get; set; }
        public DateTime? PaymentDate { get; set; }

        public string Status { get; set; } = "Open";
        public string? Notes { get; set; }

        public bool IsActive { get; set; } = true;
    }
}