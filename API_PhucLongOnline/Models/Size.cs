using System;
using System.Collections.Generic;

namespace API_PhucLongOnline.Models
{
    public partial class Size
    {
        public Size()
        {
            CtSanPhamSizes = new HashSet<CtSanPhamSize>();
        }

        public int IdSize { get; set; }
        public string TenSize { get; set; } = null!;

        public virtual ICollection<CtSanPhamSize> CtSanPhamSizes { get; set; }
    }
}
