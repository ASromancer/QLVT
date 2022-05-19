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
    public partial class frmChuyenCN : Form
    {
        public frmChuyenCN()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public delegate void chuyenChiNhanhNV(string servername);
        public chuyenChiNhanhNV chuyenCNNV;

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbxChiNhanh.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn chi nhánh", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if(MessageBox.Show("Bạn có chắc chắn muốn chuyển nhân viên này đi ?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                chuyenCNNV(cbxChiNhanh.SelectedValue.ToString());
            }
        }

        private void cbxChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmChuyenCN_Load(object sender, EventArgs e)
        {
            cbxChiNhanh.DataSource = Program.bds_dspm.DataSource;
            cbxChiNhanh.DisplayMember = "TENCN";
            cbxChiNhanh.ValueMember = "TENSERVER";
        }
    }
}
