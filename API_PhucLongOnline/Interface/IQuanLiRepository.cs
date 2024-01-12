using API_PhucLongOnline.Models;

namespace API_PhucLongOnline.Interface
{
    public interface IQuanLiRepository
    {
        IEnumerable<NhaCungCap> DanhSachNhaCungCap();
    }
}
