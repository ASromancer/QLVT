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

namespace QLVT.SubForm
{
    public partial class frmChonKhoHang : DevExpress.XtraEditors.XtraForm
    {
        public frmChonKhoHang()
        {
            InitializeComponent();
        }
        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.khoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmChonKhoHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.Kho' table. You can move, or remove it, as needed.
            DS.EnforceConstraints = false;
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS.Kho);

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
            string maKhoHang = ((DataRowView)khoBindingSource.Current)["MAKHO"].ToString();

            /*Cach nay phai tuy bien ban moi chay duoc*/
            //Program.formDonDatHang.txtMaKho.Text = maKhoHang;


            Program.maKhoDuocChon = maKhoHang;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}