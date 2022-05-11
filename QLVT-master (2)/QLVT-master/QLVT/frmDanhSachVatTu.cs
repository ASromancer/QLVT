using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class frmDanhSachVatTu : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachVatTu()
        {
            InitializeComponent();
        }


        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vattuBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmDanhSachVatTu_Load(object sender, EventArgs e)
        {
            this.vattuTableAdapter.Fill(this.DS.Vattu);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDanhSachVatTu report = new ReportDanhSachVatTu();
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportDanhSachVatTu report = new ReportDanhSachVatTu();
            try
            {
                if (File.Exists(@"D:\ReportDanhSachVatTu.pdf"))
                {
                    DialogResult dr = MessageBox.Show("File ReportDanhSachVatTu.pdf tại ổ D đã có!\nBạn có muốn tạo lại?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        report.ExportToPdf(@"D:\ReportDanhSachVatTu.pdf");
                        MessageBox.Show("File ReportDSNhanVien.pdf đã được ghi thành công tại ổ D",
                "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    report.ExportToPdf(@"D:\ReportDanhSachVatTu.pdf");
                    MessageBox.Show("File ReportDSNhanVien.pdf đã được ghi thành công tại ổ D",
                "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Vui lòng đóng file ReportDanhSachVatTu.pdf",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
        }

        private void vattuGridControl_Click(object sender, EventArgs e)
        {

        }
    }
}