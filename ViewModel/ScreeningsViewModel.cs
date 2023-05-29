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
            ListSuatChieu = new ObservableCollection<SuatChieu>(DataProvider.Instance.Database.SuatChieux);

            SelectedHourForAdd = HoursList.First();
            SelectedMinuteForAdd = minutesList.First();

            // Sắp xếp ListSuatChieu để các ListView Binding đến nó cũng sẽ được sắp xếp
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListSuatChieu);
            view.SortDescriptions.Add(new SortDescription("GioBatDau", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("PhutBatDau", ListSortDirection.Ascending));

            AddCommand = new RelayCommand<object>(
            (para) =>
            {
                if (string.IsNullOrEmpty(MaSuat_add)) return false;
                    var listMaSuat = DataProvider.Instance.Database.SuatChieux.Where(ele => ele.MaSuat == MaSuat_add);
                    if (listMaSuat == null || listMaSuat.Count() != 0) return false;
                    foreach (var suat in ListSuatChieu)
                        if (GioBatDau_add == (int)suat.GioBatDau && PhutBatDau_add == (int)suat.PhutBatDau) return false;

                    return true;
                },
                (para) =>
                {
                    var screenigs = new SuatChieu() { MaSuat = MaSuat_add, GioBatDau = GioBatDau_add, PhutBatDau = PhutBatDau_add };
                    DataProvider.Instance.Database.SuatChieux.Add(screenigs);
                    DataProvider.Instance.Database.SaveChanges();
                    ListSuatChieu.Add(screenigs);
                }
            );

            DeleteCommand = new RelayCommand<object>(
                para =>
                {
                    //ObservableCollection<LichChieu> listLichChieu = new ObservableCollection<LichChieu>(DataProvider.Instance.Database.LichChieux.Where(ele => ele.);
                    //foreach (var lichchieu in listLichChieu)
                    //{
                    //    lichchieu.ChuoiMaSuat
                    //}

                    return true;
                },
                para =>
                {
                    if (MessageBox.Show($"Bạn có chắc muốn xóa suất chiếu có mã: {SelectedItem.MaSuat}", "Xác nhận xóa?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var screenings = DataProvider.Instance.Database.SuatChieux.Where(ele => ele.MaSuat == SelectedItem.MaSuat).FirstOrDefault();
                        if (screenings != null)
                        {
                            DataProvider.Instance.Database.SuatChieux.Remove(screenings);
                            DataProvider.Instance.Database.SaveChanges();
                            ListSuatChieu.Remove(screenings);
                            SelectedItem = ListSuatChieu.First();
                        }
                    }
                }
            );
        }
    }
}
