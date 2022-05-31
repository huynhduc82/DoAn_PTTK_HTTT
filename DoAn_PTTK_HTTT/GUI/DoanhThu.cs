using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTTK_HTTT.GUI
{
    public partial class DoanhThu : Form
    {
        public DoanhThu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSQL = "SELECT hd.MaHD, hd.ThoiGian, hd.MaNV,cthd.MaSP SoLuong, cthd.DonGia, MONTH(hd.ThoiGian) AS Thang from HOADON hd,CHITIETHOADON cthd where hd.MaHD = cthd.MaHD and MONTH(ThoiGian) = '" + comboBox1.SelectedItem + "'";
            FormDoanhThu dt = new FormDoanhThu(strSQL);
            dt.Show();
        }

        public void loadcbb()
        {
            int i;
            for ( i = 1; i <= 12; i++)
            {
                comboBox1.Items.Add(i);
            }
        }
        private void DoanhThu_Load(object sender, EventArgs e)
        {
            loadcbb();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
