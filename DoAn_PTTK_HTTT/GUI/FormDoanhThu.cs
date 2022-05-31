using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_PTTK_HTTT.DAO;

namespace DoAn_PTTK_HTTT
{
    public partial class FormDoanhThu : Form
    {
        DataTable tDoanhThu;
        SQLHepler db = new SQLHepler();
        string strSQL;
        public FormDoanhThu(string sql)
        {
           
            InitializeComponent();
            tDoanhThu = new DataTable();
            strSQL = sql;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            tDoanhThu = db.getDataTable(strSQL, "Doanh Thu");
            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetDataSource(tDoanhThu);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
