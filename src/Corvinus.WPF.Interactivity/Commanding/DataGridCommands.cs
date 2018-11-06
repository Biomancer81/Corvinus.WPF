// <copyright file="DataGridCommands.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Commanding
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// DataGrid Extention Commands.
    /// </summary>
    public static class DataGridCommands
    {
        /// <summary>
        /// Read Only Dependency Property for a DataGridDoubleClick.
        /// </summary>
        public static readonly DependencyProperty DataGridDoubleClickProperty = DependencyProperty.RegisterAttached(
            "DataGridDoubleClickCommand",
            typeof(ICommand),
            typeof(DataGridCommands),
            new PropertyMetadata(new PropertyChangedCallback(AttachOrRemoveDataGridDoubleClickEvent)));

        /// <summary>
        /// Gets the data grid double click command.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>ICommand.</returns>
        public static ICommand GetDataGridDoubleClickCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(DataGridDoubleClickProperty);
        }

        /// <summary>
        /// Sets the data grid double click command.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="value">The value.</param>
        public static void SetDataGridDoubleClickCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(DataGridDoubleClickProperty, value);
        }

        /// <summary>
        /// Attaches the or remove data grid double click event.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        public static void AttachOrRemoveDataGridDoubleClickEvent(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (obj is DataGrid dataGrid)
            {
                ICommand cmd = (ICommand)args.NewValue;

                if (args.OldValue == null && args.NewValue != null)
                {
                    dataGrid.MouseDoubleClick += ExecuteDataGridDoubleClick;
                }
                else if (args.OldValue != null && args.NewValue == null)
                {
                    dataGrid.MouseDoubleClick -= ExecuteDataGridDoubleClick;
                }
            }
        }

        /// <summary>
        /// Method Executes on DataGridDoubleClick.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguements.</param>
        private static void ExecuteDataGridDoubleClick(object sender, MouseButtonEventArgs args)
        {
            DependencyObject obj = sender as DependencyObject;
            ICommand cmd = (ICommand)obj.GetValue(DataGridDoubleClickProperty);
            if (cmd != null)
            {
                if (cmd.CanExecute(obj))
                {
                    cmd.Execute(obj);
                }
            }
        }
    }
}
