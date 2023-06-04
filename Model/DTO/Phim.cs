using Project_PTUD_Desktop.Model.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.Model.DTO
{
    public class Phim
    {
        private string maPhim;
        private string tenPhim;
        private string maTheLoaiChinh;
        private int thoiLuong;

        private TheLoai theLoaiChinh;
        private ObservableCollection<TheLoai> dsTheLoaiPhus = new ObservableCollection<TheLoai>();
        private string chuoiTenTheLoaiPhu;
        private ObservableCollection<KeHoach> dsKeHoachs = new ObservableCollection<KeHoach>();
        private ObservableCollection<LichChieu> dsLichChieus = new ObservableCollection<LichChieu>();

        public string MaPhim { get => maPhim; set => maPhim = value; }
        public string TenPhim { get => tenPhim; set => tenPhim = value; }
        public string MaTheLoaiChinh { get => maTheLoaiChinh; set => maTheLoaiChinh = value; }
        public int ThoiLuong { get => thoiLuong; set => thoiLuong = value; }

        public TheLoai TheLoaiChinh { get => theLoaiChinh; set => theLoaiChinh = value; }
        public ObservableCollection<TheLoai> DsTheLoaiPhus { get => dsTheLoaiPhus; set => dsTheLoaiPhus = value; }
        public string ChuoiTenTheLoaiPhu { get => chuoiTenTheLoaiPhu; set => chuoiTenTheLoaiPhu = value; }
        public ObservableCollection<KeHoach> DsKeHoachs { get => dsKeHoachs; set => dsKeHoachs = value; }
        public ObservableCollection<LichChieu> DsLichChieus { get => dsLichChieus; set => dsLichChieus = value; }

        //TheLoaiChinh = TheLoaiDAO.Instance.GetTheLoaiByMaTheLoaiChinh(maTheLoaiChinh);
        //DsTheLoaiPhus = TheLoaiDAO.Instance.GetListTheLoaiPhusByMaPhim(maPhim);
        //ChuoiTenTheLoaiPhu = string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(DsTheLoaiPhus));
        //DsKeHoachs = KeHoachDAO.Instance.GetListKeHoachsByMaPhim(maPhim);
        //DsLichChieus = LichChieuDAO.Instance.GetListLichChieusByMaPhim(maPhim);

        public Phim(string maPhim, string tenPhim, string maTheLoaiChinh, int thoiLuong)
        {
            this.maPhim = maPhim;
            this.tenPhim = tenPhim;
            this.maTheLoaiChinh= maTheLoaiChinh;
            this.thoiLuong = thoiLuong;
        }
        public Phim(DataRow row)
        {
            maPhim = row["MaPhim"].ToString();
            tenPhim = row["TenPhim"].ToString();
            maTheLoaiChinh = row["MaTheLoaiChinh"].ToString();
            thoiLuong = (int)row["ThoiLuong"];
        }
    }
}
