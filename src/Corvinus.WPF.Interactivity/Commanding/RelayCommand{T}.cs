// <copyright file="RelayCommand{T}.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Commanding
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;

    /// <summary>
    /// RelayCommand typeof T.
    /// </summary>
    /// <typeparam name="T">type.</typeparam>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute = null;
        private readonly Func<T, bool> canExecute = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="execute">Action typeof T.</param>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }

        /// <summary>
        /// EventHandler for CanExecuteChanged
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Returns Boolean of canExecute.
        /// </summary>
        /// <param name="parameter">object.</param>
        /// <returns>True/False.</returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute((T)parameter);
        }

        /// <summary>
        /// Executes parameter.
        /// </summary>
        /// <param name="parameter">object.</param>
        public void Execute(object parameter)
        {
            this.execute((T)parameter);
        }
    }
}
