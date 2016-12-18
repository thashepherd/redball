using System.ComponentModel.DataAnnotations;

namespace redball.Models
{
    public partial class ShipperRateOverride
    {
        public int SroShipperId { get; set; }
        public virtual Shipper SroShipper { get; set; }

        [Display(Name = "Origin State")]
        public string SroOriginStateCode { get; set; }
        public virtual State SroOriginState { get; set; }

        [Display(Name = "Destination State")]
        public string SroTargetStateCode { get; set; }
        public virtual State SroTargetState { get; set; }

        public double SroCostPerMilePercentageAdjustment { get; set; }
    }
}
