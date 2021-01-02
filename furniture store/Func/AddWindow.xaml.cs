using System;
using System.Data.SqlClient;
using System.Windows;

namespace furniture_store.Func
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private string connectingString = @"Data Source=DESKTOP-B6LM2DJ\SQLEXPRESS;Initial Catalog=furniture store;Integrated Security=True";
        public AddWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool check = true;
            string sqlExpression = ("Insert INTO Product(Name,Category,Material,Price) values (@name,@category,@material,@price)");
            SqlConnection connection = new SqlConnection(connectingString);
            connection.Open();
            try
            {
                check = true;
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@name", NameAdd.Text);
                command.Parameters.AddWithValue("@category", CatAdd.Text);
                command.Parameters.AddWithValue("@material", MatAdd.Text);
                command.Parameters.AddWithValue("@price", PriceAdd.Text);
                command.ExecuteNonQuery();
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
                    MessageBox.Show("Товар добавлен!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка!");
                }
            }
        }
    }
}
