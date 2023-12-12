using GermanDict.ViewModels;
using System.Windows.Controls;

namespace GermanDict.UserControls
{
    /// <summary>
    /// Interaction logic for SearchWordUserControl_WPF.xaml
    /// </summary>
    public partial class SearchWordUserControl_WPF : UserControl
    {
        public SearchWordUserControl_WPF()
        {
            InitializeComponent();

            SearchWordViewModel vm = new SearchWordViewModel();
            DataContext = vm;
            Name = vm.Name;

        }
    }
}
