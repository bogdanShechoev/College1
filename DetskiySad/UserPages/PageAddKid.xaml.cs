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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DetskiySad.UserPages
{
    /// <summary>
    /// Interaction logic for PageAddKid.xaml
    /// </summary>
    public partial class PageAddKid : Page
    {
        public PageAddKid()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void AddToKids_Click(object sender, RoutedEventArgs e)
        {
            if (DbConnect.entObj.Kids.Count(x => x.Name == TxbName.Text) > 0)
            {
                MessageBox.Show("Такой студент уже есть!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }
            else
            {
                if (TxbName.Text == null | TxbName.Text.Trim() == "" | TxbAge.Text == null | TxbAge.Text.Trim() == "" | TxbAdress.Text == null | TxbAdress.Text.Trim() == "" | TxbGroupNmb.Text == null | TxbGroupNmb.Text.Trim() == "")
                {
                    MessageBox.Show("Заполните все поля!",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    try
                    {

                        Kids kidObj = new Kids()
                        {
                            Name = TxbName.Text,
                            Adress = TxbAdress.Text,
                            FullYears = Convert.ToInt32(TxbAge.Text),
                            GroupNumber = Convert.ToInt32(TxbGroupNmb.Text)
                        };

                        DbConnect.entObj.Kids.Add(kidObj);
                        DbConnect.entObj.SaveChanges();

                        MessageBox.Show("Студент добавлен!",
                            "Уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка добавления студента: " + ex.Message.ToString(),
                        "Критический сбой работы приложения",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    }
                }
            }
        }
    }
}
