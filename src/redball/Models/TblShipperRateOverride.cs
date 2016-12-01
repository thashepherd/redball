using System;
using System.Collections.Generic;

namespace redball.Models
{
    public partial class TblShipperRateOverride
    {
        public int SroCarrierId { get; set; }
        public string SroOriginStateCode { get; set; }
        public string SroTargetStateCode { get; set; }
        public double SroCostPerMilePercentageAdjustment { get; set; }

        public virtual TblShipper SroCarrier { get; set; }
        public virtual TblState SroOriginStateCodeNavigation { get; set; }
        public virtual TblState SroTargetStateCodeNavigation { get; set; }
    }
}
