using Project_PTUD_Desktop.ViewModel;
using Project_PTUD_Desktop.ModelEntity.EntityDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.ModelEntity.EntityDTO
{
    public class ShowTimesDTO : BaseViewModel
    {
        private string _maPhim;
        private string _maRap;
        private System.DateTime _ngayChieu;
        private string _chuoiMaSuat;
        private string _displayChuoiMaSuat;

        public string MaPhim { get => _maPhim; set { _maPhim = value; OnPropertyChanged(); } }
        public string MaRap { get => _maRap; set { _maRap = value; OnPropertyChanged(); } }
        public System.DateTime NgayChieu { get => _ngayChieu; set { _ngayChieu = value; OnPropertyChanged(); } }
        public string ChuoiMaSuat { get => _chuoiMaSuat; set { _chuoiMaSuat = value; OnPropertyChanged(); } }
        public string DisplayChuoiMaSuat { get => _displayChuoiMaSuat; set { _displayChuoiMaSuat = value; OnPropertyChanged(); } }

        public ShowTimesDTO(LichChieu lichChieu)
        {
            MaPhim = lichChieu.MaPhim;
            MaRap = lichChieu.MaRap;
            NgayChieu = lichChieu.NgayChieu;
            ChuoiMaSuat = lichChieu.ChuoiMaSuat;

            DisplayChuoiMaSuat = ShowTimesDAO.Instance.GetStringTimeSortedFromChuoiMaSuat(ChuoiMaSuat);
        }
    }
}
