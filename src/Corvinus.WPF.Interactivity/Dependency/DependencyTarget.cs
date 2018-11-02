namespace Corvinus.WPF.Interactivity.Dependency
{
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Provides the target DependencyObject.
    /// </summary>
    internal class DependencyTarget : DependencyObject
    {
        /// <summary>
        /// DependencyProperty ValueProperty.
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(DependencyTarget));

        /// <summary>
        /// Gets or sets ValueProperty.
        /// </summary>
        public object Value
        {
            get => this.GetValue(ValueProperty);
            set => this.SetValue(ValueProperty, value);
        }
    }
}
