// <copyright file="ClickCommands.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Commanding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Additional Commanding for Click Events.
    /// </summary>
    public class ClickCommands
    {
        /// <summary>
        /// MouseEventParameter Attached Dependency Property.
        /// </summary>
        public static readonly DependencyProperty MouseEventParameterProperty =
            DependencyProperty.RegisterAttached(
                "MouseEventParameter",
                typeof(object),
                typeof(ClickCommands),
                new FrameworkPropertyMetadata((object)null, null));

        /// <summary>
        /// MouseDoubleClickCommand Attached Dependency Property.
        /// </summary>
        public static readonly DependencyProperty MouseDoubleClickCommandProperty =
            DependencyProperty.RegisterAttached(
                "MouseDoubleClickCommand",
                typeof(ICommand),
                typeof(ClickCommands),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnMouseDoubleClickCommandChanged)));

        /// <summary>
        /// Gets the MouseDoubleClickCommand property.
        /// </summary>
        /// <returns>ICommand.</returns>
        /// <param name="d">DependencyObject.</param>
        public static ICommand GetMouseDoubleClickCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(MouseDoubleClickCommandProperty);
        }

        /// <summary>
        /// Sets the MouseDoubleClickCommand property.
        /// </summary>
        /// <param name="d">DependencyObject.</param>
        /// <param name="value">ICommand.</param>
        public static void SetMouseDoubleClickCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(MouseDoubleClickCommandProperty, value);
        }

        /// <summary>
        /// Gets the MouseEventParameter property.
        /// </summary>
        /// <param name="d">DependencyObject.</param>
        /// <returns>object.</returns>
        public static object GetMouseEventParameter(DependencyObject d)
        {
            return d.GetValue(MouseEventParameterProperty);
        }

        /// <summary>
        /// Sets the MouseEventParameter property.
        /// </summary>
        /// <param name="d">DependencyObject.</param>
        /// <param name="value">object.</param>
        public static void SetMouseEventParameter(DependencyObject d, object value)
        {
            d.SetValue(MouseEventParameterProperty, value);
        }

        /// <summary>
        /// Handles changes to the MouseDoubleClickCommand property.
        /// </summary>
        /// <param name="target">DependencyObject.</param>
        /// <param name="e">DependencyPropertyChangedEventArgs.</param>
        private static void OnMouseDoubleClickCommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (target is UIElement element)
            {
                if ((e.OldValue == null) && (e.NewValue != null))
                {
                    element.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(UIElementMouseLeftButtonDown), true);
                }
                else if ((e.OldValue != null) && (e.NewValue == null))
                {
                    element.RemoveHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(UIElementMouseLeftButtonDown));
                }
            }
        }

        /// <summary>
        /// Handles changes to the Mouse Left Button Down handler.
        /// </summary>
        /// <param name="sender">object.</param>
        /// <param name="e">MouseButtonEventArgs.</param>
        private static void UIElementMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // gets the sender is UIElement and check ClickCount because we want double click only
            if (sender is UIElement target && e.ClickCount > 1)
            {
                ICommand iCommand = (ICommand)target.GetValue(MouseDoubleClickCommandProperty);
                if (iCommand != null)
                {
                    // check if the command has a parameter using the MouseEventParameterProperty
                    object parameter = target.GetValue(MouseEventParameterProperty);

                    // execute the command
                    if (parameter == null)
                    {
                        parameter = target;
                    }

                    if (iCommand is RoutedCommand routedCommand)
                    {
                        routedCommand.Execute(parameter, target);
                    }
                    else
                    {
                        iCommand.Execute(parameter);
                    }

                    e.Handled = true;
                }
            }
        }
    }
}
