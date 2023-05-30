using Project_PTUD_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project_PTUD_Desktop.ViewModel
{
    public class FilmViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ICommand AddSubCategory_Add { get; set; }
        public ICommand RemoveSubCategory_Add { get; set; }
        public ICommand ClearAllSubCategory_Add { get; set; }

        private ObservableCollection<Phim> listFilm;
        public ObservableCollection<Phim> ListPhim { get => listFilm; set { listFilm = value; OnPropertyChanged(); } }

        #region properties and fields for tab add
        private string maPhim_add;
        private string tenPhim_add;
        private string maTheLoaiChinh_add;
        private int thoiLuong_add;

        private string tenTheLoaiChinh_add;
        private string tenTheLoaiPhu_add;
        private string chuoiTenTheLoaiPhu_add;

        public string MaPhim_add { get => maPhim_add; set { maPhim_add = value; OnPropertyChanged(); } }
        public string TenPhim_add { get => tenPhim_add; set { tenPhim_add = value; OnPropertyChanged(); } }
        public string MaTheLoaiChinh_add { get => maTheLoaiChinh_add; set { maTheLoaiChinh_add = value; OnPropertyChanged(); } }
        public int ThoiLuong_add { get => thoiLuong_add; set { thoiLuong_add = value; OnPropertyChanged(); } }

        public string TenTheLoaiChinh_add { get => tenTheLoaiChinh_add; set { tenTheLoaiChinh_add = value; OnPropertyChanged(); } }
        public string TenTheLoaiPhu_add { get => tenTheLoaiPhu_add; set { tenTheLoaiPhu_add = value; OnPropertyChanged(); } }
        public string ChuoiTenTheLoaiPhu_add { get => chuoiTenTheLoaiPhu_add; set { chuoiTenTheLoaiPhu_add = value; OnPropertyChanged(); } }

        private TheLoai selectedCategory_add;
        public TheLoai SelectedCategory_add
        {
            get => selectedCategory_add;
            set
            {
                selectedCategory_add = value;
                OnPropertyChanged();
                if (selectedCategory_add != null)
                {
                    TenTheLoaiChinh_add = selectedCategory_add.TenTheLoai;
                }
            }
        }

        private TheLoai selectedSubCategory_add;
        public TheLoai SelectedSubCategory_add
        {
            get => selectedSubCategory_add;
            set
            {
                selectedSubCategory_add = value;
                OnPropertyChanged();
                if (SelectedSubCategory_add != null)
                {
                    TenTheLoaiPhu_add = SelectedSubCategory_add.TenTheLoai;
                }
            }
        }
        #endregion

        private ObservableCollection<TheLoai> listTheLoai;
        public ObservableCollection<TheLoai> ListTheLoai { get => listTheLoai; set { listTheLoai = value; OnPropertyChanged(); } }

        #region properties and fields for tab edit
        private string maPhim_edit;
        private string tenPhim_edit;
        private string maTheLoaiChinh_edit;
        private int thoiLuong_edit;
        private ObservableCollection<TheLoai> listTheLoaiPhu;
        private string chuoiTenTheLoaiPhu;
        public string MaPhim_edit { get => maPhim_edit; set { maPhim_edit = value; OnPropertyChanged(); } }
        public string TenPhim_edit { get => tenPhim_edit; set { tenPhim_edit = value; OnPropertyChanged(); } }
        public string MaTheLoaiChinh_edit { get => maTheLoaiChinh_edit; set { maTheLoaiChinh_edit = value; OnPropertyChanged(); } }
        public int ThoiLuong_edit { get => thoiLuong_edit; set { thoiLuong_edit = value; OnPropertyChanged(); } }
        public ObservableCollection<TheLoai> ListTheLoaiPhu { get => listTheLoaiPhu; set { listTheLoaiPhu = value; OnPropertyChanged(); } }
        public string ChuoiTenTheLoaiPhu { get => chuoiTenTheLoaiPhu; set { chuoiTenTheLoaiPhu = value; OnPropertyChanged(); } }

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
                    MaPhim_edit = SelectedItem.MaPhim;
                    TenPhim_edit = SelectedItem.TenPhim;
                    MaTheLoaiChinh_edit = SelectedItem.MaTheLoaiChinh;
                    ThoiLuong_edit = (int)SelectedItem.ThoiLuong;
                    ListTheLoaiPhu = new ObservableCollection<TheLoai>(SelectedItem.TheLoais);
                    foreach (var theloaiphu in ListTheLoaiPhu)
                    {
                        ChuoiTenTheLoaiPhu += theloaiphu.TenTheLoai;
                    }
                }
            }
        }
        #endregion

        public FilmViewModel()
        {
            ListPhim = new ObservableCollection<Phim>(DataProvider.Instance.Database.Phims);
            ListTheLoai = new ObservableCollection<TheLoai>(DataProvider.Instance.Database.TheLoais);

            AddSubCategory_Add = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(TenTheLoaiPhu_add)) return false;
                    if (string.Compare(TenTheLoaiPhu_add, TenTheLoaiChinh_add, 0) == 0) return false;
                    return true;
                },
                para => {
                    ChuoiTenTheLoaiPhu_add += TenTheLoaiPhu_add + ',' + TenTheLoaiChinh_add;
                }
            );
            RemoveSubCategory_Add = new RelayCommand<object>(
                para =>
                {
                    return true;
                },
                para =>
                {

                }
            );
            ClearAllSubCategory_Add = new RelayCommand<object>(
                para =>
                {
                    return true;
                },
                para =>
                {
                    ChuoiTenTheLoaiPhu_add = "";
                }
            );

        }
    }
}
