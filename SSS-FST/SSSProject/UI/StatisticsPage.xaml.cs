using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Repository;
using SSS_FullyStackedTeam.Service;
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
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        private MainWindow Window { get; set; }
        private IAppointmentRepository appointmentRepository = new AppointmentRepository();
        private ICoachService coachService = new CoachService();
        double broj = 0;
        public StatisticsPage(MainWindow mainWindow)
        {
            InitializeComponent();
            Window = mainWindow;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbSelect.SelectedItem == rang)
            {
                List<Coach> l1 = coachService.GetAll().Where(p => p.Rank >= 4).ToList();
                rightListBox.ItemsSource = l1;
            }
            else
            {
                List<Coach> l2 = coachService.GetAll().Where(p => p.Profit > 10000).ToList();
                rightListBox.ItemsSource = l2;
            }
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (firstDatePicker.SelectedDate != null && secondDatePicker.SelectedDate != null)
            {
                List<Appointment> listOfAppointments = appointmentRepository.GetAll().Where(p => p.DateAndTimeOfStart >= firstDatePicker.SelectedDate.Value && p.DateAndTimeOfStart <= secondDatePicker.SelectedDate.Value).ToList();
                foreach(Appointment appointment in listOfAppointments)
                {
                    broj += appointment.Price;
                }
                leftTextBox.Text = broj.ToString();
                broj = 0;
            }
            else
            {
                MessageBox.Show("Oba datuma moraju biti odabrana");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.Content = new PrimaryPage(Window);
        }
    }
}
