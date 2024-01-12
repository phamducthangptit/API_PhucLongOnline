using API_PhucLongOnline.Data;
using API_PhucLongOnline.Interface;
using API_PhucLongOnline.Models;

namespace API_PhucLongOnline.Repository
{
    public class QuanLiRepository : IQuanLiRepository
    {
        private readonly PhucLongOnlineContext _context;

        public QuanLiRepository(PhucLongOnlineContext context) { 
            _context = context;
        }
        public IEnumerable<NhaCungCap> DanhSachNhaCungCap()
        {
            var danhSachNhaCungCap = _context.NhaCungCaps.ToList();
            return danhSachNhaCungCap;
        }
    }
}
