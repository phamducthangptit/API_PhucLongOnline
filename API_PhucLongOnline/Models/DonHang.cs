using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            CtDonHangs = new HashSet<CtDonHang>();
            HoaDons = new HashSet<HoaDon>();
        }

        public int IdDonHang { get; set; }
        public string? TrangThaiDonHang { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenDangNhap { get; set; } = null!;
        public int? IdHoaDon { get; set; }

        public virtual HoaDon? IdHoaDonNavigation { get; set; }
        public virtual ICollection<CtDonHang> CtDonHangs { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
