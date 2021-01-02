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

namespace furniture_store.Func
{
    /// <summary>
    /// Логика взаимодействия для DelWindow.xaml
    /// </summary>
    public partial class DelWindow : Window
    {
        private string connectingString = @"Data Source=DESKTOP-B6LM2DJ\SQLEXPRESS;Initial Catalog=furniture store;Integrated Security=True";
        public DelWindow()
        {
            InitializeComponent();
        }

        private void DelBut_Click(object sender, RoutedEventArgs e)
        {
            bool check = true;
            string sqlExpression = ("delete from Product where prod_ID=@id");
            SqlConnection connection = new SqlConnection(connectingString);
            connection.Open();
            try
            {
                check = true;
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@id", ProdDel.Text);
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
                    MessageBox.Show("Товар удален!");
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
