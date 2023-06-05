//using Project_PTUD_Desktop.Model.DAO;
//using Project_PTUD_Desktop.Model.DTO;
using Project_PTUD_Desktop.ModelEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Project_PTUD_Desktop.ViewModel
{
    public class TheaterViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<Rap> listRap;
        public ObservableCollection<Rap> ListRap { get => listRap; set { listRap = value; OnPropertyChanged(); } }

        private ObservableCollection<CumRap> listCumRap;
        public ObservableCollection<CumRap> ListCumRap { get => listCumRap; set { listCumRap = value; OnPropertyChanged(); } }

        #region properties and fields for add
        private string _maRap_add;
        private int _tongGhe_add;
        private string _maCum_add;

        public string MaRap_add { get => _maRap_add; set { _maRap_add = value; OnPropertyChanged(); } }
        public int TongGhe_add { get => _tongGhe_add; set { _tongGhe_add = value; OnPropertyChanged(); } }
        public string MaCum_add { get => _maCum_add; set { _maCum_add = value; OnPropertyChanged(); } }

        private CumRap _selectedCumRap_add;
        public CumRap SelectedCumRap_add
        {
            get => _selectedCumRap_add;
            set
            {
                _selectedCumRap_add = value;
                OnPropertyChanged();
                if (SelectedCumRap_add != null)
                    MaCum_add = SelectedCumRap_add.MaCum;
            }
        }
        #endregion

        #region properties and fields for edit
        private string _maRap_edit;
        private int _tongGhe_edit;
        private string _maCum_edit;

        public string MaRap_edit { get => _maRap_edit; set { _maRap_edit = value; OnPropertyChanged(); } }
        public int TongGhe_edit { get => _tongGhe_edit; set { _tongGhe_edit = value; OnPropertyChanged(); } }
        public string MaCum_edit { get => _maCum_edit; set { _maCum_edit = value; OnPropertyChanged(); } }

        private CumRap _selectedCumRap_edit;
        public CumRap SelectedCumRap_edit
        {
            get => _selectedCumRap_edit;
            set
            {
                _selectedCumRap_edit = value;
                OnPropertyChanged();
                if (SelectedCumRap_edit != null)
                    MaCum_edit = SelectedCumRap_edit.MaCum;
            }
        }

        private int _tongGhe_curr_edit;
        private string _maCum_curr_edit;

        private Rap _selectedItem;
        public Rap SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaRap_edit = SelectedItem.MaRap;
                    TongGhe_edit = (int)SelectedItem.TongGhe;
                    MaCum_edit = SelectedItem.MaCum;
                    SelectedCumRap_edit = ListCumRap.FirstOrDefault(cumrap => cumrap.MaCum == SelectedItem.MaCum);

                    _tongGhe_curr_edit = (int)SelectedItem.TongGhe;
                    _maCum_curr_edit = SelectedItem.MaCum;

                    MaRap_delete = SelectedItem.MaRap;
                    TongGhe_delete = (int)SelectedItem.TongGhe;
                    MaCum_delete = SelectedItem.MaCum;
                }
            }
        }
        #endregion

        #region properties and fields for delete
        private string _maRap_delete;
        private int _tongGhe_delete;
        private string _maCum_delete;

        public string MaRap_delete { get => _maRap_delete; set { _maRap_delete = value; OnPropertyChanged(); } }
        public int TongGhe_delete { get => _tongGhe_delete; set { _tongGhe_delete = value; OnPropertyChanged(); } }
        public string MaCum_delete { get => _maCum_delete; set { _maCum_delete = value; OnPropertyChanged(); } }
        #endregion

        public TheaterViewModel()
        {
            LoadListCumRap();
            LoadListRap();
            SelectedItem = ListRap.First();

            AddCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaRap_add) || string.IsNullOrEmpty(MaCum_add)) return false;
                    IEnumerable<Rap> checkRap = from rap in ListRap
                                                where rap.MaRap == MaRap_add
                                                select rap;
                    if (checkRap == null || checkRap.Count() != 0) return false;
                    return true;

                },
                para =>
                {
                    //Rap theater = new Rap(MaRap_add, TongGhe_add, MaCum_add);
                    //if (RapDAO.Instance.InsertRap(theater))
                    //    LoadListRap();

                    Rap theater = new Rap() { MaRap = MaRap_add, TongGhe = TongGhe_add, MaCum = MaCum_add };
                    DataProvider.Instance.Database.Raps.Add(theater);
                    DataProvider.Instance.Database.SaveChanges();
                    ListRap.Add(theater);
                }
            );

            EditCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaRap_edit) || string.IsNullOrEmpty(MaCum_edit)) return false;
                    if (string.Compare(_maCum_curr_edit, MaCum_edit, true) == 0 &&
                        _tongGhe_curr_edit == TongGhe_edit) return false;

                    return true;
                },
                para =>
                {
                    //if (RapDAO.Instance.UpdateInfoRap(TongGhe_edit, MaCum_edit, MaRap_edit))
                    //{
                    //    _tongGhe_curr_edit = TongGhe_edit;
                    //    _maCum_curr_edit = MaCum_edit;

                    //    LoadListRap();
                    //}

                    Rap theater = DataProvider.Instance.Database.Raps.Where(rap => rap.MaRap == MaRap_edit).FirstOrDefault();
                    theater.TongGhe = TongGhe_edit;
                    theater.MaCum = MaCum_edit;
                    DataProvider.Instance.Database.SaveChanges();

                    _tongGhe_curr_edit = TongGhe_edit;
                    _maCum_curr_edit = MaCum_edit;

                    //LoadListCumRap();
                }
            );

            DeleteCommand = new RelayCommand<object>(
                para =>
                {
                    if (string.IsNullOrEmpty(MaRap_delete)) return false;
                    return true;
                },
                para =>
                {
                    if (SelectedItem.LichChieux.Count != 0)
                    {
                        MessageBox.Show($"Chỉ có thể xóa các rạp không có lịch chiếu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (MessageBox.Show($"Bạn có chắc muốn xóa rạp có mã {SelectedItem.MaRap}", "Xác nhận xóa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Rap theater = DataProvider.Instance.Database.Raps.Where(rap => rap.MaRap == MaRap_delete).FirstOrDefault();
                        if (theater != null)
                        {
                            DataProvider.Instance.Database.Raps.Remove(theater);
                            DataProvider.Instance.Database.SaveChanges();
                            ListRap.Remove(theater);
                            SelectedItem = ListRap.First();
                        }
                    }
                }
            );
        }

        public void LoadListCumRap()
        {
            //ListCumRap = new ObservableCollection<CumRap>(CumRapDAO.Instance.GetListCumRaps());
            ListCumRap = new ObservableCollection<CumRap>(DataProvider.Instance.Database.CumRaps);
        }
        public void LoadListRap()
        {
            //ListRap = new ObservableCollection<Rap>(RapDAO.Instance.GetListRaps());
            ListRap = new ObservableCollection<Rap>(DataProvider.Instance.Database.Raps);

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListRap);

            PropertyGroupDescription groupDescription = new PropertyGroupDescription("MaCum");
            view.GroupDescriptions.Add(groupDescription);

            view.SortDescriptions.Add(new SortDescription("MaCum", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("MaRap", ListSortDirection.Ascending));

            SelectedItem = ListRap.First();
        }
    }
}
