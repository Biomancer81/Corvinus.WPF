// <copyright file="IWindowProvider.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Windows
{
    using System.Windows;

    /// <summary>Interface to get a window instance.</summary>
    public interface IWindowProvider
    {
        /// <summary>Gets the window.</summary>
        /// <returns>Window instance.</returns>
        Window Window { get; }
    }
}
