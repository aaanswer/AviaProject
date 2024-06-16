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
    /// Логика взаимодействия для FlightFullInfo.xaml
    /// </summary>
    public partial class FlightFullInfo : Window
    {
        private int flightID, userID;
        private bool isInFavorite;
        public FlightFullInfo(int flightID, int userID, bool isInFavorite)
        {
            InitializeComponent();
            this.flightID = flightID;
            this.userID = userID;
            if (isInFavorite)
                favoriteBtn.Content = "Удалить из избранных";
        }

        private void favoriteBtn_Click(object sender, RoutedEventArgs e)
        {
            isInFavorite = isInFavorite == true ? false: true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isInFavoriteDB = DBDefaultInfoChecker.isInFavoriteFlights(flightID, userID);
            if (isInFavorite && !isInFavoriteDB)
                DBRegistrator.insertToFavorite(flightID, userID);
            else if (!isInFavorite && isInFavoriteDB)
                DBRegistrator.deleteFromFavorite(flightID, userID);
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void fillWindow()
        {
            var flightInfo = DBDefaultInfoChecker.getFlightInfoViaID(flightID);
            if (flightInfo.HasValue)
            {
                var (id, origin, destination, departureTime, arrivalTime, countOfFreeSeats, status) = flightInfo.Value;
                airlinesLabel.Content = DBDefaultInfoChecker.getAirlinesNameByID(id);
                originLabel.Content = origin;
                destinationLabel.Content = destination;
                departureTimeLable.Content = departureTime;
                arrivalTimeLabel.Content = arrivalTime;
                countOfFreeSeatsLabel.Content = countOfFreeSeats;
                statusLabel.Content = status;
            }
        }
    }
}
