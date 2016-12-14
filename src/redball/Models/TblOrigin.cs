using System.ComponentModel.DataAnnotations;

namespace redball.Models
{
    public partial class TblOrigin
    {
        public TblOrigin()
        {
        }

        public int OId { get; set; }

        [Display(Name = "Origin State")]
        public string OStateCode { get; set; }
    }
}
