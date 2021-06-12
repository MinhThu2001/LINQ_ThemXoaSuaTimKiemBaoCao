using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_LINQ;

namespace BUS_LINQ
{
    public class BUS
    {
        DAL dal = new DAL();
        
        public List<DKLichCT> HienThi()
        {
            return dal.HienThi();
        }
        public List<HOTENDK> DSTen()
        {
            return dal.DSTen();
        }
        public bool Them(DKLichCT tb)
        {
            return dal.Them(tb);
        }
        public bool Xoa(int tb)
        {
            return dal.Xoa(tb);
        }
        public bool Sua(DKLichCT tb)
        {
            return dal.Sua(tb);
        }
        public List<DKLichCT> TimKiem(string tb)
        {
            return dal.TimKiem(tb);
        }
        public TaiKhoangDN TaiKhoan(string tk, string mk)
        {
            return dal.TaiKhoan(tk, mk);
        }
        
    }
}
