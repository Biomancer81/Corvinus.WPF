// <copyright file="TransitionPresenterViewModel.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Microsoft.Manufacturing.UI.WPF.Common.ViewModels.Controls
{
    using System.Windows;
    using Corvinus.WPF.Presentation.ViewModeling;

    /// <summary>
    /// New Transition Presenter View Model.
    /// </summary>
    /// <seealso cref="Corvinus.WPF.Presentation.ViewModeling.ViewModelBase" />
    public class TransitionPresenterViewModel : ViewModelBase
    {
        private double width;
        private double height;
        private Thickness thicknessIn;
        private Thickness thicknessOut;

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
                this.SetThickness();
                this.OnPropertyChanged("Width");
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
                this.OnPropertyChanged("Height");
            }
        }

        /// <summary>
        /// Gets or sets the thickness in.
        /// </summary>
        /// <value>
        /// The thickness in.
        /// </value>
        public Thickness ThicknessIn
        {
            get
            {
                return this.thicknessIn;
            }

            set
            {
                this.thicknessIn = value;
                this.OnPropertyChanged("ThicknessIn");
            }
        }

        /// <summary>
        /// Gets or sets the thickness out.
        /// </summary>
        /// <value>
        /// The thickness out.
        /// </value>
        public Thickness ThicknessOut
        {
            get
            {
                return this.thicknessOut;
            }

            set
            {
                this.thicknessOut = value;
                this.OnPropertyChanged("ThicknessOut");
            }
        }

        /// <summary>
        /// Sets the thickness.
        /// </summary>
        private void SetThickness()
        {
            Thickness tIn = default(Thickness);
            Thickness tOut = default(Thickness);

            tIn.Left += this.Width;
            tIn.Top = 0;
            tIn.Right -= this.Width;
            tIn.Bottom = 0;

            tOut.Left -= this.Width;
            tOut.Top = 0;
            tOut.Right += this.Width;
            tOut.Bottom = 0;

            this.ThicknessIn = tIn;
            this.ThicknessOut = tOut;
        }
    }
}
