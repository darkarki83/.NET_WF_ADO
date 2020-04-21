using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstAdo.Model
{
    public class Sales : ISales
    {
        private SqlConnectionStringBuilder builder;
        private SqlConnection connection;

        private List<long> bookIDs = new List<long>();
        private List<long> authorFKs = new List<long>();

        public Sales()
        {
            builder = new SqlConnectionStringBuilder();
            connection = new SqlConnection();
        }

        public SqlConnectionStringBuilder Builder
        {
            get =>  builder;
            set => builder = value;
        }

        public SqlConnection Connection
        {
            get => connection;
            set => connection = value;
        }

        public List<long> BookIDs
        {
            get => bookIDs;
            set => bookIDs = value;
        }

        public List<long> AuthorFKs
        {
            get => authorFKs;
            set => authorFKs = value;
        }

        public void LoadSales(ListView listView)
        {
            Builder.DataSource = "(local)";      // Сервер
            Builder.InitialCatalog = "Sales";  // Текущая БД
            Builder.IntegratedSecurity = true;   // Режим проверки подлинности

            Connection.ConnectionString = Builder.ConnectionString;

            try
            {
                Connection.Open();
                FillListView(listView);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillListView(ListView listView)
        {
            try
            {
                string sqlString =
                        "SELECT Buyers.FirstName as Buyer, Sellers.FirstName as seller, Sale.Amount as Amount, Sale.DateSale AS Date " +
                        "FROM Sale, Sellers, Buyers " +
                        "WHERE Sale.BuyersFK = Buyers.Id and Sale.SellersFK = Sellers.Id";

                using (SqlCommand command = new SqlCommand(sqlString, Connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item = listView.Items.Add(new ListViewItem());
                        item.Text = (string)reader["Buyer"];
                        item.SubItems.Add((string)reader["seller"]);
                        item.SubItems.Add(((decimal)reader["Amount"]).ToString());
                        item.SubItems.Add(((DateTime)reader["Date"]).ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.StackTrace.ToString());
            }
        }

        public void Close()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}
