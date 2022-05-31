using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_PTTK_HTTT.BUS;

namespace DoAn_PTTK_HTTT
{
    public partial class frmDoiTra : Form
    {
        DoiTraBUS dt = new DoiTraBUS();
        public frmDoiTra()
        {
            InitializeComponent();
            txtThoiGian.Enabled = false;
            timer1.Enabled = true;
            timer1.Start();
            styleGridViewDoiTra();
            loadGrvDoiTra();
            styleGridViewCTDoiTra();
            loadGrvCTDoiTra();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtThoiGian.Text = DateTime.Now.ToString();
        }
        private void loadGrvDoiTra()
        {
            grvDoiTra.DataSource = dt.LayDoiTra();
        }
        private void loadGrvCTDoiTra()
        {
            grvChiTietDoiTra.DataSource = dt.LayChiTietDoiTra();
        }
        public void styleGridViewDoiTra()
        {
            grvDoiTra.AutoGenerateColumns = false;
            grvDoiTra.Columns["MaDoiTra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grvDoiTra.Columns["MaNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grvDoiTra.Columns["MaKH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grvDoiTra.Columns["MaLoaiKH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grvDoiTra.Columns["ThoiGian"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grvDoiTra.EnableHeadersVisualStyles = false; //Bắt buộc phải có dòng này!
            grvDoiTra.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grvDoiTra.ColumnHeadersDefaultCellStyle.ForeColor = Color.Green;
            grvDoiTra.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            grvDoiTra.ForeColor = Color.Green;
        }
        public void styleGridViewCTDoiTra()
        {
            grvChiTietDoiTra.AutoGenerateColumns = false;
            grvChiTietDoiTra.Columns["MaCTDoiTra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grvChiTietDoiTra.Columns["MaDoiTra_CT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grvChiTietDoiTra.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grvChiTietDoiTra.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grvChiTietDoiTra.Columns["MoTaChiTiet"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grvChiTietDoiTra.EnableHeadersVisualStyles = false; //Bắt buộc phải có dòng này!
            grvChiTietDoiTra.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grvChiTietDoiTra.ColumnHeadersDefaultCellStyle.ForeColor = Color.Green;
            grvChiTietDoiTra.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            grvChiTietDoiTra.ForeColor = Color.Green;
        }

        private void grvDoiTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDoiTra.Text = grvDoiTra.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMaNV.Text = grvDoiTra.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMaKH.Text = grvDoiTra.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMaLoaiKH.Text = grvDoiTra.Rows[e.RowIndex].Cells[3].Value.ToString();
            btnSua.Enabled = btnXoa.Enabled = true;
        }
    }
}
