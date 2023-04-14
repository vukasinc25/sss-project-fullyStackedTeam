using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Repository;
using SSS_FullyStackedTeam.Service;
using SSSProject;
using SSSProject.Repository;
using SSSProject.Service;
using SSSProject.UI;
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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public MainWindow Window { get; set; }
        public Page PreviousPage { get; set; }

        private List<Language> languages;

        IUserService userService = new UserService();
        IClientService clientService = new ClientService();
        ICoachService coachService = new CoachService();
        ILanguageService languageService = new LanguageService();

        private User User;

        public RegisterPage(MainWindow window, Page previousPage)
        {
            InitializeComponent();
            Window = window;
            PreviousPage = previousPage;

            languages = languageService.GetAll();
            LbxLanguages.ItemsSource = languages;
            CbLanguages.ItemsSource = languages;
            CbLanguages.SelectedItem = languages[0];

            User = new User();
            DataContext = User;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            User.Password = PwbLoginPassword.Password;
            User.PrimaryLanguage = (Language)CbLanguages.SelectedItem;
            User.SecondaryLanguages.Clear();
            foreach (Language language in LbxLanguages.SelectedItems)
            {
                User.SecondaryLanguages.Add(language);
            }

            int userId = userService.Add(User);

            if ((bool)RdbClient.IsChecked)
            {
                Client client = new Client
                {
                    User = userService.GetById(userId),
                    Height = 0,
                    Weight = 0
                    
                };

                clientService.Add(client);
            }

            if ((bool)RdbCoach.IsChecked)
            {
                Coach coach = new Coach
                {
                    User = userService.GetById(userId),
                    DiplomaName = "",
                    SertificateName = "",
                    Title = "",
                    Profit = 0
                    
                };

                coachService.Add(coach);
            }

            MessageBox.Show("Successful Registration");
            Window.Content = new MainPage(Window);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window.Content = PreviousPage;
        }
    }
}
