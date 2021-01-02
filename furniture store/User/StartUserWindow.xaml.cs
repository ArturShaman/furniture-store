using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace furniture_store.User
{
    /// <summary>
    /// Логика взаимодействия для StartUserWindow.xaml
    /// </summary>
    public partial class StartUserWindow : Window
    {
        private string connectingString = @"Data Source=DESKTOP-B6LM2DJ\SQLEXPRESS;Initial Catalog=furniture store;Integrated Security=True";
        public StartUserWindow()
        {
            InitializeComponent();
        }
        private void Login_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Login.Text = "";
            if (Password.Text == "")
            {
                Password.Text = "Пароль";
            }
        }

        private void Password_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Login.Text == "")
            {
                Login.Text = "E-mail";
            }
           Password.Text = "";
        }
        private void CreateUserBut_Click(object sender, RoutedEventArgs e)
        {
            User.СreateUser сreateUse = new СreateUser();
            сreateUse.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool check = true;
            string sqlExpression = ("select * from [User] where [E-mail] = @login and Password = @password");
            SqlConnection connection = new SqlConnection(connectingString);
            SqlDataReader reader;
            connection.Open();

            try
            {
                check = true;
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter loginParam = new SqlParameter("@login", Login.Text);
                command.Parameters.Add(loginParam);
                SqlParameter passwordParam = new SqlParameter("@password", Password.Text);
                command.Parameters.Add(passwordParam);
                command.ExecuteNonQuery();
                using (reader = command.ExecuteReader())
                {
                    check = reader.Read();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                check = false;
            }
            finally
            {
                connection.Close();
                if (check)
                {
                    Main.StartWindow startWindow = new Main.StartWindow();
                    startWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }
    }
}
