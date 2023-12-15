using GermanDict.Interfaces;
using GermanDict.UI.ViewModels;
using System.Windows.Controls;

namespace GermanDict.UI.UserControls
{
    /// <summary>
    /// Interaction logic for AddAttributeUserControl_WPF.xaml
    /// </summary>
    public partial class AddAttributeUserControl_WPF : UserControl
    {
        public AddAttributeUserControl_WPF(IRepository<IDictionaryItem> repository)
        {
            InitializeComponent();

            AddAttributeViewModel vm = new AddAttributeViewModel(repository);
            DataContext = vm;
            Name = vm.Name;
        }
    }
}
