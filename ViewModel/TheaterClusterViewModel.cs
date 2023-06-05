//using Project_PTUD_Desktop.Model.DAO;
//using Project_PTUD_Desktop.Model.DTO;
using Project_PTUD_Desktop.ModelEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project_PTUD_Desktop.ViewModel
{
    public class TheaterClusterViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<CumRap> listCumRap;
        public ObservableCollection<CumRap> ListCumRap { get => listCumRap; set { listCumRap = value; OnPropertyChanged(); } }

        #region properties and fields for add
        private string _maCum_add;
        private string _tenCum_add;
        private string _diaChi_add;
        public string MaCum_add { get => _maCum_add; set { _maCum_add = value; OnPropertyChanged(); } }
        public string TenCum_add { get => _tenCum_add; set { _tenCum_add = value; OnPropertyChanged(); } }
        public string DiaChi_add { get => _diaChi_add; set { _diaChi_add = value; OnPropertyChanged(); } }
        #endregion

        #region properties and fields for edit
        private string _maCum_edit;
        private string _tenCum_edit;
        private string _diaChi_edit;
        public string MaCum_edit { get => _maCum_edit; set { _maCum_edit = value; OnPropertyChanged(); } }
        public string TenCum_edit { get => _tenCum_edit; set { _tenCum_edit = value; OnPropertyChanged(); } }
        public string DiaChi_edit { get => _diaChi_edit; set { _diaChi_edit = value; OnPropertyChanged(); } }

        private string tenCum_curr_edit;
        private string diaChi_curr_edit;

        private CumRap _selectedItem;
        public CumRap SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaCum_edit = SelectedItem.MaCum;
                    TenCum_edit = SelectedItem.TenCum;
                    DiaChi_edit = SelectedItem.DiaChi;

                    tenCum_curr_edit = SelectedItem.TenCum;
                    diaChi_curr_edit = SelectedItem.DiaChi;

                    MaCum_delete = SelectedItem.MaCum;
                    TenCum_delete = SelectedItem.TenCum;
                    DiaChi_delete = SelectedItem.DiaChi;
                }
            }
        }
        #endregion

        #region properties and fields for delete
        private string _maCum_delete;
        private string _tenCum_delete;
        private string _diaChi_delete;
        public string MaCum_delete { get => _maCum_delete; set { _maCum_delete = value; OnPropertyChanged(); } }
        public string TenCum_delete { get => _tenCum_delete; set { _tenCum_delete = value; OnPropertyChanged(); } }
        public string DiaChi_delete { get => _diaChi_delete; set { _diaChi_delete = value; OnPropertyChanged(); } }
        #endregion

        public TheaterClusterViewModel()
        {
            LoadListCumRap();

            AddCommand = new RelayCommand<object>(
                (para) =>
                {
                    if (string.IsNullOrEmpty(MaCum_add) || string.IsNullOrEmpty(TenCum_add) || string.IsNullOrEmpty(DiaChi_add)) return false;
                    var listMaCum = from cumRap in ListCumRap
                                    where cumRap.MaCum.ToUpper() == MaCum_add.ToUpper()
                                    select cumRap;
                    if (listMaCum == null || listMaCum.Count() != 0) return false;

                    return true;
                },
                (para) =>
                {
                    //CumRap theaterCluster = new CumRap(MaCum_add, tenCum_add, DiaChi_add);
                    //if (CumRapDAO.Instance.InsertCumRap(theaterCluster))
                    //    ListCumRap = CumRapDAO.Instance.GetListCumRaps();
                    //else MessageBox.Show($"Thêm cụm rạp mới không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    //TheaterViewModel.Instance.ListCumRap = new ObservableCollection<CumRap>(CumRapDAO.Instance.GetListCumRaps());

                    CumRap theaterCluster = new CumRap() { MaCum = MaCum_add, TenCum = TenCum_add, DiaChi = DiaChi_add };
                    DataProvider.Instance.Database.CumRaps.Add(theaterCluster);
                    DataProvider.Instance.Database.SaveChanges();
                    ListCumRap.Add(theaterCluster);
                }
            );

            EditCommand = new RelayCommand<object>(
                (para) =>
                {
                    if (string.IsNullOrEmpty(MaCum_edit)) return false;
                    if (string.Compare(TenCum_edit, tenCum_curr_edit, true) == 0 && string.Compare(DiaChi_edit, diaChi_curr_edit, true) == 0)
                        return false;
                    return true;
                },
                (para) =>
                {
                    //if (CumRapDAO.Instance.UpdateInfoCumRap(TenCum_edit, DiaChi_edit, MaCum_edit))
                    //{
                    //    tenCum_curr_edit = TenCum_edit;
                    //    diaChi_curr_edit = DiaChi_edit;

                    //    TenCum_delete = TenCum_edit;
                    //    DiaChi_delete = DiaChi_edit;

                    //    ListCumRap = CumRapDAO.Instance.GetListCumRaps();
                    //}
                    //else MessageBox.Show($"Cập nhật thông tin không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);

                    CumRap theaterCluster = DataProvider.Instance.Database.CumRaps.Where(ele => ele.MaCum == MaCum_edit).FirstOrDefault();
                    theaterCluster.TenCum = TenCum_edit;
                    theaterCluster.DiaChi = DiaChi_edit;
                    DataProvider.Instance.Database.SaveChanges();

                    tenCum_curr_edit = TenCum_edit;
                    diaChi_curr_edit = DiaChi_edit;

                    TenCum_delete = TenCum_edit;
                    DiaChi_delete = TenCum_edit;
                }
            );

            DeleteCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaCum_delete)) return false;
                    return true;
                },
                para =>
                {
                    //if (RapDAO.Instance.GetListRapsByMaCum(MaCum_delete).Count > 0)
                    //{
                    //    MessageBox.Show($"Chỉ có thể xóa các cụm rạp không còn rạp tham chiếu đến", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    return;
                    //}
                    //if (KeHoachDAO.Instance.GetListKeHoachsByMaCum(MaCum_delete).Count > 0)
                    //{
                    //    MessageBox.Show($"Chỉ có thể xóa các cụm rạp đang không có kế hoạch chiếu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    return;
                    //}
                    //if (MessageBox.Show($"Bạn có chắc muốn xóa cụm rạp {SelectedItem.TenCum}", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    //{
                    //    var theaterCluster = CumRapDAO.Instance.GetCumRapByMaCum(MaCum_delete);
                    //    if (theaterCluster != null)
                    //    {
                    //        if (CumRapDAO.Instance.DeleteCumRap(MaCum_delete))
                    //        {
                    //            ListCumRap = CumRapDAO.Instance.GetListCumRaps();
                    //            SelectedItem = ListCumRap.First();
                    //        }
                    //        else MessageBox.Show($"Xóa cụm rạp không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    }
                    //}

                    if (SelectedItem.Raps.Count != 0)
                    {
                        MessageBox.Show($"Chỉ có thể xóa các cụm rạp không còn rạp tham chiếu đến", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (SelectedItem.KeHoaches.Count != 0)
                    {
                        MessageBox.Show($"Chỉ có thể xóa các cụm rạp đang không có kế hoạch chiếu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (MessageBox.Show($"Bạn có chắc muốn xóa cụm rạp {SelectedItem.TenCum}", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        CumRap theaterCluster = DataProvider.Instance.Database.CumRaps.Where(cumRap => cumRap.MaCum == SelectedItem.MaCum).FirstOrDefault();
                        if (theaterCluster != null)
                        {
                            DataProvider.Instance.Database.CumRaps.Remove(theaterCluster);
                            DataProvider.Instance.Database.SaveChanges();
                            ListCumRap.Remove(theaterCluster);
                            SelectedItem = ListCumRap.First();
                        }
                    }
                }
            );
        }
        private void LoadListCumRap()
        {
            //ListCumRap = CumRapDAO.Instance.GetListCumRaps();
            ListCumRap = new ObservableCollection<CumRap>(DataProvider.Instance.Database.CumRaps);
        }
    }
}
