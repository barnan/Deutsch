using GermanDict.Interfaces;
using GermanDict.UI.ViewModels;
using System.Windows.Controls;

namespace GermanDict.UI.UserControls
{
    /// <summary>
    /// Interaction logic for SearchWordUserControl_WPF.xaml
    /// </summary>
    public partial class SearchWordUserControl_WPF : UserControl
    {
        public SearchWordUserControl_WPF(IRepository<IDictionaryItem> repository)
        {
            InitializeComponent();

            SearchWordViewModel vm = new SearchWordViewModel(repository);
            DataContext = vm;
            Name = vm.Name;

        }
    }
}
