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
    public class LichChieuDAO
    {
        private static LichChieuDAO instance;
        public static LichChieuDAO Instance
        {
            get
            {
                if (instance == null) instance = new LichChieuDAO();
                return instance;
            }
            private set => instance = value;
        }
        private LichChieuDAO() { }

        public ObservableCollection<LichChieu> GetListLichChieus()
        {
            ObservableCollection<LichChieu> list = new ObservableCollection<LichChieu>();

            string query = "select * from LichChieu";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                LichChieu lichChieu = new LichChieu(row);
                list.Add(lichChieu);
            }

            return list;
        }

        public ObservableCollection<LichChieu> GetListLichChieusByMaRap(string MaRap)
        {
            ObservableCollection<LichChieu> list = new ObservableCollection<LichChieu>();

            string query = "select * from LichChieu where MaRap = @MaRap";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { MaRap });

            foreach (DataRow row in dataTable.Rows)
            {
                LichChieu lichChieu = new LichChieu(row);
                list.Add(lichChieu);
            }

            return list;
        }
        public ObservableCollection<LichChieu> GetListLichChieusByMaPhim(string MaPhim)
        {
            ObservableCollection<LichChieu> list = new ObservableCollection<LichChieu>();

            string query = "select * from LichChieu where MaPhim = @MaPhim";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { MaPhim });

            foreach (DataRow row in dataTable.Rows)
            {
                LichChieu lichChieu = new LichChieu(row);
                list.Add(lichChieu);
            }

            return list;
        }
    
        public bool InsertLichChieu(ModelEntity.LichChieu lc)
        {
            string query = "insert LichChieu (Maphim, MaRap, NgayChieu, ChuoiMaSuat) values ( @maphim , @marap , @ngaychieu , @chuoimasuat )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { lc.MaPhim, lc.MaRap, lc.NgayChieu, lc.ChuoiMaSuat });

            return result > 0;
        }
    }
}
