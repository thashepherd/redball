using System;
using System.Collections.Generic;

namespace redball.Models
{
    public partial class TblState
    {
        public TblState()
        {
            TblShipperRateOverrideSroOriginStateCodeNavigation = new HashSet<TblShipperRateOverride>();
            TblShipperRateOverrideSroTargetStateCodeNavigation = new HashSet<TblShipperRateOverride>();
            TblTnsbenchmarkRateTbrOriginStateCodeNavigation = new HashSet<TblTnsbenchmarkRate>();
            TblTnsbenchmarkRateTbrTargetStateCodeNavigation = new HashSet<TblTnsbenchmarkRate>();
        }

        public string StateCode { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<TblShipperRateOverride> TblShipperRateOverrideSroOriginStateCodeNavigation { get; set; }
        public virtual ICollection<TblShipperRateOverride> TblShipperRateOverrideSroTargetStateCodeNavigation { get; set; }
        public virtual ICollection<TblTnsbenchmarkRate> TblTnsbenchmarkRateTbrOriginStateCodeNavigation { get; set; }
        public virtual ICollection<TblTnsbenchmarkRate> TblTnsbenchmarkRateTbrTargetStateCodeNavigation { get; set; }
    }
}
