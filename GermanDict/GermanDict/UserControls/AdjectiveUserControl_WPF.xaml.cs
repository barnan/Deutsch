using GermanDict.Interfaces;
using GermanDict.ViewModels;
using System.Windows.Controls;

namespace GermanDict.UserControls
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
