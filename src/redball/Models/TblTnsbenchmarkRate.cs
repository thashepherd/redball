using System;
using System.Collections.Generic;

namespace redball.Models
{
    public partial class TblTnsbenchmarkRate
    {
        public string TbrOriginStateCode { get; set; }
        public string TbrTargetStateCode { get; set; }
        public decimal TbrMinimumCharge { get; set; }
        public decimal TbrCostPerMile { get; set; }

        public virtual TblState TbrOriginStateCodeNavigation { get; set; }
        public virtual TblState TbrTargetStateCodeNavigation { get; set; }
    }
}
