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
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Avia.Database;

namespace Avia
{
    /// <summary>
    /// Логика взаимодействия для ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {
        private Emailer emailer;
        public ForgotPassword()
        {
            InitializeComponent();
            emailer = new Emailer();
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = mailBox.Text;
            if (DBDefaultInfoChecker.isEmailRegistered(email))
            {
                int userID = DBDefaultInfoChecker.getUserIDViaEmail(email);
                if (userID == 0) 
                    return;
                else
                {
                    string password = PasswordGenerator.generateDefaultPassword();
                    if (emailer.sendPassword(email, password))
                        backToEntering();
                    else
                        MessageBox.Show("Проблемы с отправкой пароля!");
                }
            }
        }
        private void backToEntering()
        {
            MainWindow entering = new MainWindow();
            entering.Show();
            Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            backToEntering();
        }
    }
}
