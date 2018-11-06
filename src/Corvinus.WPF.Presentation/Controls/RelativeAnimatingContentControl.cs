// <copyright file="RelativeAnimatingContentControl.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    /// <summary>
    /// RelativeAnimatingContentControl class.
    /// </summary>
    public class RelativeAnimatingContentControl : ContentControl
    {
        private const double SimpleDoubleComparisonEpsilon = 0.000009;
        private double knownWidth;
        private double knownHeight;
        private List<AnimationValueAdapter> specialAnimations;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelativeAnimatingContentControl"/> class.
        /// </summary>
        public RelativeAnimatingContentControl()
        {
            this.SizeChanged += this.OnSizeChanged;
        }

        /// <summary>
        /// DoubleAnimationDimension Enumeration.
        /// </summary>
        private enum DoubleAnimationDimension
        {
            Width,
            Height,
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e != null && e.NewSize.Height > 0 && e.NewSize.Width > 0)
            {
                this.knownWidth = e.NewSize.Width;
                this.knownHeight = e.NewSize.Height;

                this.Clip = new RectangleGeometry { Rect = new Rect(0, 0, this.knownWidth, this.knownHeight), };

                this.UpdateAnyAnimationValues();
            }
        }

        private void UpdateAnyAnimationValues()
        {
            if (this.knownHeight > 0 && this.knownWidth > 0)
            {
                if (this.specialAnimations == null)
                {
                    this.specialAnimations = new List<AnimationValueAdapter>();

                    foreach (VisualStateGroup group in VisualStateManager.GetVisualStateGroups(this))
                    {
                        if (group == null)
                        {
                            continue;
                        }

                        foreach (VisualState state in group.States)
                        {
                            if (state != null)
                            {
                                Storyboard sb = state.Storyboard;
                                if (sb != null)
                                {
                                    foreach (Timeline timeline in sb.Children)
                                    {
                                        DoubleAnimation da = timeline as DoubleAnimation;
                                        DoubleAnimationUsingKeyFrames dakeys = timeline as DoubleAnimationUsingKeyFrames;
                                        if (da != null)
                                        {
                                            this.ProcessDoubleAnimation(da);
                                        }
                                        else if (dakeys != null)
                                        {
                                            this.ProcessDoubleAnimationWithKeys(dakeys);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                this.UpdateKnownAnimations();
            }
        }

        private void UpdateKnownAnimations()
        {
            foreach (AnimationValueAdapter adapter in this.specialAnimations)
            {
                adapter.UpdateWithNewDimension(this.knownWidth, this.knownHeight);
            }
        }

        private void ProcessDoubleAnimationWithKeys(DoubleAnimationUsingKeyFrames da)
        {
            foreach (DoubleKeyFrame frame in da.KeyFrames)
            {
                var d = DoubleAnimationFrameAdapter.GetDimensionFromMagicNumber(frame.Value);
                if (d.HasValue)
                {
                    this.specialAnimations.Add(new DoubleAnimationFrameAdapter(d.Value, frame));
                }
            }
        }

        private void ProcessDoubleAnimation(DoubleAnimation da)
        {
            if (da.To.HasValue)
            {
                var d = DoubleAnimationToAdapter.GetDimensionFromMagicNumber(da.To.Value);
                if (d.HasValue)
                {
                    this.specialAnimations.Add(new DoubleAnimationToAdapter(d.Value, da));
                }
            }

            if (da.From.HasValue)
            {
                var d = DoubleAnimationFromAdapter.GetDimensionFromMagicNumber(da.To.Value);
                if (d.HasValue)
                {
                    this.specialAnimations.Add(new DoubleAnimationFromAdapter(d.Value, da));
                }
            }
        }

        private abstract class AnimationValueAdapter
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AnimationValueAdapter"/> class.
            /// </summary>
            /// <param name="dimension"><see cref="DoubleAnimationDimension"/>.</param>
            public AnimationValueAdapter(DoubleAnimationDimension dimension)
            {
                this.Dimension = dimension;
            }

            /// <summary>
            /// Gets Dimension.
            /// </summary>
            public DoubleAnimationDimension Dimension { get; private set; }

            /// <summary>
            /// Gets or sets OriginalValue.
            /// </summary>
            protected double OriginalValue { get; set; }

            /// <summary>
            /// UpdateWithNewDimension method.
            /// </summary>
            /// <param name="width"><see cref="double"/> width.</param>
            /// <param name="height"><see cref="double"/> height.</param>
            public abstract void UpdateWithNewDimension(double width, double height);
        }

        /// <summary>
        /// GeneralAnimationValueAdapter class.
        /// </summary>
        /// <typeparam name="T">Instance Type.</typeparam>
        private abstract class GeneralAnimationValueAdapter<T> : AnimationValueAdapter
        {
            private double ratio;

            /// <summary>
            /// Initializes a new instance of the <see cref="GeneralAnimationValueAdapter{T}"/> class.
            /// </summary>
            /// <param name="d"><see cref="DoubleAnimationDimension"/> Dimension.</param>
            /// <param name="instance">Instance Type.</param>
            public GeneralAnimationValueAdapter(DoubleAnimationDimension d, T instance)
                : base(d)
            {
                this.Instance = instance;

                this.InitialValue = this.StripMagicNumberOff(this.GetValue());
                this.ratio = this.InitialValue / 100;
            }

            /// <summary>
            /// Gets or sets Instance.
            /// </summary>
            protected T Instance { get; set; }

            /// <summary>
            /// Gets IntialValue.
            /// </summary>
            protected double InitialValue { get; private set; }

            /// <summary>
            /// GetDimensionFromMagicNumber method.
            /// </summary>
            /// <param name="number">Number as <see cref="double"/>.</param>
            /// <returns><see cref="DoubleAnimationDimension"/>.</returns>
            public static DoubleAnimationDimension? GetDimensionFromMagicNumber(double number)
            {
                double floor = Math.Floor(number);
                double remainder = number - floor;

                if (remainder >= .1 - SimpleDoubleComparisonEpsilon && remainder <= .1 + SimpleDoubleComparisonEpsilon)
                {
                    return DoubleAnimationDimension.Width;
                }

                if (remainder >= .2 - SimpleDoubleComparisonEpsilon && remainder <= .2 + SimpleDoubleComparisonEpsilon)
                {
                    return DoubleAnimationDimension.Height;
                }

                return null;
            }

            /// <summary>
            /// StripMagicNumberOff method.
            /// </summary>
            /// <param name="number">Number as <see cref="double"/>.</param>
            /// <returns><see cref="double"/>.</returns>
            public double StripMagicNumberOff(double number)
            {
                return this.Dimension == DoubleAnimationDimension.Width ? number - .1 : number - .2;
            }

            /// <summary>
            /// UpdateWithNewDimension method.
            /// </summary>
            /// <param name="width">Width as <see cref="double"/>.</param>
            /// <param name="height">Height as <see cref="double"/>.</param>
            public override void UpdateWithNewDimension(double width, double height)
            {
                double size = this.Dimension == DoubleAnimationDimension.Width ? width : height;
                this.UpdateValue(size);
            }

            /// <summary>
            /// GetValue method.
            /// </summary>
            /// <returns>Value as <see cref="double"/>.</returns>
            protected abstract double GetValue();

            /// <summary>
            /// SetValue method.
            /// </summary>
            /// <param name="newValue">Value as <see cref="double"/>.</param>
            protected abstract void SetValue(double newValue);

            /// <summary>
            /// UpdateValue method.
            /// </summary>
            /// <param name="sizeToUse">Size as <see cref="double"/>.</param>
            private void UpdateValue(double sizeToUse)
            {
                this.SetValue(sizeToUse * this.ratio);
            }
        }

        private class DoubleAnimationToAdapter : GeneralAnimationValueAdapter<DoubleAnimation>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DoubleAnimationToAdapter"/> class.
            /// </summary>
            /// <param name="dimension"><see cref="DoubleAnimationDimension"/>.</param>
            /// <param name="instance"><see cref="DoubleAnimation"/>.</param>
            public DoubleAnimationToAdapter(DoubleAnimationDimension dimension, DoubleAnimation instance)
                : base(dimension, instance)
            {
            }

            /// <summary>
            /// GetValue method.
            /// </summary>
            /// <returns>Value as <see cref="double"/>.</returns>
            protected override double GetValue()
            {
                return (double)this.Instance.To;
            }

            /// <summary>
            /// SetValue method.
            /// </summary>
            /// <param name="newValue">Value as <see cref="double"/>.</param>
            protected override void SetValue(double newValue)
            {
                this.Instance.To = newValue;
            }
        }

        private class DoubleAnimationFromAdapter : GeneralAnimationValueAdapter<DoubleAnimation>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DoubleAnimationFromAdapter"/> class.
            /// </summary>
            /// <param name="dimension"><see cref="DoubleAnimationDimension"/>.</param>
            /// <param name="instance"><see cref="DoubleAnimation"/>.</param>
            public DoubleAnimationFromAdapter(DoubleAnimationDimension dimension, DoubleAnimation instance)
                : base(dimension, instance)
            {
            }

            /// <summary>
            /// GetValue method.
            /// </summary>
            /// <returns>Value as <see cref="double"/>.</returns>
            protected override double GetValue()
            {
                return (double)this.Instance.From;
            }

            /// <summary>
            /// SetValue method.
            /// </summary>
            /// <param name="newValue">Value as <see cref="double"/>.</param>
            protected override void SetValue(double newValue)
            {
                this.Instance.From = newValue;
            }
        }

        private class DoubleAnimationFrameAdapter : GeneralAnimationValueAdapter<DoubleKeyFrame>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DoubleAnimationFrameAdapter"/> class.
            /// </summary>
            /// <param name="dimension"><see cref="DoubleAnimationDimension"/>.</param>
            /// <param name="instance"><see cref="DoubleAnimation"/>.</param>
            public DoubleAnimationFrameAdapter(DoubleAnimationDimension dimension, DoubleKeyFrame frame)
                : base(dimension, frame)
            {
            }

            /// <summary>
            /// GetValue method.
            /// </summary>
            /// <returns>Value as <see cref="double"/>.</returns>
            protected override double GetValue()
            {
                return this.Instance.Value;
            }

            /// <summary>
            /// SetValue method.
            /// </summary>
            /// <param name="newValue">Value as <see cref="double"/>.</param>
            protected override void SetValue(double newValue)
            {
                this.Instance.Value = newValue;
            }
        }
    }
}
