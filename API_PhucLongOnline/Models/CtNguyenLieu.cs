using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class CtNguyenLieu
    {
        public int IdCtnguyenLieu { get; set; }
        public int? IdNguyenLieu { get; set; }
        public string? MaNhaCungCap { get; set; }
        public DateTime? Ngay { get; set; }
        public double? Gia { get; set; }    

        public virtual NguyenLieu? IdNguyenLieuNavigation { get; set; }
        public virtual NhaCungCap? MaNhaCungCapNavigation { get; set; }
    }
}
