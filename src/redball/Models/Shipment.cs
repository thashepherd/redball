using System;
using System.Collections.Generic;

namespace redball.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
        }

        // TODO finesse model creation
        public int ShipmentId { get; set; }
        public Shipper ShipmentShipperId { get; set; }
        public Address ShipmentAddressId { get; set; }
        public Origin ShipmentOriginId { get; set; }
        public double ShipmentPerMileActual { get; set; }
        public DateTime ShipmentDate { get; set; }
    }
}
