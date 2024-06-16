using Microsoft.VisualBasic.ApplicationServices;
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

namespace Avia
{
    /// <summary>
    /// Логика взаимодействия для flightPanel.xaml
    /// </summary>
    public partial class flightPanel : UserControl
    {
        public int flightID { get; private set; }
        public flightPanel(int flightID)
        {
            InitializeComponent();
            this.flightID = flightID;
        }

        public virtual void favoriteBtn_Click(object sender, RoutedEventArgs e)
        {
            favoriteBtn.Content = favoriteBtn.Content.ToString() == "Удалить из избранного" ? "Добавить в избранное" : "Удалить из избранного";
        }

    }
}
