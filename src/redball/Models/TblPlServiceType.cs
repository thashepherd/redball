using System;
using System.Collections.Generic;

namespace redball.Models
{
    public partial class TblPlServiceType
    {
        public TblPlServiceType()
        {
            TblPlTrailerType = new HashSet<TblPlTrailerType>();
        }

        public byte StId { get; set; }
        public string StName { get; set; }

        public virtual ICollection<TblPlTrailerType> TblPlTrailerType { get; set; }
    }
}
