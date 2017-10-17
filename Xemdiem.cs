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
    public partial class Xemdiem : Form
    {
        public Xemdiem()
        {
            InitializeComponent();
        }

        private void Xemdiem_Load(object sender, EventArgs e)
        {
            DangNhap.cn.Open();
            //ho
            txtMSSV.Text = DangNhap.mssv;
            string sqlHo = "SELECT Ho FROM SinhVien WHERE MaSinhVien ='" + DangNhap.mssv + "'";
            SqlCommand cmd1 = new SqlCommand(sqlHo, DangNhap.cn);
            string ho = (string)cmd1.ExecuteScalar();
            //ten
            string sqlTen = "SELECT Ten FROM SinhVien WHERE MaSinhVien ='" + DangNhap.mssv + "'";
            SqlCommand cmd2 = new SqlCommand(sqlTen, DangNhap.cn);
            cmd2.CommandType = CommandType.Text;
            string ten = (string)cmd2.ExecuteScalar();
            txtHoten.Text = ho + " " + ten;
            //Khoa
            string sqlKhoa = "SELECT  TenKhoa FROM SinhVien,Khoa WHERE MaSinhVien ='" + DangNhap.mssv + "' and SinhVien.MaKhoa = Khoa.MaKhoa";
            SqlCommand cmd3 = new SqlCommand(sqlKhoa, DangNhap.cn);
            cmd3.CommandType = CommandType.Text;
            txtKhoa.Text = Convert.ToString(cmd3.ExecuteScalar());
            ///
            string sql= "SELECT * FROM SinhVien WHERE MaSinhVien ='" + txtMSSV.Text+"'";
            SqlCommand cmd4 = new SqlCommand(sql, DangNhap.cn);
            cmd4.CommandType = CommandType.Text;
            dlgXemdiem.DataSource = GetData();
        }
        private List<object> GetData()
        {
            //DangNhap.cn.Open();

            string sql = "SELECT * FROM Thi WHERE MaSinhVien ='" + DangNhap.mssv + "'";

            List<object> list = new List<object>();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DangNhap.cn);
                SqlDataReader dr = cmd.ExecuteReader();

                string maLop , maSinhVien, phongThi , caThi;
                double diemthiGK;
                double diemthiCK;
               // int c = Convert.ToInt32("diemthiCK");
                int lanthi;
                DateTime ngayThi;
                while (dr.Read())
                {
                    maLop = dr.GetString(0);
                    maSinhVien = dr.GetString(1);
                    lanthi = dr.GetInt32(2);
                   ngayThi = dr.GetDateTime(3);
                    phongThi = dr.GetString(4);
                    caThi = dr.GetString(5);
                    diemthiGK = dr.GetDouble(6);
                    diemthiCK = dr.GetDouble(7);
                    // ...

                    var prod = new
                    {
                        MaLop = maLop,
                        MSSV = maSinhVien,
                        LanThi = lanthi,
                       NgayThi = ngayThi,
                        PhongThi=phongThi,
                        Ca=caThi,
                       DiemThiGK=diemthiGK,
                       DiemThiCK=diemthiCK,
                    };
                    list.Add(prod);
                }
                dr.Close();
            }
            catch (SqlException ex) // Internet => Exception
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DangNhap.cn.Close();
            }
            return list;
        }

    }
}
