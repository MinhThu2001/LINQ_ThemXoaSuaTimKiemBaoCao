using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_LINQ
{
    public class DTO
    {
        private int stt;
        private string ngaybd;
        private string ngaykt;
        private string lydo;
        private string hoten;
        private string diengiai;

        public int STT
        {
            get
            {
                return stt;
            }
            set
            {
                stt = value;
            }
        }
        public string NgayBD
        {
            get
            {
                return ngaybd;
            }
            set
            {
                ngaybd = value;
            }
        }
        public string NgayKT
        {
            get
            {
                return ngaykt;
            }
            set
            {
                ngaykt = value;
            }
        }
        public string LyDo
        {
            get
            {
                return lydo;
            }
            set
            {
                lydo = value;
            }
        }
        public string HoTen
        {
            get
            {
                return hoten;
            }
            set
            {
                hoten = value;
            }
        }
        public string DienGiai
        {
            get
            {
                return diengiai;
            }
            set
            {
                diengiai = value;
            }
        }
        public DTO()
        {

        }
        public DTO(int stt, string bd, string kt, string ld, string ht, string dg)
        {
            this.STT = stt;
            this.NgayBD = bd;
            this.NgayKT = kt;
            this.LyDo = ld;
            this.HoTen = ht;
            this.DienGiai = dg;
        }
    }
}
