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
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private SqlConnection connPublisher = new SqlConnection();

        private void layDSPM(String cmd)
        {
            if (connPublisher.State == ConnectionState.Closed) connPublisher.Open();

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd, connPublisher);
            da.Fill(dt);

            connPublisher.Close();

            Program.bds_dspm.DataSource = dt;

            cbxChiNhanh.DataSource = Program.bds_dspm;
            cbxChiNhanh.DisplayMember = "TENCN";
            cbxChiNhanh.ValueMember = "TENSERVER";
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private int ketNoiDataBaseGoc()
        {
            if (connPublisher != null && connPublisher.State == ConnectionState.Open)
                connPublisher.Close();
            try
            {
                connPublisher.ConnectionString = Program.connstr_publisher;
                connPublisher.Open();
                return 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối cở sở dữ liệu.\nXem lại tài khoản và mật khẩu.\n " + ex.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (ketNoiDataBaseGoc() == 0)
                return;
            layDSPM("SELECT * FROM Get_Subscribes");
            cbxChiNhanh.SelectedIndex = 1;
            cbxChiNhanh.SelectedIndex = 0;

            // de test login cho nhanh, khỏi mất công gõ, có thể xóa đi
            txtLogin.Text = "TT";
            txtPass.Text = "123";
        }

        private void cbxChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cbxChiNhanh.SelectedValue.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "" || txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Login name và mật khẩu không được trống!", "", MessageBoxButtons.OK);
                return;
            }

            Program.loginName = txtLogin.Text.Trim();
            Program.loginPassword = txtPass.Text.Trim();

            if (Program.Ketnoi() == 0) return;

            Program.mChiNhanh = cbxChiNhanh.SelectedIndex; // lưu lại chi nhánh đã chọn lúc đăng nhập
            Program.currentLogin = Program.loginName;
            Program.currentPassword = Program.loginPassword;

            String sqlcmd = "EXEC SP_Lay_Thong_Tin_NV_Tu_Login '" + Program.loginName + "'";

            Program.myReader = Program.ExecSqlDataReader(sqlcmd);
            if (Program.myReader == null) return;
            Program.myReader.Read();

            Program.username = Program.myReader.GetString(0); // lay username
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Tài khoản này không có quyền truy cập \n Hãy thử tài khoản khác", "Thông Báo", MessageBoxButtons.OK);
                return;
            }

            Program.mHoten = Program.myReader.GetString(1); // lay ho ten
            Program.mGroup = Program.myReader.GetString(2); // lay nhom quyen
            Program.myReader.Close();
            Program.conn.Close();

            Program.frmChinh.MANV.Text = "MÃ NHÂN VIÊN: " + Program.username;
            Program.frmChinh.HOTEN.Text = "HỌ TÊN: " + Program.mHoten;
            Program.frmChinh.NHOM.Text = "NHÓM: " + Program.mGroup;

            // kích hoạt các phím chức năng dựa trên nhóm quyền
            Program.frmChinh.enableButtons();
            this.Visible = false;
        }

        private void txtLogin_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
