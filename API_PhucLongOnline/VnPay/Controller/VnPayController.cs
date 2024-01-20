using API_PhucLongOnline.Data;
using API_PhucLongOnline.Interface;
using API1.VnPay.Services;
using API1.VnPay.ViewModels;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API1.VnPay.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VnPayController : ControllerBase
    {
        private readonly PhucLongOnlineContext _context;
        private readonly IVnPayServices _vnPayService;
        private readonly IDatHangRepository _datHangRepository;
        

        public VnPayController(PhucLongOnlineContext context, IVnPayServices vnPayServices, IDatHangRepository datHangRepository) 
        {
            _context = context;
            _vnPayService = vnPayServices;
            _datHangRepository = datHangRepository;
        }

        [HttpPost("thanh-toan-don-hang/{tenDangNhap}/{soTien}/{diaChi}/{SDT}")]
        public IActionResult ThanhToanDonHang(string tenDangNhap, double soTien, string diaChi, string SDT)
        {
            var vnPayModel = new VnPaymentRequestModel
            {
                Amount = soTien,
                CreatedDate = DateTime.Now,
                Description = $"Thanh toán cho đơn hàng của Phúc Long",
                FullName = tenDangNhap,
                tenDangNhap = tenDangNhap,
                OrderId = new Random().Next(1000, 10000)
            };
            _datHangRepository.TaoHoaDonThanhToanOnline(tenDangNhap, diaChi, SDT);
            return Ok(new {url = _vnPayService.CreatePaymentUrl(HttpContext, vnPayModel)});
        }

        [HttpGet("PaymentCallBack")]
        public IActionResult PaymentBack()
        {
            var response = _vnPayService.PaymentExcute(Request.Query);
            var tenDangNhap = response.OrderDescription;
            if (response.VnPayResponseCode == "00")
            {
                
                _datHangRepository.ThaoTacHoaDonThanhToanOnline(tenDangNhap, 0);
                return Redirect("http://localhost:8080/lich-su-don-hang");
            }
            _datHangRepository.ThaoTacHoaDonThanhToanOnline(tenDangNhap, 1);
            return Redirect("http://localhost:8080/don-hang");
        }
    }
}
