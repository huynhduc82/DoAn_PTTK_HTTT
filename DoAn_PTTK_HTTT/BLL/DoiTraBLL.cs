using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn_PTTK_HTTT.DAO;
using DoAn_PTTK_HTTT.DTO;


namespace DoAn_PTTK_HTTT.BLL
{
    class DoiTraBLL
    {
        SQLHepler sql = new SQLHepler();
        DoiTraDAO doiTra = new DoiTraDAO();
        public int ThemDoiTra(DoiTraDTO dt)
        {
            int flag = doiTra.ThemDoiTraMoi(dt);
            return flag;
        }

        public int XoaDoiTra(string maDT)
        {
            int flag = doiTra.XoaDoiTra(maDT);
            return flag;
        }
        public int ThemChiTietDoiTra(ChiTietDoiTraDTO dt)
        {
            int flag = doiTra.ThemChiTietDoiTra(dt);
            return flag;
        }
        public int XoaChiTietDoiTra(string maCTDT)
        {
            int flag = doiTra.XoaChiTietDoiTra(maCTDT);
            return flag;
        }
        public int SuaChiTietDoiTra(ChiTietDoiTraDTO dt)
        {
            int flag = doiTra.SuaChiTietDoiTra(dt);
            return flag;
        }
        public List<ChiTietDoiTraDTO> LayChiTietDoiTra()
        {
            return doiTra.LayChiTietDoiTra();
        }
        public List<DoiTraDTO> LayDoiTra()
        {
            return doiTra.LayDoiTra();
        }

    }
}
