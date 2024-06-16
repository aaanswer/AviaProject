using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using Avia.Database;

namespace Avia
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private bool isMail = true;
        private int verificationCode;
        private string receiverMail;
        private Emailer emailer;
        private string password;

        public Registration()
        {
            InitializeComponent();
            emailer = new Emailer();
        }        

        private void backToOwner()
        {
            MainWindow entering = new MainWindow();
            entering.Show();
            Close();
        }
        
        private bool enterNewUser(string password)
        {
            if (DBRegistrator.registerNewUserLogin(receiverMail, PasswordGenerator.hashPassword(password)))
                return true;
            else return false;
        }

<<<<<<< HEAD
        private void continueRegistration()
        {
            UserInfoRegistration userInfoRegistration = new UserInfoRegistration(receiverMail);
            userInfoRegistration.Show();
            Close();
        }

=======
>>>>>>> xamlBranch
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

<<<<<<< HEAD
        private void nextStepBtn_Click(object sender, RoutedEventArgs e)
=======
        private void button2_Click(object sender, EventArgs e)
>>>>>>> xamlBranch
        {
            if (ServerPinger.PingServer())
            {
                if (isMail)
                {
                    verificationCode = CodeGenerator.generateFiveSymbCode();
                    if (emailer.sendCode(receiverMail, verificationCode))
                    {
                        mailBox.Visibility = Visibility.Hidden;
                        codeBox.Visibility = Visibility.Visible;
                        textLabel.Content = "Введите код";
                        isMail = false;
                    }
                }
                else
                {
                    password = PasswordGenerator.generateDefaultPassword();
                    if (DBRegistrator.registerNewUserLogin(receiverMail, PasswordGenerator.hashPassword(password)))
                        if (emailer.sendPassword(receiverMail, password))
                            continueRegistration();
                        else
                        {
                            MessageBox.Show("Ошибка при регистрации нового пользователя. Попробуйте позже");
                            mailBox.Visibility = Visibility.Visible;
                            codeBox.Visibility = Visibility.Hidden;
                            textLabel.Content = "Введите почту";
                            isMail = true;
                            receiverMail = string.Empty;
                            verificationCode = 0;
                        }
                }
            }
            else
            {
                MessageBox.Show("Для прохождения регистрации требуется подключение к интернету!");
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            backToOwner();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
