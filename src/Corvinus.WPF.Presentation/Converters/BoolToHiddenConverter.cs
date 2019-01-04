// <copyright file="BoolToHiddenConverter.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Converters
{
    using System;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>Boolean to visibility converter.</summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToHiddenConverter : IValueConverter
    {
        /// <summary>
        /// Boolean to Hidden Converter.
        /// </summary>
        /// <param name="value">value object.</param>
        /// <param name="targetType">Type.</param>
        /// <param name="parameter">parameter object.</param>
        /// <param name="culture">CultureInfo.</param>
        /// <returns>Return object.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                return ((bool)value) == true ? Visibility.Hidden : Visibility.Visible;
            }
            else
            {
                throw new ArgumentException("Value should be Boolean type.");
            }
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
