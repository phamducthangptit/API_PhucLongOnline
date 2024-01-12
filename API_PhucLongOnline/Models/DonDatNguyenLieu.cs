using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class DonDatNguyenLieu
    {
        public DonDatNguyenLieu()
        {
            CtDonDatHangs = new HashSet<CtDonDatHang>();
        }

        public int IdDonDatNguyenLieu { get; set; }
        public DateTime NgayDat { get; set; }
        public string? MaNhanVien { get; set; }

        public virtual NhanVien? MaNhanVienNavigation { get; set; }
        public virtual ICollection<CtDonDatHang> CtDonDatHangs { get; set; }
    }
}
