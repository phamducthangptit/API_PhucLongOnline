using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class BangGium
    {
        public BangGium()
        {
            CtBangGia = new HashSet<CtBangGium>();
        }

        public int IdBangGia { get; set; }
        public string TenLoaiGia { get; set; } = null!;
        public DateTime NgayApDung { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        public virtual ICollection<CtBangGium> CtBangGia { get; set; }
    }
}
