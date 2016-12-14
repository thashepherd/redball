using System.ComponentModel.DataAnnotations;

namespace redball.Models
{
    public partial class TblShipperRateOverride
    {
        public int SroShipperId { get; set; }

        [Display(Name = "Origin State")]
        public string SroOriginStateCode { get; set; }

        [Display(Name = "Destination State")]
        public string SroTargetStateCode { get; set; }
        public double SroCostPerMilePercentageAdjustment { get; set; }

        public virtual TblShipper SroShipper { get; set; }

        public virtual TblState SroOriginStateCodeNavigation { get; set; }

        public virtual TblState SroTargetStateCodeNavigation { get; set; }
    }
}
