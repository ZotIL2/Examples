using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Navigation;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Diagnostics;
using System.Data.OleDb;


namespace tester
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public static class GlobalPer
    {
        public static bool VisiblBut { get; set; }
        public static bool start { get; set; }
        public static string TestVibor { get; set; }
        public static string TestQ1 { get; set; }
        public static string TestQ2 { get; set; }
        public static string TestQ3 { get; set; }
        public static string Que { get; set; }
        public static string NameUser { get; set; }
        public static string NameType { get; set; }
        public static int IdTest { get; set; }
        public static int IdType { get; set; }

    }
    
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public static string connectStringBd = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Bd.mdb;";
        //  public static string connectStringBd = "Provider-Microsoft.Jet.OLEDB.4.0;Data Source=Bd.mdb;";
        //private OleDbConnection myConnection;



        /* private double _aspectRatio;
             private bool? _adjustingHeight = null;

             internal enum SWP
             {
                 NOMOVE = 0x0002
             }
             internal enum WM
             {
                 WINDOWPOSCHANGING = 0x0046,
                 EXITSIZEMOVE = 0x0232,
             }




             [StructLayout(LayoutKind.Sequential)]
             internal struct WINDOWPOS
             {
                 public IntPtr hwnd;
                 public IntPtr hwndInsertAfter;
                 public int x;
                 public int y;
                 public int cx;
                 public int cy;
                 public int flags;
             }

             [DllImport("user32.dll")]
             [return: MarshalAs(UnmanagedType.Bool)]
             internal static extern bool GetCursorPos(ref Win32Point pt);

             [StructLayout(LayoutKind.Sequential)]
             internal struct Win32Point
             {
                 public Int32 X;
                 public Int32 Y;
             };

             public static Point GetMousePosition() // mouse position relative to screen
             {
                 Win32Point w32Mouse = new Win32Point();
                 GetCursorPos(ref w32Mouse);
                 return new Point(w32Mouse.X, w32Mouse.Y);
             }


             private void Window_SourceInitialized(object sender, EventArgs ea)
             {
                 HwndSource hwndSource = (HwndSource)HwndSource.FromVisual((Window)sender);
                 hwndSource.AddHook(DragHook);

                 _aspectRatio = this.Width / this.Height;
             }

             private IntPtr DragHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
             {
                 switch ((WM)msg)
                 {
                     case WM.WINDOWPOSCHANGING:
                         {
                             WINDOWPOS pos = (WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(WINDOWPOS));

                             if ((pos.flags & (int)SWP.NOMOVE) != 0)
                                 return IntPtr.Zero;

                             Window wnd = (Window)HwndSource.FromHwnd(hwnd).RootVisual;
                             if (wnd == null)
                                 return IntPtr.Zero;

                             // determine what dimension is changed by detecting the mouse position relative to the 
                             // window bounds. if gripped in the corner, either will work.
                             if (!_adjustingHeight.HasValue)
                             {
                                 Point p = GetMousePosition();

                                 double diffWidth = Math.Min(Math.Abs(p.X - pos.x), Math.Abs(p.X - pos.x - pos.cx));
                                 double diffHeight = Math.Min(Math.Abs(p.Y - pos.y), Math.Abs(p.Y - pos.y - pos.cy));

                                 _adjustingHeight = diffHeight > diffWidth;
                             }

                             if (_adjustingHeight.Value)
                                 pos.cy = (int)(pos.cx / _aspectRatio); // adjusting height to width change
                             else
                                 pos.cx = (int)(pos.cy * _aspectRatio); // adjusting width to heigth change

                             Marshal.StructureToPtr(pos, lParam, true);
                             handled = true;
                         }
                         break;
                     case WM.EXITSIZEMOVE:
                         _adjustingHeight = null; // reset adjustment dimension and detect again next time window is resized
                         break;
                 }

                 return IntPtr.Zero;
             }
        */
       
        public MainWindow()
        {
            InitializeComponent();
           // myConnection = new OleDbConnection(connectStringBd);
           // myConnection.Open();
            // second.Show();

            //  this.SourceInitialized += Window_SourceInitialized;

        }
        private void Exit_Click_But(object sender, EventArgs e)
        {
            MessageBox.Show("ButtonClicked");
           
        }
        /* [DllImport("user32", EntryPoint = "SetWindowsHookExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
         public static extern int SetWindowsHookEx(int idHook, LowLevelKeyboardProcDelegate lpfn, int hMod, int dwThreadId);
         [DllImport("user32", EntryPoint = "UnhookWindowsHookEx", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
         public static extern int UnhookWindowsHookEx(int hHook);
         public delegate int LowLevelKeyboardProcDelegate(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);
         [DllImport("user32", EntryPoint = "CallNextHookEx", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
         public static extern int CallNextHookEx(int hHook, int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);
         public const int WH_KEYBOARD_LL = 13;

        public struct KBDLLHOOKSTRUCT
         {
             public int vkCode;
             public int scanCode;
             public int flags;
             public int time;
             public int dwExtraInfo;
         }
         public static int intLLKey;


         public int LowLevelKeyboardProc(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam)
         {
             bool blnEat = false;

             switch (wParam)
             {
                 case 256:
                 case 257:
                 case 260:
                 case 261:
                     MyTextBox.Text = "Nyprivet";
                     //Alt+Tab, Alt+Esc, Ctrl+Esc, Windows Key,
                     blnEat = ((lParam.vkCode == 9) && (lParam.flags == 32)) | ((lParam.vkCode == 27) && (lParam.flags == 32)) | ((lParam.vkCode == 27) && (lParam.flags == 0)) | ((lParam.vkCode == 91) && (lParam.flags == 1)) | ((lParam.vkCode == 92) && (lParam.flags == 1)) | ((lParam.vkCode == 73) && (lParam.flags == 0));
                     break;
             }

             if (blnEat == true)
             {
                 return 1;
             }
             else
             {
                 return CallNextHookEx(0, nCode, wParam, ref lParam);
             }
         }

         private void Form1_Load(object sender, EventArgs e)
         {
             intLLKey = SetWindowsHookEx(WH_KEYBOARD_LL, LowLevelKeyboardProc, System.Runtime.InteropServices.Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0]).ToInt32(), 0);
         }
         private void Press_KeyDown(object sender, KeyEventArgs e)
         {

             RegistryKey regkey;
             string keyValueInt = "1";
             string subKey = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
             try
             {
                 regkey = Registry.CurrentUser.CreateSubKey(subKey);
                 regkey.SetValue("DisableTaskMgr", keyValueInt);
                 regkey.Close();

             }
             catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         }
         void fileExitMenuItem_Click(object sender, RoutedEventArgs e)
         {
             RegistryKey regkey;
             string keyValueInt = "0";
             string subKey = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
             regkey = Registry.CurrentUser.CreateSubKey(subKey);
           regkey.SetValue("DisableTaskMgr", keyValueInt);
           regkey.Close();
             this.Close();
         }

        */
        void fileExitMenuItem_Click(object sender, RoutedEventArgs e)
        { this.Close();

            //myConnection.Close();
        }

            private void Button_Entry(object sender, RoutedEventArgs e)
        {
            //EntryV1.Navigate(new Page1());

            //EntryV.Navigate(new entry());
            EntryV1.Source = new Uri("entry.xaml", UriKind.RelativeOrAbsolute);
            
           // EntryV1.NavigationService.Refresh();
            //EntryV1.NavigationService.Navigate(new Uri("entry.xaml", UriKind.RelativeOrAbsolute));
            GlobalPer.VisiblBut = false;
            label.Visibility = Visibility.Collapsed;
            label1.Visibility = Visibility.Collapsed;
            EntryTest.Visibility= Visibility.Collapsed;
            Exit1.Visibility = Visibility.Collapsed;
            EntryTren.Visibility = Visibility.Collapsed;
            

            // Background.Opacity = 0;
        }

        private void EntryV_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_EntryTest(object sender, RoutedEventArgs e)
        {
            EntryV1.NavigationService.Navigate(new Uri("Page1.xaml", UriKind.RelativeOrAbsolute));
            GlobalPer.VisiblBut = false;
            label.Visibility = Visibility.Collapsed;
            label1.Visibility = Visibility.Collapsed;
            EntryTest.Visibility = Visibility.Collapsed;
            Exit1.Visibility = Visibility.Collapsed;
            EntryTren.Visibility = Visibility.Collapsed;
        }
        public void TEstMet()
        {
            if (GlobalPer.VisiblBut == true)
            {
                label.Visibility = Visibility.Visible;
                label1.Visibility = Visibility.Visible;
                EntryTest.Visibility = Visibility.Visible;
                Exit1.Visibility = Visibility.Visible;
                EntryTren.Visibility = Visibility.Visible;
                
            }
        }

        public void VisibulButton(object sender, EventArgs e)
        {
            if (GlobalPer.VisiblBut == true)
            {
                EntryTest.Visibility = Visibility.Visible;
                Exit1.Visibility = Visibility.Visible;
                EntryTren.Visibility = Visibility.Visible;
             //   EntryV1.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        
    }
}
