using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Service;
using SSS_FullyStackedTeam.UI;
using SSSProject.Model;
using SSSProject.Repository;
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
        private IComentRepository comentRepository = new ComentsRepository();
        private IAppointmentService appointmentService = new AppointmentService();

        private Client Client;

        private Coach Coach;

        private List<Appointment> appointments = new List<Appointment>();

        public PrimaryPage(MainWindow window)
        {
            InitializeComponent();
            Window = window;
            RefreshAll();

            if (Coach.SertificateName == null)
            {
                //lblHight.Visibility = Visibility.Visible;
                //lblHight1.Visibility = Visibility.Visible;
                //lblWeight.Visibility = Visibility.Visible;
                //lblWeight1.Visibility = Visibility.Visible;
                //lblGoals.Visibility = Visibility.Visible;
                //LbxGoals.Visibility = Visibility.Visible;
                //lblIllnesses.Visibility = Visibility.Visible;
                //LbxIllnesses.Visibility = Visibility.Visible;
                //lblProps.Visibility = Visibility.Visible;
                //LbxProps.Visibility = Visibility.Visible;
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
                BtnAddAppointment.Visibility = Visibility.Collapsed;
                //lblHeightA.Visibility = Visibility.Visible;
                //lblHeightAA.Visibility = Visibility.Visible;
                //lblWeightA.Visibility = Visibility.Visible;
                //lblWeightAA.Visibility = Visibility.Visible;
                lblTitleA.Visibility = Visibility.Collapsed;
                lblTitleAA.Visibility = Visibility.Collapsed;
                lblDiplomaA.Visibility = Visibility.Collapsed;
                lblDiplomaAA.Visibility = Visibility.Collapsed;
                lblSertificatA.Visibility = Visibility.Collapsed;
                lblSertificatAA.Visibility = Visibility.Collapsed;

                DataContext = Client;
            }
            else
            {
                //lblDiploma.Visibility = Visibility.Visible;
                //lblDiploma1.Visibility = Visibility.Visible;
                //lblSertificat.Visibility = Visibility.Visible;
                //lblSertificat1.Visibility = Visibility.Visible;
                //lblTitle.Visibility = Visibility.Visible;
                //lblTitle1.Visibility = Visibility.Visible;
                //lblProfit.Visibility = Visibility.Visible;
                //lblProfit1.Visibility = Visibility.Visible;
                //lblSuccessfulApointments.Visibility = Visibility.Visible;
                //lblSuccessfulApointments1.Visibility = Visibility.Visible;
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
                BtnBookAppointment.Visibility = Visibility.Collapsed;
                BtnCancelAppointment.Visibility = Visibility.Collapsed;
                lblHeightA.Visibility = Visibility.Collapsed;
                lblHeightAA.Visibility = Visibility.Collapsed;
                lblWeightA.Visibility = Visibility.Collapsed;
                lblWeightAA.Visibility = Visibility.Collapsed;
                lblGoalsA.Visibility = Visibility.Collapsed;
                lblGoalsAA.Visibility = Visibility.Collapsed;
                lblIllnesesA.Visibility = Visibility.Collapsed;
                lblIllnesesAA.Visibility = Visibility.Collapsed;
                lblPropsA.Visibility = Visibility.Collapsed;
                lblPropsAA.Visibility = Visibility.Collapsed;
                DataContext = Coach;
            }

            if(AppointentsTabItem != null)
            {
                LbxComments.ItemsSource = comentRepository.GetAll().Where(p => p.Coach.Id == Coach.Id).ToList();
            }
        }

        public void RefreshAll()
        {
            Data.Instance.LoggedInClient = clientService.GetById(Data.Instance.LoggedInClient.Id);
            Data.Instance.LoggedInCoach = coachService.GetById(Data.Instance.LoggedInCoach.Id);

            Client = Data.Instance.LoggedInClient;
            Coach = Data.Instance.LoggedInCoach;

            if (Coach.Id != 0)
            {
                appointments = appointmentService.GetAll().Where(a => a.Status == false && Coach.Id == a.CoachId).ToList();
                DgAppointments.ItemsSource = appointments;

                DgBookedAppointments.ItemsSource = appointmentService.GetAll().Where(a => a.Status == true && a.Coach.Id == Coach.Id).ToList();
            }
            else
            {
                DgAppointments.ItemsSource = appointmentService.GetAll().Where(a => a.Status == false).ToList();

                DgBookedAppointments.ItemsSource = appointmentService.GetAll().Where(a => a.ClientId == Client.Id).ToList();
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
            if (Client.Id != 0)
            {
                Window.Content = new ExtraClientInfo(Window, this);
            }
            else
            {
                Window.Content = new ExtraCoachInfo(Window, this);
            }
        }

        #endregion

        #region Appointments

        private void DgAppointments_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id" || e.PropertyName == "ClientId" || 
                e.PropertyName == "CoachId")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void DgBookedAppointments_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.Content = new ComentPage(Window, 1);
        }

        private void TabItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LbxComments.ItemsSource = comentRepository.GetAll().Where(p => p.Coach.Id == Coach.Id).ToList();
        }

        private void BtnAddAppointment_Click(object sender, RoutedEventArgs e)
        {
            var AddAppointmentWindow = new AddAppointmentWindow();

            var successeful = AddAppointmentWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshAll();
            }
        }

        private void BtnCancelAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = DgBookedAppointments.SelectedItem as Appointment;
            if (appointment != null)
            {
                appointment.Client = null;
                appointment.Status = false;
                appointmentService.Update(appointment.Id, appointment);

                RefreshAll();
            }
        }

        private void BtnBookAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = DgAppointments.SelectedItem as Appointment;
            if (appointment != null)
            {
                appointment.ClientId = Client.Id;
                appointment.Status = true;
                appointmentService.Update(appointment.Id, appointment);

                RefreshAll();
            }
        }

        #endregion
    }
}
