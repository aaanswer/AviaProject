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

        public Registration()
        {
            InitializeComponent();
            emailer = new Emailer();
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            backToOwner();
        }

        private void backToOwner()
        {
            MainWindow entering = new MainWindow();
            entering.Show();
            Close();
        }

        private SmtpClient smtpCreate()
        {
            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("testmeilbox0028@mail.ru", "XFehgm1UpW7TWcLwxtmH");
            smtpClient.EnableSsl = true;

            return smtpClient;
        }
        

        //Изменить
        private bool enterNewUser(string password)
        {
            string selectCountQuery = "SELECT COUNT(*) FROM UsersInfo";
            string insertLoginQuery = "INSERT INTO UsersLogin (PasswordHash, Email) VALUES (@PasswordHash, @Email)";
            string insertInfoQuery = "INSERT INTO UsersInfo (Email, Nickname) VALUES (@Email, @Nickname)";

            int newUserID;
            try
            {
                using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
                {
                    connection.Open();
                    using (SqlCommand countCommand = new SqlCommand(selectCountQuery, connection))
                    {
                        newUserID = Convert.ToInt32(countCommand.ExecuteScalar()) + 1;
                    }
                }

                using (SqlConnection connection = new SqlConnection(dbContainer.getAdminString()))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string hash = PasswordGenerator.hashPassword(password);
                            using (SqlCommand command = new SqlCommand(insertLoginQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@PasswordHash", hash);
                                command.Parameters.AddWithValue("@Email", receiverMail);
                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected <= 0)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }

                            using (SqlCommand command = new SqlCommand(insertInfoQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@Email", receiverMail);
                                command.Parameters.AddWithValue("@Nickname", "User_" + newUserID);
                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected <= 0)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
                    if (emailer.sendPassword(receiverMail, PasswordGenerator.generateDefaultPassword()))
                    {
                        backToOwner();
                    }
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
    }
}
