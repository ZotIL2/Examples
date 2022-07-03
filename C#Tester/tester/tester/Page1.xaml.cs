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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public static string connectStringBd = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bd.mdb;";
        private OleDbConnection myConnection;
        string[] vid = { "ТЧ1", "ТЧ2", "ТЧ3" };
        int i = 0;
        bool incorrect = false;
        bool visible = true;
        bool visible1 = true;
        private bool handle = true;
        public Page1()
        {
            InitializeComponent();
            Vidil.Visibility = Visibility.Collapsed;
            textBox.Visibility = Visibility.Collapsed;
            passwordBox.Visibility = Visibility.Collapsed;
            textBox2.Visibility = Visibility.Collapsed;
            Pocada.Visibility = Visibility.Collapsed;
            label.Visibility = Visibility.Collapsed;
            label1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;
            label3.Visibility = Visibility.Collapsed;
            label4.Visibility = Visibility.Collapsed;
            button.Visibility = Visibility.Collapsed;
            LUser.Visibility = Visibility.Collapsed;
            ListUser.Visibility = Visibility.Collapsed;
            myConnection = new OleDbConnection(connectStringBd);
            myConnection.Open();
            string test = "SELECT Посада From Посада";
            OleDbCommand comand = new OleDbCommand(test, myConnection);
            OleDbDataReader reader = comand.ExecuteReader();
            while (reader.Read())
            {
                Pocada.Items.Add(reader[0].ToString());
            }
            
            while (i < 3)
            {
               
                Vidil.Items.Add(vid[i]);
                ++i;
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
           // MainWindow wnd = new MainWindow();
            MainWindow wnd = (MainWindow)Application.Current.MainWindow;
            wnd.EntryV1.Source = new Uri("Empty.xaml", UriKind.RelativeOrAbsolute);
            GlobalPer.VisiblBut = true;
            wnd.TEstMet();
            wnd.Exit1.Visibility = Visibility.Visible;

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Pocada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (visible == true && visible1 != false) {

                Vidil.Visibility = Visibility.Visible;
                textBox.Visibility = Visibility.Visible;
                passwordBox.Visibility = Visibility.Visible;
                textBox2.Visibility = Visibility.Visible;
                Pocada.Visibility = Visibility.Visible;
                label.Visibility = Visibility.Visible;
                label1.Visibility = Visibility.Visible;
                label2.Visibility = Visibility.Visible;
                label3.Visibility = Visibility.Visible;
                label4.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Visible;
                visible = false;
            }
            else
            {
                visible = true;
                Vidil.Visibility = Visibility.Collapsed;
                textBox.Visibility = Visibility.Collapsed;
                passwordBox.Visibility = Visibility.Collapsed;
                textBox2.Visibility = Visibility.Collapsed;
                Pocada.Visibility = Visibility.Collapsed;
                label.Visibility = Visibility.Collapsed;
                label1.Visibility = Visibility.Collapsed;
                label2.Visibility = Visibility.Collapsed;
                label3.Visibility = Visibility.Collapsed;
                label4.Visibility = Visibility.Collapsed;
                button.Visibility = Visibility.Collapsed;
            }

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

            if (textBox.Text != null && textBox2.Text != null && passwordBox.Password != null && Vidil.SelectedIndex != -1 && Pocada.SelectedIndex != -1) {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = myConnection;
                //cmd.CommandText = "INSERT INTO Користувач(ПІБ, Пароль, Дорога,Відділ)VALUES(@param1,@param2,@param3,@param4)";
                int p = Pocada.SelectedIndex + 1;
                cmd.CommandText = string.Format("INSERT INTO Користувач(Посадаід,ПІБ, Пароль, Дорога,Відділ)Values('{0}','{1}','{2}','{3}','{4}')", p, textBox.Text, passwordBox.Password, textBox2.Text, Vidil.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Реєстрація пройшла успішно!");
            }
            else { MessageBox.Show("Введіть всі поля!"); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = (MainWindow)Application.Current.MainWindow;
            if (User.Text != "" && passwordBox1.Password != "")
            {
                string test = "SELECT ПІБ,Пароль From Користувач";
                OleDbCommand comand = new OleDbCommand(test, myConnection);
                OleDbDataReader chekpib = comand.ExecuteReader();
                while (chekpib.Read())
                {
                    if (User.Text == chekpib[0].ToString() && passwordBox1.Password == chekpib[1].ToString())
                    {
                        //MessageBox.Show("Verify");
                        incorrect = true;
                        GlobalPer.NameUser = User.Text;
                        wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);

                        break;
                    }
                }
                if(incorrect == false)
                {
                    MessageBox.Show("Невірні дані!");
                }
            }
            else { MessageBox.Show("Введіть дані користувача!"); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (visible1 == true && visible != false)
            {

                LUser.Visibility = Visibility.Visible;
                ListUser.Visibility = Visibility.Visible;
                visible1 = false;
                string ListUserN = "SELECT ПІБ From Користувач";
                OleDbCommand comand = new OleDbCommand(ListUserN, myConnection);
                OleDbDataReader ListUserR = comand.ExecuteReader();
                while (ListUserR.Read()) {
                    ListUser.Items.Add(ListUserR[0].ToString());
                }

            }
            else {
                LUser.Visibility = Visibility.Collapsed;
                ListUser.Visibility = Visibility.Collapsed;
                visible1 = true;
            }
        }

        private void ListUser_DropDownClosed(object sender, EventArgs e)
        {
            User.Text = ListUser.Text;
        }
    }
}
