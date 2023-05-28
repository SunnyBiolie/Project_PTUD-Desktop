using Project_PTUD_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_PTUD_Desktop.ViewModel
{
    public class FilmViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }


        private ObservableCollection<Phim> listFilm;
        public ObservableCollection<Phim> ListPhim { get => listFilm; set { listFilm = value; OnPropertyChanged(); } }

        private Phim selectedItem;
        public Phim SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaPhim = SelectedItem.MaPhim;
                    TenPhim = SelectedItem.TenPhim;
                    MaTheLoaiChinh = SelectedItem.MaTheLoaiChinh;
                    ThoiLuong = (int)SelectedItem.ThoiLuong;


                }
            }
        }

        private string maPhim;
        public string MaPhim { get => maPhim; set { maPhim = value; OnPropertyChanged(); } }
        private string tenPhim;
        public string TenPhim { get => tenPhim; set { tenPhim = value; OnPropertyChanged(); } }
        private string maTheLoaiChinh;
        public string MaTheLoaiChinh { get => maTheLoaiChinh; set { maTheLoaiChinh = value; OnPropertyChanged(); } }
        private int thoiLuong;
        public int ThoiLuong { get => thoiLuong; set { thoiLuong = value; OnPropertyChanged(); } }

        private ObservableCollection<TheLoai> listTheLoai;
        public ObservableCollection<TheLoai> ListTheLoai { get => listTheLoai; set { listTheLoai = value; OnPropertyChanged(); } }

        public FilmViewModel()
        {
            ListPhim = new ObservableCollection<Phim>(DataProvider.Instance.Database.Phims);
            ListTheLoai = new ObservableCollection<TheLoai>(DataProvider.Instance.Database.TheLoais);

            AddCommand = new RelayCommand<object>(
                (para) => {
                    if (string.IsNullOrEmpty(MaPhim)) return false;
                    var listMaPhim = DataProvider.Instance.Database.Phims.Where(ele => ele.MaPhim == MaPhim);
                    if (listMaPhim == null || listMaPhim.Count() != 0) return false;

                    return true;
                },
                (para) => {
                    var film = new Phim() { MaPhim = MaPhim, TenPhim = TenPhim, MaTheLoaiChinh = MaTheLoaiChinh, ThoiLuong = ThoiLuong };
                    DataProvider.Instance.Database.Phims.Add(film);
                    DataProvider.Instance.Database.SaveChanges();
                    ListPhim.Add(film);
                }
            );

            EditCommand = new RelayCommand<object>(
                (para) => {
                    Phim curr = SelectedItem;

                    if (string.IsNullOrEmpty(MaPhim)) return false;
                    var listMaPhim = DataProvider.Instance.Database.Phims.Where(ele => ele.MaPhim == MaPhim);
                    if (listMaPhim == null || listMaPhim.Count() != 0) return false;

                    return true;
                },
                (para) => {
                    var film = DataProvider.Instance.Database.Phims.Where(ele => ele.MaPhim == SelectedItem.MaPhim).SingleOrDefault();
                    film.MaPhim = MaPhim;
                    film.TenPhim = TenPhim;
                    film.MaTheLoaiChinh = MaTheLoaiChinh;
                    film.ThoiLuong = ThoiLuong;
                    DataProvider.Instance.Database.SaveChanges();
                    SelectedItem.MaPhim = MaPhim;
                    SelectedItem.TenPhim = TenPhim;
                    SelectedItem.MaTheLoaiChinh = MaTheLoaiChinh;
                    SelectedItem.ThoiLuong = ThoiLuong;
                }
            );
        }
    }
}
