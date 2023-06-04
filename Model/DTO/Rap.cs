using Project_PTUD_Desktop.Model.DAO;
using Project_PTUD_Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.Model.DTO
{
    public class Rap : BaseViewModel
    {
        private string maRap;
        private int tongGhe;
        private string maCum;

        private ObservableCollection<LichChieu> dsLichChieus;

        public string MaRap {  get => maRap; set { maRap = value; OnPropertyChanged(); } }
        public int TongGhe {  get => tongGhe; set { tongGhe = value; OnPropertyChanged(); } }
        public string MaCum { get => maCum; set { maCum = value; OnPropertyChanged(); } }

        public ObservableCollection<LichChieu> DsLichChieus { get => dsLichChieus; set => dsLichChieus = value; }

        //DsLichChieus = LichChieuDAO.Instance.GetListLichChieusByMaRap(maRap);


        public Rap(string maRap, int tongGhe, string maCum)
        {
            this.maRap = maRap;
            this.tongGhe = tongGhe;
            this.maCum = maCum;
        }
        public Rap(DataRow row)
        {
            maRap = row["MaRap"].ToString();
            tongGhe = (int)row["TongGhe"];
            maCum = row["MaCum"].ToString();
        }
    }
}
