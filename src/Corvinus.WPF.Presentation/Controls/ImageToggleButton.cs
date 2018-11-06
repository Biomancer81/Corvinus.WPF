// <copyright file="ImageToggleButton.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Controls
{
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;

    /// <summary>
    /// Toggle Button that can use a Geometry or Raster Image.
    /// </summary>
    public class ImageToggleButton : ToggleButton
    {
        /// <summary>
        /// Image Button Geometry Value.
        /// </summary>
        public static readonly DependencyProperty ImageGeometryProperty = DependencyProperty.Register("ImageGeometry", typeof(Geometry), typeof(ImageToggleButton), new UIPropertyMetadata(null));

        /// <summary>
        /// Image Button Raster Image Value.
        /// </summary>
        public static readonly DependencyProperty ImageUriProperty = DependencyProperty.Register("ImageUri", typeof(ImageSource), typeof(ImageToggleButton), new UIPropertyMetadata(null));

        /// <summary>
        /// Initializes static members of the <see cref="ImageToggleButton"/> class.
        /// </summary>
        static ImageToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageToggleButton), new FrameworkPropertyMetadata(typeof(ImageToggleButton)));
        }

        /// <summary>
        /// Gets or sets the image geometry.
        /// </summary>
        /// <value>The image geometry.</value>
        public Geometry ImageGeometry
        {
            get { return (Geometry)this.GetValue(ImageGeometryProperty); }
            set { this.SetValue(ImageGeometryProperty, value); }
        }

        /// <summary>
        /// Gets or sets the image URI.
        /// </summary>
        /// <value>The image URI.</value>
        public ImageSource ImageUri
        {
            get { return (ImageSource)this.GetValue(ImageUriProperty); }
            set { this.SetValue(ImageUriProperty, value); }
        }
    }
}
