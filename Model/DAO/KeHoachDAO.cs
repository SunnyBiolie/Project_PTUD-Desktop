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
    public class KeHoachDAO
    {
        private static KeHoachDAO instance;
        public static KeHoachDAO Instance
        {
            get
            {
                if (instance == null) instance = new KeHoachDAO();
                return instance;
            }
            private set => instance = value;
        }
        private KeHoachDAO() { }

        public ObservableCollection<KeHoach> GetListKeHoachs()
        {
            ObservableCollection<KeHoach> list = new ObservableCollection<KeHoach>();

            string query = "select * from KeHoach";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                KeHoach keHoach = new KeHoach(row);
                list.Add(keHoach);
            }

            return list;
        }
        public ObservableCollection<KeHoach> GetListKeHoachsByMaCum(string MaCum)
        {
            ObservableCollection<KeHoach> list = new ObservableCollection<KeHoach>();

            string query = "select * from KeHoach where MaCum = @MaCum";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { MaCum });

            foreach (DataRow row in dataTable.Rows)
            {
                KeHoach keHoach = new KeHoach(row);
                list.Add(keHoach);
            }

            return list;
        }
        public ObservableCollection<KeHoach> GetListKeHoachsByMaPhim(string MaPhim)
        {
            ObservableCollection<KeHoach> list = new ObservableCollection<KeHoach>();

            string query = "select * from KeHoach where MaPhim = @MaPhim";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { MaPhim });

            foreach (DataRow row in dataTable.Rows)
            {
                KeHoach keHoach = new KeHoach(row);
                list.Add(keHoach);
            }

            return list;
        }
    }
}
