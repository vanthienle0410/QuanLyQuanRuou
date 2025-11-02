-- XÓA DATABASE NẾU ĐÃ CÓ
IF DB_ID('QuanLyCuaHangRuou') IS NOT NULL
    DROP DATABASE QuanLyCuaHangRuou;
GO

-- TẠO DATABASE
CREATE DATABASE QuanLyCuaHangRuou;
GO
USE QuanLyCuaHangRuou;
GO

-- 1. BẢNG QUYỀN
CREATE TABLE Quyen (
    MaQuyen NVARCHAR(16) PRIMARY KEY,
    TenQuyen NVARCHAR(64) NOT NULL
);
GO

-- 2. BẢNG TÀI KHOẢN NHÂN VIÊN
CREATE TABLE TaiKhoan_NhanVien (
    MaTK_NV NVARCHAR(16) PRIMARY KEY,
    TenDangNhap NVARCHAR(64) NOT NULL,
    MatKhau NVARCHAR(64) NOT NULL,
    TenNV NVARCHAR(128) NOT NULL,
    SoDienThoai NVARCHAR(20),
    DiaChi NVARCHAR(128),
    MaQuyen NVARCHAR(16) NOT NULL FOREIGN KEY REFERENCES Quyen(MaQuyen)
);
GO

-- 3. BẢNG KHÁCH HÀNG
CREATE TABLE KhachHang (
    MaKH NVARCHAR(16) PRIMARY KEY,
    TenKH NVARCHAR(128) NOT NULL,
    SoDienThoai NVARCHAR(20),
    DiaChi NVARCHAR(128)
);
GO

-- 4. BẢNG ĐỒ UỐNG
CREATE TABLE DoUong (
    MaDo_Uong NVARCHAR(16) PRIMARY KEY,
    TenDo_Uong NVARCHAR(128) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    SoLuongTon DECIMAL(18,2),
    GhiChu NVARCHAR(256)
);
GO

-- 5. BẢNG HÓA ĐƠN
CREATE TABLE HoaDon (
    MaHD NVARCHAR(16) PRIMARY KEY,
    MaKH NVARCHAR(16) NOT NULL FOREIGN KEY REFERENCES KhachHang(MaKH),
    MaTK_NV NVARCHAR(16) NOT NULL FOREIGN KEY REFERENCES TaiKhoan_NhanVien(MaTK_NV),
    NgayHoaDon DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) DEFAULT 0,
    TrangThai CHAR(100) DEFAULT '0'
);
GO

-- 6. BẢNG CHI TIẾT HÓA ĐƠN
CREATE TABLE HoaDon_ChiTiet (
    MaHD NVARCHAR(16) NOT NULL FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaDo_Uong NVARCHAR(16) NOT NULL FOREIGN KEY REFERENCES DoUong(MaDo_Uong),
    DonGia DECIMAL(18,2) NOT NULL,
    SoLuong DECIMAL(18,2) NOT NULL,
    ThanhTien AS (DonGia * SoLuong) PERSISTED,
    CONSTRAINT PK_HoaDon_ChiTiet PRIMARY KEY (MaHD, MaDo_Uong)
);
GO
-- 7. BẢNG KÝ GỬI RƯỢU
CREATE TABLE KyGui_Ruou (
    MaKyGui NVARCHAR(16) PRIMARY KEY, -- Mã ký gửi duy nhất
    MaKH NVARCHAR(16) NOT NULL FOREIGN KEY REFERENCES KhachHang(MaKH), -- Khách hàng ký gửi
    TenRuou NVARCHAR(128) NOT NULL, -- Tên loại rượu
    DungTichConLai DECIMAL(18,2) NOT NULL, -- Dung tích/Thể tích còn lại
    DonViTinh NVARCHAR(10) NOT NULL, -- Đơn vị tính (ví dụ: 'ml', 'chai')
    NgayKyGui DATETIME DEFAULT GETDATE(), -- Ngày bắt đầu ký gửi
    HanKyGui DATETIME, -- Hạn chót lấy lại rượu (ví dụ: NgayKyGui + 30 ngày)
    ViTriLuuTru NVARCHAR(64), -- Vị trí cất giữ trong kho
    TrangThai NVARCHAR(30) NOT NULL -- Trạng thái: 'DANG_KY_GUI', 'DA_LAY_LAI', 'QUA_HAN'
);
GO

-- DỮ LIỆU MẪU
INSERT INTO Quyen (MaQuyen, TenQuyen)
VALUES (N'ADMIN', N'Quản trị viên'),
       (N'USER', N'Nhân viên');
GO

INSERT INTO TaiKhoan_NhanVien (MaTK_NV, TenDangNhap, MatKhau, TenNV, SoDienThoai, DiaChi, MaQuyen)
VALUES 
(N'ADMIN', N'admin', N'123', N'Quản trị viên', N'0909123456', N'Hồ Chí Minh', N'ADMIN'),
(N'NV01', N'tuanh', N'123', N'Tú Anh', N'0988999888', N'Bình Dương', N'USER'),
(N'NV02', N'minht', N'123', N'Minh Trí', N'0903344556', N'Vũng Tàu', N'USER');
GO

INSERT INTO KhachHang (MaKH, TenKH, SoDienThoai, DiaChi)
VALUES 
(N'KH01', N'Trần Văn A', N'0911222333', N'Vũng Tàu'),
(N'KH02', N'Lê Thị B', N'0988123456', N'Hồ Chí Minh'),
(N'KH03', N'Nguyễn Văn C', N'0903777888', N'Đồng Nai'),
(N'KH04', N'Phạm Quốc Dũng', N'0933445566', N'Bình Dương'),
(N'KH05', N'Trần Mỹ Linh', N'0919123456', N'Cần Thơ');
GO

INSERT INTO DoUong (MaDo_Uong, TenDo_Uong, DonGia, SoLuongTon, GhiChu)
VALUES 
(N'MOETCHANDON', N'Moet & Chandon', 250000, 50, N'Rượu vang Pháp cao cấp'),
(N'CHIVAS18', N'Chivas Regal 18', 1800000, 25, N'Whisky thượng hạng'),
(N'JACKDANIEL', N'Jack Daniel’s', 950000, 40, N'Whisky Mỹ'),
(N'HENNESSYVSOP', N'Hennessy VSOP', 2100000, 18, N'Cognac Pháp cao cấp'),
(N'GLENFIDDICH12', N'Glenfiddich 12', 1600000, 30, N'Scotch Whisky'),
(N'MACALLAN15', N'Macallan 15', 4200000, 12, N'Whisky quý hiếm'),
(N'SMERNOFF', N'Smirnoff Vodka', 450000, 60, N'Vodka Nga phổ biến'),
(N'ABSOLUT', N'Absolut Vodka', 500000, 55, N'Vodka Thụy Điển'),
(N'MARTELLXO', N'Martell XO', 3900000, 10, N'Cognac thượng hạng'),
(N'BALLANTINES', N'Ballantine’s 17', 2100000, 15, N'Scotch Whisky');
GO

INSERT INTO HoaDon (MaHD, MaKH, MaTK_NV, NgayHoaDon, TongTien, TrangThai)
VALUES 
(N'HD0001', N'KH01', N'NV01', GETDATE(), 4300000, '1'),
(N'HD0002', N'KH03', N'NV02', GETDATE(), 900000, '1'),
(N'HD0003', N'KH04', N'NV01', GETDATE(), 2100000, '0');
GO

INSERT INTO HoaDon_ChiTiet (MaHD, MaDo_Uong, DonGia, SoLuong)
VALUES
(N'HD0001', N'CHIVAS18', 1800000, 1),
(N'HD0001', N'GLENFIDDICH12', 1600000, 1),
(N'HD0001', N'SMERNOFF', 450000, 2),

(N'HD0002', N'JACKDANIEL', 950000, 1),

(N'HD0003', N'HENNESSYVSOP', 2100000, 1);
GO

INSERT INTO KyGui_Ruou (MaKyGui, MaKH, TenRuou, DungTichConLai, DonViTinh, NgayKyGui, HanKyGui, ViTriLuuTru, TrangThai)
VALUES
(N'KG001', N'KH01', N'Macallan 15', 450, N'ml', DATEADD(day, -10, GETDATE()), DATEADD(day, 20, GETDATE()), N'Tủ A, Kệ 01', N'DANG_KY_GUI'),
(N'KG002', N'KH02', N'Hennessy VSOP', 700, N'ml', DATEADD(day, -5, GETDATE()), DATEADD(day, 25, GETDATE()), N'Tủ A, Kệ 02', N'DANG_KY_GUI'),
(N'KG003', N'KH04', N'Martell XO', 1, N'chai', DATEADD(day, -60, GETDATE()), DATEADD(day, -30, GETDATE()), N'Tủ B, Kệ 01', N'QUA_HAN'),
(N'KG004', N'KH05', N'Chivas Regal 18', 300, N'ml', DATEADD(day, -45, GETDATE()), DATEADD(day, -15, GETDATE()), N'Tủ B, Kệ 02', N'DA_LAY_LAI'),
(N'KG005', N'KH03', N'Glenfiddich 12', 500, N'ml', DATEADD(day, -2, GETDATE()), DATEADD(day, 88, GETDATE()), N'Tủ C, Kệ 05', N'DANG_KY_GUI');
GO