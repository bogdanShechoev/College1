using DetskiySad.Data;
using System.Windows;
using System.Windows.Controls;

namespace DetskiySad.UserPages
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void ListTeachers_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new ListTeacherPage());
        }

        private void ListKids_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new ListKidsPage());
        }

        private void AddKid_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddKid());
        }

        private void AddTeacher_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddTeacher());
        }
    }
}
