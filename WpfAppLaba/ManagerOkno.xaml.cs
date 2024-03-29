using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using WpfAppLaba.LabaPPDataSetTableAdapters;

namespace WpfAppLaba
{
    public partial class ManagerOkno : Window
    {
    ProductsTableAdapter products = new ProductsTableAdapter();
    RentalsTableAdapter rentals = new RentalsTableAdapter();
    StatusProductsTableAdapter statusT = new StatusProductsTableAdapter();
    ProductsTypeTableAdapter typerT = new ProductsTypeTableAdapter();
    PublishersTableAdapter publisherT = new PublishersTableAdapter();
    PaymentsTableAdapter paymentsT = new PaymentsTableAdapter();
    OrdersTableAdapter orderT = new OrdersTableAdapter();


    private enum CurrentContext { Products, Rentals, StatusType, TyperProduct, PublisherProduct, PaymentsType, Order, OrderDetail};
    private CurrentContext currentContext;
        public ManagerOkno()
        {
            InitializeComponent();
        }

        private void tovari_Click(object sender, RoutedEventArgs e)
        {
            currentContext = CurrentContext.Products;
            DataGridDS.ItemsSource = products.GetData();

        }

        private void prokati_Click(object sender, RoutedEventArgs e)
        {
            currentContext = CurrentContext.Rentals;
            DataGridDS.ItemsSource = rentals.GetData();
            DataGridDS.Columns[1].Visibility = Visibility.Collapsed;
            DataGridDS.Columns[2].Visibility = Visibility.Collapsed;
            DataGridDS.Columns[3].Visibility = Visibility.Collapsed;

        }
        private void status_Click(object sender, RoutedEventArgs e)
        {
            currentContext = CurrentContext.StatusType;
            DataGridDS.ItemsSource = statusT.GetData();
        }
        private void publisher_Click(object sender, RoutedEventArgs e)
        {
            currentContext = CurrentContext.PublisherProduct;
            DataGridDS.ItemsSource = publisherT.GetData();
        }
        private void typer_Click(object sender, RoutedEventArgs e)
        {
            currentContext = CurrentContext.TyperProduct;
            DataGridDS.ItemsSource = typerT.GetData();
        }
        private void payment_Click(object sender, RoutedEventArgs e)
        {
            currentContext = CurrentContext.PaymentsType;
            DataGridDS.ItemsSource = paymentsT.GetData();
        }
        private void order_Click(object sender, RoutedEventArgs e)
        {
            currentContext = CurrentContext.Order;
            DataGridDS.ItemsSource = orderT.GetData();
        }

        private void orderdetail_Click(object sender, RoutedEventArgs e)
        {
            currentContext = CurrentContext.OrderDetail;
            DataGridDS.ItemsSource = orderT.GetData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentContext)
            {
                case CurrentContext.StatusType:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        statusT.UpdateQueryStatus(NameTbx.Text, Convert.ToInt32(roleId));
                        DataGridDS.ItemsSource = statusT.GetData();
                    }
                    break;
                case CurrentContext.TyperProduct:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId1 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        typerT.UpdateQueryType(NameTbx.Text, Convert.ToInt32(roleId1));
                        DataGridDS.ItemsSource = typerT.GetData();

                    }
                    break;
                case CurrentContext.PublisherProduct:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId2 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        publisherT.UpdateQueryPublisher(NameTbx.Text, Convert.ToInt32(roleId2));
                        DataGridDS.ItemsSource = publisherT.GetData();
                    }
                    break;
                case CurrentContext.PaymentsType:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId3 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        paymentsT.UpdateQueryPayment(NameTbx.Text, Convert.ToInt32(roleId3));
                        DataGridDS.ItemsSource = paymentsT.GetData();
                    }
                    break;
                case CurrentContext.Products:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId4 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        products.UpdateQueryProducts(NameTbx.Text, NameTbx1.Text, Convert.ToInt32(NameTbx2.Text));
                        DataGridDS.ItemsSource = products.GetData();

                    }
                    break;
                case CurrentContext.Rentals:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId5 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        rentals.UpdateQueryRentals(NameTbx.Text, NameTbx1.Text, Convert.ToInt32(NameTbx2.Text), Convert.ToInt32(NameTbx3.Text));
                        DataGridDS.ItemsSource = rentals.GetData();

                    }
                    break;
                case CurrentContext.Order:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId6 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        orderT.UpdateQueryOrders(Convert.ToInt32(NameTbx.Text), Convert.ToInt32(NameTbx1.Text), Convert.ToInt32(roleId6));
                        DataGridDS.ItemsSource = orderT.GetData();
                    }
                    break;
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentContext)
            {
                case CurrentContext.StatusType:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        statusT.InsertQueryStatus(NameTbx.Text);
                        DataGridDS.ItemsSource = statusT.GetData();
                    }
                    break;
                case CurrentContext.TyperProduct:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId1 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        typerT.InsertQueryType(NameTbx.Text);
                        DataGridDS.ItemsSource = typerT.GetData();

                    }
                    break;
                case CurrentContext.PublisherProduct:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId2 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        publisherT.InsertQueryPublisher(NameTbx.Text);
                        DataGridDS.ItemsSource = publisherT.GetData();
                    }
                    break;
                case CurrentContext.PaymentsType:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId3 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        paymentsT.InsertQueryPayment(NameTbx.Text);
                        DataGridDS.ItemsSource = paymentsT.GetData();
                    }
                    break;
                case CurrentContext.Products:
                    if (DataGridDS.SelectedItem != null)
                    {
                        if (int.TryParse(NameTbx2.Text, out int price))
                        {
                            object roleId4 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                            products.InsertQueryProducts(NameTbx.Text, NameTbx1.Text, price);
                            DataGridDS.ItemsSource = products.GetData();
                        }
                        else
                        {
                            MessageBox.Show("Введите целочисленное значение в поле Price.");
                        }
                    }
                    break;

                case CurrentContext.Rentals:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId5 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        rentals.InsertQueryRentals(Convert.ToInt32(NameTbx), NameTbx1.Text, NameTbx2.Text, Convert.ToInt32(NameTbx3.Text), Convert.ToInt32(NameTbxID.Text));
                        DataGridDS.ItemsSource = rentals.GetData();

                    }
                    break;
            }
        }

        private void DeleteDataButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentContext)
            {
                case CurrentContext.StatusType:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        statusT.DeleteQueryStatus(Convert.ToInt32(roleId));
                        DataGridDS.ItemsSource = statusT.GetData();
                    }
                    break;
                case CurrentContext.TyperProduct:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId1 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        typerT.DeleteQueryType(Convert.ToInt32(roleId1));
                        DataGridDS.ItemsSource = typerT.GetData();
                    }
                    break;
                case CurrentContext.PublisherProduct:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId2 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        publisherT.DeleteQueryPublisher(Convert.ToInt32(roleId2));
                        DataGridDS.ItemsSource = publisherT.GetData();
                    }
                    break;
                case CurrentContext.PaymentsType:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId3 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        paymentsT.DeleteQueryPayments(Convert.ToInt32(roleId3));
                        DataGridDS.ItemsSource = paymentsT.GetData();
                    }
                    break;
                case CurrentContext.Products:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId4 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        products.DeleteQueryProducts(Convert.ToInt32(roleId4));
                        DataGridDS.ItemsSource = products.GetData();
                    }
                    break;
                case CurrentContext.Rentals:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId4 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        rentals.DeleteQueryRentals(Convert.ToInt32(roleId4));
                        DataGridDS.ItemsSource = rentals.GetData();
                    }
                    break;
            }
        }


        private void SavePasswordToDatabase(string password)
        {
            string hashedPassword = CalculateSHA256(password);
        }
        public static string CalculateSHA256(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void imputjestko_Click(object sender, RoutedEventArgs e)
        {
            List<Class1> forImport = Class2.DeserializeObject<List<Class1>>();
            foreach (var item in forImport)
            {
                statusT.InsertQueryStatus(item.StatusProduct);
            }
        }
    }
}
