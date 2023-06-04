using Project_PTUD_Desktop.Model.DAO;
using Project_PTUD_Desktop.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string maCum_add;
        private string tenCum_add;
        private string diaChi_add;
        public string MaCum_add { get => maCum_add; set { maCum_add = value; OnPropertyChanged(); } }
        public string TenCum_add { get => tenCum_add; set { tenCum_add = value; OnPropertyChanged(); } }
        public string DiaChi_add { get => diaChi_add; set { diaChi_add = value; OnPropertyChanged(); } }
        #endregion

        #region properties and fields for edit
        private string maCum_edit;
        private string tenCum_edit;
        private string diaChi_edit;
        public string MaCum_edit { get => maCum_edit; set { maCum_edit = value; OnPropertyChanged(); } }
        public string TenCum_edit { get => tenCum_edit; set { tenCum_edit = value; OnPropertyChanged(); } }
        public string DiaChi_edit { get => diaChi_edit; set { diaChi_edit = value; OnPropertyChanged(); } }

        private string tenCum_curr_edit;
        private string diaChi_curr_edit;

        private CumRap selectedItem;
        public CumRap SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaCum_edit = SelectedItem.MaCum;
                    TenCum_edit = SelectedItem.TenCum;
                    DiaChi_edit = SelectedItem.DiaChi;

                    tenCum_curr_edit = selectedItem.TenCum;
                    diaChi_curr_edit = selectedItem.DiaChi;

                    MaCum_delete = SelectedItem.MaCum;
                    TenCum_delete = SelectedItem.TenCum;
                    DiaChi_delete = SelectedItem.DiaChi;
                }
            }
        }
        #endregion

        #region properties and fields for delete
        private string maCum_delete;
        private string tenCum_delete;
        private string diaChi_delete;
        public string MaCum_delete { get => maCum_delete; set { maCum_delete = value; OnPropertyChanged(); } }
        public string TenCum_delete { get => tenCum_delete; set { tenCum_delete = value; OnPropertyChanged(); } }
        public string DiaChi_delete { get => diaChi_delete; set { diaChi_delete = value; OnPropertyChanged(); } }

        // Edit & Delete cùng binding đến một List và SelectedItem được dùng chung cho cả hai nên ko cần thêm 1 selecteditem cho delete

        //private CumRap selectedItem_delete;
        //public CumRap SelectedItem_delete
        //{
        //    get => selectedItem_delete;
        //    set
        //    {
        //        selectedItem_delete = value;
        //        OnPropertyChanged();
        //        if (SelectedItem_delete != null)
        //        {
        //            MaCum_delete = SelectedItem_delete.MaCum;
        //            TenCum_delete = SelectedItem_delete.TenCum;
        //            DiaChi_delete = SelectedItem_delete.DiaChi;
        //        }
        //    }
        //}
        #endregion

        public TheaterClusterViewModel()
        {
            ListCumRap = CumRapDAO.Instance.GetListCumRaps();

            AddCommand = new RelayCommand<object>(
                (para) =>
                {
                    if (string.IsNullOrEmpty(MaCum_add)) return false;
                    var listMaCum = from cumRap in ListCumRap
                                    where cumRap.MaCum.ToUpper() == MaCum_add.ToUpper()
                                    select cumRap;
                    if (listMaCum == null || listMaCum.Count() != 0) return false;

                    return true;
                },
                (para) =>
                {
                    CumRap theaterCluster = new CumRap(MaCum_add, tenCum_add, DiaChi_add);
                    if (CumRapDAO.Instance.InsertCumRap(theaterCluster))
                        ListCumRap = CumRapDAO.Instance.GetListCumRaps();
                    else MessageBox.Show($"Thêm cụm rạp mới không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    TheaterViewModel.Instance.ListCumRap = new ObservableCollection<CumRap>(CumRapDAO.Instance.GetListCumRaps());
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
                    //var theaterCluster = CumRapDAO.Instance.GetCumRapByMaCum(MaCum_edit);
                    if (CumRapDAO.Instance.UpdateInfoCumRap(TenCum_edit, DiaChi_edit, MaCum_edit))
                    {
                        tenCum_curr_edit = TenCum_edit;
                        diaChi_curr_edit = DiaChi_edit;

                        TenCum_delete = TenCum_edit;
                        DiaChi_delete = DiaChi_edit;
                        
                        ListCumRap = CumRapDAO.Instance.GetListCumRaps();
                    }
                    else MessageBox.Show($"Cập nhật thông tin không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    if (RapDAO.Instance.GetListRapsByMaCum(MaCum_delete).Count > 0)
                    {
                        MessageBox.Show($"Chỉ có thể xóa các cụm rạp không còn rạp tham chiếu đến", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (KeHoachDAO.Instance.GetListKeHoachsByMaCum(MaCum_delete).Count > 0)
                    {
                        MessageBox.Show($"Chỉ có thể xóa các cụm rạp đang không có kế hoạch chiếu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (MessageBox.Show($"Bạn có chắc muốn xóa cụm rạp {SelectedItem.TenCum}", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var theaterCluster = CumRapDAO.Instance.GetCumRapByMaCum(MaCum_delete);
                        if (theaterCluster != null)
                        {
                            if (CumRapDAO.Instance.DeleteCumRap(MaCum_delete))
                            {
                                ListCumRap = CumRapDAO.Instance.GetListCumRaps();
                                SelectedItem = ListCumRap.First();
                            }
                            else MessageBox.Show($"Xóa cụm rạp không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            );
        }
    }
}
