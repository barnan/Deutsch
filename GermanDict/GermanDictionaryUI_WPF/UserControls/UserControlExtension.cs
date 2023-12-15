using System.Windows;
using System;
using System.Windows.Threading;

namespace GermanDict.UserControls
{
    public static class UserControlExtension
    {
        private static readonly Action EmptyDelegate = delegate { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
