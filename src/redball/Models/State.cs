using System.Collections.Generic;

namespace redball.Models
{
    public partial class State
    {
        public State()
        {
            ShipperRateOverrideOriginStateNavigation = new HashSet<ShipperRateOverride>();
            ShipperRateOverrideTargetStateNavigation = new HashSet<ShipperRateOverride>();
            BenchmarkRateOriginStateNavigation = new HashSet<BenchmarkRate>();
            BenchmarkRateTargetStateNavigation = new HashSet<BenchmarkRate>();
            OriginStateNavigation = new HashSet<Origin>();
            AddressStateNavigation = new HashSet<Address>();
        }

        public string StateCode { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<ShipperRateOverride> ShipperRateOverrideOriginStateNavigation { get; set; }
        public virtual ICollection<ShipperRateOverride> ShipperRateOverrideTargetStateNavigation { get; set; }
        public virtual ICollection<BenchmarkRate> BenchmarkRateOriginStateNavigation { get; set; }
        public virtual ICollection<BenchmarkRate> BenchmarkRateTargetStateNavigation { get; set; }
        public virtual ICollection<Origin> OriginStateNavigation { get; set; }
        public virtual ICollection<Address> AddressStateNavigation { get; set; }
    }
}
