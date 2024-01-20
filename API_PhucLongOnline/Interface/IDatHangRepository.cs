using API_PhucLongOnline.DTO;
using API_PhucLongOnline.Models;

namespace API_PhucLongOnline.Interface
{
    public interface IDatHangRepository
    {
        IEnumerable<LoaiSanPham> DanhSachLoaiSanPham();
        IEnumerable<SanPhamDTO> DanhSachSanPham();

        SanPhamDTO GetTenVaHinhAnhSanPham(int id);

        IEnumerable<SizeDTO> DanhSachSizeSanPham(int id);

        double GetGiaTheoSanPhamVaSize(int idSanPham, int idSize);

        int CheckSanPhamTonTaiTrongGH(string tenDangNhap, int idSanPham, int idSize);

        int ThemSanPhamMoiVaoGH(string tenDangNhap, int idSanPham, int idSize, int soLuong);
        int ThemSoLuongSanPhamVaoGH(string tenDangNhap, int idSanPham, int idSize, int soLuong);

        int GetSoLuongSanPhamTrongGioHang(string tenDangNhap);

        IEnumerable<SanPhamTrongGHDTO> GetTatCaSanPhamTrongGH(string tenDangNhap);

        int DeleteSanPhamKhoiGH(string tenDangNhap, int idSanPhamSize);

        int TangSoLuongSanPhamTrongGioHang(string tenDangNhap, int idSanPhamSize);

        int GiamSoLuongSanPhamTrongGioHang(string tenDangNhap, int idSanPhamSize);

        List<int> DanhSachSanPhamTrongDonHang(string tenDangNhap);

        int ThemSanPhamVaoDonHang(string tenDangNhap, int idSanPhamSize);

        int TaoDonHang(string tenDangNhap);

        int TangSoLuongSPTrongDonHang(string tenDangNhap, int idSanPhamSize);
        int GiamSoLuongSPTrongDonHang(string tenDangNhap, int idSanPhamSize);

        int XoaSanPhamTrongDonHang(string tenDangNhap, int idSanPhamSize);

        List<int> TongSoLuongVaTongTienDonHang(string tenDangNhap);

        IEnumerable<SanPhamTrongDonHangDTO> TatSanPhamTrongDonHang(string tenDangNhap);

        int ThucHienTaoHoaDon(string tenDangNhap, string diaChi, string SDT);

        int TaoHoaDonThanhToanOnline(string tenDangNhap, string diaChi, string SDT);
        int ThaoTacHoaDonThanhToanOnline(string tenDangNhap, int code);

        IEnumerable<HoaDonDTO> DanhSachHoaDon(string tenDangNhap);

        IEnumerable<SanPhamTrongHoaDonDTO> DanhSachSanPhamTrongHoaDon(int IdDonHang);

        IEnumerable<DonHangDTO> DanhSachDonHang(string trangThai);
        int ThayDoiTrangThaiDonHang(int IdDonHang, string trangThai);

        int CheckNguyenLieu(int idSanPhamSize, int soLuong);
    }
}
