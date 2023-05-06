using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Service;
using SSSProject.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace SSSProject.UI
{
    /// <summary>
    /// Interaction logic for AddAppointmentWindow.xaml
    /// </summary>
    public partial class AddAppointmentWindow : Window
    {

        private Appointment Appointment;
        private Coach Coach = Data.Instance.LoggedInCoach;
        private IAppointmentService AppointmentService = new AppointmentService();
        public AddAppointmentWindow()
        {
            InitializeComponent();
            DpDate.BlackoutDates.AddDatesInPast();

            Appointment = new Appointment
            {
                Status = false,
                Coach = Coach
            };

            DataContext = Appointment;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var cultureInfo = new CultureInfo("de-DE");
            Appointment.DateAndTimeOfStart = DateTime.ParseExact(TxtDateAndTime.Text, "dd.MM.yyyy HH:mm:ss", cultureInfo);

            AppointmentService.Add(Appointment);

            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void DpDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var cultureInfo = new CultureInfo("de-DE");
            TxtDateAndTime.Text = DpDate.SelectedDate.Value.ToString(cultureInfo);
        }
    }
}
