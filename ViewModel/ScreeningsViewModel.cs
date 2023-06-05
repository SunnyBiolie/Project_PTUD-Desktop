//using Project_PTUD_Desktop.Model.DAO;
//using Project_PTUD_Desktop.Model.DTO;
using Project_PTUD_Desktop.ModelEntity;
using Project_PTUD_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.ComponentModel;

namespace Project_PTUD_Desktop.ViewModel
{
    public class ScreeningsViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<SuatChieu> _listSuatChieu;
        public ObservableCollection<SuatChieu> ListSuatChieu { get => _listSuatChieu; set { _listSuatChieu = value; OnPropertyChanged(); } }

        private ObservableCollection<int> _hoursList;
        private ObservableCollection<int> _minutesList;
        public ObservableCollection<int> HoursList { get => _hoursList; set { _hoursList = value; OnPropertyChanged(); } }
        public ObservableCollection<int> MinutesList { get => _minutesList; set { _minutesList = value; OnPropertyChanged(); } }

        #region properties and fields for add
        private string _maSuat_add;
        private int _gioBatDau_add;
        private int _phutBatDau_add;
        public string MaSuat_add { get => _maSuat_add; set { _maSuat_add = value; OnPropertyChanged(); } }
        public int GioBatDau_add { get => _gioBatDau_add; set { _gioBatDau_add = value; OnPropertyChanged(); } }
        public int PhutBatDau_add { get => _phutBatDau_add; set { _phutBatDau_add = value; OnPropertyChanged(); } }

        private int _selectedHourForAdd;
        private int _selectedMinuteForAdd;
        public int SelectedHourForAdd
        {
            get => _selectedHourForAdd;
            set
            {
                _selectedHourForAdd = value;
                OnPropertyChanged();
                GioBatDau_add = SelectedHourForAdd;
            }
        }
        public int SelectedMinuteForAdd
        {
            get => _selectedMinuteForAdd;
            set
            {
                _selectedMinuteForAdd = value;
                OnPropertyChanged();
                PhutBatDau_add = SelectedMinuteForAdd;
            }
        }
        #endregion


        #region properties and fields for delete
        private string _maSuat_delete;
        private int _gioBatDau_delete;
        private int _phutBatDau_delete;
        public string MaSuat_delete { get => _maSuat_delete; set { _maSuat_delete = value; OnPropertyChanged(); } }
        public int GioBatDau_delete { get => _gioBatDau_delete; set { _gioBatDau_delete = value; OnPropertyChanged(); } }
        public int PhutBatDau_delete { get => _phutBatDau_delete; set { _phutBatDau_delete = value; OnPropertyChanged(); } }

        private SuatChieu _selectedItem;
        public SuatChieu SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaSuat_delete = SelectedItem.MaSuat;
                    GioBatDau_delete = (int)SelectedItem.GioBatDau;
                    PhutBatDau_delete = (int)SelectedItem.PhutBatDau;
                }
            }
        }
        #endregion

        public ScreeningsViewModel()
        {
            HoursList = new ObservableCollection<int>();
            for (int i = 8; i <= 23; i++) _hoursList.Add(i);
            MinutesList = new ObservableCollection<int>();
            for (int i = 0; i <= 59; i+=10) _minutesList.Add(i);
            LoadListSuatChieu();

            SelectedHourForAdd = HoursList.First();
            SelectedMinuteForAdd = _minutesList.First();

            AddCommand = new RelayCommand<object>(
                (para) =>
                {
                    if (string.IsNullOrEmpty(MaSuat_add)) return false;
                        var listMaSuat = from suatChieu in ListSuatChieu
                                         where suatChieu.MaSuat.ToUpper() == MaSuat_add.ToUpper()
                                         select suatChieu;
                    if (listMaSuat == null || listMaSuat.Count() != 0) return false;
                    foreach (var suat in ListSuatChieu)
                        if (GioBatDau_add == (int)suat.GioBatDau && PhutBatDau_add == (int)suat.PhutBatDau) return false;

                    return true;
                },
                (para) =>
                {
                    SuatChieu screenigs = new SuatChieu() { MaSuat = MaSuat_add, GioBatDau = GioBatDau_add, PhutBatDau = PhutBatDau_add };
                    //if (SuatChieuDTO.Instance.InsertSuatChieu(screenigs))
                    //    LoadListSuatChieu();
                    //else MessageBox.Show($"Thêm suất chiếu mới không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    DataProvider.Instance.Database.SuatChieux.Add(screenigs);
                    DataProvider.Instance.Database.SaveChanges();
                    ListSuatChieu.Add(screenigs);
                }
            );

            DeleteCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaSuat_delete)) return false;
                    return true;
                },
                para =>
                {
                    //if (MessageBox.Show($"Bạn có chắc muốn xóa suất chiếu có mã: {SelectedItem.MaSuat}", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    //{
                    //    var screenings = ListSuatChieu.FirstOrDefault(suatChieu => suatChieu.MaSuat == MaSuat_delete);
                    //    if (screenings != null)
                    //    {
                    //        if (SuatChieuDAO.Instance.DeleteSuatChieu(MaSuat_delete))
                    //        {
                    //            LoadListSuatChieu();
                    //            SelectedItem = ListSuatChieu.First();
                    //        }
                    //        else MessageBox.Show($"Xóa suất chiếu không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    }
                    //}

                    if (MessageBox.Show($"Bạn có chắc muốn xóa suất chiếu có mã: {SelectedItem.MaSuat}", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        SuatChieu screenings = DataProvider.Instance.Database.SuatChieux.FirstOrDefault(suatChieu => suatChieu.MaSuat == MaSuat_delete);
                        DataProvider.Instance.Database.SuatChieux.Remove(screenings);
                        DataProvider.Instance.Database.SaveChanges();
                        ListSuatChieu.Remove(screenings);
                    }
                }
            );
        }
        private void LoadListSuatChieu()
        {
            //ListSuatChieu = SuatChieuDAO.Instance.GetListSuatChieus();
            ListSuatChieu = new ObservableCollection<SuatChieu>(DataProvider.Instance.Database.SuatChieux);
            // Sắp xếp ListSuatChieu để các ListView Binding đến nó cũng sẽ được sắp xếp
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListSuatChieu);
            view.SortDescriptions.Add(new SortDescription("GioBatDau", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("PhutBatDau", ListSortDirection.Ascending));
        }
    }
}
