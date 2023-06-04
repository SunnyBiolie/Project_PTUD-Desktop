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
    public class TheLoaiDAO
    {
        private static TheLoaiDAO instance;
        public static TheLoaiDAO Instance
        {
            get
            {
                if (instance == null) instance = new TheLoaiDAO();
                return instance;
            }
            private set => instance = value;
        }
        private TheLoaiDAO() { }

        public ObservableCollection<TheLoai> GetListTheLoais()
        {
            ObservableCollection<TheLoai> list = new ObservableCollection<TheLoai>();

            string query = "select * from TheLoai";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                TheLoai theLoai = new TheLoai(row);
                list.Add(theLoai);
            }

            return list;
        }
        public TheLoai GetTheLoaiByMaTheLoaiChinh(string MaTheLoaiChinh)
        {
            string query = "select * from TheLoai where MaTheLoai = @MaTheLoaiChinh";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { MaTheLoaiChinh });

            TheLoai theLoai = new TheLoai(dataTable.Rows[0]);
            
            return theLoai;
        }
        public ObservableCollection<TheLoai> GetListTheLoaiPhusByMaPhim(string MaPhim)
        {
            ObservableCollection<TheLoai> list = new ObservableCollection<TheLoai>();

            string query = "select TheLoai.MaTheLoai, TheLoai.TenTheLoai from TheLoai, Phim, PhimTheLoaiPhu where Phim.MaPhim = PhimTheLoaiPhu.MaPhim and TheLoai.MaTheLoai = PhimTheLoaiPhu.MaTheLoai and Phim.MaPhim = @MaPhim";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { MaPhim });

            foreach (DataRow row in dataTable.Rows)
            {
                TheLoai theLoai = new TheLoai(row);
                list.Add(theLoai);
            }

            return list;
        }
        public List<string> GetListTenTheLoaisByListTheLoais(ObservableCollection<TheLoai> dsTheLoais)
        {
            List<string> list = new List<string>();
            foreach (TheLoai theloai in dsTheLoais)
            {
                list.Add(theloai.TenTheLoai);
            }

            return list;
        }

        public bool InsertTheLoai(TheLoai theLoai)
        {
            string query = $"insert TheLoai (MaTheLoai, TenTheLoai) values ( @maTheLoai , @tenTheLoai )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { theLoai.MaTheLoai, theLoai.TenTheLoai });

            return result > 0;
        }
        public bool UpdateInfoTheLoai(TheLoai theLoai)
        {
            string query = $"update TheLoai set TenTheLoai = @tenTheLoai where MaTheLoai = @maTheLoai";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { theLoai.TenTheLoai, theLoai.MaTheLoai });

            return result > 0;
        }
        public bool UpdateInfoTheLoai(string tenTheLoai, string maTheLoai)
        {
            string query = $"update TheLoai set TenTheLoai = @tenTheLoai where MaTheLoai = @maTheLoai";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenTheLoai, maTheLoai });

            return result > 0;
        }
        public bool DeleteTheLoai(string maTheLoai)
        {
            string query = $"Delete TheLoai where MaTheLoai = @maTheLoai";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maTheLoai });

            return result > 0;
        }

        public bool InsertTheLoaiPhuIntoPhim(string maTheLoaiPhu, string maPhim)
        {
            string query = $"insert PhimTheLoaiPhu (MaPhim, MaTheLoai) values ( @maPhim , @maTheLoaiPhu )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maPhim, maTheLoaiPhu });

            return result > 0;
        }
        public bool DeleteTheLoaiPhuFromPhim(string maTheLoaiPhu, string maPhim)
        {
            string query = $"Delete PhimTheLoaiPhu where MaTheLoai = @maTheLoaiPhu and MaPhim = @maPhim";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maTheLoaiPhu, maPhim });

            return result > 0;
        }
    }
}
