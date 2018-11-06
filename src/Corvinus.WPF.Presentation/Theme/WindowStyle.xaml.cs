// <copyright file="WindowStyle.xaml.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>

namespace Microsoft.Manufacturing.UI.WPF.Common.Theme
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// Code Behind for WindowStyle.xaml.
    /// </summary>
    public partial class WindowStyle : ResourceDictionary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowStyle"/> class.
        /// </summary>
        public WindowStyle()
        {
            return;
        }

        /// <summary>
        /// Event Handler for the Window Close Button.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.Close();
        }

        /// <summary>
        /// Event Handler for the Window Maximize Button.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void MaximizeRestoreClick(object sender, RoutedEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            if (window.WindowState == System.Windows.WindowState.Normal)
            {
                window.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                window.WindowState = System.Windows.WindowState.Normal;
            }
        }

        /// <summary>
        /// Event Handler for the Window Minimize Button.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.WindowState = System.Windows.WindowState.Minimized;
        }
    }
}
