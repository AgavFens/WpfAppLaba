using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using WpfAppLaba.LabaPPDataSetTableAdapters;

namespace WpfAppLaba
{
    public partial class MainWindow : Window
    {
        AuthorizationsTableAdapter adapter = new AuthorizationsTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = adapter.GetData().Rows;
            bool credentialsFound = false;

            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][2].ToString() == LoginTbx.Text &&
                    allLogins[i][3].ToString() == PasswordTbx.Password)
                {
                    int roleId = (int)allLogins[i][1];
                    credentialsFound = true;

                    switch (roleId)
                    {
                        case 1:
                            AdminOkno admin = new AdminOkno();
                            admin.Show();
                            break;
                        case 2:
                            SellerOkno seller = new SellerOkno();
                            seller.Show();
                            break;
                        case 3:
                            ManagerOkno manager = new ManagerOkno();
                            manager.Show();
                            break;
                    }

                    break;
                }
            }

            if (!credentialsFound)
            {
                MessageBox.Show("Неправильно введен пароль или логин.");
            }
        }

    }
}
