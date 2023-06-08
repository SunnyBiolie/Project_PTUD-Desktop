using Project_PTUD_Desktop.ModelEntity;
using Project_PTUD_Desktop.ModelEntity.EntityDAO;
using Project_PTUD_Desktop.ModelEntity.EntityDTO;
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
    public class PlanViewModel : BaseViewModel
    {
        #region For tab KeHoach in MainWindow
        public ICommand OpenPlanWindowCommand { get; set; }

        private string _maPhimForPlan;
        public string MaPhimForPlan { get => _maPhimForPlan; set { _maPhimForPlan = value; OnPropertyChanged(); } }

        private Phim _selectedPhimForPlan;
        public Phim SelectedPhimForPlan
        {
            get => _selectedPhimForPlan;
            set
            {
                _selectedPhimForPlan = value;
                OnPropertyChanged();
                if (SelectedPhimForPlan != null)
                {
                    MaPhimForPlan = SelectedPhimForPlan.MaPhim;


                    CollectionViewSource.GetDefaultView(ListKeHoach).Refresh();
                }
            }
        }
        #endregion

        #region properties and fields for add tab
        public ICommand AddCommand { get; set; }

        private string _maCum_add;
        private DateTime _ngayKhoiChieu_add;
        private DateTime _ngayKetThuc_add;
        private string _ghiChu_add;

        public string MaCum_add { get => _maCum_add; set { _maCum_add = value; OnPropertyChanged(); } }
        public DateTime NgayKhoiChieu_add { get => _ngayKhoiChieu_add; set { _ngayKhoiChieu_add = value; OnPropertyChanged(); } }
        public DateTime NgayKetThuc_add { get => _ngayKetThuc_add; set { _ngayKetThuc_add = value; OnPropertyChanged(); } }
        public string GhiChu_add { get => _ghiChu_add; set { _ghiChu_add = value; OnPropertyChanged(); } }

        private ObservableCollection<CumRap> _listCumRap_add;
        public ObservableCollection<CumRap> ListCumRap_add { get => _listCumRap_add; set { _listCumRap_add = value; OnPropertyChanged(); } }
        private ObservableCollection<KeHoach> _listKeHoach_add;
        public ObservableCollection<KeHoach> ListKeHoach_add { get => _listKeHoach_add; set { _listKeHoach_add = value; OnPropertyChanged(); } }
        private CumRap _selectedCumRap_add;
        public CumRap SelectedCumRap_add
        {
            get => _selectedCumRap_add;
            set
            {
                _selectedCumRap_add = value;
                OnPropertyChanged();
                if (SelectedCumRap_add != null)
                {
                    MaCum_add = SelectedCumRap_add.MaCum;
                    ListKeHoach_add = new ObservableCollection<KeHoach>();
                    ListKeHoach_add = new ObservableCollection<KeHoach>(DataProvider.Instance.Database.KeHoaches.Where(kh => kh.MaCum == MaCum_add && kh.NgayKetThuc > DateTime.Today));
                }
            }
        }
        private DateTime _selectedNgayKhoiChieu_add;
        public DateTime SelectedNgayKhoiChieu_add
        {
            get => _selectedNgayKhoiChieu_add;
            set
            {
                _selectedNgayKhoiChieu_add = value;
                OnPropertyChanged();
                if (SelectedNgayKhoiChieu_add != null)
                {
                    NgayKhoiChieu_add = SelectedNgayKhoiChieu_add;
                }
            }
        }
        private DateTime _selectedNgayKetThuc_add;
        public DateTime SelectedNgayKetThuc_add
        {
            get => _selectedNgayKetThuc_add;
            set
            {
                _selectedNgayKetThuc_add = value;
                OnPropertyChanged();
                if (SelectedNgayKetThuc_add != null)
                {
                    NgayKetThuc_add = SelectedNgayKetThuc_add;
                }
            }
        }

        private ObservableCollection<KeHoach> _listKeHoachToCheck;
        public ObservableCollection<KeHoach> ListKeHoachToCheck { get => _listKeHoachToCheck; set { _listKeHoachToCheck = value; OnPropertyChanged(); } }
        #endregion

        #region properties and fields for edit tab
        public ICommand DeleteCommand { get; set; }
        private KeHoach _selectedItem;
        public KeHoach SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {


                    MaCum_delete = SelectedItem.MaCum;
                    GhiChu_delete = SelectedItem.GhiChu;
                    DisplayNgayKhoiChieu_delete = $"{SelectedItem.NgayKhoiChieu.Day}/{SelectedItem.NgayKhoiChieu.Month}/{SelectedItem.NgayKhoiChieu.Year}";
                    DisplayNgayKetThuc_delete = $"{SelectedItem.NgayKetThuc.Day}/{SelectedItem.NgayKetThuc.Month}/{SelectedItem.NgayKetThuc.Year}";
                    NgayKhoiChieu_delete = SelectedItem.NgayKhoiChieu;
                    NgayKetThuc_delete = SelectedItem.NgayKetThuc;
                }
            }
        }
        #endregion

        #region properties and fields for delete tab
        private string _maCum_delete;
        private string _ghiChu_delete;
        private string _displayNgayKhoiChieu_delete;
        private string _displayNgayKetThuc_delete;
        private DateTime _ngayKhoiChieu_delete;
        private DateTime _ngayKetThuc_delete;

        public string MaCum_delete { get => _maCum_delete; set { _maCum_delete = value; OnPropertyChanged(); } }
        public string GhiChu_delete { get => _ghiChu_delete; set { _ghiChu_delete = value; OnPropertyChanged(); } }
        public string DisplayNgayKhoiChieu_delete { get => _displayNgayKhoiChieu_delete; set { _displayNgayKhoiChieu_delete = value; OnPropertyChanged(); } }
        public string DisplayNgayKetThuc_delete { get => _displayNgayKetThuc_delete; set { _displayNgayKetThuc_delete = value; OnPropertyChanged(); } }
        public DateTime NgayKhoiChieu_delete { get => _ngayKhoiChieu_delete; set { _ngayKhoiChieu_delete = value; OnPropertyChanged(); } }
        public DateTime NgayKetThuc_delete { get => _ngayKetThuc_delete; set { _ngayKetThuc_delete = value; OnPropertyChanged(); } }
        #endregion

        private ObservableCollection<KeHoach> _listKeHoach;
        public ObservableCollection<KeHoach> ListKeHoach { get => _listKeHoach; set { _listKeHoach = value; OnPropertyChanged(); } }

        public PlanViewModel()
        {
            LoadListKeHoach();

            OpenPlanWindowCommand = new RelayCommand<object>(
                param =>
                {
                    if (string.IsNullOrEmpty(MaPhimForPlan)) return false;
                    return true;
                },
                param =>
                {
                    //TheaterClusterDAO.Instance.GetListCumRapFromListKeHoach(new ObservableCollection<KeHoach>(DataProvider.Instance.Database.KeHoaches.Where(kh => kh.MaPhim == MaPhimForPlan)));    //chọn ra ds cụm rạp theo kế hoạch (theo mã phim)
                    ListCumRap_add = new ObservableCollection<CumRap>(DataProvider.Instance.Database.CumRaps);
                    SelectedNgayKhoiChieu_add = DateTime.Today.AddDays(1);
                    SelectedNgayKetThuc_add = DateTime.Today.AddDays(2);

                    PlanWindow pw = new PlanWindow();
                    pw.ShowDialog();
                }
            );
            AddCommand = new RelayCommand<object>(
                param =>
                {
                    if (string.IsNullOrEmpty(MaCum_add) || NgayKhoiChieu_add == null || NgayKetThuc_add == null)
                        return false;
                    if (ListKeHoach.Where(kh => kh.MaPhim == MaPhimForPlan && kh.MaCum == MaCum_add && kh.NgayKhoiChieu == NgayKhoiChieu_add && kh.NgayKetThuc == NgayKetThuc_add).Count() != 0) return false;
                    return true;
                },
                param =>
                {
                    ListKeHoachToCheck = new ObservableCollection<KeHoach>();
                    foreach (KeHoach kh in ListKeHoach_add)
                    {
                        if (kh.NgayKhoiChieu >= NgayKhoiChieu_add && kh.NgayKetThuc <= NgayKetThuc_add)
                            ListKeHoachToCheck.Add(kh);
                        else if (kh.NgayKhoiChieu <= NgayKhoiChieu_add && kh.NgayKetThuc >= NgayKhoiChieu_add)
                            ListKeHoachToCheck.Add(kh);
                        else if (kh.NgayKhoiChieu <= NgayKetThuc_add && kh.NgayKetThuc >= NgayKetThuc_add)
                            ListKeHoachToCheck.Add(kh);
                        else if (kh.NgayKhoiChieu <= NgayKhoiChieu_add && kh.NgayKetThuc >= NgayKetThuc_add)
                            ListKeHoachToCheck.Add(kh);
                    }
                    foreach (KeHoach kh in ListKeHoachToCheck)
                    {
                        if (kh.MaCum == MaCum_add && kh.MaPhim == MaPhimForPlan)
                        {
                            MessageBox.Show($"Phim hiện đang có kế hoạch chiếu ở cụm rạp \'{MaCum_add}\' trùng với khoảng thời gian được chọn", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    if (ListKeHoachToCheck.Count != 0)
                    {
                        DateTime minDateS = ListKeHoachToCheck[0].NgayKhoiChieu;
                        DateTime maxDateE = ListKeHoachToCheck[0].NgayKetThuc;
                        foreach (KeHoach kh in ListKeHoachToCheck)
                        {
                            if (kh.NgayKhoiChieu < minDateS) minDateS = kh.NgayKhoiChieu;
                            if (kh.NgayKetThuc > maxDateE) maxDateE = kh.NgayKetThuc;
                        }
                        if (minDateS < NgayKhoiChieu_add) minDateS = NgayKhoiChieu_add;
                        if (maxDateE > NgayKetThuc_add) maxDateE = NgayKetThuc_add;
                        TimeSpan length = maxDateE - minDateS;
                        int[] count = new int[(int)length.TotalDays + 1];
                        foreach (KeHoach kh in ListKeHoachToCheck)
                        {
                            for (int i = 0; i < count.Length; i++)
                            {
                                if ((count.Length - (maxDateE - kh.NgayKhoiChieu).TotalDays) - 1 <= i &&
                                    (count.Length - (maxDateE - kh.NgayKetThuc).TotalDays) - 1 >= i) count[i]++;
                            }
                        }

                        int RapCount = DataProvider.Instance.Database.Raps.Where(r => r.MaCum == MaCum_add).Count();
                        foreach (var c in count)
                        {
                            if (c >= RapCount)
                            {
                                MessageBox.Show($"Trong thời gian diễn ra kế hoạch muốn thêm đã có thời điểm tổng số kế hoạch({c}) bằng với số rạp của cụm, không thể thêm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }
                    }

                    KeHoach Plan = new KeHoach() { MaPhim = MaPhimForPlan, MaCum = MaCum_add, NgayKhoiChieu = NgayKhoiChieu_add, NgayKetThuc = NgayKetThuc_add, GhiChu = GhiChu_add };
                    DataProvider.Instance.Database.KeHoaches.Add(Plan);
                    DataProvider.Instance.Database.SaveChanges();
                    LoadListKeHoach();
                    GhiChu_add = "";

                    MessageBox.Show($"Thêm kế hoạch thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            );

            DeleteCommand = new RelayCommand<object>(
                param =>
                {
                    if (SelectedItem == null) return false;
                    return true;
                },
                param =>
                {   
                    if (SelectedItem.NgayKetThuc < DateTime.Today)
                    {
                        MessageBox.Show($"Không thể xóa kế hoạch đã qua", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (SelectedItem.NgayKhoiChieu < DateTime.Today && SelectedItem.NgayKetThuc > DateTime.Today)
                    {
                        MessageBox.Show($"Không thể xóa kế hoạch đang diễn ra", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    ICollection<Rap> listRap = DataProvider.Instance.Database.CumRaps.Find(MaCum_delete).Raps;
                    List<LichChieu> listLichChieuCuaCum = new List<LichChieu>();
                    foreach (Rap rap in listRap)
                    {
                        foreach (LichChieu lc in rap.LichChieux)
                        {
                            listLichChieuCuaCum.Add(lc);
                        }
                    }
                    List<LichChieu> listLichChieuCuaCumTheoNgay = new List<LichChieu>();
                    foreach (LichChieu lc in listLichChieuCuaCum)
                    {
                        if (lc.MaPhim == MaPhimForPlan && (lc.NgayChieu >= NgayKhoiChieu_delete && lc.NgayChieu <= NgayKetThuc_delete))
                        {
                            listLichChieuCuaCumTheoNgay.Add(lc);
                        }
                    }
                    if (MessageBox.Show($"Kế hoạch đang có {listLichChieuCuaCumTheoNgay.Count} lịch chiếu, xóa kế hoạch sẽ xóa {listLichChieuCuaCumTheoNgay.Count} lịch chiếu, bạn có chắc muốn xóa?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        foreach (LichChieu lc in listLichChieuCuaCumTheoNgay)
                        {
                            ShowTimesDAO.Instance.DeleteLichChieu(lc.MaPhim, lc.MaRap, lc.NgayChieu);
                        }
                        KeHoach KeHoach = DataProvider.Instance.Database.KeHoaches.FirstOrDefault(kh => kh.MaPhim == MaPhimForPlan && kh.MaCum == MaCum_delete && kh.NgayKhoiChieu == NgayKhoiChieu_delete && kh.NgayKetThuc == NgayKetThuc_delete);
                        DataProvider.Instance.Database.KeHoaches.Remove(KeHoach);
                        DataProvider.Instance.Database.SaveChanges();
                        LoadListKeHoach();
                        MaCum_delete = "";
                        GhiChu_delete = "";
                        DisplayNgayKhoiChieu_delete = "";
                        DisplayNgayKetThuc_delete = "";
                    }
                    MessageBox.Show($"Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            );
        }
        private void LoadListKeHoach()
        {
            ListKeHoach = new ObservableCollection<KeHoach>(DataProvider.Instance.Database.KeHoaches);
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListKeHoach);
            view.Filter = FilterByMaPhim;
        }
        private bool FilterByMaPhim(object item)
        {
            return
                (item as KeHoach).MaPhim == MaPhimForPlan;
        }
    }
}
