using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Service;
using SSSProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        private MainWindow Window { get; set; }
        private Page PreviousPage { get; set; }
        int Coachid = 0;
        int? Clientid = 0;
        private Coach coach = Data.Instance.LoggedInCoach;
        private Client client = Data.Instance.LoggedInClient;
        private ICoachService coachService = new CoachService();
        private IClientService clientService = new ClientService();
        int lowerPressure;
        int upperPressure;
        int heartRate;
        public VideoCallPage(MainWindow mainWindow, Page previousPage, int CoachId, int? ClientId)
        {
            InitializeComponent();
            Window = mainWindow;
            PreviousPage = previousPage;
            Coachid = CoachId;
            Clientid = ClientId;
            if(coach.Id != 0)
            { 
                txtCoachInfo.Text = coach.User.FirstName;
                txtClientInfo.Text = clientService.GetById(Clientid).ToString();
            }
            else
            {
                txtCoachInfo.Text = coachService.GetById(Coachid).ToString();
                txtClientInfo.Text = client.User.LastName;
            }

            //TIMER
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Random random = new Random();
            lowerPressure = random.Next(60, 80);
            upperPressure = random.Next(100, 150);
            heartRate = random.Next(60, 100);
            UpdateText();
         
        }

        private void UpdateText()
        {
            // Use the Dispatcher to update the UI element on the UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                lowerBp.Content = lowerPressure;
                higherBp.Content = upperPressure;
                bpm.Content = heartRate;
            });
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if(coach.Id != 0)
            {
                Window.Content = PreviousPage;
            }
            else
            {
                Window.Content = new ComentPage(Window, Coachid);
            }
        }

        private void btnMute_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mute");
        }

        private void Share_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Share");
        }

        private void btnTurnOnCamera_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Turn On Camera");
        }
    }
}
