using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace redball.Models
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            TblPlTrailerType = new HashSet<TrailerType>();
        }

        public byte StId { get; set; }

        [Display(Name = "Service Type")]
        public string StName { get; set; }

        [Display(Name = "Supported Trailer Type")]
        public virtual ICollection<TrailerType> TblPlTrailerType { get; set; }
    }
}
