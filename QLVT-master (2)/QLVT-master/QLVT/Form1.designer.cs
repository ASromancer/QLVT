
namespace QLVT
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnVatTu = new DevExpress.XtraBars.BarButtonItem();
            this.btnKho = new DevExpress.XtraBars.BarButtonItem();
            this.btnLapPhieu = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnDDH = new DevExpress.XtraBars.BarButtonItem();
            this.btnPN = new DevExpress.XtraBars.BarButtonItem();
            this.btnPX = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateAcc = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDanhSachNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnDanhSachVatTu = new DevExpress.XtraBars.BarButtonItem();
            this.btnChiTietNhapXuat = new DevExpress.XtraBars.BarButtonItem();
            this.btnDonHangKhongPhieuNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btnHoatDongNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnTongHopNhapXuat = new DevExpress.XtraBars.BarButtonItem();
            this.rib_QuanLy = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rib_BaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rib_HeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MANV = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.HOTEN = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NHOM = new System.Windows.Forms.ToolStripLabel();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ctddhTableAdapter1 = new QLVT.DSTableAdapters.CTDDHTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnNhanVien,
            this.btnVatTu,
            this.btnKho,
            this.btnLapPhieu,
            this.btnDDH,
            this.btnPN,
            this.btnPX,
            this.btnLogin,
            this.btnCreateAcc,
            this.btnLogout,
            this.btnExit,
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnDanhSachNhanVien,
            this.btnDanhSachVatTu,
            this.btnChiTietNhapXuat,
            this.btnDonHangKhongPhieuNhap,
            this.btnHoatDongNhanVien,
            this.btnTongHopNhapXuat});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbonControl1.MaxItemId = 30;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rib_QuanLy,
            this.rib_BaoCao,
            this.rib_HeThong});
            this.ribbonControl1.Size = new System.Drawing.Size(1285, 158);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Caption = "NHÂN VIÊN";
            this.btnNhanVien.Id = 1;
            this.btnNhanVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.ImageOptions.Image")));
            this.btnNhanVien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.ImageOptions.LargeImage")));
            this.btnNhanVien.LargeWidth = 100;
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhanVien_ItemClick);
            // 
            // btnVatTu
            // 
            this.btnVatTu.Caption = "VẬT TƯ";
            this.btnVatTu.Id = 2;
            this.btnVatTu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVatTu.ImageOptions.Image")));
            this.btnVatTu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnVatTu.ImageOptions.LargeImage")));
            this.btnVatTu.LargeWidth = 100;
            this.btnVatTu.Name = "btnVatTu";
            this.btnVatTu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVatTu_ItemClick);
            // 
            // btnKho
            // 
            this.btnKho.Caption = "KHO";
            this.btnKho.Id = 5;
            this.btnKho.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKho.ImageOptions.Image")));
            this.btnKho.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKho.ImageOptions.LargeImage")));
            this.btnKho.LargeWidth = 100;
            this.btnKho.Name = "btnKho";
            this.btnKho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKho_ItemClick);
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.ActAsDropDown = true;
            this.btnLapPhieu.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnLapPhieu.Caption = "LẬP PHIẾU";
            this.btnLapPhieu.DropDownControl = this.popupMenu1;
            this.btnLapPhieu.Id = 6;
            this.btnLapPhieu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLapPhieu.ImageOptions.SvgImage")));
            this.btnLapPhieu.LargeWidth = 100;
            this.btnLapPhieu.Name = "btnLapPhieu";
            // 
            // popupMenu1
            // 
            this.popupMenu1.ItemLinks.Add(this.btnDDH);
            this.popupMenu1.ItemLinks.Add(this.btnPN);
            this.popupMenu1.ItemLinks.Add(this.btnPX);
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbonControl1;
            // 
            // btnDDH
            // 
            this.btnDDH.Caption = "Đơn đặt hàng";
            this.btnDDH.Id = 10;
            this.btnDDH.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDDH.ImageOptions.SvgImage")));
            this.btnDDH.Name = "btnDDH";
            this.btnDDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDDH_ItemClick);
            // 
            // btnPN
            // 
            this.btnPN.Caption = "Phiếu nhập";
            this.btnPN.Id = 11;
            this.btnPN.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPN.ImageOptions.SvgImage")));
            this.btnPN.Name = "btnPN";
            this.btnPN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPN_ItemClick);
            // 
            // btnPX
            // 
            this.btnPX.Caption = "Phiếu xuất";
            this.btnPX.Id = 12;
            this.btnPX.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPX.ImageOptions.SvgImage")));
            this.btnPX.Name = "btnPX";
            this.btnPX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPX_ItemClick);
            // 
            // btnLogin
            // 
            this.btnLogin.Caption = "ĐĂNG NHẬP";
            this.btnLogin.Id = 13;
            this.btnLogin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLogin.ImageOptions.SvgImage")));
            this.btnLogin.LargeWidth = 100;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnCreateAcc
            // 
            this.btnCreateAcc.Caption = "TẠO TÀI KHOẢN";
            this.btnCreateAcc.Enabled = false;
            this.btnCreateAcc.Id = 14;
            this.btnCreateAcc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateAcc.ImageOptions.Image")));
            this.btnCreateAcc.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCreateAcc.ImageOptions.LargeImage")));
            this.btnCreateAcc.LargeWidth = 100;
            this.btnCreateAcc.Name = "btnCreateAcc";
            this.btnCreateAcc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateAcc_ItemClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "ĐĂNG XUẤT";
            this.btnLogout.Enabled = false;
            this.btnLogout.Id = 15;
            this.btnLogout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLogout.ImageOptions.SvgImage")));
            this.btnLogout.LargeWidth = 100;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "THOÁT";
            this.btnExit.Id = 16;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.LargeImage")));
            this.btnExit.LargeWidth = 100;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 18;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 19;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btnDanhSachNhanVien
            // 
            this.btnDanhSachNhanVien.Caption = "DANH SÁCH NHÂN VIÊN";
            this.btnDanhSachNhanVien.Id = 24;
            this.btnDanhSachNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDanhSachNhanVien.ImageOptions.SvgImage")));
            this.btnDanhSachNhanVien.Name = "btnDanhSachNhanVien";
            this.btnDanhSachNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDanhSachNhanVien_ItemClick);
            // 
            // btnDanhSachVatTu
            // 
            this.btnDanhSachVatTu.Caption = "DANH SÁCH VẬT TƯ";
            this.btnDanhSachVatTu.Id = 25;
            this.btnDanhSachVatTu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDanhSachVatTu.ImageOptions.SvgImage")));
            this.btnDanhSachVatTu.Name = "btnDanhSachVatTu";
            this.btnDanhSachVatTu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDanhSachVatTu_ItemClick);
            // 
            // btnChiTietNhapXuat
            // 
            this.btnChiTietNhapXuat.Caption = "CHI TIẾT NHẬP XUẤT";
            this.btnChiTietNhapXuat.Id = 26;
            this.btnChiTietNhapXuat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnChiTietNhapXuat.ImageOptions.SvgImage")));
            this.btnChiTietNhapXuat.Name = "btnChiTietNhapXuat";
            this.btnChiTietNhapXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChiTietNhapXuat_ItemClick);
            // 
            // btnDonHangKhongPhieuNhap
            // 
            this.btnDonHangKhongPhieuNhap.Caption = "ĐƠN HÀNG KHÔNG PHIẾU NHẬP";
            this.btnDonHangKhongPhieuNhap.Id = 27;
            this.btnDonHangKhongPhieuNhap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDonHangKhongPhieuNhap.ImageOptions.SvgImage")));
            this.btnDonHangKhongPhieuNhap.Name = "btnDonHangKhongPhieuNhap";
            this.btnDonHangKhongPhieuNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDonHangKhongPhieuNhap_ItemClick);
            // 
            // btnHoatDongNhanVien
            // 
            this.btnHoatDongNhanVien.Caption = "HOẠT ĐỘNG NHÂN VIÊN";
            this.btnHoatDongNhanVien.Id = 28;
            this.btnHoatDongNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHoatDongNhanVien.ImageOptions.SvgImage")));
            this.btnHoatDongNhanVien.Name = "btnHoatDongNhanVien";
            this.btnHoatDongNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHoatDongNhanVien_ItemClick);
            // 
            // btnTongHopNhapXuat
            // 
            this.btnTongHopNhapXuat.Caption = "TỔNG HỢP NHẬP XUẤT";
            this.btnTongHopNhapXuat.Id = 29;
            this.btnTongHopNhapXuat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTongHopNhapXuat.ImageOptions.SvgImage")));
            this.btnTongHopNhapXuat.Name = "btnTongHopNhapXuat";
            this.btnTongHopNhapXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTongHopNhapXuat_ItemClick);
            // 
            // rib_QuanLy
            // 
            this.rib_QuanLy.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.rib_QuanLy.Name = "rib_QuanLy";
            this.rib_QuanLy.Text = "QUẢN LÝ";
            this.rib_QuanLy.Visible = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNhanVien);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVatTu);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnKho);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLapPhieu);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "QUẢN LÝ NHẬP XUẤT";
            // 
            // rib_BaoCao
            // 
            this.rib_BaoCao.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.rib_BaoCao.Name = "rib_BaoCao";
            this.rib_BaoCao.Text = "BÁO CÁO";
            this.rib_BaoCao.Visible = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDanhSachNhanVien);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDanhSachVatTu);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnChiTietNhapXuat);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDonHangKhongPhieuNhap);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnHoatDongNhanVien);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnTongHopNhapXuat);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // rib_HeThong
            // 
            this.rib_HeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.rib_HeThong.Name = "rib_HeThong";
            this.rib_HeThong.Text = "HỆ THỐNG";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnLogin);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCreateAcc);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnLogout);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnExit, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "HỆ THỐNG";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MANV,
            this.toolStripSeparator1,
            this.HOTEN,
            this.toolStripSeparator2,
            this.NHOM});
            this.toolStrip1.Location = new System.Drawing.Point(0, 639);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1285, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MANV
            // 
            this.MANV.Name = "MANV";
            this.MANV.Size = new System.Drawing.Size(95, 22);
            this.MANV.Text = "MÃ NHÂN VIÊN:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // HOTEN
            // 
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Size = new System.Drawing.Size(52, 22);
            this.HOTEN.Text = "HỌ TÊN:";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // NHOM
            // 
            this.NHOM.Name = "NHOM";
            this.NHOM.Size = new System.Drawing.Size(48, 22);
            this.NHOM.Text = "NHÓM:";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // ctddhTableAdapter1
            // 
            this.ctddhTableAdapter1.ClearBeforeFill = true;
            // 
            // frmMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 664);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "QLVT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripLabel MANV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripLabel HOTEN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripLabel NHOM;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnVatTu;
        private DevExpress.XtraBars.BarButtonItem btnKho;
        private DevExpress.XtraBars.BarButtonItem btnLapPhieu;
        private DevExpress.XtraBars.BarButtonItem btnDDH;
        private DevExpress.XtraBars.BarButtonItem btnPN;
        private DevExpress.XtraBars.BarButtonItem btnPX;
        private DevExpress.XtraBars.BarButtonItem btnLogin;
        private DevExpress.XtraBars.BarButtonItem btnCreateAcc;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnDanhSachNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnDanhSachVatTu;
        private DevExpress.XtraBars.BarButtonItem btnChiTietNhapXuat;
        private DevExpress.XtraBars.BarButtonItem btnDonHangKhongPhieuNhap;
        private DevExpress.XtraBars.BarButtonItem btnHoatDongNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnTongHopNhapXuat;
        private DevExpress.XtraBars.Ribbon.RibbonPage rib_QuanLy;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rib_BaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage rib_HeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DSTableAdapters.CTDDHTableAdapter ctddhTableAdapter1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}

