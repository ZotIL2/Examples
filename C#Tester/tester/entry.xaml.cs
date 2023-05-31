using System;
using System.Collections.Generic;
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
using System.Data.OleDb;

namespace tester
{
    /// <summary>
    /// Логика взаимодействия для entry.xaml
    /// </summary>
  
    public partial class entry : Page
    {
        public static string connectStringBd = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bd.mdb;";
        private OleDbConnection myConnection;
        public string TestVibor;
        public static string index;
       
        public entry()
        {
          //  this.Visibility = Visibility.Visible;
            InitializeComponent();
            myConnection = new OleDbConnection(connectStringBd);
            myConnection.Open();
           // int i = 0;
            string test = "SELECT НазвЕкзам From Тестирования";
            OleDbCommand comand = new OleDbCommand(test, myConnection);
            OleDbDataReader reader = comand.ExecuteReader();
            while (reader.Read())
            {

                ListTest.Items.Add(reader[0].ToString());
            }
        }
        public OleDbDataReader Get_Res(string request, OleDbConnection myConnection)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = myConnection;
            cmd.CommandText = request;
            OleDbDataReader read = cmd.ExecuteReader();
            return read;
        }

    private void ListTest_Initialized(object sender, EventArgs e)
        {
           
        }

        private void ListTest_Unloaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = (MainWindow)Application.Current.MainWindow;
            // testpage Tpage = new testpage();
            //testpage Tpage = (testpage)Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().EntryV1.Content;
           
            index = ListTest.SelectedIndex.ToString();
            if (index.ToString() == (-1).ToString())
            {
                MessageBox.Show("Оберіть тест!");
            }
            else
            {
                wnd.EntryV1.Source = new Uri("testpage.xaml", UriKind.RelativeOrAbsolute);
                GlobalPer.TestVibor = ListTest.SelectedValue.ToString();
                //testpage Tpage = (testpage)Application.Current.Windows.OfType<testpage>();
                string q1 = "SELECT Питання From Питання Where ПитанняНомер=1";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread = Get_Res(q1, myConnection);
                qread.Read();
                GlobalPer.Que = qread.GetValue(0).ToString();
                string q2 = "SELECT Відповідь From Відповідь Where Питанняід=1";
                OleDbDataReader qread1 = Get_Res(q2, myConnection);
                string[] answer = { "1", "2", "3" };
                int i = 0;
                while (qread1.Read())
                {
                    answer[i] = qread1.GetValue(0).ToString();
                    i++;
                }
                GlobalPer.TestQ1 = answer[0];
                GlobalPer.TestQ2 = answer[1];
                GlobalPer.TestQ3 = answer[2];
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
           
            MainWindow wnd = (MainWindow)Application.Current.MainWindow;
            GlobalPer.VisiblBut = true;
            wnd.TEstMet();
            wnd.EntryV1.Source = new Uri("Empty.xaml", UriKind.RelativeOrAbsolute);
            //this.Visibility = Visibility.Collapsed;

        }
    }
}
