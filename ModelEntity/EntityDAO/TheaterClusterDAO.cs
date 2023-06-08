using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.ModelEntity.EntityDAO
{
    public class TheaterClusterDAO
    {
        private static TheaterClusterDAO instance;
        public static TheaterClusterDAO Instance
        {
            get
            {
                if (instance == null) instance = new TheaterClusterDAO();
                return instance;
            }
            private set => instance = value;
        }
        private TheaterClusterDAO() { }

        public ObservableCollection<CumRap> GetListCumRapFromListKeHoach(ObservableCollection<KeHoach> ListKeHoach)
        {
            List<string> ListMaCum = new List<string>();
            foreach (KeHoach kh in ListKeHoach)
            {
                ListMaCum.Add(kh.MaCum);
            }
            return GetListCumRapByListMaCum(ListMaCum);
        }
        public ObservableCollection<CumRap> GetListCumRapByListMaCum(List<string> ListMaCum)
        {
            ObservableCollection<CumRap> list = new ObservableCollection<CumRap>();
            foreach (string macum in ListMaCum)
            {
                list.Add(DataProvider.Instance.Database.CumRaps.FirstOrDefault(cr => cr.MaCum == macum));
            }
            return list;
        }
    }
}
