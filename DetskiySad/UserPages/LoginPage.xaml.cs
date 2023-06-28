using DetskiySad.Data;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DetskiySad.UserPages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();


            DbConnect.entObj = new CollegeEntities1();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DbConnect.entObj.User.Count(x => x.Login == TxbLogin.Text && x.Password == PsbPassword.Password);
                if (user == null)
                {
                    MessageBox.Show("Такого администратора нет!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
                else
                {
                    FrameApp.frmObj.Navigate(new MenuPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбой работы приложения:" + ex.Message.ToString(),
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);

            }
        }

        private void TxbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
