using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace furniture_store.Admin
{
    /// <summary>
    /// Логика взаимодействия для RegAdm.xaml
    /// </summary>
    public partial class RegAdm : Window
    {
        private string connectingString = @"Data Source=DESKTOP-B6LM2DJ\SQLEXPRESS;Initial Catalog=furniture store;Integrated Security=True";
        public RegAdm()
        {
            InitializeComponent();
            _Login.Text = "Art";
            _Password.Text = "1029384756";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _Login.Text = "Art";
            _Password.Text = "1029384756";
            MainClass.NameAdm = _Login.Text;
            bool check = true;
            string sqlExpression = ("select * from Admin where Login = @login and Password = @password");
            SqlConnection connection = new SqlConnection(connectingString);
            SqlDataReader reader;
            connection.Open();

            try
            {
                check = true;
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add("@login", _Login.Text);
                command.Parameters.Add("@password", _Password.Text);
                command.ExecuteNonQuery();
                using (reader = command.ExecuteReader())
                {
                    check = reader.Read();
                }
            }
            finally
            {
                connection.Close();
                if (check)
                {
                    AdmFirstWin admFirstWin = new AdmFirstWin();
                    admFirstWin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }
        }

        private void Login_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            ////if (_Password.Text == "")
            ////{
            ////    _Password.Text = "Пароль";
            ////}
            ////_Login.Text = "";
            //_Password.Text = "1029384756";
        }

        private void Password_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //_Login.Text = "Art";
            //MainClass mainClass = new MainClass();
            //mainClass.NameAdm = _Login.Text;
            //if (_Login.Text == "")
            //{
            //    _Login.Text = "Логин";
            //}
            //_Password.Text = "";
        }
    }
}
