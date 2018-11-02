// <copyright file="EventArgsExtension.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Interactivity.Extensions
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    using Corvinus.WPF.Interactivity.Dependency;

    /// <summary>
    /// EventArgsExtention MarkupExtension.
    /// </summary>
    public class EventArgsExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgsExtension"/> class.
        /// Default constructor for EventArgsExtension.
        /// </summary>
        public EventArgsExtension()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgsExtension"/> class.
        /// </summary>
        /// <param name="path">PropertyPath name.</param>
        public EventArgsExtension(string path)
        {
            this.Path = new PropertyPath(path);
        }

        /// <summary>
        /// Gets or sets Path.
        /// </summary>
        public PropertyPath Path { get; set; }

        /// <summary>
        /// Gets or sets Converter.
        /// </summary>
        public IValueConverter Converter { get; set; }

        /// <summary>
        /// Gets or sets ConverterParameter.
        /// </summary>
        public object ConverterParameter { get; set; }

        /// <summary>
        /// Gets or sets ConverterTargetType.
        /// </summary>
        public Type ConverterTargetType { get; set; }

        /// <summary>
        /// Gets or sets ConverterCulture.
        /// </summary>
        [TypeConverter(typeof(CultureInfoIetfLanguageTagConverter))]
        public CultureInfo ConverterCulture { get; set; }

        /// <summary>
        /// Provides the current instance of <see cref="EventArgsExtension"/>.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/>.</param>
        /// <returns>The current instance of <see cref="EventArgsExtension"/>.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        /// <summary>
        /// Provides the EventArgs for the Event.
        /// </summary>
        /// <param name="eventArgs"><see cref="EventArgs"/>.</param>
        /// <param name="language"><see cref="XmlLanguage"/>.</param>
        /// <returns>The EventArgs value.</returns>
        internal object GetArgumentValue(EventArgs eventArgs, XmlLanguage language)
        {
            if (this.Path == null)
            {
                return eventArgs;
            }

            object value = PropertyPathHelpers.Evaluate(this.Path, eventArgs);

            if (this.Converter != null)
            {
                value = this.Converter.Convert(value, this.ConverterTargetType ?? typeof(object), this.ConverterParameter, this.ConverterCulture ?? language.GetSpecificCulture());
            }

            return value;
        }
    }
}
