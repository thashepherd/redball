using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace redball.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            ShipperRateOverrideNavigation = new HashSet<ShipperRateOverride>();
        }

        public int ShipperId { get; set; }

        [Display(Name = "Shipper Name")]
        public string ShipperName { get; set; }

        public virtual ICollection<ShipperRateOverride> ShipperRateOverrideNavigation { get; set; }
        public virtual ICollection<Shipment> ShipmentShipperNavigation { get; set; }
    }
}
