using API_PhucLongOnline.Data;
using API_PhucLongOnline.Interface;
using API_PhucLongOnline.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_PhucLongOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatHangController : ControllerBase
    {
        private readonly IDatHangRepository _datHangRepository;

        public DatHangController(IDatHangRepository datHangRepository)
        {
            _datHangRepository = datHangRepository;
        }

        [HttpGet("danh-sach-loai-san-pham")]
        public IActionResult DanhSachLoaiSanPham()
        {
            return Ok(_datHangRepository.DanhSachLoaiSanPham());
        }

        [HttpGet("danh-sach-san-pham")]
        public IActionResult DanhSachSanPham()
        {
            var danhSachSanPham = _datHangRepository.DanhSachSanPham();
            return Ok(danhSachSanPham);
        }

        [HttpGet("get-ten-va-hinh-anh")]
        public IActionResult TenVaAnhSanPham(int id)
        {
            var sanPham = _datHangRepository.GetTenVaHinhAnhSanPham(id);
            return Ok(sanPham);
        }

        [HttpGet("get-size-san-pham")]
        public IActionResult GetSizeSanPham(int id)
        {
            var size = _datHangRepository.DanhSachSizeSanPham(id);
            return Ok(size);
        }

        [HttpGet("get-gia-theo-san-pham-va-size")]
        public IActionResult GetGiaTheoSanPhamVaSize(int idSanPham, int idSize)
        {
            var giaHienTai = _datHangRepository.GetGiaTheoSanPhamVaSize(idSanPham, idSize);
            return Ok(giaHienTai);
        }

        [HttpGet("check-ton-tai-san-pham-trong-gh")]
        public IActionResult CheckSanPhamTonTaiTrongGH(string tenDangNhap, int idSanPham, int idSize)
        {
            
            var soLuong = _datHangRepository.CheckSanPhamTonTaiTrongGH(tenDangNhap, idSanPham, idSize);
            return Ok(new { SoLuong = soLuong });
        }

        [HttpGet("them-san-pham-moi-vao-gh")]
        public IActionResult ThemSanPhamMoiVaoGH(string tenDangNhap, int idSanPham, int idSize, int soLuong)
        {
            var check = _datHangRepository.ThemSanPhamMoiVaoGH(tenDangNhap, idSanPham, idSize, soLuong);
            return Ok(new { Check = check });
        }

        [HttpGet("them-so-luong-san-pham-vao-gh")]
        public IActionResult ThemSoLuongSanPhamVaoGH(string tenDangNhap, int idSanPham, int idSize, int soLuong)
        {
            var check = _datHangRepository.ThemSoLuongSanPhamVaoGH(tenDangNhap, idSanPham, idSize, soLuong);
            return Ok(new { Check = check });
        }

        [HttpGet("get-so-luong-san-pham-trong-gio-hang")]
        public IActionResult GetSoLuongSanPhamTrongGioHang(string tenDangNhap)
        {
            var soLuong = _datHangRepository.GetSoLuongSanPhamTrongGioHang(tenDangNhap);
            return Ok(new { SoLuongSanPhamTrongGH = soLuong });
        }


        [HttpGet("get-tat-ca-san-pham-trong-gh")]
        public IActionResult GetTatCaSanPhamTrongGH(string tenDangNhap)
        {
            var sanPhamTrongGH = _datHangRepository.GetTatCaSanPhamTrongGH(tenDangNhap);
            return Ok(sanPhamTrongGH);
        }

        [HttpGet("delete-san-pham-khoi-gio-hang")]
        public IActionResult DeleteSanPhamKhoiGioHang(string tenDangNhap, int idSanPhamSize)
        {
            var check = _datHangRepository.DeleteSanPhamKhoiGH(tenDangNhap, idSanPhamSize);
            var sanPhamTrongGH = _datHangRepository.GetTatCaSanPhamTrongGH(tenDangNhap);
            return Ok(sanPhamTrongGH);
        }

        [HttpGet("tang-so-luong-san-pham-trong-gio-hang")]
        public IActionResult TangSoLuongSanPhamTrongGioHang(string tenDangNhap, int idSanPhamSize)
        {
            var check = _datHangRepository.TangSoLuongSanPhamTrongGioHang(tenDangNhap, idSanPhamSize);
            var sanPhamTrongGH = _datHangRepository.GetTatCaSanPhamTrongGH(tenDangNhap);
            return Ok(sanPhamTrongGH);
        }

        [HttpGet("giam-so-luong-san-pham-trong-gio-hang")]
        public IActionResult GiamSoLuongSanPhamTrongGioHang(string tenDangNhap, int idSanPhamSize)
        {
            var check = _datHangRepository.GiamSoLuongSanPhamTrongGioHang(tenDangNhap, idSanPhamSize);
            var sanPhamTrongGH = _datHangRepository.GetTatCaSanPhamTrongGH(tenDangNhap);
            return Ok(sanPhamTrongGH);
        }

        [HttpGet("danh-sach-san-pham-trong-don-hang")]
        public IActionResult DanhSachSanPhamTrongDonHang(string tenDangNhap)
        {
            var result = _datHangRepository.DanhSachSanPhamTrongDonHang(tenDangNhap);
            return Ok(result);
        }

        [HttpGet("tao-don-hang")]
        public IActionResult TaoDonHang(string tenDangNhap)
        {
            var check = _datHangRepository.TaoDonHang(tenDangNhap);
            return Ok(new { Check = check });
        }

        [HttpGet("them-san-pham-vao-don-hang")]
        public IActionResult ThemSanPhamVaoDonHang(string tenDangNhap, int idSanPhamSize)
        {
            var check = _datHangRepository.ThemSanPhamVaoDonHang(tenDangNhap, idSanPhamSize);
            
            return Ok(new { Check = check });
        }

        [HttpGet("tang-so-luong-san-pham-trong-don-hang")]
        public IActionResult TangSoLuongSanPhamTrongDonHang(string tenDangNhap, int idSanPhamSize)
        {
            var check = _datHangRepository.TangSoLuongSPTrongDonHang(tenDangNhap, idSanPhamSize);

            return Ok(new { Check = check });
        }

        [HttpGet("giam-so-luong-san-pham-trong-don-hang")]
        public IActionResult GiamSoLuongSanPhamTrongDonHang(string tenDangNhap, int idSanPhamSize)
        {
            var check = _datHangRepository.GiamSoLuongSPTrongDonHang(tenDangNhap, idSanPhamSize);

            return Ok(new { Check = check });
        }

        [HttpGet("xoa-san-pham-trong-don-hang")]
        public IActionResult XoaSanPhamTrongDonHang(string tenDangNhap, int idSanPhamSize)
        {
            var check = _datHangRepository.XoaSanPhamTrongDonHang(tenDangNhap, idSanPhamSize);

            return Ok(new { Check = check });
        }

        [HttpGet("tong-so-luong-va-tien-don-hang")]
        public IActionResult TongSoLuongVaTienDonhang(string tenDangNhap)
        {
            List<int> result = _datHangRepository.TongSoLuongVaTongTienDonHang(tenDangNhap);

            return Ok(new { TongSoLuong = result[0] , TongTien = result[1] });
        }

        [HttpGet("tat-ca-san-pham-trong-don-hang")]
        public IActionResult GetTatCaSanPhamTrongDonHang(string tenDangNhap)
        {
            var tatCaSanPhamTrongDH = _datHangRepository.TatSanPhamTrongDonHang(tenDangNhap);

            return Ok(tatCaSanPhamTrongDH);
        }

        [HttpGet("thuc-hien-tao-hoa-don")]
        public IActionResult ThucHienTaoHoaDon(string tenDangNhap, string diaChi, string SDT)
        {
            var check = _datHangRepository.ThucHienTaoHoaDon(tenDangNhap, diaChi, SDT);
            return Ok(new { Check = check });
        }

        [HttpGet("danh-sach-hoa-don")]
        public IActionResult DanhSachHoaDon(string tenDangNhap)
        {
            var danhSachHoaDon = _datHangRepository.DanhSachHoaDon(tenDangNhap);
            return Ok(danhSachHoaDon);
        }
        [HttpGet("chi-tiet-hoa-don")]
        public IActionResult ChiTietHoaDon(int idDonHang)
        {
            var tmp = _datHangRepository.DanhSachSanPhamTrongHoaDon(idDonHang);
            return Ok(tmp);
        }
    }
}
