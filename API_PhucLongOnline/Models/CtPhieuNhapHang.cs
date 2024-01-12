using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class CtPhieuNhapHang
    {
        public int IdCtphieuNhapHang { get; set; }
        public int IdCtdonDatHang { get; set; }
        public int IdPhieuNhapHang { get; set; }
        public int LanNhap { get; set; }
        public double SoLuongNhap { get; set; }
        public double DonGia { get; set; }

        public virtual CtDonDatHang IdCtdonDatHangNavigation { get; set; } = null!;
        public virtual PhieuNhapHang IdPhieuNhapHangNavigation { get; set; } = null!;
    }
}
