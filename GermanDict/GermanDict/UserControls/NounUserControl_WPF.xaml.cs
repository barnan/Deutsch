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
    /// Interaction logic for NounUserControl_WPF.xaml
    /// </summary>
    public partial class NounUserControl_WPF : UserControl
    {
        public NounUserControl_WPF(IRepository<IWord> repository)
        {
            InitializeComponent();

            DataContext = new NounViewModel(repository);
        }
    }
}
