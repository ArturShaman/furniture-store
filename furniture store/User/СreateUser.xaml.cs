using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace furniture_store.User
{
    /// <summary>
    /// Логика взаимодействия для СreateUser.xaml
    /// </summary>
    public partial class СreateUser : Window
    {
        private string connectingString = @"Data Source=DESKTOP-B6LM2DJ\SQLEXPRESS;Initial Catalog=furniture store;Integrated Security=True";
        public СreateUser()
        {
            InitializeComponent();
        }

        private void Name_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Surname.Text == "")
            {
                Surname.Text = "Фамилия";
            }
            if (Adress.Text == "")
            {
                Adress.Text = "Адрес";
            }
            if (Email.Text == "")
            {
                Email.Text = "E-mail";
            }
            if (Password.Text == "")
            {
                Password.Text = "Пароль";
            }
            Name.Text = "";
        }

        private void Surname_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Name.Text == "")
            {
                Name.Text = "Имя";
            }
            if (Adress.Text == "")
            {
                Adress.Text = "Адрес";
            }
            if (Email.Text == "")
            {
                Email.Text = "E-mail";
            }
            if (Password.Text == "")
            {
                Password.Text = "Пароль";
            }
            Surname.Text = "";
        }

        private void Adress_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Surname.Text == "")
            {
                Surname.Text = "Фамилия";
            }
            if (Name.Text == "")
            {
                Name.Text = "Имя";
            }
            if (Email.Text == "")
            {
                Email.Text = "E-mail";
            }
            if (Password.Text == "")
            {
                Password.Text = "Пароль";
            }
            Adress.Text = "";
        }

        private void Email_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Surname.Text == "")
            {
                Surname.Text = "Фамилия";
            }
            if (Adress.Text == "")
            {
                Adress.Text = "Адрес";
            }
            if (Name.Text == "")
            {
                Name.Text = "Имя";
            }
            if (Password.Text == "")
            {
                Password.Text = "Пароль";
            }
            Email.Text = "";
        }

        private void Password_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Surname.Text == "")
            {
                Surname.Text = "Фамилия";
            }
            if (Adress.Text == "")
            {
                Adress.Text = "Адрес";
            }
            if (Email.Text == "")
            {
                Email.Text = "E-mail";
            }
            if (Name.Text == "")
            {
                Name.Text = "Имя";
            }
            Password.Text = "";
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            string pr1;
            bool check = true;
            string sqlExpression = ("Insert INTO [User](Name,Surname,[E-mail],Adress,Password) values (@name,@surname,@email,@adress,@password)");
            string sqlExpression2 = ("Select [E-Mail] from [User]");
            SqlConnection connection = new SqlConnection(connectingString);
            connection.Open();
            try
            {
                check = true;
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
                DataSet table = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command2);
                adapter.Fill(table);
                foreach (DataTable dt in table.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        pr1 = cells[0].ToString();
                        if (pr1 == Email.Text)
                        {
                            check = false;
                        }
                    }
                }
                if (check == true)
                {
                    command.Parameters.AddWithValue("@name", Name.Text);
                    command.Parameters.AddWithValue("@surname", Surname.Text);
                    command.Parameters.AddWithValue("@email", Email.Text);
                    command.Parameters.AddWithValue("@adress", Adress.Text);
                    command.Parameters.AddWithValue("@password", Password.Text);
                    command.ExecuteNonQuery();
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
                    MessageBox.Show("Регистрация прошла успешно!");
                    User.StartUserWindow startUserWindow = new StartUserWindow();
                    startUserWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("При регистрации произошла ошибка!Возможно на данный E-Mail уже зарегистрирован аккаунт.");
                }
            }
        }


    }
}
