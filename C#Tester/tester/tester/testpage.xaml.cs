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
    /// Логика взаимодействия для testpage.xaml
    /// </summary>
    public partial class testpage : Page
    {
        public static string connectStringBd = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bd.mdb;";
        private OleDbConnection myConnection1;
        string rightanswer;
        int iq = 0;
        int numberq = 1;
        int vcego = 89;
        string q1;
        string q2;
        bool p = false;
        int i = 0;
        bool tq = false, tq1 = false, tq2 = false, tq3 = false;
        OleDbDataReader qread2;
        MainWindow wnd = (MainWindow)Application.Current.MainWindow;
        public testpage()
        {
            InitializeComponent();
        TestPlay();
        myConnection1 = new OleDbConnection(connectStringBd);
        myConnection1.Open();
            // CheckAnswer();
        
            vce.Content = vcego;
            switch (entry.index)
            {
                case "0":
                    numberq = 1;
                    vcego = 89;
                    break;
                case "1":
                    vcego = 90;
                    numberq = 89;
                    break;
                case "2":
                    vcego = 89;
                    numberq = 178;
                    break;
                case "3":
                    vcego = 90;
                    numberq = 267;
                    break;
                case "4":
                    vcego = 90;
                    numberq = 356;
                    break;
                case "5":
                    vcego = 90;
                    numberq = 445;
                    break;
                case "6":
                    vcego = 90;
                    numberq = 534;
                    break;
                case "7":
                    vcego = 90;
                    numberq = 623;
                    break;
                case "8":
                    vcego = 90;
                    numberq = 712;
                    break;

            }
                    //numberq = 79;
            }
        public OleDbDataReader Get_Res(string request, OleDbConnection myConnection)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = myConnection;
            cmd.CommandText = request;
            OleDbDataReader read = cmd.ExecuteReader();
            return read;
          
        }
        void CheckAnswer()
        {

            string rightq = $"SELECT Правильна_відповідь, Питанняід, Відповідь FROM Відповідь Where Питанняід = {numberq} and Правильна_відповідь = true";
            OleDbDataReader qread = Get_Res(rightq, myConnection1);
            qread.Read();
         
            if (q1 == null) { rightanswer = GlobalPer.TestQ2;
                if (rightanswer == TextTestQ2.Text && TestQ2.IsChecked == true) { GlobalPer.start = true; }
            }
           
            else
            {
                rightanswer = qread.GetValue(2).ToString();
            }
        }
        public void TestPlay()
        {
            //entry ent = (entry)Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().EntryV1.Content;
            TestNow.Text = GlobalPer.TestVibor;
            TextTestQ1.Text = GlobalPer.TestQ1;
            TextTestQ2.Text = GlobalPer.TestQ2;
            TextTestQ3.Text = GlobalPer.TestQ3;
            Quention.Text = GlobalPer.Que;
            TestQ4.Visibility = Visibility.Collapsed;
        }
        private void Exit(object sender, RoutedEventArgs e)
        {

        }
        void check()
        {
            string[] answer = { "1", "2", "3", "4", "5" };
            q2 = $"SELECT Відповідь From Відповідь Where Питанняід={numberq}";
            qread2 = Get_Res(q2, myConnection1);
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
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (tq == false && tq1 == false && tq2 == false && tq3 == false)
            {
                MessageBox.Show("Віберіть відповідь");
            }
            else
            {

                vce.Content = --vcego;
                string rightq = $"SELECT Правильна_відповідь, Питанняід, Відповідь FROM Відповідь Where Питанняід = {numberq} and Правильна_відповідь = true";
                OleDbDataReader qread = Get_Res(rightq, myConnection1);
                qread.Read();
                rightanswer = qread.GetValue(2).ToString();
                if (GlobalPer.start == true && entry.index != "0")
                {
                    iq++;
                    VirnuxVid.Content = iq;
                    GlobalPer.start = false;

                }
                if (rightanswer == TextTestQ1.Text && TestQ1.IsChecked == true || (rightanswer == TextTestQ2.Text) && TestQ2.IsChecked == true || (rightanswer == TextTestQ3.Text) && TestQ3.IsChecked == true || (rightanswer == TextTestQ4.Text) && TestQ4.IsChecked == true || rightanswer == GlobalPer.TestQ2 && TestQ2.IsChecked == true)
                {
                    iq++;
                    VirnuxVid.Content = iq;

                }


                numberq++;
                if (numberq == 190)
                {
                    numberq++;
                }
                switch (entry.index)
                {
                    case "0":
                        TextTestQ1.Foreground = Brushes.White;
                        TextTestQ2.Foreground = Brushes.White;
                        TextTestQ3.Foreground = Brushes.White;
                        TextTestQ4.Foreground = Brushes.White;

                        string count = $"SELECT  count(Питання) From Питання GROUP BY Посадаід";
                        q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 1");//SELECT Que From Питання Where ПитанняНомер=1
                        OleDbDataReader qread1 = Get_Res(q1, myConnection1);
                        OleDbDataReader countr = Get_Res(count, myConnection1);
                        countr.Read();
                        //string q2 = $"SELECT Відповідь From Відповідь Where Питанняід={numberq}";
                        //qread2 = Get_Res(q2, myConnection1);
                        check();
                        //  string[] answer = { "1", "2", "3", "4", "5" };
                        /* int i = 0;
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
                          */
                        if (numberq == Convert.ToInt32(countr.GetValue(0)) + 1) // последний вопрос
                        {
                            numberq = 89;
                            MessageBox.Show("Тренування завершено!");
                            wnd.EntryV1.Source = new Uri("entry.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }


                        break;
                    case "1":

                        TextTestQ1.Foreground = Brushes.White;
                        TextTestQ2.Foreground = Brushes.White;
                        TextTestQ3.Foreground = Brushes.White;
                        TextTestQ4.Foreground = Brushes.White;
                        count = $"SELECT  count(Питання) From Питання GROUP BY Посадаід";
                        q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 2");//SELECT Que From Питання Where ПитанняНомер=1
                        qread1 = Get_Res(q1, myConnection1);
                        countr = Get_Res(count, myConnection1);
                        countr.Read();
                        check();
                        if (numberq == Convert.ToInt32(countr.GetValue(0)) + 90) // последний вопрос
                        {
                            numberq = 178;
                            MessageBox.Show("Тренування завершено!");
                            wnd.EntryV1.Source = new Uri("entry.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }


                        break;
                    case "2":
                        TextTestQ1.Foreground = Brushes.White;
                        TextTestQ2.Foreground = Brushes.White;
                        TextTestQ3.Foreground = Brushes.White;
                        TextTestQ4.Foreground = Brushes.White;
                        count = $"SELECT  count(Питання) From Питання GROUP BY Посадаід";
                        q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 3");//SELECT Que From Питання Where ПитанняНомер=1
                        qread1 = Get_Res(q1, myConnection1);
                        countr = Get_Res(count, myConnection1);
                        countr.Read();
                        check();
                        if (numberq == Convert.ToInt32(countr.GetValue(0)) + 179) // последний вопрос
                        {
                            numberq = 267;
                            MessageBox.Show("Тренування завершено!");
                            wnd.EntryV1.Source = new Uri("entry.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }

                        break;
                    case "3":
                        TextTestQ1.Foreground = Brushes.White;
                        TextTestQ2.Foreground = Brushes.White;
                        TextTestQ3.Foreground = Brushes.White;
                        TextTestQ4.Foreground = Brushes.White;
                        count = $"SELECT  count(Питання) From Питання GROUP BY Посадаід";
                        q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 4");//SELECT Que From Питання Where ПитанняНомер=1
                        qread1 = Get_Res(q1, myConnection1);
                        countr = Get_Res(count, myConnection1);
                        countr.Read();
                        check();
                        if (numberq == Convert.ToInt32(countr.GetValue(0)) + 268) // последний вопрос
                        {
                            numberq = 356;
                            MessageBox.Show("Тренування завершено!");
                            wnd.EntryV1.Source = new Uri("entry.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
                        break;
                    case "4":
                        TextTestQ1.Foreground = Brushes.White;
                        TextTestQ2.Foreground = Brushes.White;
                        TextTestQ3.Foreground = Brushes.White;
                        TextTestQ4.Foreground = Brushes.White;
                        count = $"SELECT  count(Питання) From Питання GROUP BY Посадаід";
                        q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 5");//SELECT Que From Питання Where ПитанняНомер=1
                        qread1 = Get_Res(q1, myConnection1);
                        countr = Get_Res(count, myConnection1);
                        countr.Read();
                        check();
                        if (numberq == Convert.ToInt32(countr.GetValue(0)) + 357) // последний вопрос
                        {
                            numberq = 445;
                            MessageBox.Show("Тренування завершено!");
                            wnd.EntryV1.Source = new Uri("entry.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
                        break;
                    case "5":
                        TextTestQ1.Foreground = Brushes.White;
                        TextTestQ2.Foreground = Brushes.White;
                        TextTestQ3.Foreground = Brushes.White;
                        TextTestQ4.Foreground = Brushes.White;
                        count = $"SELECT  count(Питання) From Питання GROUP BY Посадаід";
                        q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 6");//SELECT Que From Питання Where ПитанняНомер=1
                        qread1 = Get_Res(q1, myConnection1);
                        countr = Get_Res(count, myConnection1);
                        countr.Read();
                        check();
                        if (numberq == Convert.ToInt32(countr.GetValue(0)) + 446) // последний вопрос
                        {
                            numberq = 534;
                            MessageBox.Show("Тренування завершено!");
                            wnd.EntryV1.Source = new Uri("entry.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
                        break;
                    case "6":
                        TextTestQ1.Foreground = Brushes.White;
                        TextTestQ2.Foreground = Brushes.White;
                        TextTestQ3.Foreground = Brushes.White;
                        TextTestQ4.Foreground = Brushes.White;
                        count = $"SELECT  count(Питання) From Питання GROUP BY Посадаід";
                        q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 7");//SELECT Que From Питання Where ПитанняНомер=1
                        qread1 = Get_Res(q1, myConnection1);
                        countr = Get_Res(count, myConnection1);
                        countr.Read();
                        check();
                        if (numberq == Convert.ToInt32(countr.GetValue(0)) + 535) // последний вопрос
                        {
                            numberq = 623;
                            MessageBox.Show("Тренування завершено!");
                            wnd.EntryV1.Source = new Uri("entry.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
                        break;
                    case "7":
                        TextTestQ1.Foreground = Brushes.White;
                        TextTestQ2.Foreground = Brushes.White;
                        TextTestQ3.Foreground = Brushes.White;
                        TextTestQ4.Foreground = Brushes.White;
                        count = $"SELECT  count(Питання) From Питання GROUP BY Посадаід";
                        q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 8");//SELECT Que From Питання Where ПитанняНомер=1
                        qread1 = Get_Res(q1, myConnection1);
                        countr = Get_Res(count, myConnection1);
                        countr.Read();
                        check();
                        if (numberq == Convert.ToInt32(countr.GetValue(0)) + 624) // последний вопрос
                        {
                            numberq = 712;
                            MessageBox.Show("Тренування завершено!");
                            wnd.EntryV1.Source = new Uri("entry.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
                        break;
                    case "8":
                        TextTestQ1.Foreground = Brushes.White;
                        TextTestQ2.Foreground = Brushes.White;
                        TextTestQ3.Foreground = Brushes.White;
                        TextTestQ4.Foreground = Brushes.White;
                        count = $"SELECT  count(Питання) From Питання GROUP BY Посадаід";
                        q1 = ($"SELECT Питання From Питання Where ПитанняНомер={numberq} and Посадаід = 9");//SELECT Que From Питання Where ПитанняНомер=1
                        qread1 = Get_Res(q1, myConnection1);
                        countr = Get_Res(count, myConnection1);
                        countr.Read();
                        check();
                        if (numberq == Convert.ToInt32(countr.GetValue(0)) + 713) // последний вопрос
                        {
                            numberq = 801;
                            MessageBox.Show("Тренування завершено!");
                            wnd.EntryV1.Source = new Uri("entry.xaml", UriKind.RelativeOrAbsolute);
                        }
                        else { qread1.Read(); Quention.Text = qread1.GetValue(0).ToString(); }
                        break;

                }

            }

        }

        private void TestQ1_Checked(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
            tq = true;
            if (TestQ1.IsChecked == true && rightanswer == TextTestQ1.Text)
            {
                TextTestQ1.Foreground = Brushes.Green;

            }
            else { TextTestQ1.Foreground = Brushes.Red;}

        }

        private void TestQ2_Checked(object sender, RoutedEventArgs e)
        {
            tq1 = true;
            CheckAnswer();
            if (TestQ2.IsChecked == true && rightanswer == TextTestQ2.Text)
            {
                TextTestQ2.Foreground = Brushes.Green;

            }
            else { TextTestQ2.Foreground = Brushes.Red; }


        }

        private void TestQ3_Checked(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
            tq2 = true;
            if (TestQ3.IsChecked == true && rightanswer == TextTestQ3.Text)
            {
                TextTestQ3.Foreground = Brushes.Green;

            }
            else { TextTestQ3.Foreground = Brushes.Red;}



        }
        private void TestQ4_Checked(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
            tq3 = true;
            if (TestQ4.IsChecked == true && rightanswer == TextTestQ4.Text)
            {
                TextTestQ4.Foreground = Brushes.Green;

            }
            else { TextTestQ4.Foreground = Brushes.Red; }


        }
    }
}

