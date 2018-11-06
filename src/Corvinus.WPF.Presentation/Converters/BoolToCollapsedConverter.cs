// <copyright file="BoolToCollapsedConverter.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Converters
{
    using System;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Converts a boolean to/from visibility.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToCollapsedConverter : IValueConverter
    {
        /// <summary>
        /// Converts a boolean value to a visibility enumeration value.
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
                return ((bool)value) == true ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        /// <summary>
        /// Converts a Visibility enumeration Value back to a boolean value.
        /// </summary>
        /// <param name="value">object.</param>
        /// <param name="targetType">Type.</param>
        /// <param name="parameter">parameter object.</param>
        /// <param name="culture">CultureInfo.</param>
        /// <returns>return object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((byte)value <= 2)
            {
                return ((Visibility)value) == Visibility.Collapsed ? true : false;
            }
            else
            {
                return false;
            }
        }
    }
}
