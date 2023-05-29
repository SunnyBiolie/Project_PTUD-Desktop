using Project_PTUD_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Project_PTUD_Desktop.ViewModel
{
    public class ScreeningsViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<SuatChieu> listSuatChieu;
        public ObservableCollection<SuatChieu> ListSuatChieu { get => listSuatChieu; set { listSuatChieu = value; OnPropertyChanged(); } }

        #region properties and fields for add
        private string maSuat_add;
        private int gioBatDau_add;
        private int phutBatDau_add;
        public string MaSuat_add { get => maSuat_add; set { maSuat_add = value; OnPropertyChanged(); } }
        public int GioBatDau_add { get => gioBatDau_add; set { gioBatDau_add = value; OnPropertyChanged(); } }
        public int PhutBatDau_add { get => phutBatDau_add; set { phutBatDau_add = value; OnPropertyChanged(); } }
        #endregion

        #region properties and fields for edit
        private string maSuat_edit;
        private int gioBatDau_edit;
        private int phutBatDau_edit;
        public string MaSuat_edit { get => maSuat_edit; set { maSuat_edit = value; OnPropertyChanged(); } }
        public int GioBatDau_edit { get => gioBatDau_edit; set { gioBatDau_edit = value; OnPropertyChanged(); } }
        public int PhutBatDau_edit { get => phutBatDau_edit; set { phutBatDau_edit = value; OnPropertyChanged(); } }

        private string maSuat_curr_edit;
        private int gioBatDau_curr_edit;
        private int phutBatDau_curr_edit;

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
                    MaSuat_edit = SelectedItem.MaSuat;
                    GioBatDau_edit = (int)SelectedItem.GioBatDau;
                    PhutBatDau_edit = (int)SelectedItem.PhutBatDau;

                    maSuat_curr_edit = SelectedItem.MaSuat;
                    gioBatDau_curr_edit = (int)selectedItem.GioBatDau;
                    phutBatDau_curr_edit = (int)selectedItem.PhutBatDau;

                    MaSuat_delete = SelectedItem.MaSuat;
                    GioBatDau_delete = (int)SelectedItem.GioBatDau;
                    PhutBatDau_delete = (int)SelectedItem.PhutBatDau;
                }
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

        private SuatChieu selectedItem_delete;
        public SuatChieu SelectedItem_delete
        {
            get => selectedItem_delete;
            set
            {
                selectedItem_delete = value;
                OnPropertyChanged();
                if (SelectedItem_delete != null)
                {
                    MaSuat_delete = SelectedItem_delete.MaSuat;
                    GioBatDau_delete = (int)SelectedItem_delete.GioBatDau;
                    PhutBatDau_delete = (int)SelectedItem_delete.PhutBatDau;
                }
            }
        }
        #endregion

        public ScreeningsViewModel()
        {
            ListSuatChieu = new ObservableCollection<SuatChieu>(DataProvider.Instance.Database.SuatChieux);

            AddCommand = new RelayCommand<object>(
                (para) =>
                {
                    if (string.IsNullOrEmpty(MaSuat_add)) return false;
                    var listMaSuat = DataProvider.Instance.Database.SuatChieux.Where(ele => ele.MaSuat == MaSuat_add);
                    if (listMaSuat == null || listMaSuat.Count() != 0) return false;

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

            EditCommand = new RelayCommand<object>(
                (para) =>
                {
                    if (string.IsNullOrEmpty(MaSuat_edit)) return false;
                    if (GioBatDau_edit == gioBatDau_curr_edit && PhutBatDau_edit == phutBatDau_curr_edit)
                        return false;
                    return true;
                },
                (para) =>
                {
                    var screenings = DataProvider.Instance.Database.SuatChieux.Where(ele => ele.MaSuat == SelectedItem.MaSuat).FirstOrDefault();
                    screenings.GioBatDau = GioBatDau_edit;
                    screenings.PhutBatDau = PhutBatDau_edit;
                    DataProvider.Instance.Database.SaveChanges();

                    // Để kiểm tra điều kiện active nút "Cập nhật" Sau khi update
                    gioBatDau_curr_edit = GioBatDau_edit;
                    phutBatDau_curr_edit = PhutBatDau_edit;

                    // Do cùng có một SelectedItem và một ListView nên cần đồng bộ hiển thị giữa Tab edit và delete
                    GioBatDau_delete = GioBatDau_edit;
                    PhutBatDau_delete = PhutBatDau_edit;
                }
            );

            DeleteCommand = new RelayCommand<object>(
                para =>
                {
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
