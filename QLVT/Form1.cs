using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLVT
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public void enableButtons()
        {
            btnLogin.Enabled = false;
            btnLogout.Enabled = true;
            btnCreateAcc.Enabled = true;

            rib_QuanLy.Visible = true;
            rib_BaoCao.Visible = true;

            if (Program.mGroup == "USER")
            {
                btnCreateAcc.Enabled = false;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null)
                frm.Activate();
            else
            {
                frmDangNhap f = new frmDangNhap();
                //f.MdiParent = this;
                f.Show();
            }
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        //giải phóng tài nguyên của tất cả các form
        private void LogoutAllForm()
        {
            foreach (Form frm in this.MdiChildren)
                frm.Dispose();
        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LogoutAllForm();

            btnLogin.Enabled = true;
            btnLogout.Enabled = false;
            btnCreateAcc.Enabled = false;
            rib_QuanLy.Visible = false;
            rib_BaoCao.Visible = false;

            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null)
                frm.Activate();
            else
            {
                frmDangNhap frmLogin = new frmDangNhap();
                frmLogin.Show();
            }
            Program.frmChinh.MANV.Text = "MÃ NHÂN VIÊN: ";
            Program.frmChinh.HOTEN.Text = "HỌ TÊN: ";
            Program.frmChinh.NHOM.Text = "NHÓM: ";
        }

        private void btnCreateAcc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(frmTaoTaiKhoan));
            if (frm != null)
                frm.Activate();
            else
            {
                frmTaoTaiKhoan f = new frmTaoTaiKhoan();
                //f.MdiParent = this;
                f.Show();
            }
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(frmNhanVien));
            if (frm != null)
                frm.Activate();
            else
            {
                frmNhanVien f = new frmNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnVatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(frmVatTu));
            if (frm != null)
                frm.Activate();
            else
            {
                frmVatTu f = new frmVatTu();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(frmKho));
            if (frm != null)
                frm.Activate();
            else
            {
                frmKho f = new frmKho();
                f.MdiParent = this;
                f.Show();
            }
        }

       /* private void btnPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(frmPhieuXuat));
            if (frm != null)
                frm.Activate();
            else
            {
                frmPhieuXuat f = new frmPhieuXuat();
                f.MdiParent = this;
                f.Show();
            }
        }*/

        private void btnDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(frmDonDatHang));
            if (frm != null)
                frm.Activate();
            else
            {
                frmDonDatHang f = new frmDonDatHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(frmPhieuNhap));
            if (frm != null)
                frm.Activate();
            else
            {
                frmPhieuNhap f = new frmPhieuNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(frmPhieuXuat));
            if (frm != null)
                frm.Activate();
            else
            {
                frmPhieuXuat f = new frmPhieuXuat();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDanhSachNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmDanhSachNhanVien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmDanhSachNhanVien form = new frmDanhSachNhanVien();
                //form.MdiParent = this;
                form.Show();
            }
        }

        private void btnDanhSachVatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmDanhSachVatTu));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmDanhSachVatTu form = new frmDanhSachVatTu();
                //form.MdiParent = this;
                form.Show();
            }
        }

        private void btnChiTietNhapXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmChiTietSoLuongTriGiaHangHoaNhapXuat));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmChiTietSoLuongTriGiaHangHoaNhapXuat form = new frmChiTietSoLuongTriGiaHangHoaNhapXuat();
                //form.MdiParent = this;
                form.Show();
            }
        }

        private void btnDonHangKhongPhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmDonHangKhongPhieuNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmDonHangKhongPhieuNhap form = new frmDonHangKhongPhieuNhap();
                //form.MdiParent = this;
                form.Show();
            }
        }

        private void btnTongHopNhapXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmTongHopNhapXuat));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmTongHopNhapXuat form = new frmTongHopNhapXuat();
                //form.MdiParent = this;
                form.Show();
            }
        }

        private void btnHoatDongNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmHoatDongNhanVien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmHoatDongNhanVien form = new frmHoatDongNhanVien();
                //form.MdiParent = this;
                form.Show();
            }
        }
    }
}
