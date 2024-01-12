using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class PhieuNhapHang
    {
        public PhieuNhapHang()
        {
            CtPhieuNhapHangs = new HashSet<CtPhieuNhapHang>();
        }

        public int IdPhieuNhapHang { get; set; }
        public DateTime NgayLapPhieuNhap { get; set; }
        public string? MaNhanVien { get; set; }

        public virtual NhanVien? MaNhanVienNavigation { get; set; }
        public virtual ICollection<CtPhieuNhapHang> CtPhieuNhapHangs { get; set; }
    }
}
