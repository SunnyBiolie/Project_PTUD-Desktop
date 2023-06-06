using Project_PTUD_Desktop.ModelEntity;
using Project_PTUD_Desktop.ModelEntity.EntityDAO;
using Project_PTUD_Desktop.ModelEntity.EntityDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
        #region for tab LichChieu in MainWindow
        public ICommand OpenShowTimesWindowCommand { get; set; }
        public ICommand SelectedDateChanged { get; set; }

        private ObservableCollection<ShowTimesDTO> _listShowTimesDTO;
        public ObservableCollection<ShowTimesDTO> ListShowTimesDTO { get => _listShowTimesDTO; set { _listShowTimesDTO = value; OnPropertyChanged(); } }

        private string _maPhimForShowTimes;
        private string _tenPhimForShowTimes;
        private DateTime _ngayChieuForShowTimes;
        private int _thoiLuongForShowTimes;

        public string MaPhimForShowTimes { get => _maPhimForShowTimes; set { _maPhimForShowTimes = value; OnPropertyChanged(); } }
        public string TenPhimForShowTimes { get => _tenPhimForShowTimes; set { _tenPhimForShowTimes = value; OnPropertyChanged(); } }
        public DateTime NgayChieuForShowTimes { get => _ngayChieuForShowTimes; set { _ngayChieuForShowTimes = value; OnPropertyChanged(); } }
        public int ThoiLuongForShowTimes { get => _thoiLuongForShowTimes; set { _thoiLuongForShowTimes = value; OnPropertyChanged(); } }

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
                    NgayChieuForShowTimes = DateTime.Today;
                    ThoiLuongForShowTimes = DataProvider.Instance.Database.Phims.FirstOrDefault(p => p.MaPhim == MaPhimForShowTimes).ThoiLuong;

                    CollectionViewSource.GetDefaultView(ListShowTimesDTO).Refresh();
                }
            }
        }
        #endregion

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        #region command, properties and fields for add tab
        public ICommand AddScreenings_add { get; set; }
        public ICommand RemoveScreenings_add { get; set; }
        public ICommand ClearScreenings_add { get; set; }

        private string _maRap_add;
        private string _chuoiMaSuat_add;
        private ObservableCollection<SuatChieu> _listSuatChieu_add;
        private string _displaySuatChieu_add;
        private string _listDisplaySuatChieu_add;

        public string MaRap_add { get => _maRap_add; set { _maRap_add = value; OnPropertyChanged(); } }
        public string ChuoiMaSuat_add { get => _chuoiMaSuat_add; set { _chuoiMaSuat_add = value; OnPropertyChanged(); } }
        public ObservableCollection<SuatChieu> ListSuatChieu_add { get => _listSuatChieu_add; set { _listSuatChieu_add = value; OnPropertyChanged(); } }
        public string DisplaySuatChieu_add { get => _displaySuatChieu_add; set { _displaySuatChieu_add = value; OnPropertyChanged(); } }
        public string ListDisplaySuatChieu_add { get => _listDisplaySuatChieu_add; set { _listDisplaySuatChieu_add = value; OnPropertyChanged(); } }

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
                    TimeSpan thoiGianSuatChieu = new TimeSpan(SelectedScreenings_add.GioBatDau, SelectedScreenings_add.PhutBatDau, 0);
                    DisplaySuatChieu_add = thoiGianSuatChieu.ToString();
                }
            }
        }

        private Rap _selectedRap_add;
        public Rap SelectedRap_add
        {
            get => _selectedRap_add;
            set
            {
                _selectedRap_add = value;
                OnPropertyChanged();
                if (SelectedRap_add != null)
                {
                    MaRap_add = SelectedRap_add.MaRap;
                }
            }
        }
        #endregion

        #region command, properties and fields for edit tab
        public ICommand AddScreenings_edit { get; set; }
        public ICommand RemoveScreenings_edit { get; set; }
        public ICommand ClearScreenings_edit { get; set; }

        private string _maRap_edit;
        private string _chuoiMaSuat_edit;
        private ObservableCollection<SuatChieu> _listSuatChieu_edit;
        private string _listDisplaySuatChieu_edit;

        public string MaRap_edit { get => _maRap_edit; set { _maRap_edit = value; OnPropertyChanged(); } }
        public string ChuoiMaSuat_edit { get => _chuoiMaSuat_edit; set { _chuoiMaSuat_edit = value; OnPropertyChanged(); } }
        public ObservableCollection<SuatChieu> ListSuatChieu_edit { get => _listSuatChieu_edit; set { _listSuatChieu_edit = value; OnPropertyChanged(); } }
        public string ListDisplaySuatChieu_edit { get => _listDisplaySuatChieu_edit; set { _listDisplaySuatChieu_edit = value; OnPropertyChanged(); } }

        //private string _maRap_curr_edit;
        private ObservableCollection<SuatChieu> _listSuatChieu_curr_edit;

        private SuatChieu _selectedScreenings_edit;
        public SuatChieu SelectedScreenings_edit
        {
            get => _selectedScreenings_edit;
            set
            {
                _selectedScreenings_edit = value;
                OnPropertyChanged();
                if (SelectedScreenings_edit != null)
                {
                }
            }
        }

        //private Rap _selectedRap_edit;
        //public Rap SelectedRap_edit
        //{
        //    get => _selectedRap_edit;
        //    set
        //    {
        //        _selectedRap_edit = value;
        //        OnPropertyChanged();
        //        if (SelectedRap_edit != null)
        //        {
        //            MaRap_edit = SelectedRap_edit.MaRap;
        //        }
        //    }
        //}

        private ShowTimesDTO _selectedItem;
        public ShowTimesDTO SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaRap_edit = SelectedItem.MaRap;
                    //_maRap_curr_edit = SelectedItem.MaRap;
                    ListSuatChieu_edit = ScreeningsDAO.Instance.GetListSuatChieuByChuoiMaSuat(SelectedItem.ChuoiMaSuat);
                    _listSuatChieu_curr_edit = ScreeningsDAO.Instance.GetListSuatChieuByChuoiMaSuat(SelectedItem.ChuoiMaSuat);
                    ListDisplaySuatChieu_edit = ShowTimesDAO.Instance.GetStringTimeByListSuatChieu(ListSuatChieu_edit);

                    MaRap_delete = SelectedItem.MaRap;
                    ListDisplaySuatChieu_delete = ShowTimesDAO.Instance.GetStringTimeByListSuatChieu(ListSuatChieu_edit);
                }
            }
        }
        #endregion

        #region command, properties and fields for edit delete
        private string _maRap_delete;
        private string _listDisplaySuatChieu_delete;

        public string MaRap_delete { get => _maRap_delete; set { _maRap_delete = value; OnPropertyChanged(); } }
        public string ListDisplaySuatChieu_delete { get => _listDisplaySuatChieu_delete; set { _listDisplaySuatChieu_delete = value; OnPropertyChanged(); } }
        #endregion

        private ObservableCollection<Rap> _listRap;
        public ObservableCollection<Rap> ListRap { get => _listRap; set { _listRap = value; OnPropertyChanged(); } }

        //private ObservableCollection<SuatChieu> _listSuatChieu;
        //public ObservableCollection<SuatChieu> ListSuatChieu { get => _listSuatChieu; set { _listSuatChieu = value; OnPropertyChanged(); } }

        private ObservableCollection<LichChieu> _listLichChieu;
        public ObservableCollection<LichChieu> ListLichChieu { get => _listLichChieu; set { _listLichChieu = value; OnPropertyChanged(); } }

        public ShowTimesViewModel()
        {
            NgayChieuForShowTimes = DateTime.Today;
            ListSuatChieu_add = new ObservableCollection<SuatChieu>();
            ListSuatChieu_edit = new ObservableCollection<SuatChieu>();

            ListRap = new ObservableCollection<Rap>(DataProvider.Instance.Database.Raps);
            //ListSuatChieu = new ObservableCollection<SuatChieu>(DataProvider.Instance.Database.SuatChieux);
            ListLichChieu = new ObservableCollection<LichChieu>(DataProvider.Instance.Database.LichChieux);
            LoadListShowTimesDTO();

            #region add tab
            AddScreenings_add = new RelayCommand<object>(
                param =>
                {
                    if (string.IsNullOrEmpty(DisplaySuatChieu_add) || SelectedRap_add == null || SelectedScreenings_add == null) return false;
                    foreach (SuatChieu sc in ListSuatChieu_add)
                    {
                        if (sc.MaSuat == SelectedScreenings_add.MaSuat) return false;
                    }
                    int totalMinutesOfSelectedScreenings_add = 60 * SelectedScreenings_add.GioBatDau + SelectedScreenings_add.PhutBatDau;
                    foreach (TimeSpan ts in ShowTimesDAO.Instance.GetListTimeByListSuatChieu(ListSuatChieu_add))
                    {
                        if (ts.TotalMinutes > totalMinutesOfSelectedScreenings_add - ThoiLuongForShowTimes && ts.TotalMinutes < totalMinutesOfSelectedScreenings_add + ThoiLuongForShowTimes) return false;
                    }
                    return true;
                },
                param =>
                {
                    ListSuatChieu_add.Add(SelectedScreenings_add);
                    ListDisplaySuatChieu_add = ShowTimesDAO.Instance.GetStringTimeByListSuatChieu(ListSuatChieu_add);
                }
            );
            RemoveScreenings_add = new RelayCommand<object>(
                param =>
                {
                    foreach (SuatChieu sc in ListSuatChieu_add)
                        if (SelectedScreenings_add == sc) return true;
                    return false;
                },
                param =>
                {
                    ListSuatChieu_add.Remove(SelectedScreenings_add);
                    ListDisplaySuatChieu_add = ShowTimesDAO.Instance.GetStringTimeByListSuatChieu(ListSuatChieu_add);
                }
            );
            ClearScreenings_add = new RelayCommand<object>(
                param =>
                {
                    if (ListSuatChieu_add.Count == 0) return false;
                    return true;
                },
                param =>
                {
                    ListSuatChieu_add.Clear();
                    ListDisplaySuatChieu_add = "";
                }
            );
            AddCommand = new RelayCommand<object>(
                param =>
                {   if (string.IsNullOrEmpty(MaRap_add) || ListSuatChieu_add.Count == 0) return false;
                    foreach (LichChieu lc in ListLichChieu.Where(lc => lc.MaPhim == MaPhimForShowTimes && lc.NgayChieu == NgayChieuForShowTimes))
                    {
                        if (lc.MaRap == MaRap_add) return false;
                    }

                    return true;
                },
                param =>
                {
                    List<string> list = new List<string>();
                    foreach (SuatChieu sc in ListSuatChieu_add)
                        list.Add(sc.MaSuat);
                    ChuoiMaSuat_add = string.Join(" ", list);
                    LichChieu lc = new LichChieu() { MaPhim = MaPhimForShowTimes, MaRap = MaRap_add, NgayChieu = NgayChieuForShowTimes, ChuoiMaSuat = ChuoiMaSuat_add };
                    ShowTimesDAO.Instance.InsertLichChieu(lc);
                    ListLichChieu.Add(lc);
                    LoadListShowTimesDTO();
                }
            );
            #endregion

            #region edit edit
            AddScreenings_edit = new RelayCommand<object>(
                param =>
                {
                    if (SelectedItem == null) return false;
                    if (SelectedScreenings_edit == null) return false;
                    foreach (SuatChieu sc in ListSuatChieu_edit)
                    {
                        if (sc.MaSuat == SelectedScreenings_edit.MaSuat) return false;
                    }
                    int totalMinutesOfSelectedScreenings_edit = 60 * SelectedScreenings_edit.GioBatDau + SelectedScreenings_edit.PhutBatDau;
                    foreach (TimeSpan ts in ShowTimesDAO.Instance.GetListTimeByListSuatChieu(ListSuatChieu_edit))
                    {
                        if (ts.TotalMinutes > totalMinutesOfSelectedScreenings_edit - ThoiLuongForShowTimes && ts.TotalMinutes < totalMinutesOfSelectedScreenings_edit + ThoiLuongForShowTimes) return false;
                    }
                    return true;
                },
                param =>
                {
                    ListSuatChieu_edit.Add(SelectedScreenings_edit);
                    ListDisplaySuatChieu_edit = ShowTimesDAO.Instance.GetStringTimeByListSuatChieu(ListSuatChieu_edit);
                    ChuoiMaSuat_edit = string.Join(" ", ScreeningsDAO.Instance.GetListMaSuatFromListSuatChieu(ListSuatChieu_edit));
                }
            );
            RemoveScreenings_edit = new RelayCommand<object>(
                param =>
                {
                    foreach (SuatChieu sc in ListSuatChieu_edit)
                        if (SelectedScreenings_edit == sc) return true;
                    return false;
                },
                param =>
                {
                    ListSuatChieu_edit.Remove(SelectedScreenings_edit);
                    ListDisplaySuatChieu_edit = ShowTimesDAO.Instance.GetStringTimeByListSuatChieu(ListSuatChieu_edit);
                    ChuoiMaSuat_edit = string.Join(" ", ScreeningsDAO.Instance.GetListMaSuatFromListSuatChieu(ListSuatChieu_edit));
                }
            );
            ClearScreenings_edit = new RelayCommand<object>(
                param =>
                {
                    if (ListSuatChieu_edit.Count == 0) return false;
                    return true;
                },
                param =>
                {
                    ListSuatChieu_edit.Clear();
                    ListDisplaySuatChieu_edit = "";
                }
            );
            EditCommand = new RelayCommand<object>(
                param =>
                {
                    if (SelectedItem == null || ListSuatChieu_edit.Count == 0) return false;
                    if (_listSuatChieu_curr_edit.Except(ListSuatChieu_edit).Count() == 0 && ListSuatChieu_edit.Except(_listSuatChieu_curr_edit).Count() == 0) return false;

                    return true;
                },
                param =>
                {
                    if (ShowTimesDAO.Instance.UpdateInfoLichChieu(ChuoiMaSuat_edit, MaPhimForShowTimes, MaRap_edit, NgayChieuForShowTimes))
                    {
                        ListLichChieu = new ObservableCollection<LichChieu>(DataProvider.Instance.Database.LichChieux);
                        LoadListShowTimesDTO();
                        //_maRap_curr_edit = MaRap_edit;
                        _listSuatChieu_curr_edit.Clear();
                        foreach (SuatChieu sc in ListSuatChieu_edit)
                            _listSuatChieu_curr_edit.Add(sc);
                    }
                    else MessageBox.Show($"Cập nhật lịch chiếu không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            );
            #endregion

            DeleteCommand = new RelayCommand<object>(
                param =>
                {
                    if (SelectedItem == null) return false;
                    return true;
                },
                param =>
                {
                    if (MessageBox.Show($"Bạn có chắc muốn xóa lịch chiếu của phim có mã \"{SelectedItem.MaPhim}\" vào ngày \"{SelectedItem.NgayChieu}\" tại rạp có mã \"{SelectedItem.MaRap}\"", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (ShowTimesDAO.Instance.DeleteLichChieu(MaPhimForShowTimes, MaRap_delete, NgayChieuForShowTimes))
                        {
                            ListLichChieu = new ObservableCollection<LichChieu>(DataProvider.Instance.Database.LichChieux);
                            LoadListShowTimesDTO();
                            ListDisplaySuatChieu_delete = "";
                        }
                    }
                }
            );

            OpenShowTimesWindowCommand = new RelayCommand<object>(
                param =>
                {
                    if (string.IsNullOrEmpty(MaPhimForShowTimes)) return false;
                    if (NgayChieuForShowTimes < DateTime.Now) return false;
                    return true;
                },
                param =>
                {
                    ShowTimesWindow stw = new ShowTimesWindow();
                    stw.ShowDialog();
                }
            );
            SelectedDateChanged = new RelayCommand<object>(
                param =>
                {
                    return true;
                },
                param =>
                {
                    CollectionViewSource.GetDefaultView(ListShowTimesDTO).Refresh();
                }
            );
        }
        private void LoadListShowTimesDTO()
        {
            ListShowTimesDTO = ShowTimesDAO.Instance.GetMoreDetailListFromListLichChieu(ListLichChieu);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListShowTimesDTO);
            view.Filter = FilterByMaPhimAndDate;
        }
        private bool FilterByMaPhimAndDate(object item)
        {
            return
                (item as ShowTimesDTO).MaPhim == MaPhimForShowTimes && (item as ShowTimesDTO).NgayChieu == NgayChieuForShowTimes;
        }
    }
}
