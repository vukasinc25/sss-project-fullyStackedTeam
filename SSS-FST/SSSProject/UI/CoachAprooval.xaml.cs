using SSS_FullyStackedTeam.Model;
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
using System.Windows.Shapes;

namespace SSSProject.UI
{
    public partial class CoachAprooval : Window
    {
        private CoachService coachService = new CoachService();
        public CoachAprooval()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            List<Coach> coaches = coachService.GetAll().Where(p => p.IsSent == false).ToList();
            DgUnacceptedCoaches.ItemsSource = coaches;
        }

        private void BtnAcceptCoach_Click(object sender, RoutedEventArgs e)
        {
            var selectedCoach = DgUnacceptedCoaches.SelectedItem as Coach;

            selectedCoach.IsSent = true;
            if (selectedCoach != null)
            {
                coachService.Update(selectedCoach.Id ,selectedCoach);
                RefreshDataGrid();
            }
        }

        private void BtnResetCoach_Click(object sender, RoutedEventArgs e)
        {
            var selectedCoach = DgUnacceptedCoaches.SelectedItem as Coach;

            selectedCoach.DiplomaName = "";
            selectedCoach.SertificateName = "";
            selectedCoach.Title = "";

            if (selectedCoach != null)
            {
                coachService.Update(selectedCoach.Id, selectedCoach);
                RefreshDataGrid();
            }
        }

        private void DgUnacceptedCoaches_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Profit" || e.PropertyName == "NumberSuccessfulAppointments"
                || e.PropertyName == "IsSent")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}
