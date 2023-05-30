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
    public class CategoryViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<TheLoai> listTheLoai;
        public ObservableCollection<TheLoai> ListTheLoai { get => listTheLoai; set { listTheLoai = value; OnPropertyChanged(); } }

        #region properties and fields for add
        private string maTheLoai_add;
        private string tenTheLoai_add;
        public string MaTheLoai_add { get => maTheLoai_add; set { maTheLoai_add = value; OnPropertyChanged(); } }
        public string TenTheLoai_add { get => tenTheLoai_add; set { tenTheLoai_add = value; OnPropertyChanged(); } }
        #endregion

        #region properties and fields for edit
        private string maTheLoai_edit;
        private string tenTheLoai_edit;
        public string MaTheLoai_edit { get => maTheLoai_edit; set { maTheLoai_edit = value; OnPropertyChanged(); } }
        public string TenTheLoai_edit { get => tenTheLoai_edit; set { tenTheLoai_edit = value; OnPropertyChanged(); } }

        private string tenTheLoai_curr_edit;

        private TheLoai selectedItem;
        public TheLoai SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaTheLoai_edit = SelectedItem.MaTheLoai;
                    TenTheLoai_edit = SelectedItem.TenTheLoai;

                    tenTheLoai_curr_edit = selectedItem.TenTheLoai;

                    MaTheLoai_delete = selectedItem.MaTheLoai;
                    TenTheLoai_delete = selectedItem.TenTheLoai;
                }
            }
        }
        #endregion

        #region properties and fields for delete
        private string maTheLoai_delete;
        private string tenTheLoai_delete;
        public string MaTheLoai_delete { get => maTheLoai_delete; set { maTheLoai_delete = value; OnPropertyChanged(); } }
        public string TenTheLoai_delete { get => tenTheLoai_delete; set { tenTheLoai_delete = value; OnPropertyChanged(); } }
        #endregion

        public CategoryViewModel()
        {
            ListTheLoai = new ObservableCollection<TheLoai>(DataProvider.Instance.Database.TheLoais);

            AddCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(maTheLoai_add)) return false;
                    var listTheLoai = DataProvider.Instance.Database.TheLoais.Where(ele => ele.MaTheLoai == MaTheLoai_add);
                    if (listTheLoai == null || listTheLoai.Count() != 0) return false;

                    return true;
                },
                para =>
                {
                    var category = new TheLoai() { MaTheLoai = MaTheLoai_add, TenTheLoai = TenTheLoai_add};
                    DataProvider.Instance.Database.TheLoais.Add(category);
                    DataProvider.Instance.Database.SaveChanges();
                    listTheLoai.Add(category);
                }
            );

            EditCommand = new RelayCommand<object>(
                (para) =>
                {
                    if (string.IsNullOrEmpty(MaTheLoai_edit)) return false;
                    if (string.Compare(TenTheLoai_edit, tenTheLoai_curr_edit, true) == 0)
                        return false;
                    return true;
                },
                (para) =>
                {
                    var category = DataProvider.Instance.Database.TheLoais.Where(ele => ele.MaTheLoai == SelectedItem.MaTheLoai).FirstOrDefault();
                    category.TenTheLoai = TenTheLoai_edit;
                    DataProvider.Instance.Database.SaveChanges();

                    tenTheLoai_curr_edit = TenTheLoai_edit;

                    TenTheLoai_delete = TenTheLoai_edit;
                }
            );

            DeleteCommand = new RelayCommand<object>(
                para =>
                {
                    return true;
                },
                para =>
                {
                    if (MessageBox.Show($"Bạn có chắc muốn xóa thể loại {SelectedItem.TenTheLoai}", "Xác nhận xóa?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var category = DataProvider.Instance.Database.TheLoais.Where(ele => ele.MaTheLoai == SelectedItem.MaTheLoai).FirstOrDefault();
                        if (category != null)
                        {
                            DataProvider.Instance.Database.TheLoais.Remove(category);
                            DataProvider.Instance.Database.SaveChanges();
                            ListTheLoai.Remove(category);
                            SelectedItem = ListTheLoai.First();
                        }
                    }
                }
            );
        }
    }
}
