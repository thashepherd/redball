using System;
using System.Collections.Generic;

namespace redball.Models
{
    public partial class TblShipper
    {
        public TblShipper()
        {
            TblShipperRateOverride = new HashSet<TblShipperRateOverride>();
        }

        public int ShipperId { get; set; }
        public string ShipperName { get; set; }

        public virtual ICollection<TblShipperRateOverride> TblShipperRateOverride { get; set; }
    }
}
