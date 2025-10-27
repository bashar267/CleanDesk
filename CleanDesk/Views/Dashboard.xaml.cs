using System.Windows;
using CleanDesk.ViewModels;

namespace CleanDesk.Views
{
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}