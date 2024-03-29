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
    /// Логика взаимодействия для Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        OrdersTableAdapter orderT = new OrdersTableAdapter();

        public Window7()
        {
            InitializeComponent();
            orderT.GetData();
        }
    }
}
