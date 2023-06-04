using Project_PTUD_Desktop.Model.DAO;
using Project_PTUD_Desktop.Model.DTO;
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
        private static TheaterViewModel instance;
        public static TheaterViewModel Instance
        {
            get
            {
                if (instance == null) instance = new TheaterViewModel();
                return instance;
            }
            private set => instance = value;
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<Rap> listRap;
        public ObservableCollection<Rap> ListRap { get => listRap; set { listRap = value; OnPropertyChanged(); } }

        private ObservableCollection<CumRap> listCumRap;
        public ObservableCollection<CumRap> ListCumRap { get => listCumRap; set { listCumRap = value; OnPropertyChanged(); } }

        #region properties and fields for add
        private string maRap_add;
        private int tongGhe_add;
        private string maCum_add;

        public string MaRap_add { get => maRap_add; set { maRap_add = value; OnPropertyChanged(); } }
        public int TongGhe_add { get => tongGhe_add; set { tongGhe_add = value; OnPropertyChanged(); } }
        public string MaCum_add { get => maCum_add; set { maCum_add = value; OnPropertyChanged(); } }

        private CumRap selectedCumRap_add;
        public CumRap SelectedCumRap_add
        {
            get => selectedCumRap_add;
            set
            {
                selectedCumRap_add = value;
                OnPropertyChanged();
                if (SelectedCumRap_add != null)
                    MaCum_add = SelectedCumRap_add.MaCum;
            }
        }
        #endregion

        public TheaterViewModel()
        {
            LoadListCumRap();
            LoadListRap();

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
                    Rap theater = new Rap(MaRap_add, TongGhe_add, MaCum_add);
                    if (RapDAO.Instance.InsertRap(theater))
                        LoadListRap();
                }
            );
        }

        public void LoadListCumRap()
        {
            ListCumRap = new ObservableCollection<CumRap>(CumRapDAO.Instance.GetListCumRaps());
        }
        public void LoadListRap()
        {
            ListRap = new ObservableCollection<Rap>(RapDAO.Instance.GetListRaps());

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListRap);

            PropertyGroupDescription groupDescription = new PropertyGroupDescription("MaCum");
            view.GroupDescriptions.Add(groupDescription);

            view.SortDescriptions.Add(new SortDescription("MaCum", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("MaRap", ListSortDirection.Ascending));
        }
    }
}
