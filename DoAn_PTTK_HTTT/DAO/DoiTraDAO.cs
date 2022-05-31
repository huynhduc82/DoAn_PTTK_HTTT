using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn_PTTK_HTTT.DTO;

namespace DoAn_PTTK_HTTT.DAO
{
    class DoiTraDAO
    {
        SQLHepler sql = new SQLHepler();
        public SqlDataAdapter ada_DoiTra = new SqlDataAdapter();
        public SqlDataAdapter ada_ChiTietDoiTra = new SqlDataAdapter();
        public static string MaDT;
        public List<DoiTraDTO> LayDoiTra()
        {
            string strSQL = "Select * from DoiTra";
            string tableName = "DoiTra";
            List<DoiTraDTO> lst = new List<DoiTraDTO>();
            DataTable dt = new DataTable("DoiTra");
            dt = sql.getDataTable(strSQL, tableName);
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
        public int ThemChiTietDoiTra(ChiTietDoiTraDTO CTDoiTra)
        {
            try
            {
                bool check = sql.checkExist("DoiTra", "ChiTietDoiTra", CTDoiTra.MaDoiTra);
                if (check == false )
                {
                    return 0;
                }
                DataRow newRow = sql.DSet.Tables["ChiTietDoiTra"].NewRow();
                newRow["MaChiTietDoiTra"] = CTDoiTra.MaCTDoiTra;
                newRow["MaDoiTra"] = CTDoiTra.MaDoiTra;
                newRow["MaSP"] = CTDoiTra.MaSP;
                newRow["SoLuong"] = CTDoiTra.SoLuong;
                newRow["MoTaChiTiet"] = CTDoiTra.MoTaChiTiet;
                sql.DSet.Tables["ChiTietHoaDon"].Rows.Add(newRow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ada_DoiTra);
                ada_DoiTra.Update(sql.DSet, "ChiTietHoaDon");
                return 1;
            }
            catch
            {
                return 2;

            }
        }
        public int ThemDoiTraMoi(DoiTraDTO doiTra)
        {
            try
            {
                bool check = sql.checkExist("DoiTra", "MaDoiTra", doiTra.MaDoiTra);
                if (check == false )
                {
                    return 0;
                }
                DataRow newRow = sql.DSet.Tables["DoiTra"].NewRow();
                newRow["MaDoiTra"] = doiTra.MaDoiTra;
                newRow["MaNV"] = doiTra.MaNV;
                newRow["MaKH"] = doiTra.MaKH;
                newRow["MaLoaiKH"] = doiTra.MaLoaiKH;
                newRow["ThoiGian"] = doiTra.ThoiGian;
                sql.DSet.Tables["DoiTra"].Rows.Add(newRow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ada_DoiTra);
                ada_DoiTra.Update(sql.DSet, "HoaDon");
                MaDT = doiTra.MaDoiTra;
                return 1;
            }
            catch
            {
                return 2;

            }
        }
    }
}
