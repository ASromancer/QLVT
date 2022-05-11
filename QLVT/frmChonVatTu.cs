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
    public partial class frmChonVatTu : Form
    {
        public frmChonVatTu()
        {
            InitializeComponent();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmChonVatTu_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            DS.EnforceConstraints = false;
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maVatTu = ((DataRowView)bdsVT.Current)["MAVT"].ToString();
            int soLuongVatTu = int.Parse(((DataRowView)bdsVT.Current)["SOLUONGTON"].ToString());
            Program.maVTDaChon = maVatTu;
            Program.sluongTonVTDaChon = soLuongVatTu;
            this.Close();
        }
    }
}
