// <copyright file="PropertyPathHelpers.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Dependency
{
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Helper Methods for getting PropertyPath information from a source.
    /// </summary>
    public static class PropertyPathHelpers
    {
        /// <summary>
        /// Evaluates the property path of the source and returns the value.
        /// </summary>
        /// <param name="path"><see cref="PropertyPath"/> with value.</param>
        /// <param name="source">Source <see cref="object"/>.</param>
        /// <returns>Value as object.</returns>
        public static object Evaluate(PropertyPath path, object source)
        {
            var target = new DependencyTarget();
            var binding = new Binding() { Path = path, Source = source, Mode = BindingMode.OneTime };
            BindingOperations.SetBinding(target, DependencyTarget.ValueProperty, binding);

            return target.Value;
        }
    }
}
