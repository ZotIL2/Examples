using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.Windows.Documents;
using System.Data.OleDb;
using System;

namespace tester
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public static string connectStringBd = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bd.mdb;";
        private OleDbConnection myConnection;
        string pass = "df";
        public Report()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectStringBd);
            myConnection.Open();
            string SRes = $"SELECT ПІБ,Код_ек,Тест, Проц_прав, Тип_Тест, Сдав  FROM Результати Where ПІБ = '{GlobalPer.NameUser}'; ";
            OleDbCommand comand2 = new OleDbCommand(SRes, myConnection);
            OleDbDataReader reader2 = comand2.ExecuteReader();
            DateTime now = DateTime.Now;
            string Title = DateTime.Now.ToString("HH:mm:ss");
            Data.Content = Title;
            DateD.Content = now.ToString("dd.MM.yyyy");
            while (reader2.Read())
            {
                tB.Text += $"\r{reader2[0]}\r";
                tB1.Text += $"\r{reader2[1]}\r";
                tB2.Text += $"{reader2[2]}\r";
                tB3.Text += $"\r{reader2[3]}\r";
                tB4.Text += $"\r{reader2[4]}\r";
                bool i = (bool)reader2[5];
                if(i == false)
                {
                    pass = "Ні";
                }
                else { pass = "Tak"; }
                tB5.Text += $"\r{pass}\r";

            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XPS Files (*.xps)|*.xps";
            if (sfd.ShowDialog() == true)
            {
                XpsDocument doc = new XpsDocument(sfd.FileName, FileAccess.Write);
                XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
                writer.Write(documentViewer.Document as FixedDocument);
                doc.Close();
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XPS Files (*.xps)|*.xps";

            if (ofd.ShowDialog() == true)
            {
                XpsDocument doc = new XpsDocument(ofd.FileName, FileAccess.Read);
                documentViewer.Document = doc.GetFixedDocumentSequence();
            }
        }
    }
}
