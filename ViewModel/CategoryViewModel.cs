//using Project_PTUD_Desktop.Model.DTO;
//using Project_PTUD_Desktop.Model.DAO;
using Project_PTUD_Desktop.ModelEntity;
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

        private ObservableCollection<TheLoai> _listTheLoai;
        public ObservableCollection<TheLoai> ListTheLoai { get => _listTheLoai; set { _listTheLoai = value; OnPropertyChanged(); } }

        #region properties and fields for add
        private string _maTheLoai_add;
        private string _tenTheLoai_add;
        public string MaTheLoai_add { get => _maTheLoai_add; set { _maTheLoai_add = value; OnPropertyChanged(); } }
        public string TenTheLoai_add { get => _tenTheLoai_add; set { _tenTheLoai_add = value; OnPropertyChanged(); } }
        #endregion

        #region properties and fields for edit
        private string _maTheLoai_edit;
        private string _tenTheLoai_edit;
        public string MaTheLoai_edit { get => _maTheLoai_edit; set { _maTheLoai_edit = value; OnPropertyChanged(); } }
        public string TenTheLoai_edit { get => _tenTheLoai_edit; set { _tenTheLoai_edit = value; OnPropertyChanged(); } }

        private string _tenTheLoai_curr_edit;

        private TheLoai _selectedItem;
        public TheLoai SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaTheLoai_edit = SelectedItem.MaTheLoai;
                    TenTheLoai_edit = SelectedItem.TenTheLoai;

                    _tenTheLoai_curr_edit = SelectedItem.TenTheLoai;

                    MaTheLoai_delete = SelectedItem.MaTheLoai;
                    TenTheLoai_delete = SelectedItem.TenTheLoai;
                }
            }
        }
        #endregion

        #region properties and fields for delete
        private string _maTheLoai_delete;
        private string _tenTheLoai_delete;
        public string MaTheLoai_delete { get => _maTheLoai_delete; set { _maTheLoai_delete = value; OnPropertyChanged(); } }
        public string TenTheLoai_delete { get => _tenTheLoai_delete; set { _tenTheLoai_delete = value; OnPropertyChanged(); } }
        #endregion

        public CategoryViewModel()
        {
            //ListTheLoai = TheLoaiDAO.Instance.GetListTheLoais();
            ListTheLoai = new ObservableCollection<TheLoai>(DataProvider.Instance.Database.TheLoais);

            AddCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaTheLoai_add)) return false;
                    var listMaTheLoai = from theloai in ListTheLoai
                                        where theloai.MaTheLoai == MaTheLoai_add
                                        select theloai;
                    if (listMaTheLoai == null || listMaTheLoai.Count() != 0) return false;

                    return true;
                },
                para =>
                {
                    //var category = new TheLoai(MaTheLoai_add, TenTheLoai_add);
                    //if (TheLoaiDAO.Instance.InsertTheLoai(category))
                    //    ListTheLoai = TheLoaiDAO.Instance.GetListTheLoais();
                    //else MessageBox.Show($"Thêm thể loại mới không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);

                    TheLoai category = new TheLoai() { MaTheLoai = MaTheLoai_add, TenTheLoai = TenTheLoai_add };
                    DataProvider.Instance.Database.TheLoais.Add(category);
                    DataProvider.Instance.Database.SaveChanges();
                    ListTheLoai.Add(category);
                }
            );

            EditCommand = new RelayCommand<object>(
                (para) =>
                {
                    if (string.IsNullOrEmpty(MaTheLoai_edit)) return false;
                    if (string.Compare(TenTheLoai_edit, _tenTheLoai_curr_edit, true) == 0)
                        return false;
                    return true;
                },
                (para) =>
                {
                    #region
                    //if (TheLoaiDAO.Instance.UpdateInfoTheLoai(TenTheLoai_edit, MaTheLoai_edit))
                    //{
                    //    tenTheLoai_curr_edit = TenTheLoai_edit;

                    //    TenTheLoai_delete = TenTheLoai_edit;

                    //    ListTheLoai = TheLoaiDAO.Instance.GetListTheLoais();
                    //}
                    //else MessageBox.Show($"Cập nhật thông tin không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    #endregion

                    TheLoai category = DataProvider.Instance.Database.TheLoais.Where(theLoai => theLoai.MaTheLoai == MaTheLoai_edit).FirstOrDefault();
                    category.TenTheLoai = TenTheLoai_edit;
                    DataProvider.Instance.Database.SaveChanges();

                    _tenTheLoai_curr_edit = TenTheLoai_edit;
                    TenTheLoai_delete = TenTheLoai_edit;
                }
            );

            DeleteCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaTheLoai_delete)) return false;
                    return true;
                },
                para =>
                {
                    #region
                    //if (PhimDAO.Instance.GetListPhimsByMaTheLoaiChinh(MaTheLoai_delete).Count != 0 || PhimDAO.Instance.GetListPhimsByMaTheLoaiPhu(MaTheLoai_delete).Count != 0)
                    //{
                    //    MessageBox.Show($"Chỉ có thể xóa thể loại khi không còn phim nào tham chiếu đến", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    return;
                    //}
                    //if (MessageBox.Show($"Bạn có chắc muốn xóa thể loại {SelectedItem.TenTheLoai}", "Xác nhận xóa?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    //{
                    //    var category = TheLoaiDAO.Instance.GetTheLoaiByMaTheLoaiChinh(MaTheLoai_delete);
                    //    if (category != null)
                    //    {
                    //        if (TheLoaiDAO.Instance.DeleteTheLoai(MaTheLoai_delete))
                    //        {
                    //            ListTheLoai = TheLoaiDAO.Instance.GetListTheLoais();
                    //            SelectedItem = ListTheLoai.First();
                    //        }
                    //        else MessageBox.Show($"Xóa thể loại không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    }
                    //}
                    #endregion

                    if (SelectedItem.Phims.Count != 0 || SelectedItem.Phims1.Count != 0)
                    {
                        MessageBox.Show($"Chỉ có thể xóa thể loại khi không còn phim nào tham chiếu đến", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (MessageBox.Show($"Bạn có chắc muốn xóa thể loại \"{SelectedItem.TenTheLoai}\"", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        TheLoai category = DataProvider.Instance.Database.TheLoais.Where(theLoai => theLoai.MaTheLoai == MaTheLoai_delete).FirstOrDefault();
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
