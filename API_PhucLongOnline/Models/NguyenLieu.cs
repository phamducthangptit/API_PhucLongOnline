using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class NguyenLieu
    {
        public NguyenLieu()
        {
            CongThucs = new HashSet<CongThuc>();
            CtDonDatHangs = new HashSet<CtDonDatHang>();
            CtNguyenLieus = new HashSet<CtNguyenLieu>();
        }

        public int IdNguyenLieu { get; set; }
        public string TenNguyenLieu { get; set; } = null!;
        public string? HinhAnh { get; set; }
        public double SoLuong { get; set; }

        public virtual ICollection<CongThuc> CongThucs { get; set; }
        public virtual ICollection<CtDonDatHang> CtDonDatHangs { get; set; }
        public virtual ICollection<CtNguyenLieu> CtNguyenLieus { get; set; }
    }
}
