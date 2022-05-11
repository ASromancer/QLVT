using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLVT
{
    static class Program
    {

        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
        public static String connstr_publisher = "Data Source=ASROMANCER;Initial Catalog=QLVT;Integrated Security=true";

        public static SqlDataReader myReader;
        public static String servername = "";
        public static String username = "";
        public static String loginName = ""; // mlogin
        public static String loginPassword = ""; // password


        /*Kết nối từ server hiện tại -> server 2 => dùng remoteLogin
          Kết nối từ server 2 -> server hiện tại => dùng currentLogin 
          Note: currentLogin & currentPassword chứa loginName & loginPassword 
          khi từ phân mảnh khác về phân mảnh hiện tại
         */
        public static String database = "QLVT";
        public static String remoteLogin = "HTKN";
        public static String remotePassword = "123";

        public static String currentLogin = "";//mloginDN
        public static String currentPassword = "";//passwordDN

        public static String mGroup = "";
        public static String mHoten = "";
        public static int mChiNhanh = 0;

        public static string manvDaChon = "";
        public static string hoTen = "";

        public static string maVTDaChon = "";
        public static int sluongTonVTDaChon = 0;

        public static string maKhoDuocChon = "";

        public static int soLuongVatTu = 0;
        public static string maDonDatHangDuocChon = "";
        public static string maDonDatHangDuocChonChiTiet = "";
        public static int donGia = 0;

        public static string maNhanVienDuocChon = "";
        public static string diaChi = "";
        public static string ngaySinh = "";

        public static BindingSource bds_dspm = new BindingSource(); // giữ các ds phân mảnh

        public static frmMain frmChinh;


        public static int Ketnoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" +
                    Program.database + ";User ID=" + Program.loginName + ";password=" +
                    Program.loginPassword;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối cở sở dữ liệu.\nXem lại tài khoản và mật khẩu.\n " + ex.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        //Thực hiện mà data trả vể chỉ để xem
        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader();
                return myreader;

            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //Thực hiện mà data trả về có thể thao tác được : thêm - sửa - xóa
        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        // Thực thi SP mà không trả về giá trị
        public static int ExecSqlNonQuery(String strlenh)
        {
            SqlCommand sqlcmd = new SqlCommand(strlenh, conn);
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandTimeout = 600;// 10 phut
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sqlcmd.ExecuteNonQuery(); conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Error converting data type varchar to int"))
                    MessageBox.Show("Bạn format Cell lại cột \"Ngày Thi\" qua kiểu Number hoặc mở File Excel.");
                else MessageBox.Show(ex.Message);
                conn.Close();
                return ex.State;

            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmChinh = new frmMain();
            Application.Run(frmChinh);
        }
    }
}
