using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            GioHangs = new HashSet<GioHang>();
        }

        public string TenDangNhap { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public int TrangThai { get; set; }
        public int? IdQuyen { get; set; }

        public virtual Quyen? IdQuyenNavigation { get; set; }
        public virtual KhachHang? KhachHang { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
