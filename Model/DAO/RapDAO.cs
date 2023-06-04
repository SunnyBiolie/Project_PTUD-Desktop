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
    public class RapDAO
    {
        private static RapDAO instance;
        public static RapDAO Instance
        {
            get
            {
                if (instance == null) instance = new RapDAO();
                return instance;
            }
            private set => instance = value;
        }
        private RapDAO() { }

        public ObservableCollection<Rap> GetListRaps()
        {
            ObservableCollection<Rap> list = new ObservableCollection<Rap>();

            string query = "select * from Rap";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                Rap rap = new Rap(row);
                list.Add(rap);
            }

            return list;
        }

        public ObservableCollection<Rap> GetListRapsByMaCum(string MaCum)
        {
            ObservableCollection<Rap> list = new ObservableCollection<Rap>();

            string query = "select * from Rap where MaCum = @MaCum";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { MaCum });

            foreach (DataRow row in dataTable.Rows)
            {
                Rap rap = new Rap(row);
                list.Add(rap);
            }

            return list;
        }

        public bool InsertRap(Rap rap)
        {
            string query = $"insert Rap (MaRap, TongGhe, MaCum) values ( @maRap , @tongGhe , @maCum )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { rap.MaRap, rap.TongGhe, rap.MaCum });

            return result > 0;
        }
    }
}
