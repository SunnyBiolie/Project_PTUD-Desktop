using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.Model.DTO
{
    public class KeHoach
    {
        private string maPhim;
        private string maCum;
        private DateTime ngayKhoiChieu;
        private DateTime ngayKetThuc;
        private string ghiChu;

        public string MaPhim { get => maPhim; set => maPhim = value; }
        public string MaCum { get => maCum; set => maCum = value; }
        public DateTime NgayKhoiChieu { get => ngayKhoiChieu; set => ngayKhoiChieu = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

        public KeHoach(string maPhim, string maCum, DateTime ngayKhoiChieu, DateTime ngayKetThuc, string ghiChu = "")
        {
            this.maPhim = maPhim;
            this.maCum = maCum;
            this.ngayKhoiChieu = ngayKhoiChieu;
            this.ngayKetThuc = ngayKetThuc;
            this.ghiChu = ghiChu;
        }
        public KeHoach(DataRow row)
        {
            maPhim = row["MaPhim"].ToString();
            maCum = row["maCum"].ToString();
            ngayKhoiChieu = (DateTime)row["NgayKhoiChieu"];
            ngayKetThuc = (DateTime)row["NgayKetThuc"];
            ghiChu = row["GhiChu"].ToString();
        }
    }
}
