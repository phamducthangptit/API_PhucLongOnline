using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int IdHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public double TongHoaDon { get; set; }
        public int? IdVoucher { get; set; }
        public int IdDonHang { get; set; }

        public virtual DonHang IdDonHangNavigation { get; set; } = null!;
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
