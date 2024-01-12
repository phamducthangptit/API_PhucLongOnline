using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class CongThuc
    {
        public int IdCongThuc { get; set; }
        public int? IdSanPhamSize { get; set; }
        public int? IdNguyenLieu { get; set; }
        public double SoLuong { get; set; }
        public string DonVi { get; set; } = null!;

        public virtual NguyenLieu? IdNguyenLieuNavigation { get; set; }
        public virtual CtSanPhamSize? IdSanPhamSizeNavigation { get; set; }
    }
}
