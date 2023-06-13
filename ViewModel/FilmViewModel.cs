//using Project_PTUD_Desktop.Model.DAO;
//using Project_PTUD_Desktop.Model.DTO;
using Project_PTUD_Desktop.ModelEntity;
using Project_PTUD_Desktop.ModelEntity.EntityDAO;
using Project_PTUD_Desktop.ModelEntity.EntityDTO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Project_PTUD_Desktop.ViewModel
{
    public class FilmViewModel : BaseViewModel
    {
        public ICommand SearchFilmCommand { get; set; }
        private string _searchString;
        public string SearchString { get => _searchString; set { _searchString = value; OnPropertyChanged(); } }

        public ICommand SearchFilmForShowTimes { get; set; }
        private string _searchStringFilmForShowTimes;
        public string SearchStringFilmForShowTimes { get => _searchStringFilmForShowTimes; set { _searchStringFilmForShowTimes = value; OnPropertyChanged(); } }

        #region For FilmWindow 
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<Phim> _listFilm;
        public ObservableCollection<Phim> ListPhim { get => _listFilm; set { _listFilm = value; OnPropertyChanged(); } }

        #region command, properties and fields for tab add
        public ICommand AddSubCategory_Add { get; set; }
        public ICommand RemoveSubCategory_Add { get; set; }
        public ICommand ClearAllSubCategory_Add { get; set; }

        private string _maPhim_add;
        private string _tenPhim_add;
        private string _maTheLoaiChinh_add;
        private int _thoiLuong_add;

        private string _tenTheLoaiChinh_add;
        private string _tenTheLoaiPhu_add;
        private string _chuoiTenTheLoaiPhu_add;
        private ObservableCollection<TheLoai> _listTheLoaiPhu_add;

        public string MaPhim_add { get => _maPhim_add; set { _maPhim_add = value; OnPropertyChanged(); } }
        public string TenPhim_add { get => _tenPhim_add; set { _tenPhim_add = value; OnPropertyChanged(); } }
        public string MaTheLoaiChinh_add { get => _maTheLoaiChinh_add; set { _maTheLoaiChinh_add = value; OnPropertyChanged(); } }
        public int ThoiLuong_add { get => _thoiLuong_add; set { _thoiLuong_add = value; OnPropertyChanged(); } }

        public string TenTheLoaiChinh_add { get => _tenTheLoaiChinh_add; set { _tenTheLoaiChinh_add = value; OnPropertyChanged(); } }
        public string TenTheLoaiPhu_add { get => _tenTheLoaiPhu_add; set { _tenTheLoaiPhu_add = value; OnPropertyChanged(); } }
        public string ChuoiTenTheLoaiPhu_add { get => _chuoiTenTheLoaiPhu_add; set { _chuoiTenTheLoaiPhu_add = value; OnPropertyChanged(); } }
        public ObservableCollection<TheLoai> ListTheLoaiPhu_add { get => _listTheLoaiPhu_add; set { _listTheLoaiPhu_add = value; OnPropertyChanged(); } }

        private TheLoai _selectedCategory_add;
        public TheLoai SelectedCategory_add
        {
            get => _selectedCategory_add;
            set
            {
                _selectedCategory_add = value;
                OnPropertyChanged();
                if (SelectedCategory_add != null)
                {
                    MaTheLoaiChinh_add = SelectedCategory_add.MaTheLoai;
                    TenTheLoaiChinh_add = SelectedCategory_add.TenTheLoai;
                }
            }
        }

        private TheLoai _selectedSubCategory_add;
        public TheLoai SelectedSubCategory_add
        {
            get => _selectedSubCategory_add;
            set
            {
                _selectedSubCategory_add = value;
                OnPropertyChanged();
                if (SelectedSubCategory_add != null)
                {
                    TenTheLoaiPhu_add = SelectedSubCategory_add.TenTheLoai;
                }
            }
        }
        #endregion

        #region command, properties and fields for tab edit
        private ObservableCollection<TheLoai> _listTheLoai;
        public ObservableCollection<TheLoai> ListTheLoai { get => _listTheLoai; set { _listTheLoai = value; OnPropertyChanged(); } }

        public ICommand AddSubCategory_Edit { get; set; }
        public ICommand RemoveSubCategory_Edit { get; set; }
        public ICommand ClearAllSubCategory_Edit { get; set; }

        private string _maPhim_edit;
        private string _tenPhim_edit;
        private string _maTheLoaiChinh_edit;
        private int _thoiLuong_edit;
        private ObservableCollection<TheLoai> _listTheLoaiPhu_edit;

        private string _chuoiTenTheLoaiPhu_edit;
        private string _tenTheLoaiChinh_edit;
        private string _tenTheLoaiPhu_edit;

        public string MaPhim_edit { get => _maPhim_edit; set { _maPhim_edit = value; OnPropertyChanged(); } }
        public string TenPhim_edit { get => _tenPhim_edit; set { _tenPhim_edit = value; OnPropertyChanged(); } }
        public string MaTheLoaiChinh_edit { get => _maTheLoaiChinh_edit; set { _maTheLoaiChinh_edit = value; OnPropertyChanged(); } }
        public int ThoiLuong_edit { get => _thoiLuong_edit; set { _thoiLuong_edit = value; OnPropertyChanged(); } }
        public ObservableCollection<TheLoai> ListTheLoaiPhu_edit { get => _listTheLoaiPhu_edit; set { _listTheLoaiPhu_edit = value; OnPropertyChanged(); } }

        public string ChuoiTenTheLoaiPhu_edit { get => _chuoiTenTheLoaiPhu_edit; set { _chuoiTenTheLoaiPhu_edit = value; OnPropertyChanged(); } }
        public string TenTheLoaiChinh_edit { get => _tenTheLoaiChinh_edit; set { _tenTheLoaiChinh_edit = value; OnPropertyChanged(); } }
        public string TenTheLoaiPhu_edit { get => _tenTheLoaiPhu_edit; set { _tenTheLoaiPhu_edit = value; OnPropertyChanged(); } }

        private string _tenPhim_curr_edit;
        private string _maTheLoaiChinh_curr_edit;
        private int _thoiLuong_curr_edit;
        private ObservableCollection<TheLoai> _listTheLoaiPhu_curr_edit;

        private TheLoai _selectedCategory_edit;
        public TheLoai SelectedCategory_edit
        {
            get => _selectedCategory_edit;
            set
            {
                _selectedCategory_edit = value;
                OnPropertyChanged();
                if (SelectedCategory_edit != null)
                {
                    MaTheLoaiChinh_edit = SelectedCategory_edit.MaTheLoai;
                    TenTheLoaiChinh_edit = SelectedCategory_edit.TenTheLoai;
                }
            }
        }

        private TheLoai _selectedSubCategory_edit;
        public TheLoai SelectedSubCategory_edit
        {
            get => _selectedSubCategory_edit;
            set
            {
                _selectedSubCategory_edit = value;
                OnPropertyChanged();
                if (SelectedSubCategory_edit != null)
                {
                    TenTheLoaiPhu_edit = SelectedSubCategory_edit.TenTheLoai;
                }
            }
        }

        private Phim _selectedItem;
        public Phim SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaPhim_edit = SelectedItem.MaPhim;
                    TenPhim_edit = SelectedItem.TenPhim;
                    MaTheLoaiChinh_edit = SelectedItem.MaTheLoaiChinh;
                    ThoiLuong_edit = (int)SelectedItem.ThoiLuong;
                    SelectedCategory_edit = ListTheLoai.FirstOrDefault(theLoai => theLoai.MaTheLoai == SelectedItem.MaTheLoaiChinh);

                    _tenPhim_curr_edit = SelectedItem.TenPhim;
                    _maTheLoaiChinh_curr_edit = SelectedItem.MaTheLoaiChinh;
                    _thoiLuong_curr_edit = (int)SelectedItem.ThoiLuong;

                    _listTheLoaiPhu_curr_edit.Clear();
                    ListTheLoaiPhu_edit.Clear();
                    //foreach (TheLoai tl in TheLoaiDAO.Instance.GetTheLoaiPhusByMaPhim(MaPhim_edit))
                    foreach (TheLoai theLoai in DataProvider.Instance.Database.Phims.Where(phim => phim.MaPhim == MaPhim_edit).FirstOrDefault().TheLoais)
                    {
                        _listTheLoaiPhu_curr_edit.Add(theLoai);
                        ListTheLoaiPhu_edit.Add(theLoai);
                    }
                    //ChuoiTenTheLoaiPhu_edit = string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_edit));
                    ChuoiTenTheLoaiPhu_edit = string.Join(", ", CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(ListTheLoaiPhu_edit));


                    MaPhim_delete = SelectedItem.MaPhim;
                    TenPhim_delete = SelectedItem.TenPhim;
                    MaTheLoaiChinh_delete = SelectedItem.MaTheLoaiChinh;
                    ThoiLuong_delete = (int)SelectedItem.ThoiLuong;
                    //TenTheLoaiChinh_delete = TheLoaiDAO.Instance.GetTheLoaiByMaTheLoaiChinh(MaTheLoaiChinh_delete).TenTheLoai;
                    //ListTheLoaiPhu_delete = TheLoaiDAO.Instance.GetListTheLoaiPhusByMaPhim(MaPhim_delete);
                    //ChuoiTenTheLoaiPhu_delete = string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_delete));
                    TenTheLoaiChinh_delete = ListTheLoai.FirstOrDefault(theLoai => theLoai.MaTheLoai == MaTheLoaiChinh_delete).TenTheLoai;
                    ListTheLoaiPhu_delete = ListPhim.FirstOrDefault(phim => phim.MaPhim == MaPhim_delete).TheLoais;
                    ChuoiTenTheLoaiPhu_delete = string.Join(", ", CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(ListTheLoaiPhu_delete));
                }
            }
        }
        #endregion

        #region properties and fields for tab delete
        private string maPhim_delete;
        private string tenPhim_delete;
        private string maTheLoaiChinh_delete;
        private int thoiLuong_delete;
        //private ObservableCollection<TheLoai> listTheLoaiPhu_delete;
        private ICollection<TheLoai> listTheLoaiPhu_delete;

        private string chuoiTenTheLoaiPhu_delete;
        private string tenTheLoaiChinh_delete;

        public string MaPhim_delete { get => maPhim_delete; set { maPhim_delete = value; OnPropertyChanged(); } }
        public string TenPhim_delete { get => tenPhim_delete; set { tenPhim_delete = value; OnPropertyChanged(); } }
        public string MaTheLoaiChinh_delete { get => maTheLoaiChinh_delete; set { maTheLoaiChinh_delete = value; OnPropertyChanged(); } }
        public int ThoiLuong_delete { get => thoiLuong_delete; set { thoiLuong_delete = value; OnPropertyChanged(); } }
        //public ObservableCollection<TheLoai> ListTheLoaiPhu_delete { get => listTheLoaiPhu_delete; set { listTheLoaiPhu_delete = value; OnPropertyChanged(); } }
        public ICollection<TheLoai> ListTheLoaiPhu_delete { get => listTheLoaiPhu_delete; set { listTheLoaiPhu_delete = value; OnPropertyChanged(); } }

        public string ChuoiTenTheLoaiPhu_delete { get => chuoiTenTheLoaiPhu_delete; set { chuoiTenTheLoaiPhu_delete = value; OnPropertyChanged(); } }
        public string TenTheLoaiChinh_delete { get => tenTheLoaiChinh_delete; set { tenTheLoaiChinh_delete = value; OnPropertyChanged(); } }
        #endregion

        #endregion

        private ObservableCollection<FilmDTO> _listFilmDTO;
        public ObservableCollection<FilmDTO> ListFilmDTO { get => _listFilmDTO; set { _listFilmDTO = value; OnPropertyChanged(); } }

        private ObservableCollection<Phim> _listPhimForShowTimes;
        public ObservableCollection<Phim> ListPhimForShowTimes { get => _listPhimForShowTimes; set { _listPhimForShowTimes = value; OnPropertyChanged(); } }

        public ICommand SearchPhimForPlan { get; set; }
        private string _searchStringPhimForPlan;
        public string SearchStringPhimForPlan { get => _searchStringPhimForPlan; set { _searchStringPhimForPlan = value; OnPropertyChanged(); } }
        private ObservableCollection<Phim> _listPhimForPlan;
        public ObservableCollection<Phim> ListPhimForPlan { get => _listPhimForPlan; set { _listPhimForPlan = value; OnPropertyChanged(); } }

        public FilmViewModel()
        {
            #region For FilmWindow

            ListPhim = new ObservableCollection<Phim>(DataProvider.Instance.Database.Phims);
            ListTheLoai = new ObservableCollection<TheLoai>(DataProvider.Instance.Database.TheLoais);

            LoadListFilmDTO();
            ListPhimForShowTimes = ListPhim;    // display list phim in MainWindow/tab LichChieu
            LoadListPhimForPlan();

            ListTheLoaiPhu_add = new ObservableCollection<TheLoai>();
            ListTheLoaiPhu_edit = new ObservableCollection<TheLoai>();
            _listTheLoaiPhu_curr_edit = new ObservableCollection<TheLoai>();
            ListTheLoaiPhu_delete = new ObservableCollection<TheLoai>();
            SelectedItem = ListPhim.First();

            #region button's logic for add tab
            AddSubCategory_Add = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(TenTheLoaiPhu_add)) return false;
                    if (string.Compare(TenTheLoaiPhu_add, TenTheLoaiChinh_add, 0) == 0) return false;
                    foreach (string tenTheLoai in CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(ListTheLoaiPhu_add))
                        if (TenTheLoaiPhu_add == tenTheLoai) return false;
                    return true;
                },
                para => {
                    ListTheLoaiPhu_add.Add(SelectedSubCategory_add);
                    ChuoiTenTheLoaiPhu_add = string.Join(", ", CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(ListTheLoaiPhu_add));
                }
            );
            RemoveSubCategory_Add = new RelayCommand<object>(
                para =>
                {
                    foreach (TheLoai theloai in ListTheLoaiPhu_add)
                        if (SelectedSubCategory_add == theloai) return true;
                    return false;
                },
                para =>
                {
                    ListTheLoaiPhu_add.Remove(SelectedSubCategory_add);
                    ChuoiTenTheLoaiPhu_add = string.Join(", ", CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(ListTheLoaiPhu_add));
                }
            );
            ClearAllSubCategory_Add = new RelayCommand<object>(
                para =>
                {
                    if (ListTheLoaiPhu_add.Count == 0) return false;
                    return true;
                },
                para =>
                {
                    ListTheLoaiPhu_add.Clear();
                    ChuoiTenTheLoaiPhu_add = "";
                }
            );
            AddCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaPhim_add) || string.IsNullOrEmpty(TenPhim_add) || SelectedCategory_add == null || string.IsNullOrEmpty(ThoiLuong_add.ToString())) return false;
                    var listMaPhim = from phim in ListPhim
                                     where phim.MaPhim.ToUpper() == MaPhim_add.ToUpper()
                                     select phim;
                    if (listMaPhim == null || listMaPhim.Count() != 0) return false;

                    return true;
                },
                para =>
                {
                    Phim film = new Phim() { MaPhim = MaPhim_add, TenPhim = TenPhim_add, MaTheLoaiChinh = MaTheLoaiChinh_add, ThoiLuong = ThoiLuong_add };
                    DataProvider.Instance.Database.Phims.Add(film);
                    foreach (TheLoai theLoai in ListTheLoaiPhu_add)
                        film.TheLoais.Add(theLoai);
                    DataProvider.Instance.Database.SaveChanges();
                    ListPhim.Add(film);
                    LoadListFilmDTO();
                    LoadListPhimForPlan();
                }
            );
            #endregion

            #region button's logic for edit tab
            AddSubCategory_Edit = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(TenTheLoaiPhu_edit)) return false;
                    if (string.Compare(TenTheLoaiPhu_edit, TenTheLoaiChinh_edit, 0) == 0) return false;
                    foreach (string tenTheLoai in CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(ListTheLoaiPhu_edit))
                        if (TenTheLoaiPhu_edit == tenTheLoai) return false;
                    return true;
                },
                para => {
                    ListTheLoaiPhu_edit.Add(SelectedSubCategory_edit);
                    ChuoiTenTheLoaiPhu_edit = string.Join(", ", CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(ListTheLoaiPhu_edit));
                }
            );
            RemoveSubCategory_Edit = new RelayCommand<object>(
                para =>
                {
                    foreach (string tenTheLoai in CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(ListTheLoaiPhu_edit))
                        if (TenTheLoaiPhu_edit == tenTheLoai) return true;

                    return false;
                },
                para =>
                {
                    foreach (TheLoai tl in ListTheLoaiPhu_edit.ToList())
                        if (tl.MaTheLoai == SelectedSubCategory_edit.MaTheLoai)
                            ListTheLoaiPhu_edit.Remove(tl);

                    ChuoiTenTheLoaiPhu_edit = string.Join(", ", CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(ListTheLoaiPhu_edit));
                }
            );
            ClearAllSubCategory_Edit = new RelayCommand<object>(
                para =>
                {
                    if (ListTheLoaiPhu_edit == null || ListTheLoaiPhu_edit.Count == 0) return false;
                    return true;
                },
                para =>
                {
                    ListTheLoaiPhu_edit.Clear();
                    ChuoiTenTheLoaiPhu_edit = "";
                }
            );
            EditCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaPhim_edit)) return false;
                    if (string.Compare(TenPhim_edit, _tenPhim_curr_edit, 0) == 0 &&
                        string.Compare(MaTheLoaiChinh_edit, _maTheLoaiChinh_curr_edit, 0) == 0 &&
                        ThoiLuong_edit == _thoiLuong_curr_edit &&
                        (_listTheLoaiPhu_curr_edit.Except(ListTheLoaiPhu_edit).Count() == 0) && (ListTheLoaiPhu_edit.Except(_listTheLoaiPhu_curr_edit).Count() == 0))
                        return false;
                    foreach (TheLoai tl in ListTheLoaiPhu_edit)
                        if (MaTheLoaiChinh_edit == tl.MaTheLoai) return false;
                    return true;
                },
                para =>
                {
                    Phim film = DataProvider.Instance.Database.Phims.Where(phim => phim.MaPhim == MaPhim_edit).FirstOrDefault();
                    film.TenPhim = TenPhim_edit;
                    film.MaTheLoaiChinh = MaTheLoaiChinh_edit;
                    film.ThoiLuong = ThoiLuong_edit;
                    DataProvider.Instance.Database.SaveChanges();
                    IEnumerable<TheLoai> listAddTheLoaiPhu = ListTheLoaiPhu_edit.Where(theloai => !_listTheLoaiPhu_curr_edit.Contains(theloai));
                    IEnumerable<TheLoai> listRemoveTheLoaiPhu = _listTheLoaiPhu_curr_edit.Where(theloai => !ListTheLoaiPhu_edit.Contains(theloai));
                    if (listAddTheLoaiPhu.Count() != 0)
                        foreach (TheLoai tl in listAddTheLoaiPhu)
                            film.TheLoais.Add(tl);
                    if (listRemoveTheLoaiPhu.Count() != 0)
                        foreach (TheLoai tl in listRemoveTheLoaiPhu)
                            film.TheLoais.Remove(tl);
                    DataProvider.Instance.Database.SaveChanges();
                    LoadListFilmDTO();
                    LoadListPhimForPlan();

                    _tenPhim_curr_edit = TenPhim_edit;
                    _maTheLoaiChinh_curr_edit = MaTheLoaiChinh_edit;
                    _thoiLuong_curr_edit = ThoiLuong_edit;
                    _listTheLoaiPhu_curr_edit.Clear();
                    foreach (TheLoai tl in ListTheLoaiPhu_edit.ToList())
                        _listTheLoaiPhu_curr_edit.Add(tl);

                    TenPhim_delete = SelectedItem.TenPhim;
                    MaTheLoaiChinh_delete = SelectedItem.MaTheLoaiChinh;
                    ThoiLuong_delete = (int)SelectedItem.ThoiLuong;
                    //TenTheLoaiChinh_delete = TheLoaiDAO.Instance.GetTheLoaiByMaTheLoaiChinh(MaTheLoaiChinh_delete).TenTheLoai;
                    //ListTheLoaiPhu_delete = TheLoaiDAO.Instance.GetListTheLoaiPhusByMaPhim(MaPhim_delete);
                    //ChuoiTenTheLoaiPhu_delete = string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_delete));
                    TenTheLoaiChinh_delete = ListTheLoai.FirstOrDefault(theLoai => theLoai.MaTheLoai == MaTheLoaiChinh_delete).TenTheLoai;
                    ListTheLoaiPhu_delete = ListPhim.FirstOrDefault(phim => phim.MaPhim == MaPhim_delete).TheLoais;
                    ChuoiTenTheLoaiPhu_delete = string.Join(", ", CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(ListTheLoaiPhu_delete));
                }
            );
            #endregion

            DeleteCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaPhim_delete)) return false;
                    return true;
                },
                para =>
                {
                    #region
                    //if (KeHoachDAO.Instance.GetListKeHoachsByMaPhim(MaPhim_delete).Count() != 0)
                    //{
                    //    MessageBox.Show($"Chỉ có thể xóa các phim đang không có kế hoạch chiếu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    return;
                    //}
                    //if (LichChieuDAO.Instance.GetListLichChieusByMaPhim(MaPhim_delete).Count() != 0)
                    //{
                    //    MessageBox.Show($"Chỉ có thể xóa các phim đang không có lịch chiếu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    return;
                    //}
                    //if (MessageBox.Show($"Bạn có chắc muốn xóa phim {SelectedItem.TenPhim}", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    //{

                    //    var film = PhimDAO.Instance.GetPhimByMaPhim(MaPhim_delete);
                    //    if (film != null)
                    //    {
                    //        foreach (TheLoai tl in ListTheLoaiPhu_delete)
                    //        {
                    //            if (!TheLoaiDAO.Instance.DeleteTheLoaiPhuFromPhim(tl.MaTheLoai, MaPhim_delete))
                    //                MessageBox.Show($"Đã xảy ra lỗi khi xóa thể loại phụ khỏi phim", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    //        }
                    //        if (PhimDAO.Instance.DeletePhim(MaPhim_delete))
                    //        {
                    //            ListPhim = PhimDAO.Instance.GetListPhims();
                    //            SelectedItem = ListPhim.First();
                    //        }
                    //        else MessageBox.Show($"Xóa phim không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    }
                    //}
                    #endregion

                    if (SelectedItem.KeHoaches.Count != 0)
                    {
                        MessageBox.Show($"Chỉ có thể xóa các phim đang không có kế hoạch chiếu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (SelectedItem.LichChieux.Count != 0)
                    {
                        MessageBox.Show($"Chỉ có thể xóa các phim đang không có lịch chiếu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (MessageBox.Show($"Bạn có chắc muốn xóa phim \"{SelectedItem.TenPhim}\"", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Phim film = DataProvider.Instance.Database.Phims.Where(phim => phim.MaPhim == MaPhim_delete).FirstOrDefault();
                        if (film != null)
                        {
                            SelectedItem.TheLoais.Clear();
                            DataProvider.Instance.Database.Phims.Remove(film);
                            DataProvider.Instance.Database.SaveChanges();
                            ListPhim.Remove(film);
                            LoadListFilmDTO();
                            LoadListPhimForPlan();

                            SelectedItem = ListPhim.First();
                        }
                    }
                }
            );


            //CheckCommand = new RelayCommand<object>(para => true, para =>
            //{
            //    MessageBox.Show($"ListTheLoaiPhu_edit: {string.Join(", ", CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(ListTheLoaiPhu_edit))}\n" +
            //            $"listTheLoaiPhu_curr_edit: {string.Join(", ", CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(_listTheLoaiPhu_curr_edit))}\n" +
            //            $"{_listTheLoaiPhu_curr_edit.Except(ListTheLoaiPhu_edit).Count()}\n" +
            //            $"{ListTheLoaiPhu_edit.Except(_listTheLoaiPhu_curr_edit).Count()}\n");
            //});
            #endregion

            CollectionView viewFilmForShowTimes = (CollectionView)CollectionViewSource.GetDefaultView(ListPhimForShowTimes);
            viewFilmForShowTimes.Filter = FilterFilmForShowTimes;
            SearchFilmForShowTimes = new RelayCommand<object>(
                param =>
                {
                    return true;
                },
                param =>
                {
                    CollectionViewSource.GetDefaultView(ListPhimForShowTimes).Refresh();
                }
            );
        }
        private void LoadListFilmDTO()
        {
            ListFilmDTO = FilmDAO.Instance.GetMoreDetailListFilmFromListPhim(ListPhim);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListFilmDTO);
            view.Filter = UserFilter;

            SearchFilmCommand = new RelayCommand<object>(
                para =>
                {
                    return true;
                },
                para =>
                {
                    CollectionViewSource.GetDefaultView(ListFilmDTO).Refresh();
                }
            );
        }
        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchString)) return true;
            else 
                return ((item as FilmDTO).TenPhim.IndexOf(SearchString, System.StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private bool FilterFilmForShowTimes(object item)
        {
            if (string.IsNullOrEmpty(SearchStringFilmForShowTimes)) return true;
            else
                return ((item as Phim).TenPhim.IndexOf(SearchStringFilmForShowTimes, System.StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void LoadListPhimForPlan()
        {
            ListPhimForPlan = new ObservableCollection<Phim>(DataProvider.Instance.Database.Phims);     // display list phim in MainWindow/tab KeHoach
            CollectionView viewPhimForPlan = (CollectionView)CollectionViewSource.GetDefaultView(ListPhimForPlan);
            viewPhimForPlan.Filter = FilterListPhimForPlan;
            SearchPhimForPlan = new RelayCommand<object>(
                param =>
                {
                    return true;
                },
                param =>
                {
                    CollectionViewSource.GetDefaultView(ListPhimForPlan).Refresh();
                }
            );
        }
        private bool FilterListPhimForPlan(object item)
        {
            if (string.IsNullOrEmpty(SearchStringPhimForPlan)) return true;
            else
                return ((item as Phim).TenPhim.IndexOf(SearchStringPhimForPlan, System.StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
