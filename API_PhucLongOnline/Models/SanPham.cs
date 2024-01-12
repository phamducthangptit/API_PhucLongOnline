using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            CtSanPhamSizes = new HashSet<CtSanPhamSize>();
        }

        public int IdSanPham { get; set; }
        public string TenSanPham { get; set; } = null!;
        public string? HinhAnh { get; set; }
        public string CachPhaChe { get; set; } = null!;
        public int? IdLoaiSanPham { get; set; }

        public virtual LoaiSanPham? IdLoaiSanPhamNavigation { get; set; }
        public virtual ICollection<CtSanPhamSize> CtSanPhamSizes { get; set; }
    }
}
