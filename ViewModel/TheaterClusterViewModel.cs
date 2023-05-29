using Project_PTUD_Desktop.Model;
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
        private string maCum;
        private string tenCum;
        private string diaChi;
        public string MaCum { get => maCum; set { maCum = value; OnPropertyChanged(); } }
        public string TenCum { get => tenCum; set { tenCum = value; OnPropertyChanged(); } }
        public string DiaChi { get => diaChi; set { diaChi = value; OnPropertyChanged(); } }

        private string maCum_curr_edit;
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
                    MaCum = SelectedItem.MaCum;
                    TenCum = SelectedItem.TenCum;
                    DiaChi = SelectedItem.DiaChi;

                    maCum_curr_edit = SelectedItem.MaCum;
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
            ListCumRap = new ObservableCollection<CumRap>(DataProvider.Instance.Database.CumRaps);

            AddCommand = new RelayCommand<object>(
                (para) =>
                {
                    if (string.IsNullOrEmpty(MaCum_add)) return false;
                    var listMaCum = DataProvider.Instance.Database.CumRaps.Where(ele => ele.MaCum == MaCum_add);
                    if (listMaCum == null || listMaCum.Count() != 0) return false;

                    return true;
                },
                (para) =>
                {
                    var theaterCluster = new CumRap() { MaCum = MaCum_add, TenCum = TenCum_add, DiaChi = DiaChi_add };
                    DataProvider.Instance.Database.CumRaps.Add(theaterCluster);
                    DataProvider.Instance.Database.SaveChanges();
                    ListCumRap.Add(theaterCluster);
                }
            );

            EditCommand = new RelayCommand<object>(
                (para) =>
                {
                    if (string.IsNullOrEmpty(MaCum)) return false;
                    if (string.Compare(TenCum, tenCum_curr_edit, true) == 0 && string.Compare(DiaChi, diaChi_curr_edit, true) == 0)
                        return false;
                    return true;
                },
                (para) =>
                {
                    var theaterCluster = DataProvider.Instance.Database.CumRaps.Where(ele => ele.MaCum == SelectedItem.MaCum).FirstOrDefault();
                    theaterCluster.TenCum = TenCum;
                    theaterCluster.DiaChi = DiaChi;
                    DataProvider.Instance.Database.SaveChanges();

                    tenCum_curr_edit = TenCum;
                    diaChi_curr_edit = DiaChi;

                    TenCum_delete = TenCum;
                    DiaChi_delete = DiaChi;
                }
            );

            DeleteCommand = new RelayCommand<object>(
                para =>
                {
                    return true;
                },
                para =>
                {
                    if (MessageBox.Show($"Bạn có chắc muốn xóa cụm rạp {SelectedItem.TenCum}", "Xác nhận xóa?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var theaterCluster = DataProvider.Instance.Database.CumRaps.Where(ele => ele.MaCum == SelectedItem.MaCum).FirstOrDefault();
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
    }
}
