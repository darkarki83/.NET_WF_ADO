using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Model
{
    public class UserModel : IUserModel
    {
        private SqlConnection sqlConnection;
        private DataSet myUserDataSet = new DataSet("Users");
        private SqlDataAdapter dataAdpater;
        private string login;
        private string password;
        private string adress;
        private string phone;
        private bool isAdmin;
        private int indexEdit;

        private SqlDataAdapter userAndPassword;
        private SqlDataAdapter oneUser;

        public UserModel()
        {
            indexEdit = -1;
        }

        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }
        public DataSet MyUserDataSet { get => myUserDataSet; set => myUserDataSet = value; }
        public SqlDataAdapter DataAdpater { get => dataAdpater; set => dataAdpater = value; }
        public SqlDataAdapter UserAndPassword { get => userAndPassword; set => userAndPassword = value; }
        public SqlDataAdapter OneUser { get => oneUser; set => oneUser = value; }


        public int IndexEdit { get => indexEdit; set => indexEdit = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Phone { get => phone; set => phone = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        public void LoadForm(DataGridView dataGrid)
        {
            string connectionString = "Data Source=(local);Initial Catalog=Users;Integrated Security=True";

            SqlConnection = new SqlConnection(connectionString);
            SqlConnection.Open();

            //myLibraryDataSet.Clear();

            UserAndPassword = new SqlDataAdapter("SELECT * FROM UserAndPassword",  sqlConnection);
            UserAndPassword.Fill(MyUserDataSet);
            //OneUser = new SqlDataAdapter("SELECT * FROM OneUser", sqlConnection);
           // OneUser.Fill(MyUserDataSet);

            dataGrid.DataSource = MyUserDataSet;
            dataGrid.DataMember = MyUserDataSet.Tables[0].TableName;
            //dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void Update()
        {
            //SqlConnection.Open();
            UserAndPassword.UpdateCommand = new SqlCommand("UPDATE UserAndPassword SET [Login] = @Login, [Password] = @Password WHERE Id = @Id", sqlConnection);
            UserAndPassword.UpdateCommand.Parameters.Add("@Id", SqlDbType.BigInt, 8, "Id");
            UserAndPassword.UpdateCommand.Parameters.Add("@Login", SqlDbType.NVarChar, 50, "[Login]");
            UserAndPassword.UpdateCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50, "[Password]");
            //SqlConnection.Close();
            DataTable UserAndPasswordTable = MyUserDataSet.Tables["UserAndPassword"];
            foreach (DataRow row in UserAndPasswordTable.Rows)
                if (Convert.ToInt64(row["Id"]) == IndexEdit)
                {
                    row["[Login]"] = Login;
                    row["[Password]"] = Password;
                }
            UserAndPassword.Update(new DataSet("Users"));

            MyUserDataSet.Clear();

            if (MyUserDataSet.Tables.Contains("UserAndPassword"))
                MyUserDataSet.Tables["UserAndPassword"].Clear();

            UserAndPassword.Fill(MyUserDataSet, "UserAndPassword");
        }

        public void DeleteRow(DataGridView dataGrid)
        {
            DataAdpater.DeleteCommand = new SqlCommand(
            "DELETE FROM UserAndPassword "
            + $"WHERE Id = {IndexEdit};", SqlConnection) ;

            DataAdpater.DeleteCommand.Parameters.Add("@IndexEdit",
              SqlDbType.Int, 4, "IndexEdit");
            DataAdpater.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            DataTable categoryTable = new DataTable();
            dataAdpater.Fill(categoryTable);

            DataRow categoryRow = categoryTable.Rows[IndexEdit];
            dataAdpater.Update(categoryTable);

           /* DataTable categoryTable = new DataTable();
            dataAdpater.Fill(categoryTable);

            DataRow categoryRow = categoryTable.Rows[IndexEdit];
            //categoryRow["Login"] = Login;
            dataAdpater.Update(categoryTable);*/

         
        }

        public void AddRow(DataGridView dataGrid)
        {
            DataAdpater.DeleteCommand = new SqlCommand(
            "DELETE FROM UserAndPassword "
            + $"WHERE Id = {IndexEdit};", SqlConnection);

            DataAdpater.DeleteCommand.Parameters.Add("@IndexEdit",
              SqlDbType.Int, 4, "IndexEdit");
            DataAdpater.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            DataTable categoryTable = new DataTable();
            dataAdpater.Fill(categoryTable);

            DataRow categoryRow = categoryTable.Rows[IndexEdit];
            dataAdpater.Update(categoryTable);

            /* DataTable categoryTable = new DataTable();
             dataAdpater.Fill(categoryTable);

             DataRow categoryRow = categoryTable.Rows[IndexEdit];
             //categoryRow["Login"] = Login;
             dataAdpater.Update(categoryTable);*/


        }


    }
}
