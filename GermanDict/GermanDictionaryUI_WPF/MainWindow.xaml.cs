using Factories;
using GermanDict.Factories;
using GermanDict.Interfaces;
using GermanDict.UI.UserControls;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using SysVersion = System.Version;

namespace GermanDict.UI
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

            Title = "Dictionary " + GetRunningVersion();

            //------------------------------------------------------------------------------------------------------------------
            // Factory part: 
            IItemParser<IDictionaryItem> wordParser = WordFactory.GetParser();
            IRepository<IDictionaryItem> wordRepository = RepositoryFactory<IDictionaryItem>.CreateRepository(@"c:\Source\", "wordRepository.bin", wordParser);

            UserControl[] addWordUserControls = new UserControl[] { 
                new NounUserControl_WPF(wordRepository), 
                new VerbUserControl_WPF(wordRepository), 
                new AdjectiveUserControl_WPF(wordRepository),
                new AddArticleUserControl_WPF(wordRepository),
                new AddAttributeUserControl_WPF(wordRepository)};

            UserControl[] userControls = new UserControl[] { 
                new SearchWordUserControl_WPF(wordRepository), 
                new AddWordUserControl_WPF(addWordUserControls)};

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
