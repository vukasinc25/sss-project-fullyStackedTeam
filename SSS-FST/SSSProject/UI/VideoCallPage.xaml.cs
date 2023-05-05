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

namespace SSSProject.UI
{
    /// <summary>
    /// Interaction logic for VideoCallPage.xaml
    /// </summary>
    public partial class VideoCallPage : Page
    {
        private Window Window { get; set; }
        public VideoCallPage(MainWindow mainWindow)
        {
            InitializeComponent();
            Window = mainWindow;
        }
    }
}
