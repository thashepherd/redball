using System;
using System.Collections.Generic;

namespace redball.Models
{
    public partial class TblPlTrailerType
    {
        public byte TtId { get; set; }
        public byte TtStId { get; set; }
        public byte TtLength { get; set; }
        public string TtName { get; set; }
        public string TtDescription { get; set; }

        public virtual TblPlServiceType TtSt { get; set; }
    }
}
