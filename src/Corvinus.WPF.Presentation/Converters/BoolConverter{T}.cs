// <copyright file="BoolConverter{T}.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>Generic class converts from a boolean value to values of type T.</summary>
    /// <typeparam name="T">The type to create.</typeparam>
    public class BoolConverter<T> : IValueConverter
    {
        /// <summary>Initializes a new instance of the <see cref="BoolConverter{T}" /> class.</summary>
        /// <param name="trueValue">The value to be returned when the input is true.</param>
        /// <param name="falseValue">The value to be returned when the input is false.</param>
        public BoolConverter(T trueValue, T falseValue)
        {
            this.TrueValue = trueValue;
            this.FalseValue = falseValue;
        }

        /// <summary>Gets or sets the value to be returned when the input is True.</summary>
        public T TrueValue { get; set; }

        /// <summary>Gets or sets the value to be returned when the input is False.</summary>
        public T FalseValue { get; set; }

        /// <summary>Converts from a boolean value to values of type T.</summary>
        /// <param name="value">The value to convert from.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">An additional parameter.</param>
        /// <param name="culture">The culture information.</param>
        /// <returns>A value of type T.</returns>
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                bool boolValue = (bool)value;
                return boolValue ? this.TrueValue : this.FalseValue;
            }
            else
            {
                return this.FalseValue;
            }
        }

        /// <summary>Converts back from values of type T to a boolean value.</summary>
        /// <param name="value">The value to convert from.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">An additional parameter.</param>
        /// <param name="culture">The culture information.</param>
        /// <returns>The opposite boolean value.</returns>
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is T && EqualityComparer<T>.Default.Equals((T)value, this.TrueValue);
        }
    }
}
