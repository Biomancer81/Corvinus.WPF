// <copyright file="ServiceProvider.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Dependency
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// ServiceProvider Class.
    /// </summary>
    internal class ServiceProvider : IServiceProvider, IProvideValueTarget
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProvider"/> class.
        /// </summary>
        /// <param name="targetObject">Target <see cref="object"/>.</param>
        /// <param name="targetProperty">Target property as <see cref="object"/>.</param>
        public ServiceProvider(object targetObject, object targetProperty)
        {
            this.TargetObject = targetObject;
            this.TargetProperty = targetProperty;
        }

        /// <inheritdoc/>
        public object TargetObject { get; }

        /// <inheritdoc/>
        public object TargetProperty { get; }

        /// <inheritdoc/>
        public object GetService(Type serviceType)
        {
            return serviceType.IsInstanceOfType(this) ? this : null;
        }
    }
}
