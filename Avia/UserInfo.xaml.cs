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
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Window
    {
        private int userID;
        public UserInfo(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void CheckIsNumeric(TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result)))
            {
                e.Handled = true;
            }
        }

        private void PreviewTextInputIsNumeric(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(userID);
            mainMenu.Show();
            Close();
        }
    }
}
