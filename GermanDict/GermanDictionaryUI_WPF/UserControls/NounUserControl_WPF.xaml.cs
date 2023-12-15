using GermanDict.Interfaces;
using GermanDict.UI.ViewModels;
using System.Windows.Controls;

namespace GermanDict.UI.UserControls
{
    /// <summary>
    /// Interaction logic for NounUserControl_WPF.xaml
    /// </summary>
    public partial class NounUserControl_WPF : UserControl
    {
        public NounUserControl_WPF(IRepository<IDictionaryItem> repository)
        {
            InitializeComponent();

            DataContext = new NounViewModel(repository);
        }
    }
}
