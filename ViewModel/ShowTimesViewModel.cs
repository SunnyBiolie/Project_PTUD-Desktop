using Project_PTUD_Desktop.ModelEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Project_PTUD_Desktop.ViewModel
{
    public class ShowTimesViewModel : BaseViewModel
    {
        #region for tab KeHoach in MainWindow
        public ICommand SelectedDateChanged { get; set; }

        private string _maPhimForShowTimes;
        private string _tenPhimForShowTimes;
        private DateTime _ngayChieuForShowTimes;

        public string MaPhimForShowTimes { get => _maPhimForShowTimes; set { _maPhimForShowTimes = value; OnPropertyChanged(); } }
        public string TenPhimForShowTimes { get => _tenPhimForShowTimes; set { _tenPhimForShowTimes = value; OnPropertyChanged(); } }
        public DateTime NgayChieuForShowTimes { get => _ngayChieuForShowTimes; set { _ngayChieuForShowTimes = value; OnPropertyChanged(); } }

        private Phim _selectedFilmForShowTimes;
        public Phim SelectedFilmForShowTimes
        {
            get => _selectedFilmForShowTimes;
            set
            {
                _selectedFilmForShowTimes = value;
                OnPropertyChanged();
                if (SelectedFilmForShowTimes != null)
                {
                    MaPhimForShowTimes = SelectedFilmForShowTimes.MaPhim;
                    TenPhimForShowTimes = SelectedFilmForShowTimes.TenPhim;
                    NgayChieuForShowTimes = DateTime.Now;

                    CollectionViewSource.GetDefaultView(ListLichChieu).Refresh();
                }
            }
        }
        #endregion

        #region properties and fields for add tab
        //private string _maPhim_add;
        //private DateTime _ngayChieu_add;
        private string _maRap_add;
        private string _chuoiMaSuat_add;
        private ObservableCollection<SuatChieu> _listSuatChieu_add;
        private string _displaySuatChieu_add;

        //public string MaPhim_add { get => _maPhim_add; set { _maPhim_add = value; OnPropertyChanged(); } }
        //public DateTime NgayChieu_add { get => _ngayChieu_add; set { _ngayChieu_add = value; OnPropertyChanged(); } }
        public string MaRap_add { get => _maRap_add; set { _maRap_add = value; OnPropertyChanged(); } }
        public string ChuoiMaSuat_add { get => _chuoiMaSuat_add; set { _chuoiMaSuat_add = value; OnPropertyChanged(); } }
        public ObservableCollection<SuatChieu> ListSuatChieu_add { get => _listSuatChieu_add; set { _listSuatChieu_add = value; OnPropertyChanged(); } }
        public string DisplaySuatChieu_add { get => _displaySuatChieu_add; set { _displaySuatChieu_add = value; OnPropertyChanged(); } }

        private SuatChieu _selectedScreenings_add;
        public SuatChieu SelectedScreenings_add
        {
            get => _selectedScreenings_add;
            set
            {
                _selectedScreenings_add = value;
                OnPropertyChanged();
                if (SelectedScreenings_add != null)
                {
                    DisplaySuatChieu_add = 
                }
            }
        }

        #endregion

        private ObservableCollection<LichChieu> _listLichChieu;
        public ObservableCollection<LichChieu> ListLichChieu { get => _listLichChieu; set { _listLichChieu = value; OnPropertyChanged(); } }

        public ShowTimesViewModel()
        {
            NgayChieuForShowTimes = DateTime.Now;

            ListLichChieu = new ObservableCollection<LichChieu>(DataProvider.Instance.Database.LichChieux);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListLichChieu);
            view.Filter = FilterByMaPhimAndDate;

            SelectedDateChanged = new RelayCommand<object>(
                param =>
                {
                    return true;
                },
                param =>
                {
                    CollectionViewSource.GetDefaultView(ListLichChieu).Refresh();
                }
            );
        }
        private bool FilterByMaPhimAndDate(object item)
        {
            return
                (item as LichChieu).MaPhim == MaPhimForShowTimes && (item as LichChieu).NgayChieu == NgayChieuForShowTimes;
        }
    }
}
