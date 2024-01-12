using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class CtDonDatHang
    {
        public CtDonDatHang()
        {
            CtPhieuNhapHangs = new HashSet<CtPhieuNhapHang>();
        }

        public int IdCtdonDatHang { get; set; }
        public int? IdDonDatNguyenLieu { get; set; }
        public int? IdNguyenLieu { get; set; }
        public string? MaNhaCungCap { get; set; }
        public double SoLuong { get; set; }

        public virtual DonDatNguyenLieu? IdDonDatNguyenLieuNavigation { get; set; }
        public virtual NguyenLieu? IdNguyenLieuNavigation { get; set; }
        public virtual NhaCungCap? MaNhaCungCapNavigation { get; set; }
        public virtual ICollection<CtPhieuNhapHang> CtPhieuNhapHangs { get; set; }
    }
}
