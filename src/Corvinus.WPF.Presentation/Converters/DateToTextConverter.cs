// <copyright file="DateToTextConverter.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Converts Date to Text.
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateToTextConverter : IValueConverter
    {
        /// <summary>
        /// Converts Date to Text.
        /// </summary>
        /// <param name="value">value object.</param>
        /// <param name="targetType">Type.</param>
        /// <param name="parameter">parameter object.</param>
        /// <param name="culture">CultureInfo.</param>
        /// <returns>return object.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime? date = (DateTime?)value;
            if (date != null)
            {
                DateTime retval = (DateTime)date;
                return retval.ToShortDateString();
            }
            else
            {
                return string.Empty;
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
