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
    public partial class Window4 : Window
    {
        ProductsTypeTableAdapter typerT = new ProductsTypeTableAdapter();

        public Window4()
        {
            InitializeComponent();
            typerT.GetData();

        }
    }
}
