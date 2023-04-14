using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Service;
using SSSProject;
using SSSProject.Model;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SSS_FullyStackedTeam.UI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public MainWindow Window { get; set; }
        public Page PreviousPage { get; set; }

        private IUserService userService = new UserService();
        private IClientService clientService = new ClientService();
        private ICoachService coachService = new CoachService();

        public LoginPage(MainWindow window, Page previousPage)
        {
            InitializeComponent();
            Window = window;
            PreviousPage = previousPage;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            foreach (User current in userService.GetAll())
            {
                if (TxtLoginEmail.Text.Trim() == current.Email
                    && PwbLoginPassword.Password.Trim() == current.Password)
                {
                    user = current;
                    break;
                }
            }
            if (user.Email == null)
            {
                MessageBox.Show("Incorrect Email or Password!");
            }
            else
            {
                foreach (Client current in clientService.GetAll())
                {
                    if (current.UserId == user.Id)
                    {
                        Data.Instance.LoggedInClient = current;
                        break;
                    }
                }

                if (Data.Instance.LoggedInClient.User == null)
                {
                    foreach (Coach current in coachService.GetAll())
                    {
                        if (current.UserId == user.Id)
                        {
                            Data.Instance.LoggedInCoach = current;
                            break;
                        }
                    }

                    if (Data.Instance.LoggedInCoach.DiplomaName == "")
                    {
                        //Window.Content = new 
                    }
                    else
                    {
                        Window.Content = new PrimaryPage(Window);
                    }
                }
                else
                {
                    if(Data.Instance.LoggedInClient.Weight == 0)
                    {
                        Window.Content = new ExtraClientInfo(Window);
                    }
                    else
                    {
                        Window.Content = new PrimaryPage(Window);
                    }
                }
            }
            
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window.Content = PreviousPage;
        }
    }
}
