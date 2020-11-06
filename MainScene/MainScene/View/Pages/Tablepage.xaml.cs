using MainScene.Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using Table = MainScene.Model.Table;
using MainScene.Repository;
using System.Diagnostics;
using System.Windows;

namespace MainScene.View.Pages
{
    /// <summary>
    /// Tablepage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Tablepage : Page
    {
        TableRepository TableRepository = App.repositoryController.GetTableRepository();
        int selecttablenum = 0;
        public System.Collections.IList SelectedItems { get; }
        public Tablepage()
        {   
            InitializeComponent();

            List<Table> table = TableRepository.GetTable();

            this.tableListbox.ItemsSource = table;
        }

        private void BackClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OrderClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(

                new Uri("View/Pages/Payment.xaml", UriKind.Relative));
        }

        private void ListBoxItem_Selected(object sender, SelectionChangedEventArgs e)
        {

            Table table = tableListbox.SelectedItem as Table;

            selecttablenum = table.tablenum;

            MessageBox.Show(selecttablenum.ToString());
        }
    }
}
