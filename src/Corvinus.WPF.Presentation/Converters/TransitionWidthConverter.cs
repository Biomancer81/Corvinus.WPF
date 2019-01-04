// <copyright file="TransitionWidthConverter.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Converters
{
    using System;
    using System.Windows.Data;

    /// <summary>
    /// Transition Width Converter.
    /// </summary>
    public class TransitionWidthConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)value / 2;
        }

        /// <summary>
        /// Not Implemented.
        /// </summary>
        /// <param name="value">object.</param>
        /// <param name="targetType">Type.</param>
        /// <param name="parameter">parameter object.</param>
        /// <param name="culture">CultureInfo.</param>
        /// <returns>return object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
