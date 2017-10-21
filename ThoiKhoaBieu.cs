using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLSV
{
    public partial class ThoiKhoaBieu : Form
    {
        public ThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void ThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select MonHoc.TenMH as N'Môn học',Lop.NgayBatDauHoc as N'Ngày bắt đầu học', Datename(DW,Lop.NgayBatDauHoc) as N'Thứ', Lop.PhongHoc as N'Phòng Học',Lop.TietBatDau as N'Tiết bắt đầu'
                                              from Lop, MonHoc , DangKy
                                              where Lop.MaMH = MonHoc.MaMH and DangKy.MaLop = Lop.MaLop and DangKy.MaSinhVien = '" + DangNhap.mssv + "'", DangNhap.cn);
            da.Fill(tb);
            dataGridView1.DataSource = tb;
        }
    }
}
