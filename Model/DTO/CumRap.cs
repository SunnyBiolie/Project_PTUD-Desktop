using Project_PTUD_Desktop.Model.DAO;
using Project_PTUD_Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_PTUD_Desktop.Model.DTO
{
    public class CumRap : BaseViewModel
    {
        private string maCum;
        private string tenCum;
        private string diaChi;

        private ObservableCollection<Rap> dsRaps = new ObservableCollection<Rap>();
        private ObservableCollection<KeHoach> dsKeHoachs = new ObservableCollection<KeHoach>();

        public string MaCum { get => maCum; set { maCum = value; OnPropertyChanged(); } }
        public string TenCum { get => tenCum; set { tenCum = value; OnPropertyChanged(); } }
        public string DiaChi { get => diaChi; set { diaChi = value; OnPropertyChanged(); } }

        public ObservableCollection<Rap> DsRaps { get => dsRaps; set => dsRaps = value; }
        public ObservableCollection<KeHoach> DsKeHoachs { get => dsKeHoachs; set => dsKeHoachs = value; }

        //DsRaps = RapDAO.Instance.GetListRapsByMaCum(maCum);
        //DsKeHoachs = KeHoachDAO.Instance.GetListKeHoachsByMaCum(maCum);

        public CumRap(string maCum, string tenCum, string diaChi)
        {
            this.maCum = maCum;
            this.tenCum = tenCum;
            this.diaChi = diaChi;

        }

        public CumRap(DataRow row)
        {
            maCum = row["MaCum"].ToString();
            tenCum = row["TenCum"].ToString();
            diaChi = row["DiaChi"].ToString();
        }
    }
}
