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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private int userID;
        public MainMenu(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void allFlights_Click(object sender, RoutedEventArgs e)
        {
            AllFlightsWindows allFlights = new AllFlightsWindows(userID);
            allFlights.Show();
            Close();
        }

        private void favoriteFlights_Click(object sender, RoutedEventArgs e)
        {
            FavoriteFlights favoriteFlights = new FavoriteFlights(userID);
            favoriteFlights.Show();
            Close();
        }

        private void infoBtn_Click(object sender, RoutedEventArgs e)
        {
            UserInfo userInfo = new UserInfo(userID);
            userInfo.Show();
            Close();
        }
    }
}
