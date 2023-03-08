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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainWindow Window { get; set; }

        public MainPage(MainWindow window)
        {
            InitializeComponent();
            Window = window;
        }


        #region Login

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Window.Content = new LoginPage(Window, this);
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Window.Content = new RegisterPage(Window, this);
        }

        #endregion

    }
}
