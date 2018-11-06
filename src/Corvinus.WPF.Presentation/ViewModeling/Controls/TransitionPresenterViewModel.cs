namespace Microsoft.Manufacturing.UI.WPF.Common.ViewModels.Controls
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Media.Animation;
    using System.Windows;

    public class TransitionPresenterViewModel : ViewModelBase
    {

        private double _width;
        private double _height;
        private Thickness _thicknessIn;
        private Thickness _thicknessOut;

        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                SetThickness();
                OnPropertyChanged("Width");
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged("Height");
            }
        }

        public Thickness ThicknessIn
        {
            get { return _thicknessIn; }
            set
            {
                _thicknessIn = value;
                OnPropertyChanged("ThicknessIn");
            }
        }

        public Thickness ThicknessOut
        {
            get { return _thicknessOut; }
            set
            {
                _thicknessOut = value;
                OnPropertyChanged("ThicknessOut");
            }
        }

        private void SetThickness()
        {
            Thickness tIn = new Thickness();
            Thickness tOut = new Thickness();

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
