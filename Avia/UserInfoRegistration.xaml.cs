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
using Avia.Database;

namespace Avia
{
    /// <summary>
    /// Логика взаимодействия для UserInfoRegistration.xaml
    /// </summary>
    public partial class UserInfoRegistration : Window
    {
        private string email;
        public UserInfoRegistration(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text, surname = surnameBox.Text, patronymic = patronymicBox.Text, passportSeries = passportSeriesBox.Text, passportNumber = passportNumberBox.Text;
            if (DBRegistrator.registerUserInfo(name, surname, patronymic, passportSeries, passportNumber, email))
                backToLogin();
            else
                MessageBox.Show("Невозможно зарегистрировать пользователя, повторите попытку позже!");
        }

        private void backToLogin()
        {
            MainWindow login = new MainWindow();
            login.Show();
            Close();
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
