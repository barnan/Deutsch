using GermanDict.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using SysVersion = System.Version;

namespace GermanDict
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            this.Title = "GermanDict " + GetRunningVersion();

            UserControl[] userControls = new UserControl[] { new SearchWordUserControl_WPF(), new AddWordUserControl_WPF() };
            CreateTabControlItems(tabControl1, userControls);

        }

        private SysVersion GetRunningVersion()
        {
            try
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
            catch (Exception)
            {
                return new SysVersion(0, 0, 0, 0);
            }
        }

        private void CreateTabControlItems(TabControl tabControl, UserControl[] userControls)
        {
            foreach (UserControl uc in userControls)
            {
                TabItem tabItem = new TabItem();
                tabItem.Header = uc.Name;
                tabItem.Content = uc;

                tabControl.Items.Add(tabItem);
            }
        }
    }
}
