using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class BangGia
    {
        public BangGia()
        {
            CtBangGia = new HashSet<CtBangGia>();
        }

        public int IdBangGia { get; set; }
        public string TenLoaiGia { get; set; } = null!;
        public DateTime NgayApDung { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        public virtual ICollection<CtBangGia> CtBangGia { get; set; }
    }
}
