using API_PhucLongOnline.Data;
using API_PhucLongOnline.DTO;
using API_PhucLongOnline.Interface;
using API_PhucLongOnline.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_PhucLongOnline.Repository
{
    public class DatHangRepository : IDatHangRepository
    {
        private readonly PhucLongOnlineContext _context;
        private String connectString;

        public DatHangRepository(PhucLongOnlineContext context) {
            _context = context;
            connectString = "Data Source=MSI;Initial Catalog=PhucLongOnline;Integrated Security=True";
        }

        public int CheckNguyenLieu(int idSanPhamSize, int soLuong)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_CHECK_NGUYEN_LIEU", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IdSanPhamSize", SqlDbType.Int));
                    command.Parameters["@IdSanPhamSize"].Value = idSanPhamSize;
                    command.Parameters.Add(new SqlParameter("@SoLuongMon", SqlDbType.Int));
                    command.Parameters["@SoLuongMon"].Value = soLuong;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int check = 0;
                        while(reader.Read())
                        {
                            check = Convert.ToInt32(reader["DuNguyenLieu"]);
                        }
                        
                        return check;
                    }
                }
            }
        }

        public int CheckSanPhamTonTaiTrongGH(string tenDangNhap, int idSanPham, int idSize)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_CHECK_TON_TAI_SP_GH", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@IdSanPham", SqlDbType.Int));
                    command.Parameters["@IdSanPham"].Value = idSanPham;
                    command.Parameters.Add(new SqlParameter("@IdSize", SqlDbType.Int));
                    command.Parameters["@IdSize"].Value = idSize;
                    

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int soLuong = Convert.ToInt32(reader["SoLuong"]);
                            return soLuong;
                        }
                    }
                }
            }
            return 0;
        }

        public IEnumerable<DonHangDTO> DanhSachDonHang(string trangThai)
        {
            List<DonHangDTO> danhSachDonHang = new List<DonHangDTO>();
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GET_DANH_SACH_DON_HANG_THEO_TRANG_THAI", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TrangThai", SqlDbType.NVarChar));
                    command.Parameters["@TrangThai"].Value = trangThai;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DonHangDTO donHang = new DonHangDTO
                            {
                                IdDonHang = Convert.ToInt32(reader["IdDonHang"]),
                                NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                                TrangThaiDonHang = reader["TrangThaiDonHang"].ToString()
                            };

                            danhSachDonHang.Add(donHang);
                        }
                    }
                }
            }
            return danhSachDonHang;
        }

        public IEnumerable<HoaDonDTO> DanhSachHoaDon(string tenDangNhap)
        {
            List<HoaDonDTO> danhSachHoaDon = new List<HoaDonDTO>();
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_DANH_SACH_HOA_DON", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoaDonDTO hoaDon = new HoaDonDTO
                            {
                                NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                                TongHoaDon = Convert.ToDouble(reader["TongHoaDon"]),
                                DiaChi = reader["DiaChi"].ToString(),
                                SDT = reader["SDT"].ToString(),
                                IdDonHang = Convert.ToInt32(reader["IdDonHang"])
                            };

                            danhSachHoaDon.Add(hoaDon);
                        }
                    }
                }
            }
            return danhSachHoaDon;
        }


        public IEnumerable<LoaiSanPham> DanhSachLoaiSanPham()
        {
            var danhSachLSP = _context.LoaiSanPhams.ToList();
            return danhSachLSP;
        }

        public IEnumerable<SanPhamDTO> DanhSachSanPham()
        {
            List<SanPhamDTO> danhSachSanPham = new List<SanPhamDTO>();
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GET_DANH_SACH_SAN_PHAM", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamDTO sanPham = new SanPhamDTO
                            {
                                IdLoaiSanPham = Convert.ToInt32(reader["IdLoaiSanPham"]),
                                IdSanPham = Convert.ToInt32(reader["IdSanPham"]),
                                TenSanPham = reader["TenSanPham"].ToString(),
                                HinhAnh = reader["HinhAnh"].ToString(),
                                GiaMin = Convert.ToDouble(reader["GiaMin"]),
                                GiaMax = Convert.ToDouble(reader["GiaMax"])
                            };

                            danhSachSanPham.Add(sanPham);
                        }
                    }
                }
            }
            return danhSachSanPham;
        }

        public List<int> DanhSachSanPhamTrongDonHang(string tenDangNhap)
        {
            List<int> result = new List<int>();
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_DANH_SACH_SAN_PHAM_TRONG_DON_HANG", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           int id = Convert.ToInt32(reader["IdSanPhamSize"]);

                            result.Add(id);
                        }
                    }
                }
            }
            return result;
        }

        public IEnumerable<SanPhamTrongHoaDonDTO> DanhSachSanPhamTrongHoaDon(int IdDonHang)
        {
            List<SanPhamTrongHoaDonDTO> danhSachSanPhamTrongHD = new List<SanPhamTrongHoaDonDTO>();
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_CHI_TIET_HOA_DON", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IdDonHang", SqlDbType.NVarChar));
                    command.Parameters["@IdDonHang"].Value = IdDonHang;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamTrongHoaDonDTO sanPham = new SanPhamTrongHoaDonDTO
                            {
                                tenSanPham = reader["TenSanPham"].ToString(),
                                hinhAnh = reader["HinhAnh"].ToString(),
                                tenSize = reader["TenSize"].ToString(),
                                soLuong = Convert.ToInt32(reader["SoLuong"]),
                                giaBan = Convert.ToDouble(reader["GiaBan"]),
                                thanhTien = Convert.ToDouble(reader["ThanhTien"]),
                            };

                            danhSachSanPhamTrongHD.Add(sanPham);
                        }
                    }
                }
            }
            return danhSachSanPhamTrongHD;
        }

        public IEnumerable<SizeDTO> DanhSachSizeSanPham(int id)
        {
            List<SizeDTO> sizeSanPham = new List<SizeDTO>();

            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GET_SIZE_BY_IDSANPHAM", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IdSanPham", SqlDbType.Int));
                    command.Parameters["@IdSanPham"].Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SizeDTO size = new SizeDTO
                            {
                                IdSize = Convert.ToInt32(reader["IdSize"]),
                                TenSize = reader["TenSize"].ToString()
                            };

                            sizeSanPham.Add(size);
                        }
                    }
                }
            }

            return sizeSanPham;
        }

        public int DeleteSanPhamKhoiGH(string tenDangNhap, int idSanPhamSize)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_DELETE_SP_KHOI_GH", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@IdSanPhamSize", SqlDbType.Int));
                    command.Parameters["@IdSanPhamSize"].Value = idSanPhamSize;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return 1;
                    }
                }
            }
        }

        public double GetGiaTheoSanPhamVaSize(int idSanPham, int idSize)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GET_GIA_BY_ID_AND_SIZE", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IdSize", SqlDbType.Int));
                    command.Parameters["@IdSize"].Value = idSize;
                    command.Parameters.Add(new SqlParameter("@IdSanPham", SqlDbType.Int));
                    command.Parameters["@IdSanPham"].Value = idSanPham;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double giaTheoSize = Convert.ToDouble(reader["GiaHienThoi"]);
                            return giaTheoSize;
                        }
                    }
                }
            }
            return 0;
        }

        public int GetSoLuongSanPhamTrongGioHang(string tenDangNhap)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GET_SO_LUONG_SP_TRONG_GH", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read()) 
                        {
                            int soLuongSanPham = Convert.ToInt32(reader["SoLuongSanPham"]);
                            return soLuongSanPham;
                        }
                        
                    }
                }
            }
            return 0;
        }

        public IEnumerable<SanPhamTrongGHDTO> GetTatCaSanPhamTrongGH(string tenDangNhap)
        {
            List<SanPhamTrongGHDTO> sanPhamTrongGH = new List<SanPhamTrongGHDTO>();
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GET_TAT_CA_SAN_PHAM_TRONG_GH", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamTrongGHDTO sanPham = new SanPhamTrongGHDTO
                            {
                                idSanPhamSize = Convert.ToInt32(reader["IdSanPhamSize"]),
                                tenSanPham = reader["TenSanPham"].ToString(),
                                hinhAnh = reader["HinhAnh"].ToString(),
                                tenSize = reader["TenSize"].ToString(),
                                giaHienThoi = Convert.ToDouble(reader["GiaHienThoi"]),
                                soLuong = Convert.ToInt32(reader["SoLuong"])
                            };

                            sanPhamTrongGH.Add(sanPham);
                        }
                    }
                }
            }
            return sanPhamTrongGH;
        }

        public SanPhamDTO GetTenVaHinhAnhSanPham(int id)
        {
            SanPhamDTO sanPham;
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GET_ANH_TEN_SAN_PHAM_BY_ID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IdSanPham", SqlDbType.Int));
                    command.Parameters["@IdSanPham"].Value = id;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sanPham = new SanPhamDTO
                            {
                                TenSanPham = reader["TenSanPham"].ToString(),
                                HinhAnh = reader["HinhAnh"].ToString(),
                            };
                            return sanPham;
                        }
                    }
                }
            }
            return null;
        }

        public int GiamSoLuongSanPhamTrongGioHang(string tenDangNhap, int idSanPhamSize)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GIAM_SO_LUONG_SAN_PHAM_TRONG_GH", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@IdSanPhamSize", SqlDbType.Int));
                    command.Parameters["@IdSanPhamSize"].Value = idSanPhamSize;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return 1;
                    }
                }
            }
        }

        public int GiamSoLuongSPTrongDonHang(string tenDangNhap, int idSanPhamSize)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GIAM_SO_LUONG_SP_TRONG_DH", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@IdSanPhamSize", SqlDbType.Int));
                    command.Parameters["@IdSanPhamSize"].Value = idSanPhamSize;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return 1;
                    }
                }
            }
        }

        public int TangSoLuongSanPhamTrongGioHang(string tenDangNhap, int idSanPhamSize)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_TANG_SO_LUONG_SAN_PHAM_TRONG_GH", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@IdSanPhamSize", SqlDbType.Int));
                    command.Parameters["@IdSanPhamSize"].Value = idSanPhamSize;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return 1;
                    }
                }
            }
        }

        public int TangSoLuongSPTrongDonHang(string tenDangNhap, int idSanPhamSize)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_TANG_SO_LUONG_SP_TRONG_DH", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@IdSanPhamSize", SqlDbType.Int));
                    command.Parameters["@IdSanPhamSize"].Value = idSanPhamSize;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return 1;
                    }
                }
            }
        }

        public int TaoDonHang(string tenDangNhap)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_TAO_DON_HANG_CTT", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return 1;
                    }
                }
            }
        }

        public int TaoHoaDonThanhToanOnline(string tenDangNhap, string diaChi, string SDT)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();
                // lập hóa đơn thanh toán online
                using (SqlCommand command = new SqlCommand("SP_THUC_HIEN_LAP_HOA_DON_THANH_TOAN_ONLINE", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@Diachi", SqlDbType.NVarChar));
                    command.Parameters["@Diachi"].Value = diaChi;
                    command.Parameters.Add(new SqlParameter("@SDT", SqlDbType.NVarChar));
                    command.Parameters["@SDT"].Value = SDT;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
            return 1;
        }

        public IEnumerable<SanPhamTrongDonHangDTO> TatSanPhamTrongDonHang(string tenDangNhap)
        {
            List<SanPhamTrongDonHangDTO> sanPhamTrongDH = new List<SanPhamTrongDonHangDTO>();
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GET_SAN_PHAM_TRONG_DON_HANG", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamTrongDonHangDTO sanPham = new SanPhamTrongDonHangDTO
                            {
                                idSanPhamSize = Convert.ToInt32(reader["IdSanPhamSize"]),
                                tenSanPham = reader["TenSanPham"].ToString(),
                                hinhAnh = reader["HinhAnh"].ToString(),
                                tenSize = reader["TenSize"].ToString(),
                                giaBan = Convert.ToDouble(reader["GiaBan"]),
                                soLuong = Convert.ToInt32(reader["SoLuong"])
                            };

                            sanPhamTrongDH.Add(sanPham);
                        }
                    }
                }
            }
            return sanPhamTrongDH;
        }

        public int ThaoTacHoaDonThanhToanOnline(string tenDangNhap, int code)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();
                // lập hóa đơn thanh toán online
                using (SqlCommand command = new SqlCommand("SP_THAO_TAC_HOA_DON_THANH_TOAN_ONLINE", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@Code", SqlDbType.Int));
                    command.Parameters["@Code"].Value = code;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
            return 1;
        }

        public int ThayDoiTrangThaiDonHang(int IdDonHang, string trangThai)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_THAY_DOI_TRANG_THAI_DON_HANG", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IdDonHang", SqlDbType.Int));
                    command.Parameters["@IdDonHang"].Value = IdDonHang;
                    command.Parameters.Add(new SqlParameter("@TrangThai", SqlDbType.NVarChar));
                    command.Parameters["@TrangThai"].Value = trangThai;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return 1;
                    }
                }
            }
        }

        public int ThemSanPhamMoiVaoGH(string tenDangNhap, int idSanPham, int idSize, int soLuong)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_ADD_SAN_PHAM_MOI_VAO_GH", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@IdSanPham", SqlDbType.Int));
                    command.Parameters["@IdSanPham"].Value = idSanPham;
                    command.Parameters.Add(new SqlParameter("@IdSize", SqlDbType.Int));
                    command.Parameters["@IdSize"].Value = idSize;
                    command.Parameters.Add(new SqlParameter("@SoLuong", SqlDbType.Int));
                    command.Parameters["@SoLuong"].Value = soLuong;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return 1;
                    }
                }
            }
        }

        public int ThemSanPhamVaoDonHang(string tenDangNhap, int idSanPhamSize)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_ADD_SAN_PHAM_VAO_DON_HANG", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@IdSanPhamSize", SqlDbType.Int));
                    command.Parameters["@IdSanPhamSize"].Value = idSanPhamSize;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return 1;
                    }
                }
            }
        }

        public int ThemSoLuongSanPhamVaoGH(string tenDangNhap, int idSanPham, int idSize, int soLuong)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_ADD_THEM_SO_LUONG_SAN_PHAM_VAO_GH", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@IdSanPham", SqlDbType.Int));
                    command.Parameters["@IdSanPham"].Value = idSanPham;
                    command.Parameters.Add(new SqlParameter("@IdSize", SqlDbType.Int));
                    command.Parameters["@IdSize"].Value = idSize;
                    command.Parameters.Add(new SqlParameter("@SoLuong", SqlDbType.Int));
                    command.Parameters["@SoLuong"].Value = soLuong;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return 1;
                    }
                }
            }
        }

        public int ThucHienTaoHoaDon(string tenDangNhap, string diaChi, string SDT)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();
                // lập hóa đơn trước
                using (SqlCommand command = new SqlCommand("SP_THUC_HIEN_LAP_HOA_DON", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@Diachi", SqlDbType.NVarChar));
                    command.Parameters["@Diachi"].Value = diaChi;
                    command.Parameters.Add(new SqlParameter("@SDT", SqlDbType.NVarChar));
                    command.Parameters["@SDT"].Value = SDT;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
            // xóa sản phẩm đặt trong gh
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();
                // lập hóa đơn trước
                using (SqlCommand command = new SqlCommand("SP_XOA_SAN_PHAM_DA_DAT_KHOI_GIO_HANG", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
            //Update id hóa đơn trong đơn hàng
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SP_UPDATE_HOA_DON_CUA_DON_HANG", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
            return 1;
        }

        public List<int> TongSoLuongVaTongTienDonHang(string tenDangNhap)
        {
            List<int> result = new List<int>();
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_TONG_SO_LUONG_VA_TIEN_DON_HANG", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tongSoLuong = Convert.ToInt32(reader["TongSoLuong"]);
                            int tongTien = Convert.ToInt32(reader["TongTien"]);
                            result.Add(tongSoLuong);
                            result.Add(tongTien);
                        }
                       
                    }
                }
            }
            return result;
        }

        public int XoaSanPhamTrongDonHang(string tenDangNhap, int idSanPhamSize)
        {
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_DELETE_SP_TRONG_DON_HANG", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenDangNhap", SqlDbType.NVarChar));
                    command.Parameters["@TenDangNhap"].Value = tenDangNhap;
                    command.Parameters.Add(new SqlParameter("@IdSanPhamSize", SqlDbType.Int));
                    command.Parameters["@IdSanPhamSize"].Value = idSanPhamSize;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return 1;
                    }
                }
            }
        }
    }
}
