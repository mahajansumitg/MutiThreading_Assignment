using MultiThreading_Assignment.Utils;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiThreading_Assignment.View
{
    /// <summary>
    /// Interaction logic for UIView.xaml
    /// </summary>
    public partial class UIView : Page
    {
        public UIView()
        {
            InitializeComponent();
            Mediator.registerVar("UIView",this);
        }
    }
}
