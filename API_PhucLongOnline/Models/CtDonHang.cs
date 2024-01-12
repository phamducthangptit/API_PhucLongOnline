using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class CtDonHang
    {
        public int IdCtdonHang { get; set; }
        public int IdDonHang { get; set; }
        public int IdSanPhamSize { get; set; }
        public double GiaBan { get; set; }
        public int SoLuong { get; set; }

        public virtual DonHang IdDonHangNavigation { get; set; } = null!;
        public virtual CtSanPhamSize IdSanPhamSizeNavigation { get; set; } = null!;
    }
}
