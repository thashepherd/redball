using System.Collections.Generic;

namespace redball.Models
{
    public partial class Address
    {
        public Address()
        {
            ShipmentAddressNavigation = new HashSet<Shipment>();
        }

        // TODO finesse model creation
        public int AddressId { get; set; }

        public string AddressStateCode { get; set; }
        public virtual State AddressState { get; set; }

        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }

        public virtual ICollection<Shipment> ShipmentAddressNavigation { get; set; }
    }
}
