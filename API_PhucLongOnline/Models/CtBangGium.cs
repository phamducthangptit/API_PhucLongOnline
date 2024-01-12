using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class CtBangGium
    {
        public int IdCtbangGia { get; set; }
        public int IdSanPhamSize { get; set; }
        public int IdBangGia { get; set; }
        public double Gia { get; set; }

        public virtual BangGium IdBangGiaNavigation { get; set; } = null!;
        public virtual CtSanPhamSize IdSanPhamSizeNavigation { get; set; } = null!;
    }
}
