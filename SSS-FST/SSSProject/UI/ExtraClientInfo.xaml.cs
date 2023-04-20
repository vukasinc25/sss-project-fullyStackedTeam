using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Service;
using SSS_FullyStackedTeam.UI;
using SSSProject.Model;
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
    /// Interaction logic for ExtraClientInfo.xaml
    /// </summary>
    public partial class ExtraClientInfo : Page
    {
        public MainWindow Window { get; set; }

        public Client client = Data.Instance.LoggedInClient;

        private IClientService clientService = new ClientService();

        private List<Goal> goals;
        private List<Illness> illnesses;
        private List<Prop> props;

        public ExtraClientInfo(MainWindow window)
        {
            InitializeComponent();
            Window = window;
            goals = clientService.GetAllGoals();
            illnesses = clientService.GetAllIllnesses();
            props = clientService.GetAllProps();
            LbxGoals.ItemsSource = goals;
            LbxIllnesses.ItemsSource = illnesses;
            LbxProps.ItemsSource = props;

            DataContext = client;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            foreach(Goal goal in LbxGoals.SelectedItems)
            {
                client.Goals.Add(goal);
            }

            foreach(Illness illness in LbxIllnesses.SelectedItems)
            {
                client.Illnesses.Add(illness);
            }

            foreach(Prop prop in LbxProps.SelectedItems)
            {
                client.Props.Add(prop);
            }

            clientService.Update(client.Id, client);

            Window.Content = new PrimaryPage(Window);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window.Content = new MainPage(Window);
        }
    }
}
