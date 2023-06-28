using DetskiySad.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DetskiySad.UserPages
{
    /// <summary>
    /// Interaction logic for ListKidsPage.xaml
    /// </summary>
    public partial class ListKidsPage : Page
    {
        public ListKidsPage()
        {
            InitializeComponent();
            DgrKids.ItemsSource = DbConnect.entObj.Kids.ToList();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAddKid());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var kidsForRemoving = DgrKids.SelectedItems.Cast<Kids>().ToList();

            var cancel = MessageBox.Show("Вы подтверждаете удаление?",
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
                    DbConnect.entObj.Kids.RemoveRange(kidsForRemoving);
                    DbConnect.entObj.SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DgrKids.ItemsSource = DbConnect.entObj.Kids.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DgrKids.ItemsSource = DbConnect.entObj.Kids.ToList();

            }
        }
    }
}
