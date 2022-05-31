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
    class DoiTraDAO:SQLHepler
    {
        public SqlDataAdapter ada_DoiTra = new SqlDataAdapter();
        public SqlDataAdapter ada_ChiTietDoiTra = new SqlDataAdapter();
        DataColumn[] primaryKey = new DataColumn[1];
        public static string MaDT;
        int count = 1;
        public DoiTraDAO()
        {
            string strSQl = "  SELECT * FROM DoiTra";
            ada_DoiTra = getDataAdapter(strSQl, "DoiTra");
            primaryKey[0] = DSet.Tables["DoiTra"].Columns["MaDoiTra"];
            DSet.Tables["DoiTra"].PrimaryKey = primaryKey;

            strSQl = "  SELECT * FROM ChiTietDoiTra";
            ada_ChiTietDoiTra = getDataAdapter(strSQl, "ChiTietDoiTra");
            primaryKey[0] = DSet.Tables["ChiTietDoiTra"].Columns["MaCTDoiTra"];
            DSet.Tables["ChiTietDoiTra"].PrimaryKey = primaryKey;
        }
        public List<DoiTraDTO> LayDoiTra()
        {
            string strSQL = "Select * from DoiTra";
            string tableName = "DoiTra"+ count;
            count++;
            List<DoiTraDTO> lst = new List<DoiTraDTO>();
            DataTable dt = new DataTable();
            dt = getDataTable(strSQL, tableName);
            lst.Clear();
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
            string tableName = "ChiTietDoiTra" + count;
            count++;
            List<ChiTietDoiTraDTO> lst = new List<ChiTietDoiTraDTO>();
            DataTable dt = new DataTable();
            dt = getDataTable(strSQL, tableName);
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
                bool check = checkExist("ChiTietDoiTra", "MaCTDoiTra", CTDoiTra.MaDoiTra);
                if (check == true )
                {
                    return 0;
                }
                DataRow newRow = DSet.Tables["ChiTietDoiTra"].NewRow();
                newRow["MaCTDoiTra"] = CTDoiTra.MaCTDoiTra;
                newRow["MaDoiTra"] = CTDoiTra.MaDoiTra;
                newRow["MaSP"] = CTDoiTra.MaSP;
                newRow["SoLuong"] = CTDoiTra.SoLuong;
                newRow["MoTaChiTiet"] = CTDoiTra.MoTaChiTiet;
                DSet.Tables["ChiTietDoiTra"].Rows.Add(newRow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ada_ChiTietDoiTra);
                ada_ChiTietDoiTra.Update(DSet, "ChiTietDoiTra");
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
                bool check = checkExist("DoiTra", "MaDoiTra", doiTra.MaDoiTra);
                if (check == true )
                {
                    return 0;
                }
                DataRow newRow = DSet.Tables["DoiTra"].NewRow();
                newRow["MaDoiTra"] = doiTra.MaDoiTra;
                newRow["MaNV"] = doiTra.MaNV;
                newRow["MaKH"] = doiTra.MaKH;
                newRow["MaLoaiKH"] = doiTra.MaLoaiKH;
                newRow["ThoiGian"] = doiTra.ThoiGian;
                DSet.Tables["DoiTra"].Rows.Add(newRow);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ada_DoiTra);
                ada_DoiTra.Update(DSet, "DoiTra");
                MaDT = doiTra.MaDoiTra;
                return 1;
            }
            catch
            {
                return 2;

            }
        }
        public int XoaChiTietDoiTra(string maCTDT)
        {
            try
            {
                DataRow deleteRow = DSet.Tables["ChiTietDoiTra"].Rows.Find(maCTDT);
                if (deleteRow == null)
                {
                    return 0;
                }
                deleteRow.Delete();
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ada_ChiTietDoiTra);
                ada_ChiTietDoiTra.Update(DSet, "ChiTietDoiTra");
                return 1;
            }
            catch
            {
                return 2;

            }
        }
        public int XoaDoiTra(string maDT)
        {
            try
            {
                DataRow deleteRow = DSet.Tables["DoiTra"].Rows.Find(maDT);
                if (deleteRow == null)
                {
                    return 0;
                }
                deleteRow.Delete();
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ada_DoiTra);
                ada_DoiTra.Update(DSet, "DoiTra");
                return 1;
            }
            catch
            {
                return 2;

            }
        }
        public int SuaChiTietDoiTra(ChiTietDoiTraDTO dt)
        {
            try
            {
                DataRow updateRow = DSet.Tables["ChiTietDoiTra"].Rows.Find(dt.MaCTDoiTra);
                if (updateRow == null)
                {
                    return 0;
                }
                updateRow["MoTaChiTiet"] = dt.MoTaChiTiet;
                updateRow["SoLuong"] = dt.SoLuong;
                updateRow["MaSP"] = dt.MaSP;
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ada_ChiTietDoiTra);
                ada_ChiTietDoiTra.Update(DSet, "ChiTietDoiTra");
                return 1;
            }
            catch
            {
                return 2;

            }
        }
    }
}
