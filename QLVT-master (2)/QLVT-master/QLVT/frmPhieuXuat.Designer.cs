
namespace QLVT
{
    partial class frmPhieuXuat
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
            System.Windows.Forms.Label mAPXLabel;
            System.Windows.Forms.Label nGAYLabel;
            System.Windows.Forms.Label hOTENKHLabel;
            System.Windows.Forms.Label hOTENLabel;
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label tENKHOLabel;
            System.Windows.Forms.Label mAKHOLabel;
            System.Windows.Forms.Label mAVTLabel;
            System.Windows.Forms.Label sOLUONGLabel;
            System.Windows.Forms.Label dONGIALabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuXuat));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnHoanTac = new DevExpress.XtraBars.BarButtonItem();
            this.btnLamMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbxCN = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new QLVT.DS();
            this.bdsPX = new System.Windows.Forms.BindingSource(this.components);
            this.phieuXuatTableAdapter = new QLVT.DSTableAdapters.PhieuXuatTableAdapter();
            this.tableAdapterManager = new QLVT.DSTableAdapters.TableAdapterManager();
            this.cTPXTableAdapter = new QLVT.DSTableAdapters.CTPXTableAdapter();
            this.gcPX = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTENKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelInputPX = new DevExpress.XtraEditors.PanelControl();
            this.btnChonMaVT = new System.Windows.Forms.Button();
            this.txtDonGia = new DevExpress.XtraEditors.TextEdit();
            this.bdsCTPX = new System.Windows.Forms.BindingSource(this.components);
            this.spnSoluong = new DevExpress.XtraEditors.SpinEdit();
            this.txtMaVT = new System.Windows.Forms.TextBox();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.txtMaKho = new System.Windows.Forms.TextBox();
            this.cbxTenKho = new System.Windows.Forms.ComboBox();
            this.bdsKho = new System.Windows.Forms.BindingSource(this.components);
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.cbxHoTenNV = new System.Windows.Forms.ComboBox();
            this.bdsHoTenNV = new System.Windows.Forms.BindingSource(this.components);
            this.txtHoTenKhach = new System.Windows.Forms.TextBox();
            this.txtNgayLap = new DevExpress.XtraEditors.DateEdit();
            this.txtMaPX = new System.Windows.Forms.TextBox();
            this.gcCTPX = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPX1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThemVT = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXoaVT = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGhiVT = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHoanTacVT = new System.Windows.Forms.ToolStripMenuItem();
            this.hOTENNVTableAdapter = new QLVT.DSTableAdapters.HOTENNVTableAdapter();
            this.khoTableAdapter = new QLVT.DSTableAdapters.KhoTableAdapter();
            this.bdsVatTu = new System.Windows.Forms.BindingSource(this.components);
            this.vattuTableAdapter = new QLVT.DSTableAdapters.VattuTableAdapter();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            mAPXLabel = new System.Windows.Forms.Label();
            nGAYLabel = new System.Windows.Forms.Label();
            hOTENKHLabel = new System.Windows.Forms.Label();
            hOTENLabel = new System.Windows.Forms.Label();
            mANVLabel = new System.Windows.Forms.Label();
            tENKHOLabel = new System.Windows.Forms.Label();
            mAKHOLabel = new System.Windows.Forms.Label();
            mAVTLabel = new System.Windows.Forms.Label();
            sOLUONGLabel = new System.Windows.Forms.Label();
            dONGIALabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputPX)).BeginInit();
            this.panelInputPX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSoluong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHoTenNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLap.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCTPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // mAPXLabel
            // 
            mAPXLabel.AutoSize = true;
            mAPXLabel.Location = new System.Drawing.Point(58, 24);
            mAPXLabel.Name = "mAPXLabel";
            mAPXLabel.Size = new System.Drawing.Size(40, 13);
            mAPXLabel.TabIndex = 0;
            mAPXLabel.Text = "Mã PX:";
            // 
            // nGAYLabel
            // 
            nGAYLabel.AutoSize = true;
            nGAYLabel.Location = new System.Drawing.Point(339, 24);
            nGAYLabel.Name = "nGAYLabel";
            nGAYLabel.Size = new System.Drawing.Size(53, 13);
            nGAYLabel.TabIndex = 2;
            nGAYLabel.Text = "Ngày lập:";
            // 
            // hOTENKHLabel
            // 
            hOTENKHLabel.AutoSize = true;
            hOTENKHLabel.Location = new System.Drawing.Point(13, 71);
            hOTENKHLabel.Name = "hOTENKHLabel";
            hOTENKHLabel.Size = new System.Drawing.Size(74, 13);
            hOTENKHLabel.TabIndex = 4;
            hOTENKHLabel.Text = "Họ tên khách:";
            // 
            // hOTENLabel
            // 
            hOTENLabel.AutoSize = true;
            hOTENLabel.Location = new System.Drawing.Point(48, 125);
            hOTENLabel.Name = "hOTENLabel";
            hOTENLabel.Size = new System.Drawing.Size(43, 13);
            hOTENLabel.TabIndex = 6;
            hOTENLabel.Text = "Họ tên:";
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(357, 122);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(41, 13);
            mANVLabel.TabIndex = 8;
            mANVLabel.Text = "Mã NV:";
            // 
            // tENKHOLabel
            // 
            tENKHOLabel.AutoSize = true;
            tENKHOLabel.Location = new System.Drawing.Point(40, 182);
            tENKHOLabel.Name = "tENKHOLabel";
            tENKHOLabel.Size = new System.Drawing.Size(49, 13);
            tENKHOLabel.TabIndex = 10;
            tENKHOLabel.Text = "Tên kho:";
            // 
            // mAKHOLabel
            // 
            mAKHOLabel.AutoSize = true;
            mAKHOLabel.Location = new System.Drawing.Point(347, 182);
            mAKHOLabel.Name = "mAKHOLabel";
            mAKHOLabel.Size = new System.Drawing.Size(45, 13);
            mAKHOLabel.TabIndex = 12;
            mAKHOLabel.Text = "Mã kho:";
            // 
            // mAVTLabel
            // 
            mAVTLabel.AutoSize = true;
            mAVTLabel.Location = new System.Drawing.Point(58, 267);
            mAVTLabel.Name = "mAVTLabel";
            mAVTLabel.Size = new System.Drawing.Size(40, 13);
            mAVTLabel.TabIndex = 15;
            mAVTLabel.Text = "Mã VT:";
            // 
            // sOLUONGLabel
            // 
            sOLUONGLabel.AutoSize = true;
            sOLUONGLabel.Location = new System.Drawing.Point(30, 319);
            sOLUONGLabel.Name = "sOLUONGLabel";
            sOLUONGLabel.Size = new System.Drawing.Size(53, 13);
            sOLUONGLabel.TabIndex = 17;
            sOLUONGLabel.Text = "Số lượng:";
            // 
            // dONGIALabel
            // 
            dONGIALabel.AutoSize = true;
            dONGIALabel.Location = new System.Drawing.Point(342, 319);
            dONGIALabel.Name = "dONGIALabel";
            dONGIALabel.Size = new System.Drawing.Size(48, 13);
            dONGIALabel.TabIndex = 19;
            dONGIALabel.Text = "Đơn giá:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnXoa,
            this.btnGhi,
            this.btnHoanTac,
            this.btnLamMoi,
            this.btnExit});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 7;
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHoanTac, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLamMoi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.LargeImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 1;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 2;
            this.btnGhi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGhi.ImageOptions.Image")));
            this.btnGhi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGhi.ImageOptions.LargeImage")));
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnHoanTac
            // 
            this.btnHoanTac.Caption = "Hoàn tác";
            this.btnHoanTac.Enabled = false;
            this.btnHoanTac.Id = 3;
            this.btnHoanTac.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHoanTac.ImageOptions.Image")));
            this.btnHoanTac.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHoanTac.ImageOptions.LargeImage")));
            this.btnHoanTac.Name = "btnHoanTac";
            this.btnHoanTac.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHoanTac_ItemClick);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Caption = "Làm mới";
            this.btnLamMoi.Id = 4;
            this.btnLamMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.Image")));
            this.btnLamMoi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.ImageOptions.LargeImage")));
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLamMoi_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Thoát";
            this.btnExit.Id = 6;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.LargeImage")));
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlTop.Size = new System.Drawing.Size(1310, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 679);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlBottom.Size = new System.Drawing.Size(1310, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 655);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1310, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 655);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbxCN);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1310, 70);
            this.panelControl1.TabIndex = 6;
            // 
            // cbxCN
            // 
            this.cbxCN.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCN.FormattingEnabled = true;
            this.cbxCN.Location = new System.Drawing.Point(360, 19);
            this.cbxCN.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCN.Name = "cbxCN";
            this.cbxCN.Size = new System.Drawing.Size(445, 24);
            this.cbxCN.TabIndex = 1;
            this.cbxCN.SelectedIndexChanged += new System.EventHandler(this.cbxCN_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi nhánh";
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsPX
            // 
            this.bdsPX.DataMember = "PhieuXuat";
            this.bdsPX.DataSource = this.DS;
            // 
            // phieuXuatTableAdapter
            // 
            this.phieuXuatTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = this.cTPXTableAdapter;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = this.phieuXuatTableAdapter;
            this.tableAdapterManager.UpdateOrder = QLVT.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // cTPXTableAdapter
            // 
            this.cTPXTableAdapter.ClearBeforeFill = true;
            // 
            // gcPX
            // 
            this.gcPX.DataSource = this.bdsPX;
            this.gcPX.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcPX.Location = new System.Drawing.Point(0, 94);
            this.gcPX.MainView = this.gridView1;
            this.gcPX.MenuManager = this.barManager1;
            this.gcPX.Name = "gcPX";
            this.gcPX.Size = new System.Drawing.Size(1310, 190);
            this.gcPX.TabIndex = 11;
            this.gcPX.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPX,
            this.colNGAY,
            this.colHOTENKH,
            this.colMANV,
            this.colMAKHO});
            this.gridView1.GridControl = this.gcPX;
            this.gridView1.Name = "gridView1";
            // 
            // colMAPX
            // 
            this.colMAPX.FieldName = "MAPX";
            this.colMAPX.MinWidth = 25;
            this.colMAPX.Name = "colMAPX";
            this.colMAPX.Visible = true;
            this.colMAPX.VisibleIndex = 0;
            this.colMAPX.Width = 94;
            // 
            // colNGAY
            // 
            this.colNGAY.FieldName = "NGAY";
            this.colNGAY.MinWidth = 25;
            this.colNGAY.Name = "colNGAY";
            this.colNGAY.Visible = true;
            this.colNGAY.VisibleIndex = 1;
            this.colNGAY.Width = 94;
            // 
            // colHOTENKH
            // 
            this.colHOTENKH.FieldName = "HOTENKH";
            this.colHOTENKH.MinWidth = 25;
            this.colHOTENKH.Name = "colHOTENKH";
            this.colHOTENKH.Visible = true;
            this.colHOTENKH.VisibleIndex = 2;
            this.colHOTENKH.Width = 94;
            // 
            // colMANV
            // 
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 3;
            this.colMANV.Width = 94;
            // 
            // colMAKHO
            // 
            this.colMAKHO.FieldName = "MAKHO";
            this.colMAKHO.MinWidth = 25;
            this.colMAKHO.Name = "colMAKHO";
            this.colMAKHO.Visible = true;
            this.colMAKHO.VisibleIndex = 4;
            this.colMAKHO.Width = 94;
            // 
            // panelInputPX
            // 
            this.panelInputPX.Controls.Add(this.btnChonMaVT);
            this.panelInputPX.Controls.Add(dONGIALabel);
            this.panelInputPX.Controls.Add(this.txtDonGia);
            this.panelInputPX.Controls.Add(sOLUONGLabel);
            this.panelInputPX.Controls.Add(this.spnSoluong);
            this.panelInputPX.Controls.Add(mAVTLabel);
            this.panelInputPX.Controls.Add(this.txtMaVT);
            this.panelInputPX.Controls.Add(this.separatorControl1);
            this.panelInputPX.Controls.Add(mAKHOLabel);
            this.panelInputPX.Controls.Add(this.txtMaKho);
            this.panelInputPX.Controls.Add(tENKHOLabel);
            this.panelInputPX.Controls.Add(this.cbxTenKho);
            this.panelInputPX.Controls.Add(mANVLabel);
            this.panelInputPX.Controls.Add(this.txtMaNV);
            this.panelInputPX.Controls.Add(hOTENLabel);
            this.panelInputPX.Controls.Add(this.cbxHoTenNV);
            this.panelInputPX.Controls.Add(hOTENKHLabel);
            this.panelInputPX.Controls.Add(this.txtHoTenKhach);
            this.panelInputPX.Controls.Add(nGAYLabel);
            this.panelInputPX.Controls.Add(this.txtNgayLap);
            this.panelInputPX.Controls.Add(mAPXLabel);
            this.panelInputPX.Controls.Add(this.txtMaPX);
            this.panelInputPX.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInputPX.Location = new System.Drawing.Point(0, 284);
            this.panelInputPX.Name = "panelInputPX";
            this.panelInputPX.Size = new System.Drawing.Size(706, 395);
            this.panelInputPX.TabIndex = 12;
            // 
            // btnChonMaVT
            // 
            this.btnChonMaVT.Enabled = false;
            this.btnChonMaVT.Location = new System.Drawing.Point(411, 258);
            this.btnChonMaVT.Name = "btnChonMaVT";
            this.btnChonMaVT.Size = new System.Drawing.Size(136, 35);
            this.btnChonMaVT.TabIndex = 21;
            this.btnChonMaVT.Text = "Chọn mã VT";
            this.btnChonMaVT.UseVisualStyleBackColor = true;
            this.btnChonMaVT.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDonGia
            // 
            this.txtDonGia.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCTPX, "DONGIA", true));
            this.txtDonGia.Location = new System.Drawing.Point(411, 316);
            this.txtDonGia.MenuManager = this.barManager1;
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Properties.DisplayFormat.FormatString = "n0";
            this.txtDonGia.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDonGia.Properties.EditFormat.FormatString = "n0";
            this.txtDonGia.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDonGia.Properties.Mask.EditMask = "n00";
            this.txtDonGia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDonGia.Size = new System.Drawing.Size(136, 20);
            this.txtDonGia.TabIndex = 20;
            // 
            // bdsCTPX
            // 
            this.bdsCTPX.DataMember = "FK_CTPX_PX";
            this.bdsCTPX.DataSource = this.bdsPX;
            // 
            // spnSoluong
            // 
            this.spnSoluong.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCTPX, "SOLUONG", true));
            this.spnSoluong.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnSoluong.Location = new System.Drawing.Point(111, 316);
            this.spnSoluong.MenuManager = this.barManager1;
            this.spnSoluong.Name = "spnSoluong";
            this.spnSoluong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnSoluong.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnSoluong.Properties.IsFloatValue = false;
            this.spnSoluong.Properties.Mask.EditMask = "n00";
            this.spnSoluong.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.spnSoluong.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnSoluong.Size = new System.Drawing.Size(174, 20);
            this.spnSoluong.TabIndex = 18;
            // 
            // txtMaVT
            // 
            this.txtMaVT.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsCTPX, "MAVT", true));
            this.txtMaVT.Enabled = false;
            this.txtMaVT.Location = new System.Drawing.Point(111, 264);
            this.txtMaVT.Name = "txtMaVT";
            this.txtMaVT.Size = new System.Drawing.Size(174, 21);
            this.txtMaVT.TabIndex = 16;
            // 
            // separatorControl1
            // 
            this.separatorControl1.Location = new System.Drawing.Point(5, 223);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(674, 23);
            this.separatorControl1.TabIndex = 14;
            // 
            // txtMaKho
            // 
            this.txtMaKho.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPX, "MAKHO", true));
            this.txtMaKho.Enabled = false;
            this.txtMaKho.Location = new System.Drawing.Point(411, 179);
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.Size = new System.Drawing.Size(136, 21);
            this.txtMaKho.TabIndex = 13;
            // 
            // cbxTenKho
            // 
            this.cbxTenKho.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsKho, "TENKHO", true));
            this.cbxTenKho.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPX, "MAKHO", true));
            this.cbxTenKho.FormattingEnabled = true;
            this.cbxTenKho.Location = new System.Drawing.Point(111, 179);
            this.cbxTenKho.Name = "cbxTenKho";
            this.cbxTenKho.Size = new System.Drawing.Size(174, 21);
            this.cbxTenKho.TabIndex = 11;
            this.cbxTenKho.SelectedIndexChanged += new System.EventHandler(this.cbxTenKho_SelectedIndexChanged);
            // 
            // bdsKho
            // 
            this.bdsKho.DataMember = "Kho";
            this.bdsKho.DataSource = this.DS;
            // 
            // txtMaNV
            // 
            this.txtMaNV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPX, "MANV", true));
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Location = new System.Drawing.Point(411, 119);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(136, 21);
            this.txtMaNV.TabIndex = 9;
            // 
            // cbxHoTenNV
            // 
            this.cbxHoTenNV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsHoTenNV, "HOTEN", true));
            this.cbxHoTenNV.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPX, "MANV", true));
            this.cbxHoTenNV.FormattingEnabled = true;
            this.cbxHoTenNV.Location = new System.Drawing.Point(111, 122);
            this.cbxHoTenNV.Name = "cbxHoTenNV";
            this.cbxHoTenNV.Size = new System.Drawing.Size(174, 21);
            this.cbxHoTenNV.TabIndex = 7;
            this.cbxHoTenNV.SelectedIndexChanged += new System.EventHandler(this.cbxHoTenNV_SelectedIndexChanged);
            // 
            // bdsHoTenNV
            // 
            this.bdsHoTenNV.DataMember = "HOTENNV";
            this.bdsHoTenNV.DataSource = this.DS;
            // 
            // txtHoTenKhach
            // 
            this.txtHoTenKhach.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPX, "HOTENKH", true));
            this.txtHoTenKhach.Location = new System.Drawing.Point(111, 71);
            this.txtHoTenKhach.Name = "txtHoTenKhach";
            this.txtHoTenKhach.Size = new System.Drawing.Size(174, 21);
            this.txtHoTenKhach.TabIndex = 5;
            // 
            // txtNgayLap
            // 
            this.txtNgayLap.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsPX, "NGAY", true));
            this.txtNgayLap.EditValue = null;
            this.txtNgayLap.Location = new System.Drawing.Point(411, 21);
            this.txtNgayLap.MenuManager = this.barManager1;
            this.txtNgayLap.Name = "txtNgayLap";
            this.txtNgayLap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgayLap.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgayLap.Size = new System.Drawing.Size(175, 20);
            this.txtNgayLap.TabIndex = 3;
            // 
            // txtMaPX
            // 
            this.txtMaPX.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPX, "MAPX", true));
            this.txtMaPX.Enabled = false;
            this.txtMaPX.Location = new System.Drawing.Point(111, 21);
            this.txtMaPX.Name = "txtMaPX";
            this.txtMaPX.Size = new System.Drawing.Size(174, 21);
            this.txtMaPX.TabIndex = 1;
            // 
            // gcCTPX
            // 
            this.gcCTPX.DataSource = this.bdsCTPX;
            this.gcCTPX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCTPX.Location = new System.Drawing.Point(706, 284);
            this.gcCTPX.MainView = this.gridView2;
            this.gcCTPX.MenuManager = this.barManager1;
            this.gcCTPX.Name = "gcCTPX";
            this.gcCTPX.Size = new System.Drawing.Size(604, 395);
            this.gcCTPX.TabIndex = 12;
            this.gcCTPX.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPX1,
            this.colMAVT,
            this.colSOLUONG,
            this.colDONGIA});
            this.gridView2.GridControl = this.gcCTPX;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colMAPX1
            // 
            this.colMAPX1.FieldName = "MAPX";
            this.colMAPX1.MinWidth = 25;
            this.colMAPX1.Name = "colMAPX1";
            this.colMAPX1.OptionsColumn.AllowEdit = false;
            this.colMAPX1.Visible = true;
            this.colMAPX1.VisibleIndex = 0;
            this.colMAPX1.Width = 94;
            // 
            // colMAVT
            // 
            this.colMAVT.FieldName = "MAVT";
            this.colMAVT.MinWidth = 25;
            this.colMAVT.Name = "colMAVT";
            this.colMAVT.OptionsColumn.AllowEdit = false;
            this.colMAVT.Visible = true;
            this.colMAVT.VisibleIndex = 1;
            this.colMAVT.Width = 94;
            // 
            // colSOLUONG
            // 
            this.colSOLUONG.FieldName = "SOLUONG";
            this.colSOLUONG.MinWidth = 25;
            this.colSOLUONG.Name = "colSOLUONG";
            this.colSOLUONG.OptionsColumn.AllowEdit = false;
            this.colSOLUONG.Visible = true;
            this.colSOLUONG.VisibleIndex = 2;
            this.colSOLUONG.Width = 94;
            // 
            // colDONGIA
            // 
            this.colDONGIA.FieldName = "DONGIA";
            this.colDONGIA.MinWidth = 25;
            this.colDONGIA.Name = "colDONGIA";
            this.colDONGIA.OptionsColumn.AllowEdit = false;
            this.colDONGIA.Visible = true;
            this.colDONGIA.VisibleIndex = 3;
            this.colDONGIA.Width = 94;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemVT,
            this.btnXoaVT,
            this.btnGhiVT,
            this.btnHoanTacVT});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 92);
            // 
            // btnThemVT
            // 
            this.btnThemVT.Name = "btnThemVT";
            this.btnThemVT.Size = new System.Drawing.Size(198, 22);
            this.btnThemVT.Text = "Thêm vật tư vào chi tiết";
            this.btnThemVT.Click += new System.EventHandler(this.btnThemVT_Click);
            // 
            // btnXoaVT
            // 
            this.btnXoaVT.Name = "btnXoaVT";
            this.btnXoaVT.Size = new System.Drawing.Size(198, 22);
            this.btnXoaVT.Text = "Xóa vật tư khỏi chi tiết";
            this.btnXoaVT.Click += new System.EventHandler(this.btnXoaVT_Click);
            // 
            // btnGhiVT
            // 
            this.btnGhiVT.Name = "btnGhiVT";
            this.btnGhiVT.Size = new System.Drawing.Size(198, 22);
            this.btnGhiVT.Text = "Ghi vật tư vào chi tiết";
            this.btnGhiVT.Click += new System.EventHandler(this.btnGhiVT_Click);
            // 
            // btnHoanTacVT
            // 
            this.btnHoanTacVT.Enabled = false;
            this.btnHoanTacVT.Name = "btnHoanTacVT";
            this.btnHoanTacVT.Size = new System.Drawing.Size(198, 22);
            this.btnHoanTacVT.Text = "Hoàn tác";
            this.btnHoanTacVT.Click += new System.EventHandler(this.btnHoanTacVT_Click);
            // 
            // hOTENNVTableAdapter
            // 
            this.hOTENNVTableAdapter.ClearBeforeFill = true;
            // 
            // khoTableAdapter
            // 
            this.khoTableAdapter.ClearBeforeFill = true;
            // 
            // bdsVatTu
            // 
            this.bdsVatTu.DataMember = "Vattu";
            this.bdsVatTu.DataSource = this.DS;
            // 
            // vattuTableAdapter
            // 
            this.vattuTableAdapter.ClearBeforeFill = true;
            // 
            // frmPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 679);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.gcCTPX);
            this.Controls.Add(this.panelInputPX);
            this.Controls.Add(this.gcPX);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPhieuXuat";
            this.Text = "PHIẾU XUẤT";
            this.Load += new System.EventHandler(this.frmPhieuXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputPX)).EndInit();
            this.panelInputPX.ResumeLayout(false);
            this.panelInputPX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSoluong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHoTenNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLap.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCTPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnHoanTac;
        private DevExpress.XtraBars.BarButtonItem btnLamMoi;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cbxCN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bdsPX;
        private DS DS;
        private DSTableAdapters.PhieuXuatTableAdapter phieuXuatTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcPX;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPX;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTENKH;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private DevExpress.XtraEditors.PanelControl panelInputPX;
        private DSTableAdapters.CTPXTableAdapter cTPXTableAdapter;
        private System.Windows.Forms.BindingSource bdsCTPX;
        private DevExpress.XtraGrid.GridControl gcCTPX;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPX1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAVT;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colDONGIA;
        private System.Windows.Forms.TextBox txtHoTenKhach;
        private DevExpress.XtraEditors.DateEdit txtNgayLap;
        private System.Windows.Forms.TextBox txtMaPX;
        private System.Windows.Forms.BindingSource bdsHoTenNV;
        private DSTableAdapters.HOTENNVTableAdapter hOTENNVTableAdapter;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.ComboBox cbxHoTenNV;
        private System.Windows.Forms.BindingSource bdsKho;
        private DSTableAdapters.KhoTableAdapter khoTableAdapter;
        private System.Windows.Forms.TextBox txtMaKho;
        private System.Windows.Forms.ComboBox cbxTenKho;
        private System.Windows.Forms.BindingSource bdsVatTu;
        private DSTableAdapters.VattuTableAdapter vattuTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnThemVT;
        private System.Windows.Forms.ToolStripMenuItem btnXoaVT;
        private System.Windows.Forms.ToolStripMenuItem btnGhiVT;
        private DevExpress.XtraEditors.TextEdit txtDonGia;
        private DevExpress.XtraEditors.SpinEdit spnSoluong;
        private System.Windows.Forms.TextBox txtMaVT;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private System.Windows.Forms.Button btnChonMaVT;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.ToolStripMenuItem btnHoanTacVT;
    }
}