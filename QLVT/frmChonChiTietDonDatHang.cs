using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class frmChonChiTietDonDatHang : DevExpress.XtraEditors.XtraForm
    {
        public frmChonChiTietDonDatHang()
        {
            InitializeComponent();
        }

        private void cTDDHBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cTDDHBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }
        private void frmChonChiTietDonDatHang_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);
        }

        private void btnCHON_Click(object sender, EventArgs e)
        {
            DataRowView drv = ((DataRowView)(cTDDHBindingSource.Current));
            string maDonHang = drv["MasoDDH"].ToString().Trim();
            string maVatTu = drv["MaVT"].ToString().Trim();
            int soLuong = int.Parse(drv["SOLUONG"].ToString().Trim());
            int donGia = int.Parse(drv["DONGIA"].ToString().Trim());


            /*Kiem tra xem ma don hang cua gcPhieuNhap co trung voi ma don hang duoc chon hay khong ?*/
            Program.maDonDatHangDuocChonChiTiet = maDonHang;
            if (Program.maDonDatHangDuocChon != Program.maDonDatHangDuocChonChiTiet)
            {
                MessageBox.Show("Bạn phải chọn chi tiết đơn hàng có mã đơn hàng là " + Program.maDonDatHangDuocChon, "Thông báo", MessageBoxButtons.OK);
                return;
            }

            /**
             * Viết 1 đoạn code chạy stored procedure kiểm tra xem mã PN10 và mã vật tư W8
             * đã tồn tại hay chưa ???
             */


            Program.maVTDaChon = maVatTu;
            Program.soLuongVatTu = soLuong;
            Program.donGia = donGia;
            this.Close();
        }

        private void btnTHOAT_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}