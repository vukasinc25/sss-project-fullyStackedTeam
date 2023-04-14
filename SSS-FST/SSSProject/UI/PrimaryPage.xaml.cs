using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.UI;
using SSSProject.Model;
using SSSProject.Service;
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
    /// Interaction logic for PrimaryPage.xaml
    /// </summary>
    public partial class PrimaryPage : Page
    {
        public MainWindow Window { get; set; }

        private Client Client = Data.Instance.LoggedInClient;

        private Coach Coach = Data.Instance.LoggedInCoach;

        public PrimaryPage(MainWindow window)
        {
            InitializeComponent();
            Window = window;

            if (Coach.SertificateName == null)
            {
                DataContext = Client;
            }
            else
            {
                DataContext = Coach;
            }
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Window.Content = new MainPage(Window);
        }
    }
}
