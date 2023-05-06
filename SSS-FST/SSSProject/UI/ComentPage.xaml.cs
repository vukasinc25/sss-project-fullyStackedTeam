using SSS_FullyStackedTeam.Model;
using SSS_FullyStackedTeam.Service;
using SSSProject.Model;
using SSSProject.Repository;
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
    /// Interaction logic for ComentPage.xaml
    /// </summary>
    public partial class ComentPage : Page
    {
        int id = 0;
        int broj = 0;
        double rank = 0;
        public MainWindow Window { get; set; }

        private IComentRepository comentRepository = new ComentsRepository();
        private ICoachService coachService = new CoachService();
        private Coach coach = Data.Instance.LoggedInCoach;
        private Client client = Data.Instance.LoggedInClient;
        private Coments coment = new Coments();
        public ComentPage(MainWindow window, int Id)
        {
            InitializeComponent();
            Window = window;
            id = Id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Coach coach1 = coachService.GetById(id);
            if (client.Weight != null)
            {
                coment.Client = client;
            }
            if(txtRating.Text == "" || Convert.ToDouble(txtRating.Text) > 5 || Convert.ToDouble(txtRating.Text) <=0)
            {
                MessageBox.Show("Niste uneli odgovarajuci broj");
            }
            if(txtComent.Text == "")
            {
                MessageBox.Show("Komentar mora biti popunjen");
            }
            else
            {
                coment.Rating = Convert.ToDouble(txtRating.Text);
                coment.Coach = coach1;
                coment.Coment = txtComent.Text;
                comentRepository.Add(coment);
                foreach(Coments coment in comentRepository.GetAll().Where(p => p.CoachId == coach1.Id))
                {
                    rank += coment.Rating;
                    broj++;
                }
                coach1.Rank = rank / broj;
                coachService.Update(coach1.Id, coach1);
                Window.Content = new PrimaryPage(Window);
            }
        }
    }
}
