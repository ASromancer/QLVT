using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class frmTaoTaiKhoan : Form
    {
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnChonMaNV_Click(object sender, EventArgs e)
        {
            Form frm = CheckExists(typeof(frmChonNhanVien));
            if (frm != null)
                frm.Activate();
            else
            {
                frmChonNhanVien f = new frmChonNhanVien();
                f.ShowDialog();
                this.txtMaNV.Text = Program.manvDaChon;
            }
        }

        private bool checkThongTin()
        {

            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Chưa chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK);
                btnChonMaNV.Focus();
                return false;
            }

            if (txtPass.Text == "")
            {
                MessageBox.Show("Mật khẩu trống", "Thông báo", MessageBoxButtons.OK);
                txtPass.Focus();
                return false;
            }

            if (txtPassConfirm.Text == "")
            {
                MessageBox.Show("Mật khẩu xác nhận trống", "Thông báo", MessageBoxButtons.OK);
                txtPassConfirm.Focus();
                return false;
            }

            if (txtPass.Text != txtPassConfirm.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp", "Thông báo", MessageBoxButtons.OK);
                txtPassConfirm.Focus();
                return false;
            }
            return true;
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            if (!checkThongTin())
                return;

            string hoTen = Program.hoTen.Trim();
            string pass = txtPass.Text.Trim();
            string manv = Program.manvDaChon;
            string vaitro = radioCHINHANH.Checked ? "CHINHANH" : "USER";

            string sql = "EXEC sp_TAOLOGIN '" + hoTen + "', '" + pass + "', '" +
                          manv + "', '" + vaitro + "'";
            SqlCommand sqlCmd = new SqlCommand(sql, Program.conn);
            try
            {
                Program.myReader = Program.ExecSqlDataReader(sql);

                if (Program.myReader == null)
                    return;
                MessageBox.Show("Tạo tài khoản thành công\n\nTài khoản: " + hoTen + "\nMật khẩu: "
                    + pass + "\n Mã Nhân Viên: " + manv + "\n Vai Trò: " + vaitro, "Thông Báo", MessageBoxButtons.OK);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo tài khoản thất bại!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            // cài sẵn password test cho lẹ
            txtPass.Text = "123";
            txtPassConfirm.Text = "123";

            if (Program.mGroup == "CONGTY")
            {
                radioCHINHANH.Enabled = false;
                radioUSER.Enabled = false;
            }
        }
    }
}
