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
    /// Interaction logic for PrimaryPage.xaml
    /// </summary>
    public partial class PrimaryPage : Page
    {
        public MainWindow Window { get; set; }

        private IClientService clientService = new ClientService();
        private ICoachService coachService = new CoachService();

        private Client Client;

        private Coach Coach;

        public PrimaryPage(MainWindow window)
        {
            InitializeComponent();
            Window = window;
            Data.Instance.LoggedInClient = clientService.GetById(Data.Instance.LoggedInClient.Id);
            //Data.Instance.LoggedInCoach = coachService.GetById(Data.Instance.LoggedInCoach.Id);

            Client = Data.Instance.LoggedInClient;
            Coach = Data.Instance.LoggedInCoach;

            if (Coach.SertificateName == null)
            {
                lblHight.Visibility = Visibility.Visible;
                lblHight1.Visibility = Visibility.Visible;
                lblWeight.Visibility = Visibility.Visible;
                lblWeight1.Visibility = Visibility.Visible;
                lblGoals.Visibility = Visibility.Visible;
                LbxGoals.Visibility = Visibility.Visible;
                lblIllnesses.Visibility = Visibility.Visible;
                LbxIllnesses.Visibility = Visibility.Visible;
                lblProps.Visibility = Visibility.Visible;
                LbxProps.Visibility = Visibility.Visible;
                lblDiploma.Visibility = Visibility.Collapsed;
                lblDiploma1.Visibility = Visibility.Collapsed;
                lblSertificat.Visibility = Visibility.Collapsed;
                lblSertificat1.Visibility = Visibility.Collapsed;
                lblTitle.Visibility = Visibility.Collapsed;
                lblTitle1.Visibility = Visibility.Collapsed;
                lblProfit.Visibility = Visibility.Collapsed;
                lblProfit1.Visibility = Visibility.Collapsed;
                lblSuccessfulApointments.Visibility = Visibility.Collapsed;
                lblSuccessfulApointments1.Visibility = Visibility.Collapsed;
                DataContext = Client;
            }
            else
            {
                lblDiploma.Visibility = Visibility.Visible;
                lblDiploma1.Visibility = Visibility.Visible;
                lblSertificat.Visibility = Visibility.Visible;
                lblSertificat1.Visibility = Visibility.Visible;
                lblTitle.Visibility = Visibility.Visible;
                lblTitle1.Visibility = Visibility.Visible;
                lblProfit.Visibility = Visibility.Visible;
                lblProfit1.Visibility = Visibility.Visible;
                lblSuccessfulApointments.Visibility = Visibility.Visible;
                lblSuccessfulApointments1.Visibility = Visibility.Visible;
                lblHight.Visibility = Visibility.Collapsed;
                lblHight1.Visibility = Visibility.Collapsed;
                lblWeight.Visibility = Visibility.Collapsed;
                lblWeight1.Visibility = Visibility.Collapsed;
                lblGoals.Visibility = Visibility.Collapsed;
                LbxGoals.Visibility = Visibility.Collapsed;
                lblIllnesses.Visibility = Visibility.Collapsed;
                LbxIllnesses.Visibility = Visibility.Collapsed;
                lblProps.Visibility = Visibility.Collapsed;
                LbxProps.Visibility = Visibility.Collapsed;
                DataContext = Coach;
            }
        }

        #region Profile

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Window.Content = new MainPage(Window);
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (Coach.SertificateName == null)
            {
                Window.Content = new RegisterPage(Window, this, Client.User);
            }
            else
            {
                Window.Content = new RegisterPage(Window, this, Coach.User);
            }
        }

        private void BtnEditExtraInfo_Click(object sender, RoutedEventArgs e)
        {
            if(Client.Id != 0)
            {
                Window.Content = new ExtraClientInfo(Window, this);
            }
            else
            {
                Window.Content = new ExtraCoachInfo(Window, this);
            }
        }

        #endregion

        private void DgAppointments_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}
