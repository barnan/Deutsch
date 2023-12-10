using GermanDict.ViewModels;
using System.Windows.Controls;

namespace GermanDict.UserControls
{
    /// <summary>
    /// Interaction logic for AddWordUserControl_WPF.xaml
    /// </summary>
    public partial class AddWordUserControl_WPF : UserControl
    {
        public AddWordUserControl_WPF(UserControl[] userControls)
        {
            InitializeComponent();

            // UserControl[] userControls = new UserControl[] { new NounUserControl_WPF(), new VerbUserControl_WPF(), new AdjectiveUserControl_WPF() };
            DataContext = new AddWordViewModel(userControls);
        }
    }
}
