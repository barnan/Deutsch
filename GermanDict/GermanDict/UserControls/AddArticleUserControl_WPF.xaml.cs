﻿using GermanDict.ViewModels;
using System.Windows.Controls;

namespace GermanDict.UserControls
{
    /// <summary>
    /// Interaction logic for AddArticleAttributeUserControl_WPF.xaml
    /// </summary>
    public partial class AddArticleUserControl_WPF : UserControl
    {
        public AddArticleUserControl_WPF()
        {
            InitializeComponent();

            AddArticleViewModel vm = new AddArticleViewModel();
            DataContext = vm;
            Name = vm.Name;
        }
    }
}