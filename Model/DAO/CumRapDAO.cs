using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_PTUD_Desktop.Model.DTO;

namespace Project_PTUD_Desktop.Model.DAO
{
    public class CumRapDAO
    {
        private static CumRapDAO instance;
        public static CumRapDAO Instance
        {
            get
            {
                if (instance == null) instance = new CumRapDAO();
                return instance;
            }
            private set => instance = value;
        }
        private CumRapDAO() { }

        public ObservableCollection<CumRap> GetListCumRaps()
        {
            ObservableCollection<CumRap> list = new ObservableCollection<CumRap>();

            string query = "select * from CumRap";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                CumRap cumRap = new CumRap(row);
                list.Add(cumRap);
            }

            return list;
        }
        public CumRap GetCumRapByMaCum(string maCum)
        {
            string query = "select * from CumRap where MaCum = @maCum";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { maCum });

            CumRap cumRap = new CumRap(dataTable.Rows[0]);

            return cumRap;
        }

        public bool InsertCumRap(string maCum, string tenCum, string diaChi)
        {
            string query = $"insert CumRap (MaCum, TenCum, DiaChi) values ( @maCum , @tenCum , @diaChi )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maCum, tenCum, diaChi });

            return result > 0;
        }
        public bool InsertCumRap(CumRap cumRap)
        {
            string query = $"insert CumRap (MaCum, TenCum, DiaChi) values ( @maCum , @tenCum , @diaChi )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { cumRap.MaCum, cumRap.TenCum, cumRap.DiaChi });

            return result > 0;
        }
        public bool UpdateInfoCumRap(string tenCum, string diaChi, string maCum)
        {
            string query = $"update CumRap set TenCum = @tenCum , DiaChi = @diaChi where MaCum = @maCum";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenCum, diaChi, maCum });

            return result > 0;
        }
        public bool UpdateInfoCumRap(CumRap cumRap)
        {
            string query = $"update CumRap set TenCum = @tenCum , DiaChi = @diaChi where MaCum = @maCum";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { cumRap.TenCum, cumRap.DiaChi, cumRap.MaCum });

            return result > 0;
        }
        public bool DeleteCumRap(string maCum)
        {
            string query = $"Delete CumRap where MaCum = @maCum";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maCum });

            return result > 0;
        }
    }
}
