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
    public partial class frmVatTu : Form
    {
        /* vitri được dùng để lưu lại vị trí dòng của VT đang dứng, dùng trong btn undo
            Ex: đang đứng vtri thứ 2 ấn thêm VT, sau đó ấn btn undo thì phải
            quay trở lại vtri thứ 2.
         */
        int vitri = 0;
        String maCN = "";
        bool dangThemMoi = false;

        Stack undoList = new Stack();

        public frmVatTu()
        {
            InitializeComponent();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmVatTu_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS.CTPN);

            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);

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

                panelInputVT.Enabled = false;
            }

            // nhóm CHINHANH hoặc USER có thể thao tác dữ liệu nhưng không thể chọn chi nhánh
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cbxCN.Enabled = false;
                btnHoanTac.Enabled = false;
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.vattuTableAdapter.Fill(this.DS.Vattu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi RELOAD: " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dangThemMoi = true;
            vitri = bdsVT.Position; // lưu lại vị trí đang đứng
            this.bdsVT.AddNew();

            spnSLT.Value = 1; // cài mặc định slt = 1

            btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnExit.Enabled = false;
            btnGhi.Enabled = btnHoanTac.Enabled = txtMaVT.Enabled = true;

            gcVatTu.Enabled = false;
            panelInputVT.Enabled = true;
        }

        private void btnHoanTac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dangThemMoi == true && btnThem.Enabled == false)
            {
                dangThemMoi = false;
                btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnExit.Enabled = btnGhi.Enabled = true;
                txtMaVT.Enabled = false;

                gcVatTu.Enabled = true;
                panelInputVT.Enabled = true;

                bdsVT.CancelEdit();
                this.vattuTableAdapter.Fill(this.DS.Vattu);
                bdsVT.Position = vitri;

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
                this.vattuTableAdapter.Fill(DS.Vattu);
            }

            if (undoList.Count == 0)
            {
                btnHoanTac.Enabled = false;
            }
        }

        private bool checkThongTin()
        {
            if (txtMaVT.Text == "")
            {
                MessageBox.Show("Mã vật tư trống", "Thông báo", MessageBoxButtons.OK);
                txtMaVT.Focus();
                return false;
            }
            if (txtMaVT.Text.Length > 4)
            {
                MessageBox.Show("Mã vật tư tối đa 4 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtMaVT.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtMaVT.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã vật tư chỉ chứa chữ cái và số", "Thông báo", MessageBoxButtons.OK);
                txtMaVT.Focus();
                return false;
            }

            if (txtTen.Text == "")
            {
                MessageBox.Show("Tên vật tư trống", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            if (txtTen.Text.Length > 30)
            {
                MessageBox.Show("Tên vật tư tối đa 30 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtTen.Text, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("Tên vật tư chỉ chứa chữ cái, số và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }

            if (txtDVT.Text == "")
            {
                MessageBox.Show("Đơn vị tính trống", "Thông báo", MessageBoxButtons.OK);
                txtDVT.Focus();
                return false;
            }
            if (txtDVT.Text.Length > 15)
            {
                MessageBox.Show("Đơn vị tính tối đa 15 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtDVT.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtDVT.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Đơn vị tính chỉ chứa chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtDVT.Focus();
                return false;
            }

            return true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!checkThongTin())
            {
                return;
            }

            // lưu lại thông tin của VT để dưa vào lệnh hoàn tác
            DataRowView drv = (DataRowView)bdsVT[bdsVT.Position];
            String mavt = txtMaVT.Text.Trim(),
                   tenvt = drv["TENVT"].ToString().Trim(),
                   dvt = drv["DVT"].ToString().Trim();
            int slt = (int)drv["SOLUONGTON"];


            /* Nếu đang thực hiện chức năng thêm thì
              mới kiểm tra tồn tại mã VT, còn hiệu chỉnh
              thông tin VT thì không càn kiểm tra
            */
            if (dangThemMoi)
            {
                String sql = "DECLARE	@return_value int " +
                         "EXEC @return_value = [dbo].[sp_KiemTraTonTaiVatTu] " +
                         "@MAVT = '" + mavt + "' " +
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
                    MessageBox.Show("Mã vật tư này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
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
                    txtMaVT.Enabled = false;

                    gcVatTu.Enabled = true;
                    panelInputVT.Enabled = true;

                    this.bdsVT.EndEdit();
                    this.bdsVT.ResetCurrentItem();
                    this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.vattuTableAdapter.Update(DS.Vattu);

                    String undoString = "";

                    if (dangThemMoi)
                    {
                        undoString = "DELETE FROM Vattu WHERE MAVT = '" + mavt + "'";
                    }
                    else
                    {
                        undoString = "UPDATE Vattu " +
                                    "SET " +
                                    "TENVT = '" + tenvt + "', " +
                                    "DVT = '" + dvt + "', " +
                                    "SOLUONGTON = " + slt + " " +
                                    "WHERE MAVT = '" + mavt + "'";
                    }

                    undoList.Push(undoString);
                    dangThemMoi = false;
                    MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    bdsVT.RemoveCurrent();
                    MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsVT.Count == 0)
            {
                MessageBox.Show("Không còn vật tư để xóa", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsDDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư vì đã lập đơn đặt hăng", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư vì đã lập phiếu nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsCTPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư vì đã lập phiếu xuất", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            // kiểm tra mã VT đó đã được sử dụng ở CN còn lại hay chưa
            string mavt = txtMaVT.Text.Trim();
            string sql = "DECLARE	@return_value int " +
                         "EXEC @return_value = [dbo].[sp_KiemTraMaVatTuChiNhanhConLai] " +
                         "@MAVT = '" + mavt + "'" +
                         "SELECT  'Return Value' = @return_value";
            try
            {
                Program.myReader = Program.ExecSqlDataReader(sql);
                if (Program.myReader.Read() == false) // không có dòng nào
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tonTai = Program.myReader.GetInt32(0);
            Program.myReader.Close();
            if(tonTai == 1) // 1 là có tồn tại, 0 là không có
            {
                MessageBox.Show("Không thể xóa vì vật tư này đã được sử dụng ở chi nhánh khác!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            String undoString = "INSERT INTO Vattu(MAVT, TENVT, DVT, SOLUONGTON) " +
                                "VALUES( '" + txtMaVT.Text.Trim() + "', '" + 
                                              txtTen.Text.Trim() + "', '" +
                                              txtDVT.Text.Trim() + "', " +
                                              (int)spnSLT.Value + ")";
            undoList.Push(undoString);

            if (MessageBox.Show("Bạn có muốn xóa vật tư này ?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    vitri = bdsVT.Position;
                    bdsVT.RemoveCurrent();
                    this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.vattuTableAdapter.Update(this.DS.Vattu);

                    btnHoanTac.Enabled = true;

                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi xóa vật tư. Hãy thử lại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    this.vattuTableAdapter.Fill(this.DS.Vattu);
                    bdsVT.Position = vitri;
                    return;
                }
            }
            else
            {
                undoList.Pop();
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
                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Fill(this.DS.Vattu);
            }
        }
    }
}
