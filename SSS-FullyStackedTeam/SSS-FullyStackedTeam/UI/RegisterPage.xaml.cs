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

namespace SSS_FullyStackedTeam.UI
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public MainWindow Window { get; set; }
        public Page PreviousPage { get; set; }

        public RegisterPage(MainWindow window, Page previousPage)
        {
            InitializeComponent();
            Window = window;
            PreviousPage = previousPage;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window.Content = PreviousPage;
        }
    }
}
