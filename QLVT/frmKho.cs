using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class frmKho : Form
    {
        /* vitri được dùng để lưu lại vị trí dòng của VT đang dứng, dùng trong btn undo
            Ex: đang đứng vtri thứ 2 ấn thêm VT, sau đó ấn btn undo thì phải
            quay trở lại vtri thứ 2.
         */
        int vitri = 0;
        String maCN = "";
        bool dangThemMoi = false;

        Stack undoList = new Stack();
        public frmKho()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS.Kho);

            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

            cbxCN.DataSource = Program.bds_dspm;
            cbxCN.DisplayMember = "TENCN";
            cbxCN.ValueMember = "TENSERVER";
            cbxCN.SelectedIndex = Program.mChiNhanh;

            maCN = ((DataRowView)bdsKho[0])["MACN"].ToString();
            // nhóm CONGTY chỉ được xem dữ liệu
            if (Program.mGroup == "CONGTY")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnGhi.Enabled = false;
                btnHoanTac.Enabled = false;

                panelInputKho.Enabled = false;
            }

            // nhóm CHINHANH hoặc USER có thể thao tác dữ liệu nhưng không thể chọn chi nhánh
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cbxCN.Enabled = false;
                btnHoanTac.Enabled = false;
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
                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.DS.Kho);
            }
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.khoTableAdapter.Fill(this.DS.Kho);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi RELOAD: " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dangThemMoi = true;
            vitri = bdsKho.Position; // lưu lại vị trí đang đứng
            this.bdsKho.AddNew();
            txtMaCN.Text = maCN.Trim();

            btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnExit.Enabled = false;
            btnGhi.Enabled = btnHoanTac.Enabled = txtMaKho.Enabled = true;

            gcKho.Enabled = false;
            panelInputKho.Enabled = true;
        }

        private void btnHoanTac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dangThemMoi == true && btnThem.Enabled == false)
            {
                dangThemMoi = false;
                btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnExit.Enabled = btnGhi.Enabled = true;
                txtMaKho.Enabled = false;

                gcKho.Enabled = true;
                panelInputKho.Enabled = true;

                bdsKho.CancelEdit();
                this.khoTableAdapter.Fill(this.DS.Kho);
                bdsKho.Position = vitri;

            }
            else // nếu undoList vẫn còn stack lệnh thì lấy ra hoàn tác
            {
                string undoString = undoList.Pop().ToString();

                if (Program.Ketnoi() == 0)
                {
                    return;
                }
                else
                {
                    int n = Program.ExecSqlNonQuery(undoString);
                }
                this.khoTableAdapter.Fill(DS.Kho);
            }

            if (undoList.Count == 0)
            {
                btnHoanTac.Enabled = false;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsKho.Count == 0)
            {
                MessageBox.Show("Không còn kho để xóa", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if(bdsDDH.Count > 0)
            {
                MessageBox.Show("Không xóa kho vì đã lập đơn đặt hàng", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không xóa kho vì đã lập phiếu nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsPX.Count > 0)
            {
                MessageBox.Show("Không xóa kho vì đã lập phiếu xuất", "Thông báo", MessageBoxButtons.OK);
                return;
            }


            String undoString = "INSERT INTO Kho(MAKHO, TENKHO, DIACHI, MACN) " +
                                "VALUES ('" + txtMaKho.Text.Trim()  + "', '" +
                                            txtTen.Text.Trim() + "', '" +
                                            txtDiaChi.Text.Trim() + "', '" +
                                            txtMaCN.Text.Trim() + "')";
            undoList.Push(undoString);

            if (MessageBox.Show("Bạn có muốn xóa kho này ?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    vitri = bdsKho.Position;
                    bdsKho.RemoveCurrent();
                    this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.khoTableAdapter.Update(this.DS.Kho);

                    btnHoanTac.Enabled = true;

                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi xóa kho. Hãy thử lại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    this.khoTableAdapter.Fill(this.DS.Kho);
                    bdsKho.Position = vitri;
                    return;
                }
            }
            else
            {
                undoList.Pop();
            }
        }

        private bool checkThongTin()
        {
            if(txtMaKho.Text == "")
            {
                MessageBox.Show("Mã kho trống", "Thông báo", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return false;
            }
            if(txtMaKho.Text.Length > 4)
            {
                MessageBox.Show("Mã kho không quá 4 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return false;
            }
            if(!Regex.IsMatch(txtMaKho.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã kho chỉ chứa chữ cái và số", "Thông báo", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return false;
            }

            if(txtTen.Text == "")
            {
                MessageBox.Show("Tên kho trống", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            if(txtTen.Text.Length > 30)
            {
                MessageBox.Show("Tên kho không quá 30 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            if(!Regex.IsMatch(txtTen.Text, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("Tên kho chỉ chứa chữ cái và số", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }

            if(txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ trống", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }
            if (txtDiaChi.Text.Length > 100)
            {
                MessageBox.Show("Địa chỉ không quá 100 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }
            if(!Regex.IsMatch(txtDiaChi.Text, @"^[a-zA-Z0-9\s\,\/]+$"))
            {
                MessageBox.Show("Địa chỉ chỉ chứa chữ cái, số, dấu phẩy và dấu /", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!checkThongTin())
                return;

            DataRowView drv = (DataRowView)bdsKho[bdsKho.Position];
            string makho = txtMaKho.Text.Trim(),
                   tenkho = drv["TENKHO"].ToString().Trim(),
                   diachi = drv["DIACHI"].ToString().Trim();

            /* Nếu đang thực hiện chức năng thêm thì
              mới kiểm tra tồn tại mã kho, còn hiệu chỉnh
              thông tin kho thì không càn kiểm tra
            */
            if(dangThemMoi)
            {
                String sql = "DECLARE	@return_value int " +
                         "EXEC @return_value = [dbo].[sp_KiemTraTonTaiKho] " +
                         "@MAKHO = '" + makho + "' " +
                         "SELECT  'Return Value' = @return_value";
                try
                {
                    Program.myReader = Program.ExecSqlDataReader(sql);

                    if (Program.myReader.Read() == false) // không có dòng nào
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int tonTai = Program.myReader.GetInt32(0); // gia tri tra ve 1 là tồn tại và 0 là chưa
                Program.myReader.Close();

                if (tonTai == 1)
                {
                    MessageBox.Show("Mã kho này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }

            if (MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnExit.Enabled = btnHoanTac.Enabled = true;
                    //btnGhi.Enabled = false;
                    txtMaKho.Enabled = false;

                    gcKho.Enabled = true;
                    panelInputKho.Enabled = true;

                    this.bdsKho.EndEdit();
                    this.bdsKho.ResetCurrentItem();
                    this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.khoTableAdapter.Update(DS.Kho);

                    String undoString = "";

                    if (dangThemMoi)
                    {
                        undoString = "DELETE FROM Kho WHERE MAKHO = '" + makho + "'";
                    }
                    else
                    {
                        undoString = "UPDATE Kho " +
                                    "SET " +
                                    "TENKHO = '" + tenkho + "', " +
                                    "DIACHI = '" + diachi + "' " +
                                    "WHERE MAKHO = '" + makho + "'";
                    }

                    undoList.Push(undoString);
                    dangThemMoi = false;
                    MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    bdsKho.RemoveCurrent();
                    MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
