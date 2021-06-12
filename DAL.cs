using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_LINQ
{
    public class DAL 
    {
        LINQKDLCTDataContext db = new LINQKDLCTDataContext();
        List<DKLichCT> DS1 = new List<DKLichCT>();
        List<HOTENDK> HT = new List<HOTENDK>();
        //List<TaiKhoangDN> TK = new List<TaiKhoangDN>();

        public List<DKLichCT> HienThi()
        {
            DS1 = db.DKLichCTs.OrderBy(p => p.STT).ToList();
            return DS1;
        }
        public List<HOTENDK> DSTen()
        {
            HT = db.HOTENDKs.OrderBy(p=> p.HoTenDK1).ToList();
            return HT;
        }
        public bool Them(DKLichCT tb)
        {
            try
            {
                db.DKLichCTs.InsertOnSubmit(tb);

                db.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool Xoa(int tb)
        {
            try
            {
                DKLichCT tv = db.DKLichCTs.Where(p => p.STT == tb).FirstOrDefault();
                db.DKLichCTs.DeleteOnSubmit(tv);

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Sua(DKLichCT tb)
        {
            try
            {
                DKLichCT tv = db.DKLichCTs.Where(p => p.STT == tb.STT).FirstOrDefault();
                tv.NgayBD = tb.NgayBD;
                tv.NgayKT = tb.NgayKT;
                tv.LyDo = tb.LyDo;
                tv.HoTen = tb.HoTen;
                tv.DienGiai = tb.DienGiai;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<DKLichCT> TimKiem(string tb)
        {
            List<DKLichCT> tk = new List<DKLichCT>();

            tk.AddRange(db.DKLichCTs.Where(p => p.HoTen == tb));
            return tk;
        }
        //public List<TaiKhoangDN> TaiKhoan(string tk, string mk)
        //{
        //    //List<TaiKhoangDN> TK = new List<TaiKhoangDN>()/*;*/
        //    List<TaiKhoangDN> taikhoan = new List<TaiKhoangDN>();
        //    taikhoan.Add(db.TaiKhoangDNs.Where(p => p.Users == tk && p.PassWord == mk).FirstOrDefault());

        //    TaiKhoangDN dn = new TaiKhoangDN();
        //    dn = db.TaiKhoangDNs.Where(p => p.Users == tk && p.PassWord == mk).FirstOrDefault();
        //    return taikhoan;
        //}
        public TaiKhoangDN TaiKhoan(string tk, string mk)
        {

            TaiKhoangDN dn = new TaiKhoangDN();
            dn = db.TaiKhoangDNs.Where(p => p.Users == tk && p.PassWord == mk).FirstOrDefault();
            return dn;
        }


    }
}
