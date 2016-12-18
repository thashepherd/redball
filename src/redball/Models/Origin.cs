using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace redball.Models
{
    public partial class Origin
    {
        public Origin()
        {
            ShipmentOriginNavigation = new HashSet<Shipment>();
        }
        public int OriginId { get; set; }

        [Display(Name = "Origin State")]
        public string OriginStateCode { get; set; }

        public virtual State OriginState { get; set; }

        public virtual ICollection<Shipment> ShipmentOriginNavigation { get; set; }
    }
}
