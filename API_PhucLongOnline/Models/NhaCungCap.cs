using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            CtDonDatHangs = new HashSet<CtDonDatHang>();
            CtNguyenLieus = new HashSet<CtNguyenLieu>();
        }

        public string MaNhaCungCap { get; set; } = null!;
        public string TenNhaCungCap { get; set; } = null!;

        public virtual ICollection<CtDonDatHang> CtDonDatHangs { get; set; }
        public virtual ICollection<CtNguyenLieu> CtNguyenLieus { get; set; }
    }
}
