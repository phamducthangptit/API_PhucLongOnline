using API_PhucLongOnline.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_PhucLongOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatHangController : ControllerBase
    {
        private readonly PhucLongOnlineContext _context;

        public DatHangController(PhucLongOnlineContext context)
        {
            _context = context;
        }
    }
}
