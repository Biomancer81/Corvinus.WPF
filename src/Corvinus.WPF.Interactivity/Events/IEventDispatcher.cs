// <copyright file="IEventDispatcher.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Events
{
    using System;

    /// <summary>Use to publish and subscribe to events.</summary>
    /// <typeparam name="TEventArgs">Type of event arguments.</typeparam>
    public interface IEventDispatcher<TEventArgs> : IEventPublisher<TEventArgs>,
                                                    IEventSubscriber<TEventArgs>
        where TEventArgs : EventArgs
    {
    }
}
