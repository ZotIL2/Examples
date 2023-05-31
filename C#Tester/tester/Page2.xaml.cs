using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tester
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public static string connectStringBd = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bd.mdb;";
        private OleDbConnection myConnection;
        int i = 0;
        public Page2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectStringBd);
            myConnection.Open();
            //TestRes.Visibility = Visibility.Collapsed;
            // ResText.Visibility = Visibility.Collapsed;

            Name_us.Text = GlobalPer.NameUser;
            string test = "SELECT НазвЕкзам From Тестирования";
            OleDbCommand comand = new OleDbCommand(test, myConnection);
            OleDbDataReader reader = comand.ExecuteReader(); 
            while (reader.Read())
            {

                testU.Items.Add(reader[0].ToString());
            }
            myConnection.Close();
            myConnection.Open();
            string test1 = "SELECT Тип From ТипЭкзамена";
            OleDbCommand comand1 = new OleDbCommand(test1, myConnection);
            OleDbDataReader reader1 = comand1.ExecuteReader();
            while (reader1.Read())
            {
                testTip.Items.Add(reader1[0].ToString());
            }
            string SRes = $"SELECT top 2 ПІБ, Тест, Тип_Тест, Проц_прав,  НомерРезультата FROM Результати WHERE ПІБ = '{GlobalPer.NameUser}' GROUP BY ПІБ, НомерРезультата, Тест, Проц_прав, Тип_Тест ORDER BY НомерРезультата DESC";
            OleDbCommand comand2 = new OleDbCommand(SRes, myConnection);
            OleDbDataReader reader2 = comand2.ExecuteReader();
          /*  if (reader2.Read() == false)
            {
                TestRes.Visibility = Visibility.Collapsed;
                ResText.Visibility = Visibility.Collapsed;
                LabRes.Visibility = Visibility.Collapsed;
            }
            else
            {*/
                while (reader2.Read())
                {
                    TestRes.Items.Add(reader2[1].ToString());
                }
           // }
            
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StartTest(object sender, RoutedEventArgs e)
        {

            if (testU.SelectedIndex == -1 || testTip.SelectedIndex == -1)
            {
                MessageBox.Show("Оберіть тест!");
            }
            else
            {
                GlobalPer.IdTest = testU.SelectedIndex;
                GlobalPer.IdType = testTip.SelectedIndex;
                GlobalPer.NameType = testTip.SelectedValue.ToString();
                GlobalPer.TestVibor = testU.SelectedValue.ToString();

                if (GlobalPer.IdTest == 0 && GlobalPer.IdType == 4 || GlobalPer.IdTest == 1 && GlobalPer.IdType == 4 || GlobalPer.IdTest == 2 && GlobalPer.IdType == 4 || GlobalPer.IdTest == 3 && GlobalPer.IdType == 4 || GlobalPer.IdTest == 4 && GlobalPer.IdType == 4 || GlobalPer.IdTest == 5 && GlobalPer.IdType == 4 || GlobalPer.IdTest == 6 && GlobalPer.IdType == 4 || GlobalPer.IdTest == 7 && GlobalPer.IdType == 4 || GlobalPer.IdTest == 8 && GlobalPer.IdType == 4)
                {
                    MessageBox.Show("Тип тестування не був додан!");
                }
                else
                {
                    MainWindow wnd = (MainWindow)Application.Current.MainWindow;
                    wnd.EntryV1.Source = new Uri("Maintest.xaml", UriKind.RelativeOrAbsolute);
                }
            }
        }

        private void TestRes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            string SRes = $"SELECT top 2 ПІБ, Тест, Тип_Тест, Проц_прав,  НомерРезультата FROM Результати WHERE ПІБ = '{GlobalPer.NameUser}' GROUP BY ПІБ, НомерРезультата, Тест, Проц_прав, Тип_Тест ORDER BY НомерРезультата DESC";
            //string SRes = $"SELECT ПІБ, Тест, Проц_прав, Тип_Тест, Сдав FROM Результати Where ПІБ = '{GlobalPer.NameUser}'";
            OleDbCommand comand2 = new OleDbCommand(SRes, myConnection);
            OleDbDataReader reader2 = comand2.ExecuteReader();
            if (TestRes.SelectedIndex == 0)
            {
                reader2.Read();
                ResText.Text = $"{reader2[0].ToString()}, \rТест = {reader2[1].ToString()}, \rТип тесту = {reader2[2].ToString()}, \rВідсоток вірних відповідей={reader2[3].ToString()}";
            }
            if (TestRes.SelectedIndex == 1)
            {
                reader2.Read();
                reader2.Read();
                ResText.Text = $"{reader2[0].ToString()}, \rТест = {reader2[1].ToString()}, \rТип тесту = {reader2[2].ToString()}, \rВідсоток вірних відповідей={reader2[3].ToString()}";
            }
        }

        private void exit_T_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = (MainWindow)Application.Current.MainWindow;
            wnd.EntryV1.Source = new Uri("Empty.xaml", UriKind.RelativeOrAbsolute);
            GlobalPer.VisiblBut = true;
            wnd.TEstMet();
            wnd.Exit1.Visibility = Visibility.Visible;
        }


        private void Report1(object sender, RoutedEventArgs e)
        {
            Report taskWindow = new Report();
            taskWindow.Show();
        }
    }
}
