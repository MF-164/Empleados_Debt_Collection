using Debt_Collection_CORE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.ViewModels
{
    public class ClientForAgentVM
    {
        public string Name { get; set; }
        public List<SiteForClientVM> SitesName { get; set; }
    }

}
