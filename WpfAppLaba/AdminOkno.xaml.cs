    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
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
    using System.Windows.Shapes;
    using WpfAppLaba.LabaPPDataSetTableAdapters;
    using static MaterialDesignThemes.Wpf.Theme;

namespace WpfAppLaba
{
    public partial class AdminOkno : Window
    {
        RolesTableAdapter roles = new RolesTableAdapter();
        EmployersTableAdapter employers = new EmployersTableAdapter();
        AuthorizationsTableAdapter authorizations = new AuthorizationsTableAdapter();
        private enum CurrentContext { Roles, Employers, Authorizations };
        private CurrentContext currentContext;

        public AdminOkno()
        {
            InitializeComponent();
        }

        private void RoleKnopka_Click(object sender, RoutedEventArgs e)
        {
            currentContext = CurrentContext.Roles;
            DataGridDS.ItemsSource = roles.GetData();
            NameTbx1.Visibility = Visibility.Collapsed;
            NameTbx2.Visibility = Visibility.Collapsed;
            NameTbx3.Visibility = Visibility.Collapsed;
            NameTbxID.Visibility = Visibility.Collapsed;

        }

        private void Employerknopka_Click(object sender, RoutedEventArgs e)
        {
            currentContext = CurrentContext.Employers;
            DataGridDS.ItemsSource = employers.GetData();
            NameTbx1.Visibility = Visibility.Visible;
            NameTbx2.Visibility = Visibility.Visible;
            NameTbx3.Visibility = Visibility.Visible;
            NameTbxID.Visibility = Visibility.Visible;
            DataGridDS.Columns[5].Visibility = Visibility.Collapsed;

        }

        private void avtorizationKnopka_Click(object sender, RoutedEventArgs e)
        {
            currentContext = CurrentContext.Authorizations;
            DataGridDS.ItemsSource = authorizations.GetData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentContext)
            {
                case CurrentContext.Roles:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId = (DataGridDS.SelectedItem as DataRowView).Row[0];
                        roles.UpdateQueryRole(NameTbx.Text, Convert.ToInt32(roleId));
                        DataGridDS.ItemsSource = roles.GetData();
                    }
                    break;
                case CurrentContext.Employers:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId1 = (DataGridDS.SelectedItem as DataRowView).Row[0];
                        employers.UpdateQueryEmployer(NameTbx.Text, NameTbx1.Text, NameTbx2.Text, Convert.ToInt32(NameTbx3.Text), Convert.ToInt32(roleId1));
                        DataGridDS.ItemsSource = employers.GetData();
                    }

                    break;
                case CurrentContext.Authorizations:
                    object roleId2 = (DataGridDS.SelectedItem as DataRowView).Row[0];
                    authorizations.UpdateQueryAuthorizations(NameTbxID.Text, NameTbxgg.Password, Convert.ToInt32(NameTbx1.Text), Convert.ToInt32(roleId2));
                    DataGridDS.ItemsSource = authorizations.GetData();
                    break;
            }
        }
        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentContext)
            {
                case CurrentContext.Roles:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId = (DataGridDS.SelectedItem as DataRowView).Row[0];
                        roles.InsertQueryRole(NameTbx.Text);
                        DataGridDS.ItemsSource = roles.GetData();
                    }
                    break;
                case CurrentContext.Employers:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId1 = (DataGridDS.SelectedItem as DataRowView).Row[0];
                        employers.InsertQueryEmployer(NameTbx.Text, NameTbx1.Text, NameTbx2.Text, Convert.ToInt32(NameTbx3.Text));
                        DataGridDS.ItemsSource = employers.GetData();
                        NameTbxID.Visibility = Visibility.Collapsed;
                        DataGridDS.Columns[5].Visibility = Visibility.Collapsed;
                    }
                    break;
                case CurrentContext.Authorizations:
                    object roleId2 = (DataGridDS.SelectedItem as DataRowView).Row[0];
                    authorizations.InsertQueryAuthorizations(Convert.ToInt32(NameTbxID.Text), NameTbx1.Text, NameTbxgg.Password);
                    DataGridDS.ItemsSource = authorizations.GetData();
                    break;
            }
        }

        private void DeleteDataButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentContext)
            {
                case CurrentContext.Roles:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        roles.DeleteQueryRole(Convert.ToInt32(roleId));
                        DataGridDS.ItemsSource = roles.GetData();
                    }
                    break;
                case CurrentContext.Employers:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId1 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        employers.DeleteQueryEmployer(Convert.ToInt32(roleId1));
                        DataGridDS.ItemsSource = employers.GetData();
                        NameTbxID.Visibility = Visibility.Collapsed;
                        DataGridDS.Columns[5].Visibility = Visibility.Collapsed;
                    }
                    break;
                case CurrentContext.Authorizations:
                    if (DataGridDS.SelectedItem != null)
                    {
                        object roleId2 = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
                        authorizations.DeleteQueryAuthorizations(Convert.ToInt32(roleId2));
                        DataGridDS.ItemsSource = authorizations.GetData();
                    }
                    break;

            }
        }

        private void DataGridDS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NameTbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           if (!Char.IsLetter(e.Text,0)) e.Handled = true;
        }

        private void NameTbx1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;

        }

        private void NameTbx2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;

        }
    }
}
