namespace redball.Models
{
    public partial class BenchmarkRate
    {
        public string TbrOriginStateCode { get; set; }
        public virtual State TbrOriginState { get; set; }

        public string TbrTargetStateCode { get; set; }
        public virtual State TbrTargetState { get; set; }

        public decimal TbrMinimumCharge { get; set; }
        public decimal TbrCostPerMile { get; set; }
    }
}
