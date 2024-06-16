using Avia.Database;
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

namespace Avia
{
    /// <summary>
    /// Логика взаимодействия для AllFlightsWindows.xaml
    /// </summary>
    public partial class AllFlightsWindows : Window
    {
        private List<(int, int, string, string, DateTime, DateTime, int, string)> flights;
        private int userID;
        private FlightCardCreator creator;
        public AllFlightsWindows(int userID)
        {
            InitializeComponent();
            flights = DBDefaultInfoChecker.getAllFlights();
            this.userID = userID;
            creator = new FlightCardCreator();
            loadAllFlights();
        }

        private void loadAllFlights()
        {
            foreach (var flight in flights)
            {
                var card = creator.createCard(flight.Item1, DBDefaultInfoChecker.getAirlinesNameByID(flight.Item2), flight.Item3, flight.Item4, flight.Item5, flight.Item6);
                card.moreInfoBtn.Click += moreInfoButtno_Click;
                card.bookBtn.Click += bookBtn_Click;
                panelContainer.Children.Add(card);
            }
        }
        private void moreInfoButtno_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int flightID = (int)button.Tag;
                FlightFullInfo flightFullInfo = new FlightFullInfo(flightID, userID, true);
                flightFullInfo.ShowDialog();
            }
        }

        private void bookBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (DBRegistrator.bookFlight(userID, (int)button.Tag))
                    MessageBox.Show("Бронь успешно выполнена");
                else
                    MessageBox.Show("Невозможно выполнить бронирование. Попробуйте позже.");
            }
        }
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(userID);
            mainMenu.Show();
            Close();
        }
    }
}
