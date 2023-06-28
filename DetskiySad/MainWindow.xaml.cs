using DetskiySad.Data;
using DetskiySad.UserPages;
using System.Windows;

namespace DetskiySad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FrameApp.frmObj = Frm;

            DbConnect.entObj = new CollegeEntities1();

            Frm.Navigate(new LoginPage());
        }

        
          
          
                 
         

    }
}
