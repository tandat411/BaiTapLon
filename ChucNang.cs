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
    public partial class ChucNang : Form
    {
        public ChucNang()
        {
            InitializeComponent();
        }

        private void ChucNang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                e.Cancel = true;
        }

        private void ChucNang_Load(object sender, EventArgs e)
        {
            txtMSSV.Text = DangNhap.mssv;
            //ho
            string sqlHo = "SELECT Ho FROM SinhVien WHERE MaSinhVien ='" + DangNhap.mssv +"'";
            SqlCommand cmd1 = new SqlCommand(sqlHo, DangNhap.cn);
            cmd1.CommandType = CommandType.Text;
            string ho = (string)cmd1.ExecuteScalar();
            //ten
            string sqlTen = "SELECT Ten FROM SinhVien WHERE MaSinhVien ='" + DangNhap.mssv + "'";
            SqlCommand cmd2 = new SqlCommand(sqlTen, DangNhap.cn);
            cmd2.CommandType = CommandType.Text;
            string ten = (string)cmd2.ExecuteScalar();
            txtHoTen.Text = ho + " " + ten;
            //ngaysinh
            string sqlNgaySinh = "SELECT  Convert(nvarchar(10),NgaySinh,103) FROM SinhVien WHERE MaSinhVien ='" + DangNhap.mssv + "'";
            SqlCommand cmd3 = new SqlCommand(sqlNgaySinh, DangNhap.cn);
            cmd3.CommandType = CommandType.Text;
            txtNgaySinh.Text = Convert.ToString(cmd3.ExecuteScalar());
            //noisinh
            string sqlNoiSinh = "SELECT  NoiSinh FROM SinhVien WHERE MaSinhVien ='" + DangNhap.mssv + "'";
            SqlCommand cmd4 = new SqlCommand(sqlNoiSinh, DangNhap.cn);
            cmd4.CommandType = CommandType.Text;
            txtNoiSinh.Text = Convert.ToString(cmd4.ExecuteScalar());
            //Diachi
            string sqlDiaChi = "SELECT  DiaChi FROM SinhVien WHERE MaSinhVien ='" + DangNhap.mssv + "'";
            SqlCommand cmd5 = new SqlCommand(sqlDiaChi, DangNhap.cn);
            cmd5.CommandType = CommandType.Text;
            txtDiaChi.Text = Convert.ToString(cmd5.ExecuteScalar());
            //SDT
            string sqlSDT = "SELECT  DienThoai FROM SinhVien WHERE MaSinhVien ='" + DangNhap.mssv + "'";
            SqlCommand cmd6 = new SqlCommand(sqlSDT, DangNhap.cn);
            cmd6.CommandType = CommandType.Text;
            txtSDT.Text = Convert.ToString(cmd6.ExecuteScalar());
            //Khoa
            string sqlKhoa = "SELECT Khoa.TenKhoa FROM SinhVien, Khoa WHERE MaSinhVien ='" + DangNhap.mssv + "' and SinhVien.MaKhoa = Khoa.MaKhoa";
            SqlCommand cmd7 = new SqlCommand(sqlKhoa, DangNhap.cn);
            cmd7.CommandType = CommandType.Text;
            txtKhoa.Text = Convert.ToString(cmd7.ExecuteScalar());
            //NienKhoa
            string sqlNienKhoa = "SELECT  NienKhoa FROM SinhVien WHERE MaSinhVien ='" + DangNhap.mssv + "'";
            SqlCommand cmd8 = new SqlCommand(sqlNienKhoa, DangNhap.cn);
            cmd8.CommandType = CommandType.Text;
            txtNienKhoa.Text = Convert.ToString(cmd8.ExecuteScalar());
        }

        private void btXemDiem_Click(object sender, EventArgs e)
        {
            Xemdiem f = new Xemdiem();
            
            f.Show();
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            DKMH dk = new DKMH();
            dk.Show();
        }
    }
}
