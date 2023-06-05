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
    public class SuatChieuDAO
    {
        private static SuatChieuDAO instance;
        public static SuatChieuDAO Instance
        {
            get
            {
                if (instance == null) instance = new SuatChieuDAO();
                return instance;
            }
            private set => instance = value;
        }
        private SuatChieuDAO() { }

        public ObservableCollection<SuatChieuDTO> GetListSuatChieus()
        {
            ObservableCollection<SuatChieuDTO> list = new ObservableCollection<SuatChieuDTO>();

            string query = "select * from SuatChieu";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                SuatChieuDTO suatChieu = new SuatChieuDTO(row);
                list.Add(suatChieu);
            }

            return list;
        }

        public bool InsertSuatChieu(SuatChieuDTO suatChieu)
        {
            string query = $"insert SuatChieu (MaSuat, GioBatDau, PhutBatDau) values ( @maSuat , @gioBatDau , @suatBatDau )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { suatChieu.MaSuat, suatChieu.GioBatDau, suatChieu.PhutBatDau });

            return result > 0;
        }
        public bool DeleteSuatChieu(string maSuat)
        {
            string query = $"Delete SuatChieu where MaSuat = @maSuat";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSuat });

            return result > 0;
        }
    }
}
