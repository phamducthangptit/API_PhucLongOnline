using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int IdLoaiSanPham { get; set; }
        public string TenLoai { get; set; } = null!;

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
