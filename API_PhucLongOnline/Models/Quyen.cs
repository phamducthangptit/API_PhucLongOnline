using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class Quyen
    {
        public Quyen()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int IdQuyen { get; set; }
        public string ChucVu { get; set; } = null!;
        public string CapDo { get; set; } = null!;

        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
