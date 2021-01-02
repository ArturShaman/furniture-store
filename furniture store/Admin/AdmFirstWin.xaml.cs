using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace furniture_store.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdmFirstWin.xaml
    /// </summary>
    public partial class AdmFirstWin : Window
    {
        private string connectingString = @"Data Source=DESKTOP-B6LM2DJ\SQLEXPRESS;Initial Catalog=furniture store;Integrated Security=True";
        public AdmFirstWin()
        {
            InitializeComponent();
            l11.Content = MainClass.NameAdm;
            ButAdd.Visibility = Visibility.Hidden;
            ButDel.Visibility = Visibility.Hidden;
            TSearch.Visibility = Visibility.Hidden;
            ButSear.Visibility = Visibility.Hidden;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ButAdd.Visibility = Visibility.Visible;
            ButDel.Visibility = Visibility.Visible;
            TSearch.Visibility = Visibility.Visible;
            ButSear.Visibility = Visibility.Visible;
            DPick_Start.Visibility = Visibility.Hidden;
            DPick_End.Visibility = Visibility.Hidden;
            SL.Visibility = Visibility.Hidden;
            EL.Visibility = Visibility.Hidden;
            EdL.Visibility = Visibility.Hidden;
            ButV.Visibility = Visibility.Hidden;
            CatAdd.Visibility = Visibility.Hidden;
            NameS.Visibility = Visibility.Hidden;
            ButVN.Visibility = Visibility.Hidden;
            NameAdd.Visibility = Visibility.Hidden;
            L1.Items.Clear();
            DataSet table = new DataSet();
            string sqlExpression = ("select * from Product");
            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                foreach (DataTable dt in table.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        Controls.AdmOutControl admOutControl = new Controls.AdmOutControl();
                        admOutControl.Name1.Content = cells[1].ToString();
                        admOutControl.Name1.Content = cells[0].ToString();
                        admOutControl.Name2.Content = cells[1].ToString();
                        admOutControl.Name3.Content = cells[2].ToString();
                        admOutControl.Name4.Content = cells[3].ToString();
                        admOutControl.Name5.Content = cells[4].ToString();
                        L1.Items.Add(admOutControl);
                    }
                }
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButAdd.Visibility = Visibility.Hidden;
            ButDel.Visibility = Visibility.Hidden;
            TSearch.Visibility = Visibility.Hidden;
            ButSear.Visibility = Visibility.Hidden;
            DPick_Start.Visibility = Visibility.Hidden;
            DPick_End.Visibility = Visibility.Hidden;
            SL.Visibility = Visibility.Hidden;
            EL.Visibility = Visibility.Hidden;
            EdL.Visibility = Visibility.Hidden;
            ButV.Visibility = Visibility.Hidden;
            CatAdd.Visibility = Visibility.Hidden;
            NameS.Visibility = Visibility.Hidden;
            ButVN.Visibility = Visibility.Hidden;
            NameAdd.Visibility = Visibility.Hidden;
            L1.Items.Clear();
            DataSet table = new DataSet();
            string sqlExpression = ("select * from [User]");
            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                foreach (DataTable dt in table.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        Controls.ShowUsAdm showUsAdm = new Controls.ShowUsAdm();
                        showUsAdm.Name1.Content = cells[0].ToString();
                        showUsAdm.Name2.Content = cells[1].ToString();
                        showUsAdm.Name3.Content = cells[2].ToString();
                        showUsAdm.Name4.Content = cells[3].ToString();
                        showUsAdm.Name5.Content = cells[4].ToString();
                        L1.Items.Add(showUsAdm);
                    }
                }
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        private void DealB_Click(object sender, RoutedEventArgs e)
        {
            ButAdd.Visibility = Visibility.Hidden;
            ButDel.Visibility = Visibility.Hidden;
            TSearch.Visibility = Visibility.Hidden;
            ButSear.Visibility = Visibility.Hidden;
            DPick_Start.Visibility = Visibility.Hidden;
            DPick_End.Visibility = Visibility.Hidden;
            SL.Visibility = Visibility.Hidden;
            EL.Visibility = Visibility.Hidden;
            EdL.Visibility = Visibility.Hidden;
            ButV.Visibility = Visibility.Hidden;
            CatAdd.Visibility = Visibility.Hidden;
            NameS.Visibility = Visibility.Hidden;
            ButVN.Visibility = Visibility.Hidden;
            NameAdd.Visibility = Visibility.Hidden;
            L1.Items.Clear();
            DataSet table = new DataSet();
            string sqlExpression = ("select * from Deal");
            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                foreach (DataTable dt in table.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        Controls.ShowDealAdm showDealAdm = new Controls.ShowDealAdm();
                        showDealAdm.Name1.Content = cells[0].ToString();
                        showDealAdm.Name2.Content = cells[1].ToString();
                        showDealAdm.Name3.Content = cells[2].ToString();
                        showDealAdm.Name4.Content = cells[3].ToString();
                        L1.Items.Add(showDealAdm);
                    }
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void ButAdd_Click(object sender, RoutedEventArgs e)
        {
            Func.AddWindow addWindow = new Func.AddWindow();
            addWindow.Show();
        }

        private void ButSear_Click(object sender, RoutedEventArgs e)
        {
            L1.Items.Clear();
            bool check = true;
            string sqlExpression = ("Select * from Product group by prod_ID,Name,Category,Material,Price having Name like @name or Category like @name or Material like @name or Price like @name");
            SqlConnection connection = new SqlConnection(connectingString);
            connection.Open();
            try
            {
                check = true;
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@name", "%" + TSearch.Text + "%");
                DataSet table = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                foreach (DataTable dt in table.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        Controls.AdmOutControl admOutControl = new Controls.AdmOutControl();
                        admOutControl.Name1.Content = cells[0].ToString();
                        admOutControl.Name2.Content = cells[1].ToString();
                        admOutControl.Name3.Content = cells[2].ToString();
                        admOutControl.Name4.Content = cells[3].ToString();
                        admOutControl.Name5.Content = cells[4].ToString();
                        L1.Items.Add(admOutControl);
                    }
                }
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
            }
        }

        private void ButDel_Click(object sender, RoutedEventArgs e)
        {
            Func.DelWindow delWindow = new Func.DelWindow();
            delWindow.Show();
        }
        private void Stat_Click(object sender, RoutedEventArgs e)
        {
            ButAdd.Visibility = Visibility.Hidden;
            ButDel.Visibility = Visibility.Hidden;
            TSearch.Visibility = Visibility.Hidden;
            ButSear.Visibility = Visibility.Hidden;
            DPick_Start.Visibility = Visibility.Visible;
            DPick_End.Visibility = Visibility.Visible;
            SL.Visibility = Visibility.Visible;
            EL.Visibility = Visibility.Visible;
            EdL.Visibility = Visibility.Visible;
            ButV.Visibility = Visibility.Visible;
            CatAdd.Visibility = Visibility.Visible;
            NameS.Visibility = Visibility.Visible;
            ButVN.Visibility = Visibility.Visible;
            NameAdd.Visibility = Visibility.Visible;
            DPick_Start.SelectedDate = DPick_Start.DisplayDate;
            DPick_End.SelectedDate = DPick_Start.DisplayDate;
            L1.Items.Clear();
        }

        private void ButV_Click(object sender, RoutedEventArgs e)
        {
            L1.Items.Clear();
            DateTime dateTimestart;
            DateTime dateTimeend;
            dateTimestart = DPick_Start.SelectedDate.Value;
            dateTimeend = DPick_End.SelectedDate.Value;
            DataSet table = new DataSet();
            DataSet table2 = new DataSet();
            string sqlExpression = ("select  Deal.Deal_ID,Deal.Product_ID,Deal.User_ID,Product.Name,Product.Category,Deal.DateDeal from Deal inner join Product on Deal.Product_ID=Product.prod_ID where Deal.DateDeal between @date1 and @date2 and Product.Category like @Cat group by Deal.Deal_ID,Deal.Product_ID,Deal.User_ID,Product.Name,Product.Category,Deal.DateDeal");
            string sqlExpression2 = ("select COUNT(Product.Category) from Deal inner join Product on Deal.Product_ID=Product.prod_ID where Deal.DateDeal between @date1 and @date2 and Product.Category like @Cat order by count(Category)");
            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                command.Parameters.AddWithValue("@date1", dateTimestart);
                command.Parameters.AddWithValue("@date2", dateTimeend);
                command.Parameters.AddWithValue("@Cat", "%" + CatAdd.Text + "%");
                command2.Parameters.AddWithValue("@date1", dateTimestart);
                command2.Parameters.AddWithValue("@date2", dateTimeend);
                command2.Parameters.AddWithValue("@Cat", "%" + CatAdd.Text + "%");
                adapter.Fill(table);
                adapter2.Fill(table2);
                foreach (DataTable dt in table2.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        MainClass.Amount = cells[0].ToString();
                    }
                }
                foreach (DataTable dt in table.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        Controls.StatControl statControl = new Controls.StatControl();
                        statControl.Name1.Content = cells[0].ToString();
                        statControl.Name2.Content = cells[1].ToString();
                        statControl.Name3.Content = cells[2].ToString();
                        statControl.Name4.Content = cells[3].ToString();
                        statControl.Name5.Content = cells[4].ToString();
                        statControl.Name6.Content = cells[5].ToString();
                        statControl.Name7.Content = MainClass.Amount;
                        L1.Items.Add(statControl);
                    }
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void ButVN_Click(object sender, RoutedEventArgs e)
        {
            L1.Items.Clear();
            DateTime dateTimestart;
            DateTime dateTimeend;
            dateTimestart = DPick_Start.SelectedDate.Value;
            dateTimeend = DPick_End.SelectedDate.Value;
            DataSet table = new DataSet();
            DataSet table2 = new DataSet();
            string sqlExpression = ("select  Deal.Deal_ID,Deal.Product_ID,Deal.User_ID,Product.Name,Product.Category,Deal.DateDeal from Deal inner join Product on Deal.Product_ID=Product.prod_ID where Deal.DateDeal between @date1 and @date2 and Product.Name like @Name group by Deal.Deal_ID,Deal.Product_ID,Deal.User_ID,Product.Name,Product.Category,Deal.DateDeal");
            string sqlExpression2 = ("select COUNT(Product.Category) from Deal inner join Product on Deal.Product_ID=Product.prod_ID where Deal.DateDeal between @date1 and @date2 and Product.Category like @Cat order by count(Category)");
            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                command.Parameters.AddWithValue("@date1", dateTimestart);
                command.Parameters.AddWithValue("@date2", dateTimeend);
                command.Parameters.AddWithValue("@Name",  NameAdd.Text);
                command2.Parameters.AddWithValue("@date1", dateTimestart);
                command2.Parameters.AddWithValue("@date2", dateTimeend);
                command2.Parameters.AddWithValue("@Cat", "%" + CatAdd.Text + "%");
                adapter.Fill(table);
                adapter2.Fill(table2);
                foreach (DataTable dt in table2.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        MainClass.Amount = cells[0].ToString();
                    }
                }
                foreach (DataTable dt in table.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        Controls.StatControl statControl = new Controls.StatControl();
                        statControl.Name1.Content = cells[0].ToString();
                        statControl.Name2.Content = cells[1].ToString();
                        statControl.Name3.Content = cells[2].ToString();
                        statControl.Name4.Content = cells[3].ToString();
                        statControl.Name5.Content = cells[4].ToString();
                        statControl.Name6.Content = cells[5].ToString();
                        statControl.Name7.Content = MainClass.Amount;
                        L1.Items.Add(statControl);
                    }
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

