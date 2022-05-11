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
    public partial class frmPhieuXuat : DevExpress.XtraEditors.XtraForm
    {

        /* vitri được dùng để lưu lại vị trí dòng của nhân viên đang dứng, dùng trong btn undo
            Ex: đang đứng vtri thứ 2 ấn thêm NV, sau đó ấn btn undo thì phải
            quay trở lại vtri thứ 2.
         */
        int vitri = 0;
        int vitriCTPX = 0;
        String maCN = "";
        bool dangThemMoi = false;
        bool dangThemMoiCTPX = false;

        Stack undoList = new Stack();
        Stack undoListCTPX = new Stack();
        public frmPhieuXuat()
        {
            InitializeComponent();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void phieuXuatBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPX.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);

            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS.Kho);

            this.hOTENNVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hOTENNVTableAdapter.Fill(this.DS.HOTENNV);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);

            cbxCN.DataSource = Program.bds_dspm;
            cbxCN.DisplayMember = "TENCN";
            cbxCN.ValueMember = "TENSERVER";
            cbxCN.SelectedIndex = Program.mChiNhanh;

            cbxHoTenNV.DataSource = bdsHoTenNV;
            cbxHoTenNV.DisplayMember = "HOTEN";
            cbxHoTenNV.ValueMember = "MANV";

            cbxTenKho.DataSource = bdsKho;
            cbxTenKho.DisplayMember = "TENKHO";
            cbxTenKho.ValueMember = "MAKHO";

            // nhóm CONGTY chỉ được xem dữ liệu
            if (Program.mGroup == "CONGTY")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnGhi.Enabled = false;
                btnHoanTac.Enabled = false;

                panelInputPX.Enabled = false;

                btnThemVT.Enabled = btnXoaVT.Enabled = btnGhiVT.Enabled = btnHoanTacVT.Enabled = btnChonMaVT.Enabled = false;
            }

            // nhóm CHINHANH hoặc USER có thể thao tác dữ liệu nhưng không thể chọn chi nhánh
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cbxCN.Enabled = false;
                btnHoanTac.Enabled = false;
            }
        }

        private void cbxHoTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaNV.Text = cbxHoTenNV.SelectedValue.ToString();
            }
            catch(Exception ex)
            {
               
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
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.DS.CTPX);      
            }
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.DS.CTPX);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi làm mới\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }


        private void cbxTenKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaKho.Text = cbxTenKho.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnThemVT_Click(object sender, EventArgs e)
        {
            // kiểm tra nếu phiếu đó do chính mình tạo thì cho phép thêm
            string manv = ((DataRowView)bdsPX[bdsPX.Position])["MANV"].ToString();
            if( Program.username != manv)
            {
                MessageBox.Show("Không thể thêm chi tiết phiếu xuất trên phiếu không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (txtMaPX.Text == "")
                return;

            gcPX.Focus(); // thêm chỗ này để tránh bị lỗi không addnew được dòng CPTX vì gcCPTX đang được focus

            vitriCTPX = bdsCTPX.Position;
            dangThemMoiCTPX = true;
            bdsCTPX.AddNew();

            // tự copy mã PX sang CTPX
            ((DataRowView)bdsCTPX[bdsCTPX.Position])["MAPX"] = txtMaPX.Text.Trim();

            //enabled các field nhập chi tiết phiếu
            txtMaVT.Text = "";
            spnSoluong.Value = 1;
            txtDonGia.EditValue = 0;

            btnChonMaVT.Enabled = btnHoanTacVT.Enabled = true;
            gcCTPX.Enabled = btnXoaVT.Enabled = btnThemVT.Enabled = false;

            btnChonMaVT.Focus();

        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = CheckExists(typeof(frmChonVatTu));
            if (frm != null)
                frm.Activate();
            else
            {
                frmChonVatTu f = new frmChonVatTu();
                f.ShowDialog();
                this.txtMaVT.Text = Program.maVTDaChon.Trim();
            }
        }

        private int kiemTraSoLuongTonVatTu(String mavt)
        {
            string sql = "DECLARE	@return_value int " +
                          "EXEC @return_value = [dbo].[sp_KiemTraSoLuongTonVT] " +
                          "@MAVT = N'" + mavt + "' " +
                          "SELECT  'Return Value' = @return_value";
            Program.myReader = Program.ExecSqlDataReader(sql);
            Program.myReader.Read();
            int slt = Program.myReader.GetInt32(0);
            Program.myReader.Close();
            return slt;
        }

        private bool checkThongTinCTPX()
        {
            
            if(txtMaVT.Text == "")
            {
                MessageBox.Show("Mã vật tư trống", "Thông báo", MessageBoxButtons.OK);
                btnChonMaVT.Focus();
                return false;
            }

            // nếu đang thêm mới CTPX thì slt đã lấy được ở lúc chọn mãvt
            // nhưng nếu đang sửa CPTX thì phải chạy sp để lấy slt
            if (dangThemMoiCTPX == true)
            {
                if(spnSoluong.Value > Program.sluongTonVTDaChon)
                {
                    MessageBox.Show("Số lượng vật tư xuất không thể lớn hơn\n\tsố lượng tồn hiện tại của vật tư" +
                    "\nSố lượng tồn hiện tại: " + Program.sluongTonVTDaChon, "Thông báo", MessageBoxButtons.OK);
                    spnSoluong.Focus();
                    return false;
                }
                
                
            }
            else
            {
                string mavt = ((DataRowView)bdsCTPX[bdsCTPX.Position])["MAVT"].ToString().Trim();
                int slt = kiemTraSoLuongTonVatTu(mavt);

                // chỗ này phải ktra số lượng trên bdsCTPX chứ k lấy từ spinner số lượng để tránh bị lỗi (hỏi thằng fix lỗi để biết lỗi gì)
                if ( Convert.ToInt32(((DataRowView)bdsCTPX[bdsCTPX.Position])["SOLUONG"]) > slt)
                {
                    MessageBox.Show("Số lượng vật tư xuất không thể lớn hơn\n\tsố lượng tồn hiện tại của vật tư" +
                    "\nSố lượng tồn hiện tại: " + slt, "Thông báo", MessageBoxButtons.OK);
                    spnSoluong.Focus();
                    return false;
                }
            }

            if(Convert.ToDouble(txtDonGia.EditValue) < 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn hoặc bằng 0", "Thông báo", MessageBoxButtons.OK);
                txtDonGia.Focus();
                return false;
            }

            return true;
        }

        private void CapNhatSoLuongTonVatTu(string mode, string mavt, int soluong)
            // mode : 'NHAP', 'XUAT'
        {
           try
            {
                Program.ExecSqlNonQuery("EXEC sp_CapNhatSoLuongVT '" + mode + "', '" + mavt + "', " + soluong);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật số lượng tồn vật tư thất bại", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnGhiVT_Click(object sender, EventArgs e)
        {
            string manv = ((DataRowView)bdsPX[bdsPX.Position])["MANV"].ToString();
            if (Program.username != manv)
            {
                MessageBox.Show("Không thể ghi chi tiết phiếu xuất trên phiếu không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (!checkThongTinCTPX())
            {
                if (dangThemMoiCTPX == false) {
                    // nếu đang sửa CTPX thì fill lại
                    vitriCTPX = bdsCTPX.Position;
                    this.cTPXTableAdapter.Fill(DS.CTPX);
                    bdsCTPX.Position = vitriCTPX;
                }
                return;
            }
                

            // lưu lại thông tin chi tiết phiếu xuất để làm hoàn tác
            DataRowView drv = (DataRowView)bdsCTPX[bdsCTPX.Position];
            string mapx = txtMaPX.Text.Trim(),
                   mavt = txtMaVT.Text.Trim(),
                   soluong =drv["SOLUONG"].ToString().Trim(),
                   dongia = drv["DONGIA"].ToString().Trim();

            if (MessageBox.Show("Bạn có chắc muốn ghi chi tiết phiếu xuất này vào cơ sở dữ liệu ?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    CapNhatSoLuongTonVatTu("XUAT", txtMaVT.Text.Trim(), (int)spnSoluong.Value);

                    btnChonMaVT.Enabled = false;
                    gcCTPX.Enabled = btnXoaVT.Enabled = btnHoanTacVT.Enabled = btnThemVT.Enabled = true;

                    bdsCTPX.EndEdit();
                    bdsCTPX.ResetCurrentItem();
                    this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPXTableAdapter.Update(this.DS.CTPX);

                    String undoString = "";

                    if (dangThemMoiCTPX)
                    {
                        undoString = "DELETE FROM DBO.CTPX " +
                                    "WHERE MAPX = '" + mapx + "' " +
                                    "AND MAVT = '" + mavt + "'\n" +

                                    "EXEC sp_CapNhatSoLuongVT 'NHAP', '" + mavt + "', " + spnSoluong.Value;
                    }
                    else // đang sửa chi tiết phiếu
                    {
                        undoString = "UPDATE CTPX SET " +
                                        "SOLUONG = " + soluong + ", " +
                                        "DONGIA = " + dongia + " " +
                                        "WHERE MAPX = '" + mapx + "' AND " +
                                        "MAVT = '" + mavt + "'";
                    }
                    
                    undoListCTPX.Push(undoString);
                    dangThemMoiCTPX = false;
                    MessageBox.Show("Ghi vào chi tiết phiếu xuất thành công", "Thông báo", MessageBoxButtons.OK);

                }
                catch (Exception ex)
                {
                    bdsCTPX.RemoveCurrent();
                    MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHoanTacVT_Click(object sender, EventArgs e)
        {
            if (dangThemMoiCTPX == true && btnThemVT.Enabled == false)
            {
                dangThemMoiCTPX = false;
                btnChonMaVT.Enabled = false;
                gcCTPX.Enabled = btnXoaVT.Enabled = btnThemVT.Enabled = true;

                bdsCTPX.CancelEdit();
                this.cTPXTableAdapter.Fill(this.DS.CTPX);
                bdsCTPX.Position = vitriCTPX;
            }
            else // nếu undoListCTPX vẫn còn stack lệnh thì lấy ra hoàn tác
            {
                string undoString = undoListCTPX.Pop().ToString();

                if (Program.Ketnoi() == 0)
                {
                    return;
                }
                else
                {
                    int n = Program.ExecSqlNonQuery(undoString);
                }
                this.cTPXTableAdapter.Fill(this.DS.CTPX);
            }
            if (undoListCTPX.Count == 0)
            {
                btnHoanTacVT.Enabled = false;
            }
        }

        private void btnXoaVT_Click(object sender, EventArgs e)
        {
            string manv = ((DataRowView)bdsPX[bdsPX.Position])["MANV"].ToString();
            if (Program.username != manv)
            {
                MessageBox.Show("Không thể xóa chi tiết phiếu xuất trên phiếu không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa vật tư này khỏi chi tiết phiếu xuất ?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    CapNhatSoLuongTonVatTu("NHAP", txtMaVT.Text.Trim(), (int)spnSoluong.Value);

                    string undoString = "INSERT INTO CTPX(MAPX, MAVT, SOLUONG, DONGIA) " +
                                        "VALUES('" + txtMaPX.Text.Trim() + "', '" +
                                                     txtMaVT.Text.Trim() + "', " +
                                                     spnSoluong.Value + ", " +
                                                     txtDonGia.EditValue + ")\n" +
                                        "EXEC sp_CapNhatSoLuongVT 'XUAT', '" + txtMaVT.Text.Trim() + "', " + spnSoluong.Value;

                    undoListCTPX.Push(undoString);

                    vitriCTPX = bdsCTPX.Position;
                    bdsCTPX.RemoveCurrent();
                    this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPXTableAdapter.Update(this.DS.CTPX);

                    btnHoanTacVT.Enabled = true;

                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi xóa. Hãy thử lại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    this.cTPXTableAdapter.Fill(this.DS.CTPX);
                    bdsCTPX.Position = vitriCTPX;
                    return;
                }

            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsPX.Position;
            dangThemMoi = true;
            bdsPX.AddNew();

            //enabled các field nhập phiếu
            btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnExit.Enabled  = cbxHoTenNV.Enabled = false;
            btnHoanTac.Enabled = txtMaPX.Enabled = true;

            // nhân viên đăng nhập hiện tại sẽ là người lập phiếu
            cbxHoTenNV.SelectedValue = Program.username;
            // lấy ngày hiện tại làm ngày lập phiếu
            txtNgayLap.EditValue = DateTime.Now;

            gcPX.Enabled = false;
        }

        private void btnHoanTac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dangThemMoi == true && btnThem.Enabled == false)
            {
                dangThemMoi = false;
                btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnExit.Enabled = cbxHoTenNV.Enabled = true;
                txtMaPX.Enabled = false;

                gcPX.Enabled = true;

                bdsPX.CancelEdit();
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(DS.PhieuXuat);
                bdsPX.Position = vitri;
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
                this.phieuXuatTableAdapter.Fill(DS.PhieuXuat);
            }

            if (undoList.Count == 0)
            {
                btnHoanTac.Enabled = false;
            }
        }

        private bool checkThongTin()
        {
            if (txtMaPX.Text == "")
            {
                MessageBox.Show("Mã phiếu nhập trống", "Thông báo", MessageBoxButtons.OK);
                txtMaPX.Focus();
                return false;
            }
            if (txtMaPX.Text.Length > 8)
            {
                MessageBox.Show("Mã phiếu nhập tối đa 8 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtMaPX.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtMaPX.Text, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("Mã phiếu nhập chỉ chứa chữ cái và số", "Thông báo", MessageBoxButtons.OK);
                txtMaPX.Focus();
                return false;
            }

            if(txtHoTenKhach.Text == "")
            {
                MessageBox.Show("Họ tên khách trống", "Thông báo", MessageBoxButtons.OK);
                txtHoTenKhach.Focus();
                return false;
            }
            if(txtHoTenKhach.Text.Length > 100)
            {
                MessageBox.Show("Họ tên khách tối đa 100 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtHoTenKhach.Focus();
                return false;
            }
            if(!Regex.IsMatch(txtHoTenKhach.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Họ tên khách chỉ chứa chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtHoTenKhach.Focus();
                return false;
            }

            if(txtMaNV.Text == "")
            {
                MessageBox.Show("Mã nhân viên trống", "Thông báo", MessageBoxButtons.OK);
                cbxHoTenNV.Focus();
                return false;
            }

            if(txtMaKho.Text == "")
            {
                MessageBox.Show("Mã kho trống", "Thông báo", MessageBoxButtons.OK);
                cbxTenKho.Focus();
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

            DataRowView drv = (DataRowView)bdsPX[bdsPX.Position];
            String mapx = txtMaPX.Text.Trim(),
                   hotenkhach = drv["HOTENKH"].ToString().Trim(),
                   makho = drv["MAKHO"].ToString().Trim();
            DateTime ngaylap = (DateTime)(drv["NGAY"]);

            /* Nếu đang thực hiện chức năng thêm thì
              mới kiểm tra tồn tại mã PX, còn hiệu chỉnh
              thông tin PX thì không càn kiểm tra
            */
            if (dangThemMoi)
            {
                string sql = "DECLARE	@return_value int " +
                             "EXEC @return_value = [dbo].[sp_KiemTraMaPhieuXuat] " +
                             "@MAPX = N'" + mapx + "' " +
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
                    MessageBox.Show("Mã phiếu xuất này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                string manv = ((DataRowView)bdsPX[bdsPX.Position])["MANV"].ToString();
                if (Program.username != manv)
                {
                    MessageBox.Show("Không thể sửa phiếu xuất không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }

            if (MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnExit.Enabled = gcPX.Enabled = btnHoanTac.Enabled =  true;
                    txtMaPX.Enabled = false;

                    bdsPX.EndEdit();
                    bdsPX.ResetCurrentItem();
                    this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuXuatTableAdapter.Update(DS.PhieuXuat);

                    string undoString = "";

                    if (dangThemMoi)
                    {
                        undoString = "DELETE FROM PhieuXuat WHERE MAPX = '" + mapx + "'";
                    }
                    else
                    {
                        undoString = "UPDATE PhieuXuat SET " +
                                     "NGAY = '" + ngaylap.ToString("dd-MM-yyyy") + "', " +
                                     "HOTENKH = '" + hotenkhach + "', " +
                                     "MAKHO = '" + makho + "' " +
                                     "WHERE MAPX = '" + mapx + "'";
                    }

                    undoList.Push(undoString);
                    dangThemMoi = false;
                    MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    bdsPX.RemoveCurrent();
                    MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string manv = ((DataRowView)bdsPX[bdsPX.Position])["MANV"].ToString();
            if (Program.username != manv)
            {
                MessageBox.Show("Không thể xóa phiếu xuất không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsCTPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa vì có chi tiết phiếu xuất", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa phiếu xuất này ?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    string undoString = "INSERT INTO PhieuXuat(MAPX, NGAY, HOTENKH, MANV, MAKHO) VALUES('" +
                                                txtMaPX.Text.Trim() + "', '" +
                                                txtNgayLap.Text.Trim() + "', '" +
                                                txtHoTenKhach.Text.Trim() + "', '" +
                                                txtMaNV.Text.Trim() + "', '" +
                                                txtMaKho.Text.Trim() + "')";
                    undoList.Push(undoString);

                    vitri = bdsPX.Position;
                    bdsPX.RemoveCurrent();
                    this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuXuatTableAdapter.Update(DS.PhieuXuat);

                    btnHoanTac.Enabled = true;
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa phiếu xuất. Hãy thử lại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    this.phieuXuatTableAdapter.Fill(DS.PhieuXuat);
                    bdsPX.Position = vitri;
                    return;
                }
            }
        }
    }
}
