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
