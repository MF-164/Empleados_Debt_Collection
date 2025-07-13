using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.Models
{
    public class Client
    {
        public int Id { get; set; } // Unique identifier for the client
        public string Name { get; set; }
        public string InvoiceContact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal RegularEmployeeRate { get; set; }
        public decimal ProfessionalEmployeeRate { get; set; }
        public bool PaysBreaks { get; set; }
        public bool IsActive { get; set; }
        public decimal PaymentForecast { get; set; }
        public decimal AgentRate { get; set; }


        public int AgentId { get; set; }
        public Agent Agent { get; set; }

        public ICollection<Site> Sites { get; set; }
    }

}
