using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWAdo2.Model
{
    public class Acounting : IAcounting
    {
        private SqlConnectionStringBuilder builder;
        private SqlConnection connection;
        private ConnectionStringSettings settings;

        public Acounting()
        {
            builder = new SqlConnectionStringBuilder();
            connection = new SqlConnection();
            settings = new ConnectionStringSettings();
        }


        public SqlConnectionStringBuilder Builder { get => builder; set => builder = value; }
        public SqlConnection Connection { get => connection; set => connection = value; }
        public ConnectionStringSettings Settings { get => settings; set => settings = value; }

        public void LoadAcounting(ComboBox outComboBox, PictureBox outPictureBox, ListBox outListBox)
        {
           Builder.DataSource = "(local)";      // Сервер
           Builder.InitialCatalog = "Acounting";  // Текущая БД
           Builder.IntegratedSecurity = true;   // Режим проверки подлинности


            // Классы ConfigurationManager и ConnectionStringSettings требуют
            // явного подключения сборки System.Configuration
            Settings = ConfigurationManager.ConnectionStrings["Acounting"];

            Connection.ConnectionString = Settings != null ? settings.ConnectionString : Builder.ConnectionString;
            try
            {
                connection.Open();
                FillListView(outComboBox, outPictureBox, outListBox);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillListView(ComboBox outComboBox, PictureBox outPictureBox, ListBox outListBox)
        {
            try
            {
                string sqlString =
                        "SELECT W.Id, W.FirstName, W.LastName, W.Patronymic, W.DateBirth,  W.HiringNumber, W.DismissalNumber, Foto.[Name] as AdressFoto, Foto.TheFoto as [image] " +
                        "FROM Worker W, Foto " +
                        "WHERE W.Id = Foto.Id";

                using (SqlCommand command = new SqlCommand(sqlString, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        //BookIDs.Add((long)reader["Id"]);
                        //AuthorFKs.Add((long)reader["AuthorFk"]);*/

                        outComboBox.Items.Add((string)reader["FirstName"] + " " + (string)reader["LastName"]);
                        for (; i < 1; i++)
                        {
                            try
                            {
                                outListBox.Items.Insert(11, (int)reader["DismissalNumber"]);
                            }
                            catch(Exception)
                            {
                                outListBox.Items.Insert(11, 0);
                            }
                            outListBox.Items.Insert(9, (int)reader["HiringNumber"]);
                            outListBox.Items.Insert(7, (DateTime)reader["DateBirth"]);
                            outListBox.Items.Insert(5, (string)reader["Patronymic"]);
                            outListBox.Items.Insert(3, (string)reader["LastName"]);
                            outListBox.Items.Insert(1, (string)reader["FirstName"]);
                            
                            try
                            {
                                outPictureBox.Image = new Bitmap((string)reader["AdressFoto"]);
                            }
                            catch (Exception)
                            {
                                //outPictureBox.Image
                            }


                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void NewWorker(ComboBox outComboBox, PictureBox outPictureBox, ListBox outListBox)
        {
            try
            {
                string sqlString =
                        "SELECT W.Id, W.FirstName, W.LastName, W.Patronymic, W.DateBirth,  W.HiringNumber, W.DismissalNumber, Foto.[Name] as AdressFoto, Foto.TheFoto as [image] " +
                        "FROM Worker W, Foto " +
                        "WHERE W.Id = Foto.Id";

                using (SqlCommand command = new SqlCommand(sqlString, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int i = outComboBox.SelectedIndex;
                    int j = 0;
                    while (reader.Read())
                    {
                        if (j == i)
                        {
                            for (int k = 0; k <  1; k++)
                            {
                                try
                                {
                                    outListBox.Items[16] = (int)reader["DismissalNumber"];
                                }
                                catch (Exception)
                                {
                                    outListBox.Items[16] = 0;
                                }
                                outListBox.Items[13] = (int)reader["HiringNumber"];
                                outListBox.Items[10] = (DateTime)reader["DateBirth"];
                                outListBox.Items[7] = (string)reader["Patronymic"];
                                outListBox.Items[4] =  (string)reader["LastName"];
                                outListBox.Items[1] =  (string)reader["FirstName"];

                                try
                                {
                                    outPictureBox.Image = new Bitmap((string)reader["AdressFoto"]);
                                }
                                catch (Exception)
                                {
                                    //outPictureBox.Image
                                }
                            }
                        }
                        j++;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
