namespace redball.Models
{
    public partial class BenchmarkRate
    {
        public State TbrOriginStateCode { get; set; }
        public State TbrTargetStateCode { get; set; }
        public decimal TbrMinimumCharge { get; set; }
        public decimal TbrCostPerMile { get; set; }
    }
}
