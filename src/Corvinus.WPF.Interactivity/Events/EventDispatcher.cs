// <copyright file="EventDispatcher.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Events
{
    using System;

    /// <summary>Event aggregator used for subscribing and publishing events.</summary>
    /// <typeparam name="TEventArgs">Event arguments.</typeparam>
    public class EventDispatcher<TEventArgs> : IEventDispatcher<TEventArgs>
        where TEventArgs : EventArgs
    {
        /// <summary>Delegate for handling events.</summary>
        /// <param name="sender">Sender - unused.</param>
        /// <param name="ea">Event arguments.</param>
        public delegate void EventDispatcherHandler(object sender, TEventArgs ea);

        /// <summary>Event handler for handling events.</summary>
        public event EventHandler<TEventArgs> EventOccurred;

        /// <summary>Gets or sets current operating mode.</summary>
        public TEventArgs EventArguments { get; set; }

        /// <summary>Publishes events to all subscribers.</summary>
        /// <param name="eventArgs">Event arguments.</param>
        public void Publish(TEventArgs eventArgs)
        {
            this.EventOccurred?.Invoke(this, eventArgs);
        }

        /// <summary>Sets up a subscription recieve events.</summary>
        /// <param name="eventHandler">Action to called when the event occurs.</param>
        public void Subscribe(Action<TEventArgs> eventHandler)
        {
            this.EventOccurred += (sender, args) => eventHandler(args);
        }

        /// <summary>Removes a subscription recieve events.</summary>
        /// <param name="eventHandler">Action to called when the event occurs.</param>
        public void Unsubscribe(Action<TEventArgs> eventHandler)
        {
            // TODO: Implement this.
            throw new NotImplementedException();
        }
    }
}
