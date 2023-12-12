using GermanDict.ViewModels;
using System.Windows.Controls;

namespace GermanDict.UserControls
{
    /// <summary>
    /// Interaction logic for AddAttributeUserControl_WPF.xaml
    /// </summary>
    public partial class AddAttributeUserControl_WPF : UserControl
    {
        public AddAttributeUserControl_WPF()
        {
            InitializeComponent();

            AddAttributeViewModel vm = new AddAttributeViewModel();
            DataContext = vm;
            Name = vm.Name;
        }
    }
}
