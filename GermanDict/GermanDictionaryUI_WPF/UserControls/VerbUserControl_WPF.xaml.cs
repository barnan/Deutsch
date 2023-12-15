using GermanDict.Interfaces;
using GermanDict.UI.ViewModels;
using System.Windows.Controls;

namespace GermanDict.UI.UserControls
{
    /// <summary>
    /// Interaction logic for VerbUserControl.xaml
    /// </summary>
    public partial class VerbUserControl_WPF : UserControl
    {
        public VerbUserControl_WPF(IRepository<IDictionaryItem> repository)
        {
            InitializeComponent();

            DataContext = new VerbViewModel(repository);
        }
    }
}
