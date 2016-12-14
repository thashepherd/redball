using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace redball.Models
{
    public partial class TblShipper
    {
        public TblShipper()
        {
            TblShipperRateOverride = new HashSet<TblShipperRateOverride>();
        }

        public int ShipperId { get; set; }

        [Display(Name = "Shipper Name")]
        public string ShipperName { get; set; }

        public virtual ICollection<TblShipperRateOverride> TblShipperRateOverride { get; set; }
    }
}
