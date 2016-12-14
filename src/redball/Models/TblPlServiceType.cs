using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace redball.Models
{
    public partial class TblPlServiceType
    {
        public TblPlServiceType()
        {
            TblPlTrailerType = new HashSet<TblPlTrailerType>();
        }

        public byte StId { get; set; }

        [Display(Name = "Service Type")]
        public string StName { get; set; }

        [Display(Name = "Supported Trailer Type")]
        public virtual ICollection<TblPlTrailerType> TblPlTrailerType { get; set; }
    }
}
