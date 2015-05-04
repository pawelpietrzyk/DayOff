using butterfly.com.mongo;
using DayOff.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DayOff.View
{
    /// <summary>
    /// Interaction logic for DayOffView.xaml
    /// </summary>
    public partial class DayOffView : UserControl
    {
        private DayOffViewModel model;
        public DayOffView()
        {
            InitializeComponent();
            this.model = new DayOffViewModel();
            this.DataContext = this.model;
        }

        private void btnReadClick(object sender, RoutedEventArgs e)
        {
            this.model.Read();
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            this.model.Add();
        }
        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            MongoDayOff day = listBoxInfo.SelectedItem as MongoDayOff;
            if (day != null)
            {
                this.model.Delete(day);
            }
            
        }
        public void EditItem(object obj)
        {
            MongoDayOff day = obj as MongoDayOff;
            if (day != null)
            {
                this.model.Edit(day);

            }
        }
        private void ListBoxKey(object sender, KeyEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                switch (e.Key)
                {
                    case Key.F2:
                        this.EditItem(listBox.SelectedItem);                        
                        //this.EditItem(listBox.SelectedItem);
                        break;
                    case Key.F4:
                        //this.CopyPassword(listBox.SelectedItem);
                        break;
                    case Key.F3:
                        //this.ShowPassword(listBox.SelectedItem);
                        break;
                    case Key.F6:
                        //this.SaveContent();
                        break;
                    case Key.Delete:
                        //this.DeleteItem(listBox.SelectedItem);
                        break;
                }
            }
            

        }
       
    }
}
