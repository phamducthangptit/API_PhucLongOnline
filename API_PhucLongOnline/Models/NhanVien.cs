using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            DonDatNguyenLieus = new HashSet<DonDatNguyenLieu>();
            PhieuNhapHangs = new HashSet<PhieuNhapHang>();
        }

        public string MaNhanVien { get; set; } = null!;
        public string Ho { get; set; } = null!;
        public string Ten { get; set; } = null!;
        public string GioiTinh { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public DateTime NgaySinh { get; set; }
        public string Sdt { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Mst { get; set; }
        public string? HinhAnh { get; set; }
        public DateTime? HopDong { get; set; }
        public string? SoBhxh { get; set; }

        public virtual TaiKhoan MaNhanVienNavigation { get; set; } = null!;
        public virtual ICollection<DonDatNguyenLieu> DonDatNguyenLieus { get; set; }
        public virtual ICollection<PhieuNhapHang> PhieuNhapHangs { get; set; }
    }
}
