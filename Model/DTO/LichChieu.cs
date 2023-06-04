using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.Model.DTO
{
    public class LichChieu
    {
        private string maPhim;
        private string maRap;
        private DateTime ngayChieu;
        private string chuoiMaSuat;

        public string MaPhim { get => maPhim; set => maPhim = value; }
        public string MaRap { get => maRap; set => maRap = value; }
        public DateTime NgayChieu { get => ngayChieu; set => ngayChieu = value; }
        public string ChuoiMaSuat { get => chuoiMaSuat; set => chuoiMaSuat = value; }

        public LichChieu(string maPhim, string maRap, DateTime ngayChieu, string chuoiMaSuat)
        {
            this.maPhim = maPhim;
            this.maRap = maRap;
            this.ngayChieu = ngayChieu;
            this.chuoiMaSuat = chuoiMaSuat;
        }
        public LichChieu(DataRow row)
        {
            maPhim = row["MaPhim"].ToString();
            maRap = row["MaRap"].ToString();
            ngayChieu = (DateTime)row["NgayChieu"];
            chuoiMaSuat = row["ChuoiMaSuat"].ToString();
        }
    }
}
