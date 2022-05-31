using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn_PTTK_HTTT.DAO;
using DoAn_PTTK_HTTT.DTO;


namespace DoAn_PTTK_HTTT.BUS
{
    class DoiTraBUS
    {
        SQLHepler sql = new SQLHepler();   
        public static int ThemDoiTra(DoiTraDTO dt)
        {

            return 2;
        }

        public static int XoaDoiTra(DoiTraDTO dt)
        {

            return 2;
        }

        public static int SuaDoiTra(DoiTraDTO dt)
        {

            return 2;
        }
        public static int ThemChiTietDoiTra(DoiTraDTO dt)
        {

            return 2;
        }
        public static int XoaChiTietDoiTra(DoiTraDTO dt)
        {

            return 2;
        }
        public static int SuaChiTietDoiTra(DoiTraDTO dt)
        {

            return 2;
        }
        public List<DoiTraDTO> LayDoiTra()
        {
            string strSQL = "Select * from DoiTra";
            string tableName = "DoiTra";
            List<DoiTraDTO> lst = new List<DoiTraDTO>();
            DataTable dt = new DataTable("DoiTra");
            dt = sql.getDataTable(strSQL,tableName);
            lst = (from DataRow dr in dt.Rows
                   select new DoiTraDTO()
                   {
                       MaDoiTra = dr["MaDoiTra"].ToString(),
                       MaNV = dr["MaNV"].ToString(),
                       MaKH = dr["MaKH"].ToString(),
                       MaLoaiKH = dr["MaLoaiKH"].ToString(),
                       ThoiGian = DateTime.Parse(dr["ThoiGian"].ToString())
                   }).ToList();
            return lst;
        }
        public List<ChiTietDoiTraDTO> LayChiTietDoiTra()
        {
            string strSQL = "Select * from ChiTietDoiTra";
            string tableName = "ChiTietDoiTra";
            List<ChiTietDoiTraDTO> lst = new List<ChiTietDoiTraDTO>();
            DataTable dt = new DataTable("ChiTietDoiTra");
            dt = sql.getDataTable(strSQL, tableName);
            lst = (from DataRow dr in dt.Rows
                   select new ChiTietDoiTraDTO()
                   {
                       MaCTDoiTra = dr["MaCTDoiTra"].ToString(),
                       MaDoiTra = dr["MaDoiTra"].ToString(),
                       MaSP = dr["MaSP"].ToString(),
                       SoLuong = int.Parse(dr["SoLuong"].ToString()),
                       MoTaChiTiet = dr["MoTaChiTiet"].ToString()
                   }).ToList();
            return lst;
        }
    }
}
