using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class frmChonNhanVien : Form
    {
        public frmChonNhanVien()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmChonNhanVien_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            DS.EnforceConstraints = false;
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);

            cbxCN.DataSource = Program.bds_dspm;/*sao chep bingding source tu form dang nhap*/
            cbxCN.DisplayMember = "TENCN";
            cbxCN.ValueMember = "TENSERVER";
            cbxCN.SelectedIndex = Program.mChiNhanh;

            if (Program.mGroup == "CONGTY")
            {
                cbxCN.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRowView drv = ((DataRowView)(bdsNV.Current));
            string maNhanVien = drv["MANV"].ToString().Trim();

            string ho = drv["HO"].ToString().Trim();
            string ten = drv["TEN"].ToString().Trim();
            string hoTen = ho + " " + ten;

            string ngaySinh = ((DateTime)drv["NGAYSINH"]).ToString("dd-MM-yyyy");
            string diaChi = drv["DIACHI"].ToString().Trim();

            Program.maNhanVienDuocChon = maNhanVien;
            Program.hoTen = hoTen;
            //Console.WriteLine(Program.hoTen);
            Program.ngaySinh = ngaySinh;
            Program.diaChi = diaChi;

            this.Close();
        }

        private void cbxCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCN.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            Program.servername = cbxCN.SelectedValue.ToString();

            // nếu server chọn != server đang kết nối thì dùng tài khoản HTKN
            if (cbxCN.SelectedIndex != Program.mChiNhanh)
            {
                Program.loginName = Program.remoteLogin;
                Program.loginPassword = Program.remotePassword;
            }
            else
            {
                Program.loginName = Program.currentLogin;
                Program.loginPassword = Program.currentPassword;
            }

            if (Program.Ketnoi() == 0)
            {
                MessageBox.Show("Xảy ra lỗi kết nối với chi nhánh hiện tại", "Thông báo", MessageBoxButtons.OK);
            }

            else
            {
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
            }
        }
    }
}

