using MultiThreading_Assignment.Model;
using MultiThreading_Assignment.Utils;
using MultiThreading_Assignment.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MultiThreading_Assignment.View
{
    /// <summary>
    /// Interaction logic for OutputWindow_View.xaml
    /// </summary>
    public partial class OutputWindow_View : Window
    {
        public ObservableCollection<Customer> listViewList = new ObservableCollection<Customer>();
        MainWindow MainWindow;
        
        public OutputWindow_View()
        {
            InitializeComponent();
            TotalThreads.Text = "0";
            TotalTime.Text = "00:00:00";
            listView.ItemsSource = listViewList;
        }

        private void CloseOutputWindow(object sender, RoutedEventArgs e)
        {
            MainWindow = Mediator.getVar("MainWindow") as MainWindow;
            MainWindow.Opacity = 1;
            Close();
        }
    }
}
