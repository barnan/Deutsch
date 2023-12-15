using GermanDict.Interfaces;
using GermanDict.UI.ViewModels;
using System.Windows.Controls;

namespace GermanDict.UI.UserControls
{
    /// <summary>
    /// Interaction logic for AddArticleAttributeUserControl_WPF.xaml
    /// </summary>
    public partial class AddArticleUserControl_WPF : UserControl
    {
        public AddArticleUserControl_WPF(IRepository<IDictionaryItem> repository)
        {
            InitializeComponent();

            AddArticleViewModel vm = new AddArticleViewModel(repository);
            DataContext = vm;
            Name = vm.Name;
        }
    }
}
