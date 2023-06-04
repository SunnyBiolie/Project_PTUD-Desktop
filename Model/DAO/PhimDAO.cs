using Project_PTUD_Desktop.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.Model.DAO
{
    public class PhimDAO
    {
        private static PhimDAO instance;
        public static PhimDAO Instance
        {
            get
            {
                if (instance == null) instance = new PhimDAO();
                return instance;
            }
            private set => instance = value;
        }
        private PhimDAO() { }

        public ObservableCollection<Phim> GetListPhims()
        {
            ObservableCollection<Phim> list = new ObservableCollection<Phim>();

            string query = "select * from Phim";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                Phim phim = new Phim(row);
                phim.TheLoaiChinh = TheLoaiDAO.Instance.GetTheLoaiByMaTheLoaiChinh(phim.MaTheLoaiChinh);
                phim.DsTheLoaiPhus = TheLoaiDAO.Instance.GetListTheLoaiPhusByMaPhim(phim.MaPhim);
                phim.ChuoiTenTheLoaiPhu = string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(phim.DsTheLoaiPhus));
                phim.DsKeHoachs = KeHoachDAO.Instance.GetListKeHoachsByMaPhim(phim.MaPhim);
                phim.DsLichChieus = LichChieuDAO.Instance.GetListLichChieusByMaPhim(phim.MaPhim);

                list.Add(phim);
            }

            return list;
        }
        public ObservableCollection<Phim> GetListPhimsByMaTheLoaiChinh(string maTheLoaiChinh)
        {
            ObservableCollection<Phim> list = new ObservableCollection<Phim>();

            string query = "select * from Phim where MaTheLoaiChinh = @maTheLoaiChinh";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { maTheLoaiChinh });

            foreach (DataRow row in dataTable.Rows)
            {
                Phim phim = new Phim(row);
                list.Add(phim);
            }

            return list;
        }
        public ObservableCollection<Phim> GetListPhimsByMaTheLoaiPhu(string maTheLoaiPhu)
        {
            ObservableCollection<Phim> list = new ObservableCollection<Phim>();

            string query = "select Phim.MaPhim, Phim.TenPhim, Phim.MaTheLoaiChinh, Phim.ThoiLuong from Phim, PhimTheLoaiPhu where Phim.MaPhim = PhimTheLoaiPhu.MaPhim and PhimTheLoaiPhu.MaTheLoai = @maTheLoaiPhu";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { maTheLoaiPhu });

            foreach (DataRow row in dataTable.Rows)
            {
                Phim theLoai = new Phim(row);
                list.Add(theLoai);
            }

            return list;
        }
        public Phim GetPhimByMaPhim(string maPhim)
        {
            string query = "select * from Phim where MaPhim = @maPhim";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { maPhim });

            Phim phim = new Phim(dataTable.Rows[0]);

            return phim;
        }

        public bool InsertPhim(Phim phim)
        {
            string query = $"insert Phim (MaPhim, TenPhim, MaTheloaiChinh, ThoiLuong) values ( @maPhim , @tenPhim , @maTheLoaiChinh , @thoiLuong )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { phim.MaPhim, phim.TenPhim, phim.MaTheLoaiChinh, phim.ThoiLuong });

            return result > 0;
        }
        public bool UpdateInfoPhim(Phim phim)
        {
            string query = $"update Phim set TenPhim = @tenPhim , MaTheLoaiChinh = @maTheLoaiChinh , ThoiLuong = @thoiLuong where MaPhim = @maPhim";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { phim.TenPhim, phim.MaTheLoaiChinh, phim.ThoiLuong, phim.MaPhim });

            return result > 0;
        }
        public bool DeletePhim(string maPhim)
        {
            string query = $"Delete Phim where MaPhim = @maPhim";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maPhim });

            return result > 0;
        }
    }
}
