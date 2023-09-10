using GermanDict.Interfaces;
using GermanDict.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GermanDict.UserControls
{
    /// <summary>
    /// Interaction logic for VerbUserControl.xaml
    /// </summary>
    public partial class VerbUserControl_WPF : UserControl
    {
        public VerbUserControl_WPF(IRepository<IWord> repository)
        {
            InitializeComponent();

            DataContext = new VerbViewModel(repository);
        }
    }
}
