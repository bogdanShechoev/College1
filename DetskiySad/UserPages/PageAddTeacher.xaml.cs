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
using System.Xml.Linq;
using MessageBox = System.Windows.MessageBox;

namespace DetskiySad.UserPages
{
    /// <summary>
    /// Interaction logic for PageAddTeacher.xaml
    /// </summary>
    public partial class PageAddTeacher : Page
    {
        public PageAddTeacher()
        {
            InitializeComponent();
        }
       
               
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void AddToTeacher_Click(object sender, RoutedEventArgs e)
        {
            if (DbConnect.entObj.Teachers.Count(x => x.Name == TxbName.Text) > 0)
            {
                System.Windows.MessageBox.Show("Такой работник уже есть уже есть!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }
            else
            {
                if (TxbName.Text == null | TxbName.Text.Trim() == "" | TxbAge.Text == null | TxbAge.Text.Trim() == "" | TxbAdress.Text == null | TxbAdress.Text.Trim() == "" | TxbExp.Text == null | TxbExp.Text.Trim() == "" | TxbPostName.Text == null | TxbPostName.Text.Trim() == "" | TxbLastWork.Text == null | TxbLastWork.Text.Trim() == "")
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
                        Teachers teacherObj = new Teachers()
                        {
                            Name = TxbName.Text,
                            Adress = TxbAdress.Text,
                            FullYears = Convert.ToInt32(TxbAge.Text),
                            Expereince = Convert.ToInt32(TxbExp.Text),
                            LastWorkPlace = TxbLastWork.Text,
                            Post = TxbPostName.Text
                        };
                        DbConnect.entObj.Teachers.Add(teacherObj);
                        DbConnect.entObj.SaveChanges();

                        MessageBox.Show("Сотрудник добавлен!",
                            "Уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка добавления сотрудника: " + ex.Message.ToString(),
                            "Критический сбой работы приложения",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        
                    }
                }
            }
               
            
        }
   
    }
}
