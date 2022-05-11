using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using System;
using System.Collections;
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
    public partial class frmPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        int viTri = 0;
        bool dangThemMoi = false;
        public string makho = "";
        string maChiNhanh = "";
        Stack undoList = new Stack();
        BindingSource bds = null;
        GridControl gc = null;
        string type = "";
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void phieuNhapBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phieuNhapBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS.CTPN);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

            cmbCHINHANH.DataSource = Program.bds_dspm;/*sao chep bingding source tu form dang nhap*/
            cmbCHINHANH.DisplayMember = "TENCN";
            cmbCHINHANH.ValueMember = "TENSERVER";
            cmbCHINHANH.SelectedIndex = Program.mChiNhanh;

        }

        private void gcChiTietPhieuNhap_Click(object sender, EventArgs e)
        {

        }

        private void gcPhieuNhap_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gcChiTietPhieuNhap_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBoxPhieuNhap_Enter(object sender, EventArgs e)
        {

        }

        private void cmbCHINHANH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCHINHANH.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            Program.servername = cmbCHINHANH.SelectedValue.ToString();

            /*Neu chon sang chi nhanh khac voi chi nhanh hien tai*/
            if (cmbCHINHANH.SelectedIndex != Program.mChiNhanh)
            {
                Program.loginName = Program.remoteLogin;
                Program.loginPassword = Program.remotePassword;
            }
            /*Neu chon trung voi chi nhanh dang dang nhap o formDangNhap*/
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
                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.DS.CTPN);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
            }
        }

        private void btnTHOAT_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void btnPHIEUNHAP_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnMENU.Links[0].Caption = "Phiếu Nhập";

            /*Step 1*/
            bds = phieuNhapBindingSource;
            gc = gcPhieuNhap;


            /*Step 2*/
            /*Bat chuc nang cua phieu nhap*/
            txtMaPhieuNhap.Enabled = false;
            dteNgay.Enabled = false;

            txtMaDonDatHang.Enabled = false;
            btnChonDonHang.Enabled = false;

            txtMaNhanVien.Enabled = false;
            txtMaKho.Enabled = false;

            btnChonChiTietDonHang.Enabled = false;

            /*Tat chuc nang cua chi tiet phieu nhap*/
            txtMaVatChiTietPhieuNhap.Enabled = false;
            txtSoLuongChiTietPhieuNhap.Enabled = false;
            txtDonGiaChiTietPhieuNhap.Enabled = false;

            /*Bat cac grid control len*/
            gcPhieuNhap.Enabled = true;
            gcChiTietPhieuNhap.Enabled = true;


            /*Step 3*/
            /*CONG TY chi xem du lieu*/
            if (Program.mGroup == "CONGTY")
            {

                cmbCHINHANH.Enabled = true;

                this.btnTHEM.Enabled = false;
                this.btnXOA.Enabled = false;
                this.btnGHI.Enabled = false;

                this.btnHOANTAC.Enabled = false;
                this.btnLAMMOI.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnTHOAT.Enabled = true;

                this.groupBoxPhieuNhap.Enabled = false;
            }

            if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cmbCHINHANH.Enabled = false;

                this.btnTHEM.Enabled = true;
                bool turnOn = (phieuNhapBindingSource.Count > 0) ? true : false;
                this.btnXOA.Enabled = turnOn;
                this.btnGHI.Enabled = true;

                this.btnHOANTAC.Enabled = false;
                this.btnLAMMOI.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnTHOAT.Enabled = true;
            }
        }

        private void btnCHITIETPHIEUNHAP_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnMENU.Links[0].Caption = "Chi Tiết Phiếu Nhập";

            /*Step 1*/
            bds = cTPNBindingSource;
            gc = gcPhieuNhap;

            /*Step 2*/
            /*Tat chuc nang cua chi tiet phieu nhap*/
            txtMaPhieuNhap.Enabled = false;
            dteNgay.Enabled = false;

            txtMaDonDatHang.Enabled = false;
            btnChonDonHang.Enabled = false;

            txtMaNhanVien.Enabled = false;
            txtMaKho.Enabled = false;

            /*Bat chuc nang cua chi tiet don hang*/
            txtMaVatTu.Enabled = false;
            txtSoLuongChiTietPhieuNhap.Enabled = false;
            txtDonGiaChiTietPhieuNhap.Enabled = false;

            btnChonChiTietDonHang.Enabled = false;

            /*Bat cac grid control len*/
            gcPhieuNhap.Enabled = true;
            gcChiTietPhieuNhap.Enabled = true;

            /*Step 3*/
            /*CONG TY chi xem du lieu*/
            if (Program.mGroup == "CONGTY")
            {
                cmbCHINHANH.Enabled = true;

                this.btnTHEM.Enabled = false;
                this.btnXOA.Enabled = false;
                this.btnGHI.Enabled = false;

                this.btnHOANTAC.Enabled = false;
                this.btnLAMMOI.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnTHOAT.Enabled = true;
            }

            /* CHI NHANH & USER co the xem - xoa - sua du lieu nhung khong the 
             chuyen sang chi nhanh khac*/
            if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cmbCHINHANH.Enabled = false;

                this.btnTHEM.Enabled = true;
                //bool turnOn = (bdsChiTietPhieuNhap.Count > 0) ? true : false;
                this.btnXOA.Enabled = false;
                this.btnGHI.Enabled = true;

                this.btnHOANTAC.Enabled = false;
                this.btnLAMMOI.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnTHOAT.Enabled = true;
            }
        }

        private void btnChonDonHang_Click(object sender, EventArgs e)
        {
            frmChonDonDatHang form = new frmChonDonDatHang();
            form.ShowDialog();

            this.txtMaDonDatHang.Text = Program.maDonDatHangDuocChon;
            this.txtMaKho.Text = Program.maKhoDuocChon;
        }

        private void btnTHEM_ItemClick(object sender, ItemClickEventArgs e)
        {
            viTri = bds.Position;
            dangThemMoi = true;

            bds.AddNew();
            if (btnMENU.Links[0].Caption == "Phiếu Nhập")
            {
                this.txtMaPhieuNhap.Enabled = true;

                this.dteNgay.EditValue = DateTime.Now;
                this.dteNgay.Enabled = false;

                this.txtMaDonDatHang.Enabled = false;
                this.btnChonDonHang.Enabled = true;

                this.txtMaNhanVien.Text = Program.username;
                this.txtMaKho.Text = Program.maKhoDuocChon;


                /*Gan tu dong may truong du lieu nay*/
                ((DataRowView)(phieuNhapBindingSource.Current))["NGAY"] = DateTime.Now;
                ((DataRowView)(phieuNhapBindingSource.Current))["MasoDDH"] = Program.maDonDatHangDuocChon;
                ((DataRowView)(phieuNhapBindingSource.Current))["MANV"] = Program.username;
                ((DataRowView)(phieuNhapBindingSource.Current))["MAKHO"] =
                Program.maKhoDuocChon;

            }

            if (btnMENU.Links[0].Caption == "Chi Tiết Phiếu Nhập")
            {
                DataRowView drv = ((DataRowView)phieuNhapBindingSource[phieuNhapBindingSource.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.username != maNhanVien)
                {
                    MessageBox.Show("Bạn không thêm chi tiết phiếu nhập trên phiếu không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    cTPNBindingSource.RemoveCurrent();
                    return;
                }

                /*Gan tu dong may truong du lieu nay*/
                ((DataRowView)(cTPNBindingSource.Current))["MAPN"] = ((DataRowView)(phieuNhapBindingSource.Current))["MAPN"];
                ((DataRowView)(cTPNBindingSource.Current))["MAVT"] =
                    Program.maVTDaChon;
                ((DataRowView)(cTPNBindingSource.Current))["SOLUONG"] =
                    Program.soLuongVatTu;
                ((DataRowView)(cTPNBindingSource.Current))["DONGIA"] =
                    Program.donGia;

                this.txtMaVatTu.Enabled = false;
                this.btnChonChiTietDonHang.Enabled = true;

                this.txtSoLuong.Enabled = true;
                this.txtSoLuong.EditValue = 1;

                this.txtDonGia.Enabled = true;
                this.txtDonGia.EditValue = 1;

                this.txtSoLuongChiTietPhieuNhap.Enabled = true;
                this.txtDonGiaChiTietPhieuNhap.Enabled = true;
            }


            /*Step 3*/
            this.btnTHEM.Enabled = false;
            this.btnXOA.Enabled = false;
            this.btnGHI.Enabled = true;

            this.btnHOANTAC.Enabled = true;
            this.btnLAMMOI.Enabled = false;
            this.btnMENU.Enabled = false;
            this.btnTHOAT.Enabled = false;

            gcPhieuNhap.Enabled = false;
            gcChiTietPhieuNhap.Enabled = false;
        }

        private void btnLAMMOI_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
                this.cTPNTableAdapter.Fill(this.DS.CTPN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi làm mời dữ liệu\n\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private void btnChonChiTietDonHang_Click(object sender, EventArgs e)
        {
            Program.maDonDatHangDuocChon = ((DataRowView)(phieuNhapBindingSource.Current))["MasoDDH"].ToString().Trim();

            //Console.WriteLine(Program.maDonDatHangDuocChon);
            frmChonChiTietDonDatHang form = new frmChonChiTietDonDatHang();
            form.ShowDialog();



            this.txtMaVatChiTietPhieuNhap.Text = Program.maVTDaChon;
            this.txtSoLuongChiTietPhieuNhap.Value = Program.soLuongVatTu;
            this.txtDonGiaChiTietPhieuNhap.Value = Program.donGia;
        }

        private void btnHOANTAC_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dangThemMoi == true && this.btnTHEM.Enabled == false)
            {
                dangThemMoi = false;

                /*dang o che do Phiếu Nhập*/
                if (btnMENU.Links[0].Caption == "Phiếu Nhập")
                {
                    this.txtMaDonDatHang.Enabled = false;
                    dteNgay.Enabled = false;

                    txtMaDonDatHang.Enabled = false;
                    txtMaKho.Enabled = false;

                    btnChonDonHang.Enabled = false;
                    txtMaDonDatHang.Enabled = false;
                }
                /*dang o che do Chi Tiết Phiếu Nhập*/
                if (btnMENU.Links[0].Caption == "Chi Tiết Phiếu Nhập")
                {
                    this.txtMaDonDatHang.Enabled = false;
                    this.btnChonChiTietDonHang.Enabled = false;

                    this.txtMaVatChiTietPhieuNhap.Enabled = false;
                    this.txtSoLuongChiTietPhieuNhap.Enabled = false;
                    this.txtDonGiaChiTietPhieuNhap.Enabled = false;

                    this.btnXOA.Enabled = false;
                }

                this.btnTHEM.Enabled = true;
                this.btnXOA.Enabled = true;
                this.btnGHI.Enabled = true;

                //this.btnHOANTAC.Enabled = false;
                this.btnLAMMOI.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnTHOAT.Enabled = true;

                this.gcPhieuNhap.Enabled = true;
                this.gcChiTietPhieuNhap.Enabled = true;

                bds.CancelEdit();
                /*xoa dong hien tai*/
                bds.RemoveCurrent();
                /* trở về lúc đầu con trỏ đang đứng*/
                bds.Position = viTri;
                return;
            }

            /*Step 1*/
            if (undoList.Count == 0)
            {
                MessageBox.Show("Không còn thao tác nào để khôi phục", "Thông báo", MessageBoxButtons.OK);
                btnHOANTAC.Enabled = false;
                return;
            }

            /*Step 2*/
            bds.CancelEdit();
            String cauTruyVanHoanTac = undoList.Pop().ToString();

            Console.WriteLine(cauTruyVanHoanTac);
            int n = Program.ExecSqlNonQuery(cauTruyVanHoanTac);

            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
            this.cTPNTableAdapter.Fill(this.DS.CTPN);

            phieuNhapBindingSource.Position = viTri;
        }

        private void capNhatSoLuongVatTu(string maVatTu, int soLuong)
        {
            string cauTruyVan = "EXEC sp_CapNhatSoLuongVatTu 'IMPORT','" + maVatTu + "', " + soLuong;


            int n = Program.ExecSqlNonQuery(cauTruyVan);
            Console.WriteLine(cauTruyVan);
        }

        private String taoCauTruyVanHoanTac(String cheDo)
        {
            String cauTruyVan = "";
            DataRowView drv;

            /*TH1: dang sua phieu nhap - nhung ko co truong du lieu nao co the cho sua duoc ca*/
            if (cheDo == "Phiếu Nhập" && dangThemMoi == false)
            {
                // khong co gi ca
            }

            /*TH2: them moi phieu nhap*/
            if (cheDo == "Phiếu Nhập" && dangThemMoi == true)
            {
                // tao trong btnGHI thi hon
            }

            /*TH3: them moi chi tiet phieu nhap*/
            if (cheDo == "Chi Tiết Phiếu Nhập" && dangThemMoi == true)
            {
                // tao trong btnGHI thi hon
            }

            /*TH4: dang sua chi tiet phieu nhap*/
            if (cheDo == "Chi Tiết Phiếu Nhập" && dangThemMoi == false)
            {
                drv = ((DataRowView)(cTPNBindingSource.Current));
                int soLuong = int.Parse(drv["SOLUONG"].ToString().Trim());
                float donGia = float.Parse(drv["DONGIA"].ToString().Trim());
                String maPhieuNhap = drv["MAPN"].ToString().Trim();
                String maVatTu = drv["MAVT"].ToString().Trim();

                cauTruyVan = "UPDATE DBO.CTPN " +
                    "SET " +
                    "SOLUONG = " + soLuong + ", " +
                    "DONGIA = " + donGia + " " +
                    "WHERE MAPN = '" + maPhieuNhap + "' " +
                    "AND MAVT = '" + maVatTu + "' ";
            }
            return cauTruyVan;
        }

        private bool kiemTraDuLieuDauVao(String cheDo)
        {
            if (cheDo == "Phiếu Nhập")
            {
                if (txtMaPhieuNhap.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã phiếu nhập !", "Thông báo", MessageBoxButtons.OK);
                    txtMaPhieuNhap.Focus();
                    return false;
                }


                if (txtMaNhanVien.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã nhân viên !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }

                if (txtMaKho.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã kho !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }

                if (txtMaDonDatHang.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã đơn đặt hàng !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
            }

            if (cheDo == "Chi Tiết Phiếu Nhập")
            {
                /*Do chung khoa chinh cua no la MAPN + MAVT*/
                /* tạo 2 phiếu nhập cùng mã đơn hàng thì bị lỗi do maDonHang trong phiếu 
                 * nhập chỉ được xuất hiện 1 lần duy nhất
                 */
                /*
                if (bdsChiTietPhieuNhap.Count > 1)
                {
                    MessageBox.Show("Không thể thêm chi tiết phiếu nhập quá 1 lần", "Thông báo", MessageBoxButtons.OK);
                    bdsChiTietPhieuNhap.RemoveCurrent();
                    return false;
                }*/

                if (txtMaVatChiTietPhieuNhap.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã vật tư !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }

                if (txtSoLuongChiTietPhieuNhap.Value < 0 ||
                    txtSoLuongChiTietPhieuNhap.Value > Program.soLuongVatTu)
                {
                    MessageBox.Show("Số lượng vật tư không thể lớn hơn số lượng vật tư trong chi tiết đơn hàng !", "Thông báo", MessageBoxButtons.OK);
                    txtSoLuongChiTietPhieuNhap.Focus();
                    return false;
                }

                if (txtDonGiaChiTietPhieuNhap.Value < 1)
                {
                    MessageBox.Show("Đơn giá không thể nhỏ hơn 1 VND", "Thông báo", MessageBoxButtons.OK);
                    txtDonGiaChiTietPhieuNhap.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnGHI_ItemClick(object sender, ItemClickEventArgs e)
        {
            String cheDo = (btnMENU.Links[0].Caption == "Phiếu Nhập") ? "Phiếu Nhập" : "Chi Tiết Phiếu Nhập";


            /*Step 2*/
            bool ketQua = kiemTraDuLieuDauVao(cheDo);
            if (ketQua == false) return;



            /*Step 3*/
            string cauTruyVanHoanTac = taoCauTruyVanHoanTac(cheDo);


            /*Step 4*/
            String maPhieuNhap = txtMaPhieuNhap.Text.Trim();
            //Console.WriteLine(maPhieuNhap);
            String cauTruyVan =
                    "DECLARE	@result int " +
                    "EXEC @result = sp_KiemTraMaPhieuNhap '" +
                    maPhieuNhap + "' " +
                    "SELECT 'Value' = @result";
            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
            try
            {
                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                /*khong co ket qua tra ve thi ket thuc luon*/
                if (Program.myReader == null)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return;
            }
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();


            /*Step 5*/
            int viTriConTro = phieuNhapBindingSource.Position;
            int viTriMaPhieuNhap = phieuNhapBindingSource.Find("MAPN", maPhieuNhap);

            /*Dang them moi phieu nhap*/
            if (result == 1 && cheDo == "Phiếu Nhập" && viTriMaPhieuNhap != viTriConTro)
            {
                MessageBox.Show("Mã phiếu nhập đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                txtMaPhieuNhap.Focus();
                return;
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "Thông báo",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        /*TH1: them moi phieu nhap*/
                        if (cheDo == "Phiếu Nhập" && dangThemMoi == true)
                        {
                            cauTruyVanHoanTac =
                                "DELETE FROM DBO.PHIEUNHAP " +
                                "WHERE MAPN = '" + maPhieuNhap + "'";
                        }

                        /*TH2: them moi chi tiet don hang*/
                        if (cheDo == "Chi Tiết Phiếu Nhập" && dangThemMoi == true)
                        {
                            cauTruyVanHoanTac =
                                "DELETE FROM DBO.CTPN " +
                                "WHERE MAPN = '" + maPhieuNhap + "' " +
                                "AND MAVT = '" + Program.maVTDaChon + "'";

                            string maVatTu = txtMaVatChiTietPhieuNhap.Text.Trim();
                            int soLuong = (int)txtSoLuongChiTietPhieuNhap.Value;

                            capNhatSoLuongVatTu(maVatTu, soLuong);
                        }

                        /*TH3: chinh sua phieu nhap -> chang co gi co the chinh sua
                         * duoc -> chang can xu ly*/
                        /*TH4: chinh sua chi tiet phieu nhap - > thi chi can may dong lenh duoi la xong*/
                        undoList.Push(cauTruyVanHoanTac);
                        Console.WriteLine("cau truy van hoan tac");
                        Console.WriteLine(cauTruyVanHoanTac);

                        this.phieuNhapBindingSource.EndEdit();
                        this.cTPNBindingSource.EndEdit();
                        this.phieuNhapTableAdapter.Update(this.DS.PhieuNhap);
                        this.cTPNTableAdapter.Update(this.DS.CTPN);

                        this.btnTHEM.Enabled = true;
                        this.btnXOA.Enabled = true;
                        this.btnGHI.Enabled = true;

                        this.btnHOANTAC.Enabled = true;
                        this.btnLAMMOI.Enabled = true;
                        this.btnMENU.Enabled = true;
                        this.btnTHOAT.Enabled = true;

                        this.gcPhieuNhap.Enabled = true;
                        this.gcChiTietPhieuNhap.Enabled = true;

                        this.txtSoLuongChiTietPhieuNhap.Enabled = false;
                        this.txtDonGiaChiTietPhieuNhap.Enabled = false;
                        /*cập nhật lại trạng thái thêm mới cho chắc*/
                        dangThemMoi = false;
                        MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        bds.RemoveCurrent();
                        MessageBox.Show("Da xay ra loi !\n\n" + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnXOA_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRowView drv;
            string cauTruyVanHoanTac = "";
            string cheDo = (btnMENU.Links[0].Caption == "Phiếu Nhập") ? "Phiếu Nhập" : "Chi Tiết Phiếu Nhập";



            if (cheDo == "Phiếu Nhập")
            {
                drv = ((DataRowView)phieuNhapBindingSource[phieuNhapBindingSource.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.username != maNhanVien)
                {
                    MessageBox.Show("Không xóa chi tiết phiếu xuất không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                if (cTPNBindingSource.Count > 0)
                {
                    MessageBox.Show("Không thể xóa phiếu nhập vì có chi tiết phiếu nhập", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                drv = ((DataRowView)phieuNhapBindingSource[phieuNhapBindingSource.Position]);
                DateTime ngay = ((DateTime)drv["NGAY"]);

                cauTruyVanHoanTac = "INSERT INTO DBO.PHIEUNHAP(MAPN, NGAY, MasoDDH, MANV, MAKHO) " +
                    "VALUES( '" + drv["MAPN"].ToString().Trim() + "', '" +
                    ngay.ToString("yyyy-MM-dd") + "', '" +
                    drv["MasoDDH"].ToString() + "', '" +
                    drv["MANV"].ToString() + "', '" +
                    drv["MAKHO"].ToString() + "')";

            }

            if (cheDo == "Chi Tiết Phiếu Nhập")
            {
                drv = ((DataRowView)phieuNhapBindingSource[phieuNhapBindingSource.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.username != maNhanVien)
                {
                    MessageBox.Show("Bạn không xóa chi tiết phiếu nhập không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    return;
                }


                drv = ((DataRowView)cTPNBindingSource[cTPNBindingSource.Position]);
                cauTruyVanHoanTac = "INSERT INTO DBO.CTPN(MAPN, MAVT, SOLUONG, DONGIA) " +
                    "VALUES('" + drv["MAPN"].ToString().Trim() + "', '" +
                    drv["MAVT"].ToString().Trim() + "', " +
                    drv["SOLUONG"].ToString().Trim() + ", " +
                    drv["DONGIA"].ToString().Trim() + ")";
            }

            undoList.Push(cauTruyVanHoanTac);
            //Console.WriteLine("Line 842");
            //Console.WriteLine(cauTruyVanHoanTac);

            /*Step 2*/
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    /*Step 3*/
                    viTri = bds.Position;
                    if (cheDo == "Phiếu Nhập")
                    {
                        phieuNhapBindingSource.RemoveCurrent();
                    }
                    if (cheDo == "Chi Tiết Phiếu Nhập")
                    {
                        phieuNhapBindingSource.RemoveCurrent();
                    }


                    this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuNhapTableAdapter.Update(this.DS.PhieuNhap);

                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Update(this.DS.CTPN);

                    //bdsPhieuNhap.Position = viTri;
                    /*Cap nhat lai do ben tren can tao cau truy van nen da dat dangThemMoi = true*/
                    dangThemMoi = false;
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK);
                    this.btnHOANTAC.Enabled = true;
                }
                catch (Exception ex)
                {
                    /*Step 4*/
                    MessageBox.Show("Lỗi xóa nhân viên. Hãy thử lại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuNhapTableAdapter.Update(this.DS.PhieuNhap);

                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Update(this.DS.CTPN);
                    // tro ve vi tri cua nhan vien dang bi loi
                    bds.Position = viTri;
                    //bdsNhanVien.Position = bdsNhanVien.Find("MANV", manv);
                    return;
                }
            }
            else
            {
                // xoa cau truy van hoan tac di
                undoList.Pop();
            }
        }
    }
}