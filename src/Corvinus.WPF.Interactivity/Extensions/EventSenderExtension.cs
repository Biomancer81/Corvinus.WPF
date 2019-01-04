// <copyright file="EventSenderExtension.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Extensions
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// Markup Extension to allow Event Sender to be passed.
    /// </summary>
    public class EventSenderExtension : MarkupExtension
    {
        /// <summary>
        /// Provides Event Sender as vale.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/> used by event handler.</param>
        /// <returns>The event sender.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
