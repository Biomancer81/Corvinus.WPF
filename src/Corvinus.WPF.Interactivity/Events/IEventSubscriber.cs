// <copyright file="IEventSubscriber.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Events
{
    using System;

    /// <summary>Use to subscribe to events.</summary>
    /// <typeparam name="TEventArgs">Type of event arguments.</typeparam>
    public interface IEventSubscriber<TEventArgs>
        where TEventArgs : EventArgs
    {
        /// <summary>Sets up a subscription recieve events.</summary>
        /// <param name="eventHandler">Action to called when the event occurs.</param>
        void Subscribe(Action<TEventArgs> eventHandler);

        /// <summary>Removes a subscription recieve events.</summary>
        /// <param name="eventHandler">Action to called when the event occurs.</param>
        void Unsubscribe(Action<TEventArgs> eventHandler);
    }
}
