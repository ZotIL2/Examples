using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace tester
{
    /// <summary>
    /// Логика взаимодействия для MainTest.xaml
    /// </summary>
    /// 
    public partial class MainTest : Page
    {
        public static string connectStringBd = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bd.mdb;";
        private OleDbConnection myConnection;
        int min =  9;
        int sec = 59;
        int vcego = 20;
        int ch_sdal;
        string rightanswer;
        int iq = 0;
        int numberq = 1;
        string q1;
        bool checknum;
        string q2;
        int i = 0;
        int percent = 0;
        OleDbDataReader qread2;
        private DispatcherTimer dispatcherTimer;
        MainWindow wnd = (MainWindow)Application.Current.MainWindow;

        public MainTest()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectStringBd);
            myConnection.Open();
            checknum = true;
            Name_us.Text = GlobalPer.NameUser;
            ChooseT.Text = GlobalPer.TestVibor;
            NumQ.Content = 20;
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();      
                string q1 = "SELECT Питання From Питання Where ПитанняНомер=1";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread = Get_Res(q1, myConnection);
                qread.Read();
            
                Quention.Text = qread.GetValue(0).ToString();
                string q2 = "SELECT Відповідь From Відповідь Where Питанняід=1";
                OleDbDataReader qread1 = Get_Res(q2, myConnection);
                string[] answer = { "1", "2", "3" };
                int i = 0;
                while (qread1.Read())
                {
                    answer[i] = qread1.GetValue(0).ToString();
                    i++;
                }
                TextTestQ1.Text = answer[0];
                TextTestQ2.Text = answer[1];
                TextTestQ3.Text = answer[2];
                TestQ4.Visibility = Visibility.Collapsed;
            CheckAnswer(numberq);
        }
        public OleDbDataReader Get_Res(string request, OleDbConnection myConnection)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = myConnection;
            cmd.CommandText = request;
            OleDbDataReader read = cmd.ExecuteReader();
            return read;
        }
        void CheckAnswer(int numberq)
        {

            string rightq = $"SELECT Правильна_відповідь, Питанняід, Відповідь FROM Відповідь Where Питанняід = {numberq} and Правильна_відповідь = true";
            OleDbDataReader qread = Get_Res(rightq, myConnection);
            while (qread.Read())
            {
                rightanswer = qread.GetValue(2).ToString();
            }
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           
            sec = sec - 1;
                if (sec <= 0)
                {
                if (min <= 0 && sec <= 0)
                {
                    Timer.Content = $"{min}:{sec}";
                    dispatcherTimer.Stop();
                    MessageBox.Show("Тест завершено, час вийшов!");
                    Res();
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else
                {
                    min = min - 1;
                    sec = 59;
                }
                }
                Timer.Content = $"{min}:{sec}";
        }

        private void exit_T_Click(object sender, RoutedEventArgs e)
        {
            string sMessageBoxText = "Ви дійсно бажаєте вийти?\rРезультат не збережеться!";
            string sCaption = "Попередження";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    MainWindow wnd = (MainWindow)Application.Current.MainWindow;
                    wnd.EntryV1.Source = new Uri("Page1.xaml", UriKind.RelativeOrAbsolute);
                    break;
                case MessageBoxResult.No:
                    
                    break;
            }
          
        }
        void check(int numberq)
        {
            string[] answer = { "1", "2", "3", "4", "5" };
            q2 = $"SELECT Відповідь From Відповідь Where Питанняід={numberq}";
            qread2 = Get_Res(q2, myConnection);
            i = 0;
            while (qread2.Read())
            {
                answer[i] = qread2.GetValue(0).ToString();
                i++;
            }
            TextTestQ1.Text = answer[0];
            if (answer[1] != 2.ToString() || answer[1] == null)
            {
                TestQ2.Visibility = Visibility.Visible;
                TextTestQ2.Text = answer[1];
            }
            else { TestQ2.Visibility = Visibility.Collapsed; }
            if (answer[3] != 4.ToString() || answer[3] == null)
            {
                TestQ4.Visibility = Visibility.Visible;
                TextTestQ4.Text = answer[3];
            }
            else { TestQ4.Visibility = Visibility.Collapsed; }
            if (answer[2] != 3.ToString() || answer[2] == null)
            {
                TestQ3.Visibility = Visibility.Visible;
                TextTestQ3.Text = answer[2];
            }
            else { TestQ3.Visibility = Visibility.Collapsed; }
        }
        void Res()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = myConnection;
            if (percent  >= 80)
            {
                ch_sdal = 1;
            } else { ch_sdal = 0; }
            cmd.CommandText = string.Format("INSERT INTO Результати(ПІБ,Код_ек,Тест,Проц_прав,Тип_Тест,Сдав)Values('{0}','{1}','{2}','{3}','{4}','{5}')", GlobalPer.NameUser,GlobalPer.IdTest+1,GlobalPer.TestVibor,percent,GlobalPer.NameType,ch_sdal);
            cmd.ExecuteNonQuery();
            MessageBox.Show($"Іспит склав на {percent}%!");
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ColQ.Content = --vcego;
            CheckAnswer(numberq);
            if (rightanswer == TextTestQ1.Text && TestQ1.IsChecked == true || (rightanswer == TextTestQ2.Text) && TestQ2.IsChecked == true || (rightanswer == TextTestQ3.Text) && TestQ3.IsChecked == true || (rightanswer == TextTestQ4.Text) && TestQ4.IsChecked == true || rightanswer == GlobalPer.TestQ2 && TestQ2.IsChecked == true)
            {
                iq++;
                percent = percent + 5;
                Result.Content = $"{percent}%";
                NumTRQ.Content = iq;

            }
            numberq++;
            if (numberq == 190)
            {
                numberq++;
            }
            TextTestQ1.Foreground = Brushes.White;
            TextTestQ2.Foreground = Brushes.White;
            TextTestQ3.Foreground = Brushes.White;
            TextTestQ4.Foreground = Brushes.White;
            if(GlobalPer.IdTest == 0 && GlobalPer.IdType ==0) { 
            q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 1");//SELECT Que From Питання Where ПитанняНомер=1
            OleDbDataReader qread1 = Get_Res(q1, myConnection);
            check(numberq);
            if (numberq == 21) // последний вопрос
            {
                dispatcherTimer.Stop();
                numberq = 20;
                    Res();
                MessageBox.Show("Тестування завершено!");
                wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
            }
            else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 0 && GlobalPer.IdType == 1)
            {
                if(checknum == true)
                {
                    numberq = 20;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 1";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 39) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 38;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 0 && GlobalPer.IdType == 2)
            {
                if (checknum == true)
                {
                    numberq = 41;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 1";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if (numberq == 60) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 59;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 0 && GlobalPer.IdType == 3)
            {
                if (checknum == true)
                {
                    numberq = 61;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 1";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 80) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 79;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 1 && GlobalPer.IdType == 0) // ID = 1 Posada 
            {
                if (checknum == true)
                {
                    numberq = 91;
                    checknum = false;
                }
                q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 2");//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 110) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 109;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 1 && GlobalPer.IdType == 1)
            {
                if (checknum == true)
                {
                    numberq = 111;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 2";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 130) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 129;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 1 && GlobalPer.IdType == 2)
            {
                if (checknum == true)
                {
                    numberq = 132;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 2";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 151) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 150;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 1 && GlobalPer.IdType == 3)
            {
                if (checknum == true)
                {
                    numberq = 151;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 2";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 170) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 169;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 2 && GlobalPer.IdType == 0) // ID = 2 Posada 
            {
                if (checknum == true)
                {
                    numberq = 179;
                    checknum = false;
                }
                q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 3");//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 199) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 198;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 2 && GlobalPer.IdType == 1)
            {
                if (checknum == true)
                {
                    numberq = 200;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 3";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 219) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 218;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 2 && GlobalPer.IdType == 2)
            {
                if (checknum == true)
                {
                    numberq = 220;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 3";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 239) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 238;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 2 && GlobalPer.IdType == 3)
            {
                if (checknum == true)
                {
                    numberq = 240;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 3";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 259) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 258;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 3 && GlobalPer.IdType == 0) // ID = 3 Posada 
            {
                if (checknum == true)
                {
                    numberq = 268;
                    checknum = false;
                }
                q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 4");//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 287) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 286;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 3 && GlobalPer.IdType == 1)
            {
                if (checknum == true)
                {
                    numberq = 288;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 4";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 307) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 306;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 3 && GlobalPer.IdType == 2)
            {
                if (checknum == true)
                {
                    numberq = 307;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 4";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 326) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 325;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 3 && GlobalPer.IdType == 3)
            {
                if (checknum == true)
                {
                    numberq = 326;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 4";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 345) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 344;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 4 && GlobalPer.IdType == 0) // ID = 4 Posada 
            {
                if (checknum == true)
                {
                    numberq = 357;
                    checknum = false;
                }
                q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 5");//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 376) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 375;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 4 && GlobalPer.IdType == 1)
            {
                if (checknum == true)
                {
                    numberq = 377;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 5";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 396) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 395;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 4 && GlobalPer.IdType == 2)
            {
                if (checknum == true)
                {
                    numberq = 397;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 5";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 416) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 415;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 4 && GlobalPer.IdType == 3)
            {
                if (checknum == true)
                {
                    numberq = 417;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 5";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 436) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 435;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 5 && GlobalPer.IdType == 0) // ID = 5 Posada 
            {
                if (checknum == true)
                {
                    numberq = 446;
                    checknum = false;
                }
                q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 6");//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 465) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 464;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 5 && GlobalPer.IdType == 1)
            {
                if (checknum == true)
                {
                    numberq = 466;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 6";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 485) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 484;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 5 && GlobalPer.IdType == 2)
            {
                if (checknum == true)
                {
                    numberq = 486;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 6";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 505) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 504;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 5 && GlobalPer.IdType == 3)
            {
                if (checknum == true)
                {
                    numberq = 506;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 6";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 525) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 524;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 6 && GlobalPer.IdType == 0) // ID = 6 Posada 
            {
                if (checknum == true)
                {
                    numberq = 535;
                    checknum = false;
                }
                q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 7");//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 554) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 553;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 6 && GlobalPer.IdType == 1)
            {
                if (checknum == true)
                {
                    numberq = 555;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 7";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 574) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 573;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 6 && GlobalPer.IdType == 2)
            {
                if (checknum == true)
                {
                    numberq = 575;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 7";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 594) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 593;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 6 && GlobalPer.IdType == 3)
            {
                if (checknum == true)
                {
                    numberq = 595;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 7";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 614) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 613;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 7 && GlobalPer.IdType == 0) // ID = 7 Posada 
            {
                if (checknum == true)
                {
                    numberq = 624;
                    checknum = false;
                }
                q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 8");//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 643) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 642;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 7 && GlobalPer.IdType == 1)
            {
                if (checknum == true)
                {
                    numberq = 644;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 8";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 663) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 662;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 7 && GlobalPer.IdType == 2)
            {
                if (checknum == true)
                {
                    numberq = 664;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 8";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 683) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 682;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 7 && GlobalPer.IdType == 3)
            {
                if (checknum == true)
                {
                    numberq = 684;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 8";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 703) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 702;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 8 && GlobalPer.IdType == 0) // ID = 8 Posada 
            {
                if (checknum == true)
                {
                    numberq = 713;
                    checknum = false;
                }
                q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 9");//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 732) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 731;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 8 && GlobalPer.IdType == 1)
            {
                if (checknum == true)
                {
                    numberq = 733;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 9";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 752) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 751;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 8 && GlobalPer.IdType == 2)
            {
                if (checknum == true)
                {
                    numberq = 753;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 9";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 772) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 771;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
            if (GlobalPer.IdTest == 8 && GlobalPer.IdType == 3)
            {
                if (checknum == true)
                {
                    numberq = 773;
                    checknum = false;
                }
                q1 = $"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 9";//SELECT Que From Питання Where ПитанняНомер=1
                OleDbDataReader qread1 = Get_Res(q1, myConnection);
                check(numberq);
                if ((numberq) == 792) // последний вопрос
                {
                    dispatcherTimer.Stop();
                    numberq = 791;
                    Res();
                    MessageBox.Show("Тестування завершено!");
                    wnd.EntryV1.Source = new Uri("Page2.xaml", UriKind.RelativeOrAbsolute);
                }
                else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
            }
        }
        private void TestQ1_Checked(object sender, RoutedEventArgs e)
        {

            if (TestQ1.IsChecked == true)
            {
                TextTestQ1.Foreground = Brushes.Green;
                TextTestQ2.Foreground = Brushes.White;
                TextTestQ3.Foreground = Brushes.White;
                TextTestQ4.Foreground = Brushes.White;

            }
            else { TextTestQ1.Foreground = Brushes.White; }

        }

        private void TestQ2_Checked(object sender, RoutedEventArgs e)
        {

            if (TestQ2.IsChecked == true)
            {
                TextTestQ2.Foreground = Brushes.Green;
                TextTestQ1.Foreground = Brushes.White;
                TextTestQ3.Foreground = Brushes.White;
                TextTestQ4.Foreground = Brushes.White;

            }
            else { TextTestQ2.Foreground = Brushes.White; }


        }

        private void TestQ3_Checked(object sender, RoutedEventArgs e)
        {

            if (TestQ3.IsChecked == true)
            {
                TextTestQ3.Foreground = Brushes.Green; 
                TextTestQ1.Foreground = Brushes.White;
                TextTestQ2.Foreground = Brushes.White;
                TextTestQ4.Foreground = Brushes.White;

            }
            else { TextTestQ3.Foreground = Brushes.White; }



        }
        private void TestQ4_Checked(object sender, RoutedEventArgs e)
        {
          
            if (TestQ4.IsChecked == true)
            {
                TextTestQ4.Foreground = Brushes.Green;
                TextTestQ1.Foreground = Brushes.White;
                TextTestQ2.Foreground = Brushes.White;
                TextTestQ3.Foreground = Brushes.White;

            }
            else { TextTestQ4.Foreground = Brushes.White; }


        }
    }
}

