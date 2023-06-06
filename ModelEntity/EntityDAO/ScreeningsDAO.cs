using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.ModelEntity.EntityDAO
{
    public class ScreeningsDAO
    {
        private static ScreeningsDAO instance;
        public static ScreeningsDAO Instance
        {
            get
            {
                if (instance == null) instance = new ScreeningsDAO();
                return instance;
            }
            private set => instance = value;
        }
        private ScreeningsDAO() { }

        public ObservableCollection<SuatChieu> GetListSuatChieuByChuoiMaSuat(string chuoiMaSuat)
        {
            ObservableCollection<SuatChieu> ListAllSuatChieu = new ObservableCollection<SuatChieu>(DataProvider.Instance.Database.SuatChieux);
            ObservableCollection<SuatChieu> list = new ObservableCollection<SuatChieu>();

            string[] listMaSuat = chuoiMaSuat.Split(' ');
            foreach (string ms in listMaSuat)
            {
                list.Add(ListAllSuatChieu.FirstOrDefault(sc => sc.MaSuat == ms));
            }

            return list;
        }

        public List<string> GetListMaSuatFromListSuatChieu(ObservableCollection<SuatChieu> listSuatChieu)
        {
            List<string> lists = new List<string>();
            foreach (SuatChieu sc in listSuatChieu)
            {
                lists.Add(sc.MaSuat);
            }

            return lists;
        }
    }
}
