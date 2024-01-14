using API_PhucLongOnline.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_PhucLongOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLiController : ControllerBase
    {
        private readonly IQuanLiRepository _quanLiRepository;

        public QuanLiController(IQuanLiRepository quanLiRepository) { 
            _quanLiRepository = quanLiRepository;
        }

        [HttpGet("danh-sach-nha-cung-cap")]
        public IActionResult danhSachNhaCungCap() {
            var danhSachNhaCungCap = _quanLiRepository.DanhSachNhaCungCap();
            return Ok(danhSachNhaCungCap);
        }
    }
}
