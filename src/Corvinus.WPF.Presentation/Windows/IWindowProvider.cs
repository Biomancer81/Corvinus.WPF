// <copyright file="IWindowProvider.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
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
