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
using System.Windows.Shapes;
using WpfAppLaba.LabaPPDataSetTableAdapters;

namespace WpfAppLaba
{
    /// <summary>
    /// Логика взаимодействия для Window10.xaml
    /// </summary>
    /// 
    public partial class Window10 : Window
    {
        AuthorizationsTableAdapter authorizations = new AuthorizationsTableAdapter();
        public Window10()
        {
            InitializeComponent();
            authorizations.GetData();
        }

        private void DataGridDS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
