using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class KhachHang
    {
        public string TenDangNhap { get; set; } = null!;
        public string Ho { get; set; } = null!;
        public string Ten { get; set; } = null!;
        public string GioiTinh { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        public string Sdt { get; set; } = null!;
        public string? Email { get; set; }
        public string? Mst { get; set; }
        public string? HinhAnh { get; set; }
        public double? DiemTichLuy { get; set; }

        public virtual TaiKhoan TenDangNhapNavigation { get; set; } = null!;
    }
}
