using Factories;
using GermanDict.Factories;
using GermanDict.Interfaces;
using GermanDict.UserControls;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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
            this.DataContext = new MainViewModel();

            this.Title = "Dictionary " + GetRunningVersion();

            //------------------------------------------------------------------------------------------------------------------
            // Factory part: 
            IDictionaryParser<IDictionaryItem> wordParser = WordFactory.GetParser();
            IRepository<IDictionaryItem> wordRepository = RepositoryFactory<IDictionaryItem>.CreateRepository(@"c:\Source\Deutsch\", "wordRepository.bin", wordParser);

            UserControl[] addWordUserControls = new UserControl[] { 
                new NounUserControl_WPF(wordRepository), 
                new VerbUserControl_WPF(wordRepository), 
                new AdjectiveUserControl_WPF(wordRepository) };

            UserControl[] userControls = new UserControl[] { 
                new SearchWordUserControl_WPF(), 
                new AddWordUserControl_WPF(addWordUserControls) };

            //------------------------------------------------------------------------------------------------------------------

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
                TabItem tabItem = new TabItem
                {
                    Header = uc.Name,
                    Content = uc
                };

                tabControl.Items.Add(tabItem);
            }
        }
    }
}
