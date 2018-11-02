// <copyright file="IEventPublisher.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Events
{
    using System;

    /// <summary>Use to publish events.</summary>
    /// <typeparam name="TEventArgs">Type of event arguments.</typeparam>
    public interface IEventPublisher<TEventArgs>
        where TEventArgs : EventArgs
    {
        /// <summary>Publishes events to all subscribers.</summary>
        /// <param name="eventArgs">Event arguments.</param>
        void Publish(TEventArgs eventArgs);
    }
}
