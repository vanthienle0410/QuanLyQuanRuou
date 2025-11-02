namespace QuanLyCuaHangRuou_GUI
{
    // Lớp tĩnh để lưu trữ thông tin phiên đăng nhập
    public static class Session
    {
        // Lưu trữ Mã Quyền của người dùng hiện tại
        public static string MaQuyenHienTai { get; set; } = string.Empty;

        // Lưu trữ Mã TK_NV của người dùng hiện tại (Tùy chọn, nhưng hữu ích)
        public static string MaNhanVienHienTai { get; set; } = string.Empty;
    }
}