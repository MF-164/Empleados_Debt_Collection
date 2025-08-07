using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.ViewModels
{
    namespace Debt_Collection_CORE.ViewModels
    {
        public class InvoiceRecordVM
        {
            public int Id { get; set; }

            public int SiteId { get; set; }
            public string? SiteName { get; set; }

            public DateTime IssueDate { get; set; }
            public DateTime DueDate { get; set; }

            public decimal Amount { get; set; }
            public decimal? PaidAmount { get; set; }
            public DateTime? PaymentDate { get; set; }

            public string Status { get; set; }
            public string? Notes { get; set; }

            public bool IsActive { get; set; }
        }
    }

}
