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
    /// Логика взаимодействия для Window8.xaml
    /// </summary>
    public partial class Window8 : Window
    {
        RolesTableAdapter roles = new RolesTableAdapter();
        public Window8()
        {
            InitializeComponent();
            roles.GetData();
        }
    }
}
