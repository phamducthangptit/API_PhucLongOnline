using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class CtSanPhamSize
    {
        public CtSanPhamSize()
        {
            CongThucs = new HashSet<CongThuc>();
            CtBangGia = new HashSet<CtBangGia>();
            CtDonHangs = new HashSet<CtDonHang>();
            GioHangs = new HashSet<GioHang>();
        }

        public int IdSanPhamSize { get; set; }
        public int IdSize { get; set; }
        public int IdSanPham { get; set; }

        public virtual SanPham IdSanPhamNavigation { get; set; } = null!;
        public virtual Size IdSizeNavigation { get; set; } = null!;
        public virtual ICollection<CongThuc> CongThucs { get; set; }
        public virtual ICollection<CtBangGia> CtBangGia { get; set; }
        public virtual ICollection<CtDonHang> CtDonHangs { get; set; }
        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
