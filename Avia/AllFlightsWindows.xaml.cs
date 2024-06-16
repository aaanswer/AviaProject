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
        }

        private void loadAllFlights()
        {
            foreach (var flight in flights)
            {
                var card = creator.createCard(flight.Item1, DBDefaultInfoChecker.getAirlinesNameByID(flight.Item2), flight.Item3, flight.Item4, flight.Item5, flight.Item6);
                panelContainer.Children.Add(card);
            }
        }
    }
}
