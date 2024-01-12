using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class GioHang
    {
        public int IdGioHang { get; set; }
        public string TenDangNhap { get; set; } = null!;
        public int? IdSanPhamSize { get; set; }
        public int? SoLuong { get; set; }

        public virtual CtSanPhamSize? IdSanPhamSizeNavigation { get; set; }
        public virtual TaiKhoan TenDangNhapNavigation { get; set; } = null!;
    }
}
