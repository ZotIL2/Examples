using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Common;
using System.Data.SqlClient;
using TextBox = System.Windows.Controls.TextBox;
using MessageBox = System.Windows.MessageBox;

namespace tester
{
    /// <summary>
    /// Логика взаимодействия для AddData.xaml
    /// </summary>
    public partial class AddData : Page
    {
        /*  public static string connectStringBd = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bd.mdb;";
            string connetionString;
            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter;
            OleDbCommandBuilder oledbCmdBuilder;
            DataSet ds = new DataSet();
            DataSet changes;
            int i;
            string Sql;

            private DataTable dataTable;
            public AddData()
            {
                InitializeComponent();
                ExitBut.Visibility = Visibility.Visible;
              //  LoadData();
            }
            private OleDbConnection myConnection;

            private void LoadData()
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Користувач";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGrid.ItemsSource = dataTable.DefaultView;
                }
            }

            private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
            {
                // Отримання індексу редагованого рядка
                int rowIndex = dataGrid.Items.IndexOf(e.Row.Item);

                // Оновлення бази даних
                using (myConnection = new OleDbConnection(connectStringBd))
                {
                    myConnection.Open();
                    string updateQuery = "UPDATE Користувач SET " +
                        "Посадаід = @Посадаід, " +
                        "ПІБ = @ПІБ, " +
                        "Пароль = @Пароль, " +
                        "Дорога = @Дорога, " +
                        "Відділ = @Відділ, " +
                        "Користувачі = @Користувачі " +
                        "WHERE Id = @Id";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, myConnection);
                    updateCommand.Parameters.AddWithValue("@Посадаід", ((TextBox)e.EditingElement).Text);
                    updateCommand.Parameters.AddWithValue("@ПІБ", ((TextBox)e.EditingElement).Text);
                    updateCommand.Parameters.AddWithValue("@Пароль", ((TextBox)e.EditingElement).Text);
                    updateCommand.Parameters.AddWithValue("@Дорога", ((TextBox)e.EditingElement).Text);
                    updateCommand.Parameters.AddWithValue("@Відділ", ((TextBox)e.EditingElement).Text);
                    updateCommand.Parameters.AddWithValue("@Користувачі", ((TextBox)e.EditingElement).Text);
                    updateCommand.Parameters.AddWithValue("@Id", dataTable.Rows[rowIndex]["Id"]);
                    updateCommand.ExecuteNonQuery();
                }
            }

         /*  private void UpdateButС(object sender, RoutedEventArgs e)
            {
                try
                {
                    oledbCmdBuilder = new OleDbCommandBuilder(oledbAdapter);
                    changes = ds.GetChanges();
                    ;
                    if (changes != null)
                    {
                        oledbAdapter.Update((DataSet)dataGrid.DataContext);
                    }
                    ds.AcceptChanges();
                    System.Windows.MessageBox.Show("Save changes");
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                }
            }
            private void Grid_Loaded(object sender, RoutedEventArgs e)
            {
                myConnection = new OleDbConnection(connectStringBd);
                myConnection.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from Користувач", myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds, "Користувач");
              //  ds.Tables[0].DefaultView.RowFilter = "VOLc_Age = '48'";
                dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                dataGrid.DataContext = ds.Tables[0];

                //    adap = new OleDbDataAdapter("Select * from Користувач", myConnection);
                //   OleDbCommandBuilder bulder = new OleDbCommandBuilder(adap);
                //    OleDbDataReader ListUserR = comand.ExecuteReader();
                //   adap.InsertCommand = bulder.GetInsertCommand();
                //   adap.Fill(ds);
                //  string ListUserN = "SELECT * From Користувач";
                //  OleDbCommand comand = new OleDbCommand(ListUserN, myConnection);
                //  OleDbDataReader ListUserR = comand.ExecuteReader();
                //   dataGrid.ItemsSource = ;
                //  adap.Update(ds.Tables[0]);
                //   myConnection.Close();
            }

            private void Exit(object sender, RoutedEventArgs e)
            {
                // MainWindow wnd = new MainWindow();
                MainWindow wnd = (MainWindow)System.Windows.Application.Current.MainWindow;
                wnd.EntryV1.Source = new Uri("Empty.xaml", UriKind.RelativeOrAbsolute);
                GlobalPer.VisiblBut = true;
                wnd.TEstMet();
                wnd.Exit1.Visibility = Visibility.Visible;

            }
        }
    }*/
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bd.mdb;";
        private const string tableName = "Користувач";

        private DataTable dataTable;
        private OleDbDataAdapter dataAdapter;

        public AddData()
        {
            InitializeComponent();
            LoadTableNames();
            LoadDataFromDatabase("Користувач");
        }

        private void LoadDataFromDatabase(string tableName)
        {
            dataTable = new DataTable();
            dataAdapter = new OleDbDataAdapter($"SELECT * FROM {tableName}", connectionString);
            dataAdapter.Fill(dataTable);

            dataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void SaveChangesToDatabase()
        {
            try
            {
                OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
                dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();

                dataAdapter.Update(dataTable);
                MessageBox.Show("Зміни успішно збережені в базі даних.", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Помилка при оновленні бази даних: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            SaveChangesToDatabase();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            // MainWindow wnd = new MainWindow();
            MainWindow wnd = (MainWindow)System.Windows.Application.Current.MainWindow;
            wnd.EntryV1.Source = new Uri("Empty.xaml", UriKind.RelativeOrAbsolute);
            GlobalPer.VisiblBut = true;
            wnd.TEstMet();
            wnd.Exit1.Visibility = Visibility.Visible;

        }
        private void LoadTableNames()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DataTable schema = connection.GetSchema("Tables");

                    foreach (DataRow row in schema.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        comboBoxTables.Items.Add(tableName);
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show($"Помилка при завантаженні таблиць: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void comboBoxTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTable = comboBoxTables.SelectedItem.ToString();
            LoadDataFromDatabase(selectedTable);
        }
    }
}