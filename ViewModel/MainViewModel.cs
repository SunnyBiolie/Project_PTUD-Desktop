using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_PTUD_Desktop.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand OpenTheaterClusterWindowCommand { get; set; }
        public ICommand OpenFilmWindowCommand { get; set; }
        public ICommand OpenScreeningsWindowCommand { get; set; }

        public MainViewModel()
        {
            OpenTheaterClusterWindowCommand = new RelayCommand<object>((para) => { return true; }, (para) => {
                TheaterClusterWindow tcw = new TheaterClusterWindow();
                tcw.ShowDialog();
            });
            OpenFilmWindowCommand = new RelayCommand<object>((para) => { return true; }, (para) => {
                FilmWindow fw = new FilmWindow();
                fw.ShowDialog();
            });
            OpenScreeningsWindowCommand = new RelayCommand<object>(para => { return true; }, para =>
            {
                ScreeningsWindow sw = new ScreeningsWindow();
                sw.ShowDialog();
            });
        }
    }
}
