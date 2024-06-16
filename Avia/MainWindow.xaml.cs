using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using Avia.Database;

namespace Avia;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void enterButton_Click(object sender, EventArgs e)
    {
        string email = mailBox.Text;
        if (DBDefaultInfoChecker.isEmailRegistered(mailBox.Text))
        {
            int userID = DBDefaultInfoChecker.getUserIDViaEmail(mailBox.Text);
            if (VerifyPassword(passwordBox.Password, DBDefaultInfoChecker.getPasswordHashViaEmail(email)))
            {
                MainMenu menu = new MainMenu(userID);
                menu.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пароль введен неверно!");
                passwordBox.Password = "";
            }
        }
    }    

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return string.Equals(PasswordGenerator.hashPassword(password), hashedPassword, StringComparison.OrdinalIgnoreCase);        
    }

    private void registrationButton_Click(object sender, RoutedEventArgs e)
    {
        ForgotPassword forgotPassword = new ForgotPassword();
        forgotPassword.Show();
        Close();
    }
}
