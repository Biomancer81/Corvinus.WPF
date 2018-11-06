// <copyright file="InverseBoolConverter.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>Converts from a boolean value to its' inverse value.</summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBoolConverter : IValueConverter
    {
        /// <summary>Converts from a boolean value to the opposite boolean value.</summary>
        /// <param name="value">The value to convert from.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">An additional parameter.</param>
        /// <param name="culture">The culture information.</param>
        /// <returns>The opposite boolean value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;
            return !boolValue;
        }

        /// <summary>Converts back from a boolean value to the opposite boolean value.</summary>
        /// <param name="value">The value to convert from.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">An additional parameter.</param>
        /// <param name="culture">The culture information.</param>
        /// <returns>The opposite boolean value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;
            return !boolValue;
        }
    }
}
