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
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Window
    {
        private int userID;
        public UserInfo(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            fillUserInfo();
        }

        private void fillUserInfo()
        {
            var userInfo = DBDefaultInfoChecker.getUserInfo(userID);
            if (userInfo.HasValue)
            {
                var (name, surname, patronymic, passportSeries, passportNumber) = userInfo.Value;
                nameBox.Text = name;
                surnameBox.Text = surname;
                patronymicBox.Text = patronymic;
                passportSeriesBox.Text = passportSeries;
                passportNumberBox.Text = passportNumber;
            }
            else
                MessageBox.Show("Проблемы с поиском выших данных. Попробуйте позже!");
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DBRegistrator.changeUserInfo(userID, nameBox.Text, surnameBox.Text, patronymicBox.Text, passportSeriesBox.Text, passportNumberBox.Text))
                MessageBox.Show("Данные успешно обновлены!");
            else
                MessageBox.Show("Не удалось обновить данные. Попробуйте позже.");
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
    }
}
