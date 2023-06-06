using Project_PTUD_Desktop.Model.DTO;
using Project_PTUD_Desktop.ModelEntity.EntityDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.ModelEntity.EntityDAO
{
    public class ShowTimesDAO
    {
        private static ShowTimesDAO instance;
        public static ShowTimesDAO Instance
        {
            get
            {
                if (instance == null) instance = new ShowTimesDAO();
                return instance;
            }
            private set => instance = value;
        }
        private ShowTimesDAO() { }

        public string GetStringTimeSortedFromChuoiMaSuat(string chuoiMaSuat)
        {
            ObservableCollection<SuatChieu> listSuatChieu = ScreeningsDAO.Instance.GetListSuatChieuByChuoiMaSuat(chuoiMaSuat);
            List<TimeSpan> listTGChieu = new List<TimeSpan>();
            foreach (SuatChieu sc in listSuatChieu)
            {
                TimeSpan ts = new TimeSpan(sc.GioBatDau, sc.PhutBatDau, 0);
                listTGChieu.Add(ts);
            }
            for (int i = 0; i < listTGChieu.Count; i++)
            {
                for (int j = i + 1; j < listTGChieu.Count - 1; j++)
                {
                    if (TimeSpan.Compare(listTGChieu[i], listTGChieu[j]) > 0)
                    {
                        TimeSpan temp = listTGChieu[i];
                        listTGChieu[i] = listTGChieu[j];
                        listTGChieu[j] = temp;
                    }
                }
            }
            List<string> strings = new List<string>();
            foreach (TimeSpan ts in listTGChieu)
            {
                if (ts.Minutes == 0) strings.Add($"{ts.Hours}h");
                else strings.Add($"{ts.Hours}h{ts.Minutes}");
            }

            return string.Join("  ", strings);
        }

        public ObservableCollection<ShowTimesDTO> GetMoreDetailListFromListLichChieu(ObservableCollection<LichChieu> listLichChieu)
        {
            ObservableCollection<ShowTimesDTO> list = new ObservableCollection<ShowTimesDTO>();
            foreach (LichChieu lc in listLichChieu)
            {
                ShowTimesDTO st = new ShowTimesDTO(lc);
                list.Add(st);
            }

            return list;
        }

        public string GetStringTimeByListSuatChieu(ObservableCollection<SuatChieu> listSuatChieu)
        {
            List<TimeSpan> list = new List<TimeSpan>();
            foreach (SuatChieu sc in listSuatChieu)
            {
                TimeSpan tg = new TimeSpan(sc.GioBatDau, sc.PhutBatDau, 0);
                list.Add(tg);
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (TimeSpan.Compare(list[i], list[j]) > 0)
                    {
                        TimeSpan temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            List<string> strings = new List<string>();
            foreach (TimeSpan ts in list)
            {
                if (ts.Minutes == 0) strings.Add($"{ts.Hours}h");
                else strings.Add($"{ts.Hours}h{ts.Minutes}");
            }

            return string.Join("  ", strings);
        }

        public ObservableCollection<TimeSpan> GetListTimeByListSuatChieu(ObservableCollection<SuatChieu> listSuatChieu)
        {
            ObservableCollection<TimeSpan> list = new ObservableCollection<TimeSpan>();
            foreach (SuatChieu sc in listSuatChieu)
            {
                TimeSpan tg = new TimeSpan(sc.GioBatDau, sc.PhutBatDau, 0);
                list.Add(tg);
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (TimeSpan.Compare(list[i], list[j]) > 0)
                    {
                        TimeSpan temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }

            return list;
        }

        public bool InsertLichChieu(ModelEntity.LichChieu lc)
        {
            string query = "insert LichChieu (Maphim, MaRap, NgayChieu, ChuoiMaSuat) values ( @maphim , @marap , @ngaychieu , @chuoimasuat )";
            int result = DataProviderDirect.Instance.ExecuteNonQuery(query, new object[] { lc.MaPhim, lc.MaRap, lc.NgayChieu, lc.ChuoiMaSuat });

            return result > 0;
        }
        public bool UpdateInfoLichChieu(string chuoiMaSuat, string maPhim, string maRap, DateTime ngayChieu)
        {
            string query = $"update LichChieu set ChuoiMaSuat = @chuoiMaSuat where MaPhim = @maPhim and MaRap = @maRap and NgayChieu = @ngayChieu";
            int result = DataProviderDirect.Instance.ExecuteNonQuery(query, new object[] { chuoiMaSuat, maPhim, maRap, ngayChieu });

            return result > 0;
        }
        public bool DeleteLichChieu(string maPhim, string maRap, DateTime ngayChieu)
        {
            string query = $"Delete LichChieu where MaPhim = @maPhim and MaRap = @maRap and NgayChieu = @ngayChieu";
            int result = DataProviderDirect.Instance.ExecuteNonQuery(query, new object[] { maPhim, maRap, ngayChieu });

            return result > 0;
        }
    }
}
