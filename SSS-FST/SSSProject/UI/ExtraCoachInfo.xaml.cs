using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Service;
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
    /// Interaction logic for ExtraCoachInfo.xaml
    /// </summary>
    public partial class ExtraCoachInfo : Page
    {
        public MainWindow Window { get; set; }

        private ICoachService coachService = new CoachService();

        Coach coach;
        public ExtraCoachInfo(MainWindow window)
        {
            InitializeComponent();
            Window = window;

            coach = coachService.GetById(Data.Instance.LoggedInCoach.Id);
            DataContext = coach;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            coachService.Update(coach.Id, coach);
            MessageBox.Show("Uspesno izmenjeni podaci kod Trenera");
            Window.Content = new PrimaryPage(Window);

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (coach.DiplomaName != "")
            {
                Window.Content = new PrimaryPage(Window);
            }
            else
            {
                Window.Content = new MainPage(Window);
            }
        }
    }
}
