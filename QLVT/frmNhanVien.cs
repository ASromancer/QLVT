using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        /* vitri được dùng để lưu lại vị trí dòng của nhân viên đang dứng, dùng trong btn undo
            Ex: đang đứng vtri thứ 2 ấn thêm NV, sau đó ấn btn undo thì phải
            quay trở lại vtri thứ 2.
         */
        int vitri = 0;
        String maCN = "";
        bool dangThemMoi = false;

        Stack undoList = new Stack();

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            /* Đặt nhân viên lên đầu vì nhân viên có trước sau đó đến ddh, pn px */
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);

            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

            maCN = ((DataRowView)bdsNV[0])["MACN"].ToString();
            cbxCN.DataSource = Program.bds_dspm;
            cbxCN.DisplayMember = "TENCN";
            cbxCN.ValueMember = "TENSERVER";
            cbxCN.SelectedIndex = Program.mChiNhanh;

            // nhóm CONGTY chỉ được xem dữ liệu
            if (Program.mGroup == "CONGTY")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnGhi.Enabled = false;
                btnHoanTac.Enabled = false;
                btnChuyenCN.Enabled = false;

                panelInputNV.Enabled = false;
            }

            // nhóm CHINHANH hoặc USER có thể thao tác dữ liệu nhưng không thể chọn chi nhánh
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cbxCN.Enabled = false;
                btnHoanTac.Enabled = false;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dangThemMoi = true;
            vitri = bdsNV.Position;
            this.bdsNV.AddNew();
            txtMaCN.Text = maCN.Trim();
            txtNgaySinh.EditValue = "";
            txtLuong.EditValue = 4000000; // để mặc định 4 triệu
            checkBoxTTS.Checked = false;

            btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnChuyenCN.Enabled = btnExit.Enabled = false;
            btnGhi.Enabled = btnHoanTac.Enabled = txtMaNV.Enabled = true;

            gcNhanVien.Enabled = false;
            panelInputNV.Enabled = true;
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi RELOAD: " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnHoanTac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dangThemMoi == true && btnThem.Enabled == false)
            {
                dangThemMoi = false;
                btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnChuyenCN.Enabled = btnExit.Enabled = btnGhi.Enabled = true;
                txtMaNV.Enabled = false;

                gcNhanVien.Enabled = true;
                panelInputNV.Enabled = true;

                bdsNV.CancelEdit();
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                bdsNV.Position = vitri;
            }
            else // nếu undoList vẫn còn stack lệnh thì lấy ra hoàn tác
            {
                string undoString = undoList.Pop().ToString();

                if(undoString.Contains("sp_CHUYENCN"))
                {

                    try
                    {
                        string serverHienTai = Program.servername;
                        string serverChuyenToi = Program.serverNameChuyenToi;

                        /* Kết nối qua bên kia để chạy sp hoàn tác*/
                        Program.servername = serverChuyenToi;
                        Program.loginName = Program.remoteLogin;
                        Program.loginPassword = Program.remotePassword;
                        if (Program.Ketnoi() == 0)
                        {
                            return;
                        }
                        Program.ExecSqlNonQuery(undoString);
                        MessageBox.Show("Chuyển nhân viên trở lại thành công", "Thông báo", MessageBoxButtons.OK);
                        Program.servername = serverHienTai;
                        Program.loginName = Program.currentLogin;
                        Program.loginPassword = Program.currentPassword;
                        if(Program.Ketnoi() == 0) /*Kết nối về lại server hiện tại*/
                        {
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chuyển nhân viên trở lại thất bại \n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                } 
                else /*lệnh khác không phải chuyển chi nhánh*/
                {
                    if (Program.Ketnoi() == 0)
                    {
                        return;
                    }
                    else
                    {
                        Program.ExecSqlNonQuery(undoString);
                    }
                }

                this.nhanVienTableAdapter.Fill(DS.NhanVien);
            }

            if (undoList.Count == 0)
            {
                btnHoanTac.Enabled = false;
            }

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string uname = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
            int manv = 0;
            if (uname == Program.username)
            {
                MessageBox.Show("Tài khoản này đang đăng nhập. Không thể xóa", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsNV.Count == 0)
            {
                MessageBox.Show("Không còn nhân viên nào để xóa", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsDDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa vì nhân viên này đã lập đơn đặt hàng", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa vì nhân viên này đã lập phiếu nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa vì nhân viên này đã lập phiếu xuất", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            DateTime ngaysinh = Convert.ToDateTime(((DataRowView)bdsNV[bdsNV.Position])["NGAYSINH"]);
            int trangthaixoa = checkBoxTTS.Checked ? 1 : 0;

            string undoString = string.Format("INSERT INTO DBO.NhanVien(MANV,HO,TEN,DIACHI,NGAYSINH,LUONG,MACN, TrangThaiXoa)" +
                " VALUES({0}, N'{1}', N'{2}', N'{3}', '{4}', {5}, N'{6}', {7})", txtMaNV.Text, txtHo.Text, txtTen.Text,
                txtDiaChi.Text, ngaysinh.ToString("dd-MM-yyyy"), txtLuong.EditValue, txtMaCN.Text.Trim(), trangthaixoa);

            undoList.Push(undoString);

            if (MessageBox.Show("Bạn có thật sự muôn xóa nhân viên này ?", "Xác nhận", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                try
                {
                    manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    bdsNV.RemoveCurrent();
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Update(this.DS.NhanVien);
                    MessageBox.Show("Xóa nhân viên thành công!\n", "", MessageBoxButtons.OK);

                    btnHoanTac.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa nhân viên, hãy xóa lại!\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                    bdsNV.Position = bdsNV.Find("MANV", manv);
                    return;
                }
            }
            else
            {
                undoList.Pop();
            }
        }

        private int CalculateAge(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;
            if (DateTime.Now.DayOfYear < dob.DayOfYear)
                age -= 1;
            return age;
        }

        private bool checkThongTin()
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Mã nhân viên trống", "Thông báo", MessageBoxButtons.OK);
                txtMaNV.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtMaNV.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Mã nhân viên chỉ chứa số", "Thông báo", MessageBoxButtons.OK);
                txtMaNV.Focus();
                return false;
            }

            if (txtHo.Text == "")
            {
                MessageBox.Show("Họ trống", "Thông báo", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtHo.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Họ chỉ chứa chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }
            if (txtHo.Text.Length > 40)
            {
                MessageBox.Show("Họ không quá 40 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }

            if (txtTen.Text == "")
            {
                MessageBox.Show("Tên trống", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtTen.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Tên chỉ chứa chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            if (txtTen.Text.Length > 10)
            {
                MessageBox.Show("Tên không quá 10 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }

            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ trống", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtDiaChi.Text, @"^[a-zA-Z\s,]+$"))
            {
                MessageBox.Show("Địa chỉ chỉ chứa chữ cái, dấu phẩy và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }
            if (txtDiaChi.Text.Length > 100)
            {
                MessageBox.Show("Địa không quá 100 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            if (CalculateAge(txtNgaySinh.DateTime) < 18)
            {
                MessageBox.Show("Nhân viên chưa đủ 18 tuổi", "Thông báo", MessageBoxButtons.OK);
                txtNgaySinh.Focus();
                return false;
            }

            if (Convert.ToDouble(txtLuong.EditValue) < 4000000)
            {
                MessageBox.Show("Lương tối thiểu là 4.000.000", "Thông báo", MessageBoxButtons.OK);
                txtLuong.Focus();
                return false;
            }

            return true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!checkThongTin())
                return;

            // lưu lại thông tin trước khi update của nhân viên để đưa vào lệnh hoàn tác
            DataRowView drv = (DataRowView)bdsNV[bdsNV.Position];
            string manv = txtMaNV.Text.Trim(),
                   ho = drv["HO"].ToString().Trim(),
                   ten = drv["TEN"].ToString().Trim(),
                   diachi = drv["DIACHI"].ToString().Trim(),
                   macn = maCN.Trim(); // mã chi nhánh sẽ có gtri của biến toàn cục maCN
            DateTime ngaysinh = (DateTime)drv["NGAYSINH"];
            double luong = Convert.ToDouble(drv["LUONG"]);
            int trangthaixoa = (int)drv["TrangThaiXoa"];

            /* Nếu đang thực hiện chức năng thêm thì
               mới kiểm tra tồn tại mã NV, còn hiệu chỉnh
               thông tin NV thì không càn kiểm tra
             */
            if (dangThemMoi)
            {
                // kiểm tra mã nhân viên tồn tại hay chưa
                string sql = "DECLARE @return_value int " +
                              "EXEC @return_value = [dbo].[sp_kiemTraTonTaiNhanVien] " +
                              "'" + manv + "' " +
                              "SELECT  'Return Value' = @return_value";
                //SqlCommand sqlCmd = new SqlCommand(sql, Program.conn);
                try
                {
                    Program.myReader = Program.ExecSqlDataReader(sql);

                    if (Program.myReader.Read() == false) // không có dòng nào
                    {
                        return;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int tonTai = Program.myReader.GetInt32(0); // 1 là có, 0 là chưa có
                Program.myReader.Close();

                if (tonTai == 1)
                {
                    MessageBox.Show("Mã nhân viên này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }

            // nếu chưa tồn tại mã nv đó thì tiến hành ghi vào DB
            if (MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnChuyenCN.Enabled
                    = btnExit.Enabled = btnHoanTac.Enabled = true;
                    //btnGhi.Enabled = false;
                    txtMaNV.Enabled = false;

                    gcNhanVien.Enabled = true;
                    panelInputNV.Enabled = true;

                    this.bdsNV.EndEdit();
                    this.bdsNV.ResetCurrentItem();
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Update(this.DS.NhanVien);

                    String undoString = "";

                    if (dangThemMoi)
                    {
                        undoString = "DELETE FROM NHANVIEN WHERE MANV = '" + manv + "'";
                    }
                    else
                    {
                        undoString = "UPDATE NhanVien SET " +
                                     "HO = '" + ho + "'," +
                                     "TEN = '" + ten + "'," +
                                     "DIACHI = '" + diachi + "'," +
                                     "NGAYSINH = '" + ngaysinh.ToString("dd-MM-yyyy") + "'," +
                                     "LUONG = " + luong + "," +
                                     "TrangThaiXoa = " + trangthaixoa + " " +
                                     "WHERE MANV = '" + manv + "'";
                    }
                    Console.WriteLine(undoString);
                    undoList.Push(undoString);
                    dangThemMoi = false;
                    MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK);

                }
                catch (Exception ex)
                {
                    this.bdsNV.RemoveCurrent();
                    MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        public void chuyenCN(String tenServer)
        {
            if(Program.servername == tenServer)
            {
                MessageBox.Show("Không thể chuyển vì nhân viên đang làm việc ở chi nhánh này, hãy chọn chi nhánh khác!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
            string maChiNhanhHienTai = "";
            string maChiNhanhMoi = "";

            if(tenServer.Contains("1"))
            {
                maChiNhanhHienTai = "CN2";
                maChiNhanhMoi = "CN1";
            } 

            else if(tenServer.Contains("2"))
            {
                maChiNhanhHienTai = "CN1";
                maChiNhanhMoi = "CN2";
            } 

            else
            {
                MessageBox.Show("Mã chi nhánh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string undoString = "EXEC sp_CHUYENCN " + maNV + ", '" + maChiNhanhHienTai + "'";
            undoList.Push(undoString);

            /* lưu lại tên server chuyển tới để sau này lấy ra remote sang đó để hoàn tác */
            Program.serverNameChuyenToi = tenServer; 

            string sql = "EXEC sp_CHUYENCN " + maNV + ", '" + maChiNhanhMoi + "'";
            try
            {
                Program.ExecSqlNonQuery(sql);
                MessageBox.Show("Chuyển chi nhánh thành công", "thông báo", MessageBoxButtons.OK);

                btnHoanTac.Enabled = true;

            } catch(Exception ex)
            {
                MessageBox.Show("Chuyển nhân viên thất bại!\n\n" + ex.Message, "thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
        }

        private void btnChuyenCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int vitri = bdsNV.Position;
            int tts = int.Parse(((DataRowView)bdsNV[vitri])["TrangThaiXoa"].ToString());
            string manv = ((DataRowView)bdsNV[vitri])["MANV"].ToString();

            if(manv == Program.username)
            {
                MessageBox.Show("Không thể chuyển chính người đang đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(tts == 1)
            {
                MessageBox.Show("Nhân viên này không có ở chi nhánh này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form frm = CheckExists(typeof(frmChuyenCN));

            if(frm != null)
            {
                frm.Activate();
            } else
            {
                frmChuyenCN f = new frmChuyenCN();
                f.Show();
                f.chuyenCNNV = new frmChuyenCN.chuyenChiNhanhNV(chuyenCN);

                
            }
            
        }
    }
}
