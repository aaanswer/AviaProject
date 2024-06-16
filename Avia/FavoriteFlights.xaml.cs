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
    /// Логика взаимодействия для FavoriteFlights.xaml
    /// </summary>
    public partial class FavoriteFlights : Window
    {
        private List<(int, int, string, string, DateTime, DateTime, int, string)> flights;
        private int userID;
        public FavoriteFlights(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            flights = DBDefaultInfoChecker.getFavoriteFlights(userID);
            
        }
    }
}
