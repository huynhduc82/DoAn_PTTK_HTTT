using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_PTTK_HTTT.BLL;
using DoAn_PTTK_HTTT.DTO;
using DoAn_PTTK_HTTT.DAO;

namespace DoAn_PTTK_HTTT
{
    public partial class frmDoiTra : Form
    {
        DoiTraBLL dt = new DoiTraBLL();
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
            btnXoa_DoiTra.Enabled = false;
            btnLuu_DoiTra.Enabled = false;
            btnSua_CT.Enabled = btnLuu_CT.Enabled = btnXoa_CT.Enabled = false;
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
            btnXoa_DoiTra.Enabled = true;
        }

        private void grvChiTietDoiTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaChiTietDoiTra.Text = grvChiTietDoiTra.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMaDoiTra_CT.Text = grvChiTietDoiTra.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMaSP.Text = grvChiTietDoiTra.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoLuong.Text = grvChiTietDoiTra.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMoTaChiTiet.Text = grvChiTietDoiTra.Rows[e.RowIndex].Cells[4].Value.ToString();
            btnXoa_CT.Enabled = btnSua_CT.Enabled = true;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaDoiTra.Clear();
            txtMaNV.Clear();
            txtMaKH.Clear();
            txtMaLoaiKH.Clear();
            txtMaDoiTra.Focus();
            btnXoa_DoiTra.Enabled = false;
            btnLuu_DoiTra.Enabled = true;
        }

        private void btnLuu_DoiTra_Click(object sender, EventArgs e)
        {
            DoiTraDTO doiTra = new DoiTraDTO();
            doiTra.MaDoiTra = txtMaDoiTra.Text;
            doiTra.MaKH = txtMaKH.Text;
            doiTra.MaNV = txtMaNV.Text;
            doiTra.MaLoaiKH = txtMaLoaiKH.Text;
            doiTra.ThoiGian = DateTime.Now;
            int kt = dt.ThemDoiTra(doiTra);
            if (kt == 1)
            {
                MessageBox.Show("Đã thêm thành công");
                loadGrvDoiTra();
                btnLuu_DoiTra.Enabled = false;
            }
            else if (kt == 0)
            {
                MessageBox.Show("Đã tồn tại đổi trả này rồi!");
            }
            else
            {
                MessageBox.Show("Bị lỗi hãy thử lại");
            }
        }

        private void btnXoa_DoiTra_Click(object sender, EventArgs e)
        {
            string maDT = txtMaDoiTra.Text;
            int kt = dt.XoaDoiTra(maDT);
            if (kt == 1)
            {
                MessageBox.Show("Đã xoá thành công");
                btnXoa_DoiTra.Enabled = false;
                loadGrvDoiTra();
            }
            else if (kt == 0)
            {
                MessageBox.Show("Sản phẩm không có trong hoá đơn rồi!");
            }
            else
            {
                MessageBox.Show("Bị lỗi hãy thử lại");
            }
        }

        private void btnThemMoi_CT_Click(object sender, EventArgs e)
        {
            txtMaChiTietDoiTra.Clear();
            txtMaDoiTra_CT.Clear();
            txtMaSP.Clear();
            txtSoLuong.Clear();
            txtMoTaChiTiet.Clear();
            txtMaChiTietDoiTra.Focus();
            btnXoa_CT.Enabled = false;
            btnSua_CT.Enabled = false;
            btnLuu_CT.Enabled = true;
        }

        private void btnLuu_CT_Click(object sender, EventArgs e)
        {
            ChiTietDoiTraDTO doiTra = new ChiTietDoiTraDTO();
            doiTra.MaCTDoiTra = txtMaChiTietDoiTra.Text;
            doiTra.MaDoiTra = txtMaDoiTra_CT.Text;
            doiTra.MaSP = txtMaSP.Text;
            doiTra.SoLuong = int.Parse(txtSoLuong.Text);
            doiTra.MoTaChiTiet = txtMoTaChiTiet.Text;
            int kt = dt.ThemChiTietDoiTra(doiTra);
            if (kt == 1)
            {
                MessageBox.Show("Đã thêm thành công");
                loadGrvCTDoiTra();
                btnLuu_CT.Enabled = false;

            }
            else if (kt == 0)
            {
                MessageBox.Show("Đã tồn tại đổi trả này rồi!");
            }
            else
            {
                MessageBox.Show("Bị lỗi hãy thử lại");
            }
        }

        private void btnXoa_CT_Click(object sender, EventArgs e)
        {
            string maCTDT = txtMaChiTietDoiTra.Text;
            int kt = dt.XoaChiTietDoiTra(maCTDT);
            if (kt == 1)
            {
                btnSua_CT.Enabled = btnXoa_CT.Enabled = false;
                MessageBox.Show("Đã xoá thành công");
                btnXoa_DoiTra.Enabled = false;
                loadGrvCTDoiTra();
                
            }
            else if (kt == 0)
            {
                MessageBox.Show("Sản phẩm không có trong hoá đơn rồi!");
            }
            else
            {
                MessageBox.Show("Bị lỗi hãy thử lại");
            }
        }

        private void btnSua_CT_Click(object sender, EventArgs e)
        {
            ChiTietDoiTraDTO ct = new ChiTietDoiTraDTO();
            ct.MaCTDoiTra = txtMaChiTietDoiTra.Text;
            ct.SoLuong = int.Parse(txtSoLuong.Text);
            ct.MoTaChiTiet = txtMoTaChiTiet.Text;
            ct.MaSP = txtMaSP.Text;
            int kt = dt.SuaChiTietDoiTra(ct);
            if (kt == 1)
            {
                MessageBox.Show("Đã sửa thành công");
                loadGrvCTDoiTra();
                btnSua_CT.Enabled = false;
            }
            else if (kt == 0)
            {
                MessageBox.Show("Sản phẩm chưa có trong hoá đơn rồi!");
            }
            else
            {
                MessageBox.Show("Bị lỗi hãy thử lại");
            }
        }
    }
}
