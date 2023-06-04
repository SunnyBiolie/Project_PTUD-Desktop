using Project_PTUD_Desktop.Model.DAO;
using Project_PTUD_Desktop.Model.DTO;
using Project_PTUD_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Project_PTUD_Desktop.ViewModel
{
    public class FilmViewModel : BaseViewModel
    {

        public ICommand CheckCommand { get; set; }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<Phim> listFilm;
        public ObservableCollection<Phim> ListPhim { get => listFilm; set { listFilm = value; OnPropertyChanged(); } }

        #region command, properties and fields for tab add
        public ICommand AddSubCategory_Add { get; set; }
        public ICommand RemoveSubCategory_Add { get; set; }
        public ICommand ClearAllSubCategory_Add { get; set; }

        private string maPhim_add;
        private string tenPhim_add;
        private string maTheLoaiChinh_add;
        private int thoiLuong_add;

        private string tenTheLoaiChinh_add;
        private string tenTheLoaiPhu_add;
        private string chuoiTenTheLoaiPhu_add;
        private ObservableCollection<TheLoai> listTheLoaiPhu_add;

        public string MaPhim_add { get => maPhim_add; set { maPhim_add = value; OnPropertyChanged(); } }
        public string TenPhim_add { get => tenPhim_add; set { tenPhim_add = value; OnPropertyChanged(); } }
        public string MaTheLoaiChinh_add { get => maTheLoaiChinh_add; set { maTheLoaiChinh_add = value; OnPropertyChanged(); } }
        public int ThoiLuong_add { get => thoiLuong_add; set { thoiLuong_add = value; OnPropertyChanged(); } }

        public string TenTheLoaiChinh_add { get => tenTheLoaiChinh_add; set { tenTheLoaiChinh_add = value; OnPropertyChanged(); } }
        public string TenTheLoaiPhu_add { get => tenTheLoaiPhu_add; set { tenTheLoaiPhu_add = value; OnPropertyChanged(); } }
        public string ChuoiTenTheLoaiPhu_add { get => chuoiTenTheLoaiPhu_add; set { chuoiTenTheLoaiPhu_add = value; OnPropertyChanged(); } }
        public ObservableCollection<TheLoai> ListTheLoaiPhu_add { get => listTheLoaiPhu_add; set { listTheLoaiPhu_add = value; OnPropertyChanged(); } }

        private TheLoai selectedCategory_add;
        public TheLoai SelectedCategory_add
        {
            get => selectedCategory_add;
            set
            {
                selectedCategory_add = value;
                OnPropertyChanged();
                if (selectedCategory_add != null)
                {
                    MaTheLoaiChinh_add = selectedCategory_add.MaTheLoai;
                    TenTheLoaiChinh_add = selectedCategory_add.TenTheLoai;
                }
            }
        }

        private TheLoai selectedSubCategory_add;
        public TheLoai SelectedSubCategory_add
        {
            get => selectedSubCategory_add;
            set
            {
                selectedSubCategory_add = value;
                OnPropertyChanged();
                if (SelectedSubCategory_add != null)
                {
                    TenTheLoaiPhu_add = SelectedSubCategory_add.TenTheLoai;
                }
            }
        }
        #endregion

        #region command, properties and fields for tab edit
        private ObservableCollection<TheLoai> listTheLoai;
        public ObservableCollection<TheLoai> ListTheLoai { get => listTheLoai; set { listTheLoai = value; OnPropertyChanged(); } }

        public ICommand AddSubCategory_Edit { get; set; }
        public ICommand RemoveSubCategory_Edit { get; set; }
        public ICommand ClearAllSubCategory_Edit { get; set; }

        private string maPhim_edit;
        private string tenPhim_edit;
        private string maTheLoaiChinh_edit;
        private int thoiLuong_edit;
        private ObservableCollection<TheLoai> listTheLoaiPhu_edit;

        private string chuoiTenTheLoaiPhu_edit;
        private string tenTheLoaiChinh_edit;
        private string tenTheLoaiPhu_edit;

        public string MaPhim_edit { get => maPhim_edit; set { maPhim_edit = value; OnPropertyChanged(); } }
        public string TenPhim_edit { get => tenPhim_edit; set { tenPhim_edit = value; OnPropertyChanged(); } }
        public string MaTheLoaiChinh_edit { get => maTheLoaiChinh_edit; set { maTheLoaiChinh_edit = value; OnPropertyChanged(); } }
        public int ThoiLuong_edit { get => thoiLuong_edit; set { thoiLuong_edit = value; OnPropertyChanged(); } }
        public ObservableCollection<TheLoai> ListTheLoaiPhu_edit { get => listTheLoaiPhu_edit; set { listTheLoaiPhu_edit = value; OnPropertyChanged(); } }

        public string ChuoiTenTheLoaiPhu_edit { get => chuoiTenTheLoaiPhu_edit; set { chuoiTenTheLoaiPhu_edit = value; OnPropertyChanged(); } }
        public string TenTheLoaiChinh_edit { get => tenTheLoaiChinh_edit; set { tenTheLoaiChinh_edit = value; OnPropertyChanged(); } }
        public string TenTheLoaiPhu_edit { get => tenTheLoaiPhu_edit; set { tenTheLoaiPhu_edit = value; OnPropertyChanged(); } }

        private string tenPhim_curr_edit;
        private string maTheLoaiChinh_curr_edit;
        private int thoiLuong_curr_edit;
        private ObservableCollection<TheLoai> listTheLoaiPhu_curr_edit;

        private TheLoai selectedCategory_edit;
        public TheLoai SelectedCategory_edit
        {
            get => selectedCategory_edit;
            set
            {
                selectedCategory_edit = value;
                OnPropertyChanged();
                if (selectedCategory_edit != null)
                {
                    MaTheLoaiChinh_edit = SelectedCategory_edit.MaTheLoai;
                    TenTheLoaiChinh_edit = SelectedCategory_edit.TenTheLoai;
                }
            }
        }

        private TheLoai selectedSubCategory_edit;
        public TheLoai SelectedSubCategory_edit
        {
            get => selectedSubCategory_edit;
            set
            {
                selectedSubCategory_edit = value;
                OnPropertyChanged();
                if (SelectedSubCategory_edit != null)
                {
                    TenTheLoaiPhu_edit = SelectedSubCategory_edit.TenTheLoai;
                }
            }
        }

        private Phim selectedItem;
        public Phim SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
                if (selectedItem != null)
                {
                    MaPhim_edit = SelectedItem.MaPhim;
                    TenPhim_edit = SelectedItem.TenPhim;
                    MaTheLoaiChinh_edit = SelectedItem.MaTheLoaiChinh;
                    ThoiLuong_edit = SelectedItem.ThoiLuong;
                    SelectedCategory_edit = ListTheLoai.FirstOrDefault(theLoai => theLoai.MaTheLoai == SelectedItem.MaTheLoaiChinh);

                    tenPhim_curr_edit = SelectedItem.TenPhim;
                    maTheLoaiChinh_curr_edit = SelectedItem.MaTheLoaiChinh;
                    thoiLuong_curr_edit = SelectedItem.ThoiLuong;

                    listTheLoaiPhu_curr_edit.Clear();
                    ListTheLoaiPhu_edit.Clear();
                    foreach (TheLoai tl in TheLoaiDAO.Instance.GetListTheLoaiPhusByMaPhim(MaPhim_edit))
                    {
                        listTheLoaiPhu_curr_edit.Add(tl);
                        ListTheLoaiPhu_edit.Add(tl);
                    }
                    ChuoiTenTheLoaiPhu_edit = string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_edit));


                    MaPhim_delete = SelectedItem.MaPhim;
                    TenPhim_delete = SelectedItem.TenPhim;
                    MaTheLoaiChinh_delete = SelectedItem.MaTheLoaiChinh;
                    ThoiLuong_delete = SelectedItem.ThoiLuong;
                    TenTheLoaiChinh_delete = TheLoaiDAO.Instance.GetTheLoaiByMaTheLoaiChinh(MaTheLoaiChinh_delete).TenTheLoai;
                    ListTheLoaiPhu_delete = TheLoaiDAO.Instance.GetListTheLoaiPhusByMaPhim(MaPhim_delete);
                    ChuoiTenTheLoaiPhu_delete = string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_delete));
                }
            }
        }
        #endregion

        #region properties and fields for tab delete
        private string maPhim_delete;
        private string tenPhim_delete;
        private string maTheLoaiChinh_delete;
        private int thoiLuong_delete;
        private ObservableCollection<TheLoai> listTheLoaiPhu_delete;

        private string chuoiTenTheLoaiPhu_delete;
        private string tenTheLoaiChinh_delete;

        public string MaPhim_delete { get => maPhim_delete; set { maPhim_delete = value; OnPropertyChanged(); } }
        public string TenPhim_delete { get => tenPhim_delete; set { tenPhim_delete = value; OnPropertyChanged(); } }
        public string MaTheLoaiChinh_delete { get => maTheLoaiChinh_delete; set { maTheLoaiChinh_delete = value; OnPropertyChanged(); } }
        public int ThoiLuong_delete { get => thoiLuong_delete; set { thoiLuong_delete = value; OnPropertyChanged(); } }
        public ObservableCollection<TheLoai> ListTheLoaiPhu_delete { get => listTheLoaiPhu_delete; set { listTheLoaiPhu_delete = value; OnPropertyChanged(); } }

        public string ChuoiTenTheLoaiPhu_delete { get => chuoiTenTheLoaiPhu_delete; set { chuoiTenTheLoaiPhu_delete = value; OnPropertyChanged(); } }
        public string TenTheLoaiChinh_delete { get => tenTheLoaiChinh_delete; set { tenTheLoaiChinh_delete = value; OnPropertyChanged(); } }
        #endregion

        public FilmViewModel()
        {
            ListPhim = PhimDAO.Instance.GetListPhims();
            ListTheLoai = new ObservableCollection<TheLoai>(TheLoaiDAO.Instance.GetListTheLoais());

            ListTheLoaiPhu_add = new ObservableCollection<TheLoai>();
            ListTheLoaiPhu_edit = new ObservableCollection<TheLoai>();
            listTheLoaiPhu_curr_edit = new ObservableCollection<TheLoai>();
            ListTheLoaiPhu_delete = new ObservableCollection<TheLoai>();
            SelectedItem = ListPhim.First();

            #region button's logic for add tab
            AddSubCategory_Add = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(TenTheLoaiPhu_add)) return false;
                    if (string.Compare(TenTheLoaiPhu_add, TenTheLoaiChinh_add, 0) == 0) return false;
                    foreach (string ten in TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_add))
                        if (TenTheLoaiPhu_add == ten) return false;
                    return true;
                },
                para => {
                    ListTheLoaiPhu_add.Add(SelectedSubCategory_add);
                    ChuoiTenTheLoaiPhu_add = string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_add));
                }
            );
            RemoveSubCategory_Add = new RelayCommand<object>(
                para =>
                {   
                    foreach (TheLoai theloai in ListTheLoaiPhu_add)
                        if (SelectedSubCategory_add == theloai) return true;
                    return false;
                },
                para =>
                {
                    ListTheLoaiPhu_add.Remove(SelectedSubCategory_add);
                    ChuoiTenTheLoaiPhu_add = string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_add));
                }
            );
            ClearAllSubCategory_Add = new RelayCommand<object>(
                para =>
                {
                    if (ListTheLoaiPhu_add.Count == 0) return false;
                    return true;
                },
                para =>
                {
                    ListTheLoaiPhu_add.Clear();
                    ChuoiTenTheLoaiPhu_add = "";
                }
            );
            AddCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaPhim_add) && string.IsNullOrEmpty(TenPhim_add)) return false;
                    var listMaPhim = from phim in ListPhim
                                     where phim.MaPhim.ToUpper() == MaPhim_add.ToUpper()
                                     select phim;
                    if (listMaPhim == null || listMaPhim.Count() != 0) return false;

                    return true;
                },
                para =>
                {
                    Phim film = new Phim(MaPhim_add, TenPhim_add, MaTheLoaiChinh_add, ThoiLuong_add);
                    if (!PhimDAO.Instance.InsertPhim(film))
                        MessageBox.Show($"Thêm phim mới không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    foreach (TheLoai theloai in ListTheLoaiPhu_add)
                    {
                        if (!TheLoaiDAO.Instance.InsertTheLoaiPhuIntoPhim(theloai.MaTheLoai, MaPhim_add))
                            MessageBox.Show($"Xảy ra lỗi khi thêm thể loại phụ cho phim", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    ListPhim = PhimDAO.Instance.GetListPhims();
                }
            );
            #endregion

            #region button's logic for edit tab
            AddSubCategory_Edit = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(TenTheLoaiPhu_edit)) return false;
                    if (string.Compare(TenTheLoaiPhu_edit, TenTheLoaiChinh_edit, 0) == 0) return false;
                    foreach (string ten in TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_edit))
                        if (TenTheLoaiPhu_edit == ten) return false;
                    return true;
                },
                para => {
                    ListTheLoaiPhu_edit.Add(SelectedSubCategory_edit);
                    ChuoiTenTheLoaiPhu_edit = string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_edit));
                }
            );
            RemoveSubCategory_Edit = new RelayCommand<object>(
                para =>
                {
                    foreach (string ten in TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_edit))
                        if (TenTheLoaiPhu_edit == ten) return true;

                    return false;
                },
                para =>
                {
                    foreach (TheLoai tl in ListTheLoaiPhu_edit.ToList())
                        if (tl.MaTheLoai == SelectedSubCategory_edit.MaTheLoai)
                            ListTheLoaiPhu_edit.Remove(tl);

                    ChuoiTenTheLoaiPhu_edit = string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_edit));
                }
            );
            ClearAllSubCategory_Edit = new RelayCommand<object>(
                para =>
                {
                    if (ListTheLoaiPhu_edit == null || ListTheLoaiPhu_edit.Count == 0) return false;
                    return true;
                },
                para =>
                {
                    ListTheLoaiPhu_edit.Clear();
                    ChuoiTenTheLoaiPhu_edit = "";
                }
            );
            EditCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaPhim_edit)) return false;
                    if (string.Compare(TenPhim_edit, tenPhim_curr_edit, 0) == 0 &&
                        string.Compare(MaTheLoaiChinh_edit, maTheLoaiChinh_curr_edit, 0) == 0 &&
                        ThoiLuong_edit == thoiLuong_curr_edit &&
                        (listTheLoaiPhu_curr_edit.Except(ListTheLoaiPhu_edit).Count() == 0) && (ListTheLoaiPhu_edit.Except(listTheLoaiPhu_curr_edit).Count() == 0))
                        return false;
                    foreach (TheLoai tl in ListTheLoaiPhu_edit)
                        if (MaTheLoaiChinh_edit == tl.MaTheLoai) return false;
                    return true;
                },
                para =>
                {
                    Phim film = new Phim(MaPhim_edit, TenPhim_edit, MaTheLoaiChinh_edit, ThoiLuong_edit);
                    if (PhimDAO.Instance.UpdateInfoPhim(film))
                    {
                        IEnumerable<TheLoai> listAddTheLoaiPhu = ListTheLoaiPhu_edit.Where(theloai => !listTheLoaiPhu_curr_edit.Contains(theloai));
                        IEnumerable<TheLoai> listRemoveTheLoaiPhu = listTheLoaiPhu_curr_edit.Where(theloai => !ListTheLoaiPhu_edit.Contains(theloai));
                        if (listAddTheLoaiPhu.Count() != 0)
                        {
                            foreach (TheLoai tl in listAddTheLoaiPhu)
                                if (!TheLoaiDAO.Instance.InsertTheLoaiPhuIntoPhim(tl.MaTheLoai, MaPhim_edit))
                                    MessageBox.Show($"Cập nhật thể loại phụ cho phim không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        if (listRemoveTheLoaiPhu.Count() != 0)
                        {
                            foreach (TheLoai tl in listRemoveTheLoaiPhu)
                                if (!TheLoaiDAO.Instance.DeleteTheLoaiPhuFromPhim(tl.MaTheLoai, MaPhim_edit))
                                    MessageBox.Show($"Cập nhật thể loại phụ cho phim không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                        tenPhim_curr_edit = TenPhim_edit;
                        maTheLoaiChinh_curr_edit = MaTheLoaiChinh_edit;
                        thoiLuong_curr_edit = ThoiLuong_edit;
                        listTheLoaiPhu_curr_edit.Clear();
                        foreach (TheLoai tl in ListTheLoaiPhu_edit.ToList())
                            listTheLoaiPhu_curr_edit.Add(tl);

                        ListPhim = PhimDAO.Instance.GetListPhims();
                    }
                    else MessageBox.Show($"Cập nhật thông tin không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            );
            #endregion

            DeleteCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaPhim_delete)) return false;
                    return true;
                },
                para =>
                {
                    if (KeHoachDAO.Instance.GetListKeHoachsByMaPhim(MaPhim_delete).Count() != 0)
                    {
                        MessageBox.Show($"Chỉ có thể xóa các phim đang không có kế hoạch chiếu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (LichChieuDAO.Instance.GetListLichChieusByMaPhim(MaPhim_delete).Count() != 0)
                    {
                        MessageBox.Show($"Chỉ có thể xóa các phim đang không có lịch chiếu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (MessageBox.Show($"Bạn có chắc muốn xóa phim {SelectedItem.TenPhim}", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        var film = PhimDAO.Instance.GetPhimByMaPhim(MaPhim_delete);
                        if (film != null)
                        {
                            foreach (TheLoai tl in ListTheLoaiPhu_delete)
                            {
                                if (!TheLoaiDAO.Instance.DeleteTheLoaiPhuFromPhim(tl.MaTheLoai, MaPhim_delete))
                                    MessageBox.Show($"Đã xảy ra lỗi khi xóa thể loại phụ khỏi phim", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            if (PhimDAO.Instance.DeletePhim(MaPhim_delete))
                            {
                                ListPhim = PhimDAO.Instance.GetListPhims();
                                SelectedItem = ListPhim.First();
                            }
                            else MessageBox.Show($"Xóa phim không thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            );


            CheckCommand = new RelayCommand<object>(para => true, para =>
            {
                MessageBox.Show($"ListTheLoaiPhu_edit: {string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(ListTheLoaiPhu_edit))}\n" +
                        $"listTheLoaiPhu_curr_edit: {string.Join(", ", TheLoaiDAO.Instance.GetListTenTheLoaisByListTheLoais(listTheLoaiPhu_curr_edit))}\n" +
                        $"{listTheLoaiPhu_curr_edit.Except(ListTheLoaiPhu_edit).Count()}\n" +
                        $"{ListTheLoaiPhu_edit.Except(listTheLoaiPhu_curr_edit).Count()}\n");
            });
        }
    }
}
