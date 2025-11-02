using Microsoft.Reporting.WinForms;
using QuanLyCuaHangRuou_BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyCuaHangRuou_GUI
{ 
    public partial class frmReportHoaDon : Form
{
    private HoaDon_ChiTietBUS cthdBUS = new HoaDon_ChiTietBUS();
    private HoaDonBUS hdBUS = new HoaDonBUS();

    private string maHD; // ✅ Biến lưu mã hóa đơn cần in

    // ✅ Constructor có tham số
    public frmReportHoaDon(string maHD)
    {
        InitializeComponent();
        this.maHD = maHD;
    }

    private void frmReportHoaDon_Load(object sender, EventArgs e)
    {
        // ✅ Lấy chi tiết hóa đơn theo mã được truyền vào
        var listCTHD = cthdBUS.GetByMaHD(maHD);

        // ✅ Chuyển sang DataTable để đưa vào ReportViewer
        DataTable dt = new DataTable();
        dt.Columns.Add("MaHD");
        dt.Columns.Add("MaDo_Uong");
        dt.Columns.Add("DonGia");
        dt.Columns.Add("SoLuong");
        dt.Columns.Add("ThanhTien");

        foreach (var item in listCTHD)
        {
            dt.Rows.Add(item.MaHD, item.MaDo_Uong, item.DonGia, item.SoLuong, item.DonGia * item.SoLuong);
        }

        // ✅ Gán nguồn dữ liệu cho Report
        reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
        var rds = new ReportDataSource("DataSet1", dt);
        reportViewer1.LocalReport.DataSources.Clear();
        reportViewer1.LocalReport.DataSources.Add(rds);

        reportViewer1.RefreshReport();
    }
}
}