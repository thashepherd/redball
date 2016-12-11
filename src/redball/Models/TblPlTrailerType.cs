using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace redball.Models
{
    public partial class TblPlTrailerType
    {
        public byte TtId { get; set; }
        public byte TtStId { get; set; }

        [Display(Name = "Trailer Length")]
        public byte TtLength { get; set; }
        public string TtName { get; set; }
        public string TtDescription { get; set; }

        public virtual TblPlServiceType TtSt { get; set; }

        public override string ToString()
        {
            return string.Format("{0}' {1} {2}",
                TtLength,
                string.IsNullOrWhiteSpace(TtName)
                    ? "trailer"
                    : TtName,
                string.IsNullOrWhiteSpace(TtDescription)
                    ? ""
                    : string.Format("({0})", TtDescription)
            );
        }
    }
}
