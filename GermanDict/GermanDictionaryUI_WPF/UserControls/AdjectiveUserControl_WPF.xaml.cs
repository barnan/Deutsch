using GermanDict.Interfaces;
using GermanDict.UI.ViewModels;
using System.Windows.Controls;

namespace GermanDict.UI.UserControls
{
    /// <summary>
    /// Interaction logic for AdjectiveUserControl_WPF.xaml
    /// </summary>
    public partial class AdjectiveUserControl_WPF : UserControl
    {
        public AdjectiveUserControl_WPF(IRepository<IDictionaryItem> repository)
        {
            InitializeComponent();
            DataContext = new AdjectiveViewModel(repository);
        }
    }
}
