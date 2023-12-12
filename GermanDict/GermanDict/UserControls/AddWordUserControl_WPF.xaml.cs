﻿using GermanDict.ViewModels;
using System.Windows.Controls;

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

            AddWordViewModel vm = new AddWordViewModel(userControls);
            DataContext = vm;
            Name = vm.Name;
        }
    }
}
