using DetskiySad.Data;
using System.Linq;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DetskiySad.UserPages
{
    /// <summary>
    /// Interaction logic for ListTeacherPage.xaml
    /// </summary>
    public partial class ListTeacherPage : Page
    {
        public ListTeacherPage()
        {
            InitializeComponent();
            DgrTeachers.ItemsSource = DbConnect.entObj.Teachers.ToList();
        }

        private void BtnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddTeacher());
        }

        private void BtnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var teachersForRemoving = DgrTeachers.SelectedItems.Cast<Teachers>().ToList();

            var cancel = System.Windows.Forms.MessageBox.Show("Вы подтверждаете удаление?",
                            "Подтверждение",
                            (MessageBoxButtons)MessageBoxButton.OKCancel);
            if (DialogResult.Cancel == cancel)
            {
                FrameApp.frmObj.Navigate(new ListKidsPage());
            }
            else
            {

                try
                {
                    DbConnect.entObj.Teachers.RemoveRange(teachersForRemoving);
                    DbConnect.entObj.SaveChanges();
                    System.Windows.Forms.MessageBox.Show("Данные удалены");

                    DgrTeachers.ItemsSource = DbConnect.entObj.Teachers.ToList();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString());

                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Page_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DgrTeachers.ItemsSource = DbConnect.entObj.Teachers.ToList();

            }
        }
    }
}
