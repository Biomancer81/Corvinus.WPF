// <copyright file="ImageTabItem.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Image Tab Item Allows the use of a Geometry Vector Image in the tab.
    /// </summary>
    public class ImageTabItem : TabItem
    {
        /// <summary>
        /// DependencyProperty used to store the Geometry for a Vector.
        /// </summary>
        public static readonly DependencyProperty ImageGeometryProperty = DependencyProperty.Register("ImageGeometry", typeof(Geometry), typeof(ImageTabItem), new UIPropertyMetadata(null));

        ///// <summary>
        ///// DependencyProperty used to store the SolidColorBrush for the background onMouseOver.
        ///// </summary>
        // public static readonly DependencyProperty MouseOverColorProperty = DependencyProperty.Register("MouseOverColor", typeof(SolidColorBrush), typeof(ImageTabItem), new UIPropertyMetadata(null));

        ///// <summary>
        ///// DependencyProperty used to store the SolidColorBrush for the background onMouseDown.
        ///// </summary>
        // public static readonly DependencyProperty HighlightColorProperty = DependencyProperty.Register("HighlightColor", typeof(SolidColorBrush), typeof(ImageTabItem), new UIPropertyMetadata(null));

        /// <summary>
        /// Initializes static members of the <see cref="ImageTabItem"/> class.
        /// </summary>
        static ImageTabItem()
        {
            // DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageTabItem), new FrameworkPropertyMetadata(typeof(ImageTabItem)));
        }

        /// <summary>
        /// Gets or sets Geometry Resource.
        /// </summary>
        public Geometry ImageGeometry
        {
            get { return (Geometry)this.GetValue(ImageGeometryProperty); }
            set { this.SetValue(ImageGeometryProperty, value); }
        }
    }
}
