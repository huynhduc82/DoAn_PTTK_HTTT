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

        public int XoaDoiTra(DoiTraDTO dt)
        {

            return 2;
        }

        public int SuaDoiTra(DoiTraDTO dt)
        {

            return 2;
        }
        public int ThemChiTietDoiTra(DoiTraDTO dt)
        {

            return 2;
        }
        public int XoaChiTietDoiTra(DoiTraDTO dt)
        {

            return 2;
        }
        public int SuaChiTietDoiTra(DoiTraDTO dt)
        {

            return 2;
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
