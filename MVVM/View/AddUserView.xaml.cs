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
using System.Windows.Navigation;
using System.Windows.Shapes;
using JobListTracker.Core;
using JobListTracker.MVVM.ViewModel;

namespace JobListTracker.MVVM.View
{
    /// <summary>
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : UserControl
    {
        public RelayCommand CVDropCommand
        {
            get { return (RelayCommand)GetValue(CVDropCommandProperty); }
            set { SetValue(CVDropCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CVDropCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CVDropCommandProperty =
            DependencyProperty.Register("CVDropCommand", typeof(RelayCommand), typeof(TextBlock), new PropertyMetadata(null));



        public AddUserView()
        {
            InitializeComponent();
        }

        private void TextBlock_CV_Drop(object sender, DragEventArgs e)
        {
            // I should not be doing this here but oh well. I will learn MVVM properly after I get mvp.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                // Process the dropped files
                
                if (files.Length > 1)
                    Console.Error.WriteLine("Error, adding more than 1 cv");

                string cvPath = files[0];

                AddUserViewModel dataContext = (AddUserViewModel)DataContext;
                dataContext.DropTextBox_CV_Command.Execute(cvPath);
            }
        }

        private void TextBlock_CV_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void TextBlock_CV_DragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
    }
}
