using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace Project_PTUD_Desktop.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        #region
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseLeftButtonDownWindowCommand { get; set; }

        public ControlBarViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((para) => { return para == null ? false : true; }, (para) => {
                FrameworkElement window = GetParent_Window(para);
                var Window = window as Window;
                if (Window != null)
                {
                    Window.Close();
                }
            });

            MaximizeWindowCommand = new RelayCommand<UserControl>((para) => { return para == null ? false : true; }, (para) => {
                FrameworkElement window = GetParent_Window(para);
                var Window = window as Window;
                if (Window != null)
                {
                    if (Window.WindowState != WindowState.Maximized) Window.WindowState = WindowState.Maximized;
                    else Window.WindowState = WindowState.Normal;
                }
            });

            MinimizeWindowCommand = new RelayCommand<UserControl>((para) => { return para == null ? false : true; }, (para) => {
                FrameworkElement window = GetParent_Window(para);
                var Window = window as Window;
                if (Window != null)
                {
                    if (Window.WindowState != WindowState.Minimized) Window.WindowState = WindowState.Minimized;
                    //else Window.WindowState = WindowState.Maximized;
                }
            });

            MouseLeftButtonDownWindowCommand = new RelayCommand<UserControl>((para) => { return para == null ? false : true; }, (para) => {
                FrameworkElement window = GetParent_Window(para);
                var Window = window as Window;
                if (Window != null)
                {
                    Window.DragMove();
                }
            });
        }

        FrameworkElement GetParent_Window(UserControl para)
        {
            FrameworkElement parent = para;

            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }
        #endregion
    }
}
