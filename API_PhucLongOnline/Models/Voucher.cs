using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int IdVoucher { get; set; }
        public string NoiDung { get; set; } = null!;
        public DateTime? NgayApDung { get; set; }
        public DateTime NgayHetHan { get; set; }
        public double PhanTramGiam { get; set; }
        public double? TienGiam { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
