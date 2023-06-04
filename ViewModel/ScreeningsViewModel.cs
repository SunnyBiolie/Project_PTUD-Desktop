using Project_PTUD_Desktop.Model.DAO;
using Project_PTUD_Desktop.Model.DTO;
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

        private ObservableCollection<SuatChieu> listSuatChieu;
        public ObservableCollection<SuatChieu> ListSuatChieu { get => listSuatChieu; set { listSuatChieu = value; OnPropertyChanged(); } }

        private ObservableCollection<int> hoursList;
        private ObservableCollection<int> minutesList;
        public ObservableCollection<int> HoursList { get => hoursList; set { hoursList = value; OnPropertyChanged(); } }
        public ObservableCollection<int> MinutesList { get => minutesList; set { minutesList = value; OnPropertyChanged(); } }

        #region properties and fields for add
        private string maSuat_add;
        private int gioBatDau_add;
        private int phutBatDau_add;
        public string MaSuat_add { get => maSuat_add; set { maSuat_add = value; OnPropertyChanged(); } }
        public int GioBatDau_add { get => gioBatDau_add; set { gioBatDau_add = value; OnPropertyChanged(); } }
        public int PhutBatDau_add { get => phutBatDau_add; set { phutBatDau_add = value; OnPropertyChanged(); } }

        private int selectedHourForAdd;
        private int selectedMinuteForAdd;
        public int SelectedHourForAdd
        {
            get => selectedHourForAdd;
            set
            {
                selectedHourForAdd = value;
                OnPropertyChanged();
                GioBatDau_add = SelectedHourForAdd;
            }
        }
        public int SelectedMinuteForAdd
        {
            get => selectedMinuteForAdd;
            set
            {
                selectedMinuteForAdd = value;
                OnPropertyChanged();
                PhutBatDau_add = SelectedMinuteForAdd;
            }
        }
        #endregion


        #region properties and fields for delete
        private string maSuat_delete;
        private int gioBatDau_delete;
        private int phutBatDau_delete;
        public string MaSuat_delete { get => maSuat_delete; set { maSuat_delete = value; OnPropertyChanged(); } }
        public int GioBatDau_delete { get => gioBatDau_delete; set { gioBatDau_delete = value; OnPropertyChanged(); } }
        public int PhutBatDau_delete { get => phutBatDau_delete; set { phutBatDau_delete = value; OnPropertyChanged(); } }

        private SuatChieu selectedItem;
        public SuatChieu SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
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
            for (int i = 8; i <= 23; i++) hoursList.Add(i);
            MinutesList = new ObservableCollection<int>();
            for (int i = 0; i <= 59; i+=10) minutesList.Add(i);
            LoadListSuatChieu();

            SelectedHourForAdd = HoursList.First();
            SelectedMinuteForAdd = minutesList.First();

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
                    SuatChieu screenigs = new SuatChieu(MaSuat_add, GioBatDau_add, PhutBatDau_add);
                    if (SuatChieuDAO.Instance.InsertSuatChieu(screenigs))
                        LoadListSuatChieu();
                    else MessageBox.Show($"Thêm suất chiếu mới không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    if (MessageBox.Show($"Bạn có chắc muốn xóa suất chiếu có mã: {SelectedItem.MaSuat}", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var screenings = ListSuatChieu.FirstOrDefault(suatChieu => suatChieu.MaSuat == MaSuat_delete);
                        if (screenings != null)
                        {
                            if (SuatChieuDAO.Instance.DeleteSuatChieu(MaSuat_delete))
                            {
                                LoadListSuatChieu();
                                SelectedItem = ListSuatChieu.First();
                            }
                            else MessageBox.Show($"Xóa suất chiếu không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            );
        }
        private void LoadListSuatChieu()
        {
            ListSuatChieu = SuatChieuDAO.Instance.GetListSuatChieus();
            // Sắp xếp ListSuatChieu để các ListView Binding đến nó cũng sẽ được sắp xếp
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListSuatChieu);
            view.SortDescriptions.Add(new SortDescription("GioBatDau", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("PhutBatDau", ListSortDirection.Ascending));
        }
    }
}
