using Microsoft.VisualStudio.Modeling.Diagrams;
using System.ComponentModel;
using System.Windows.Media;

namespace ColorPallete2
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };


        private HslColor _hslColor = HslColor.FromRgbColor(ConvertColor(Colors.Blue));
        private Color _baseHueColor;
        public SolidColorBrush ColorBrush
        {
            get
            {
                return new SolidColorBrush(ConvertColor(_hslColor.ToRgbColor()));
            }
            set { }
        }
        public SolidColorBrush BaseHueColorBrush
        {
            get
            {
                return new SolidColorBrush(_baseHueColor);
            }
            set { }
        }
        public int Hue
        {
            get { return _hslColor.Hue; }
            set
            {
                _hslColor.Hue = value;
                UpdateBaseHue();
                PropertyChanged(this, new PropertyChangedEventArgs("BaseHueGradientBrush"));
                PropertyChanged(this, new PropertyChangedEventArgs("BaseHueColorBrush"));
                PropertyChanged(this, new PropertyChangedEventArgs("Hue"));
                PropertyChanged(this, new PropertyChangedEventArgs("ColorBrush"));
            }
        }
        public int Saturation
        {
            get { return _hslColor.Saturation; }
            set
            {
                _hslColor.Saturation = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Saturation"));
                PropertyChanged(this, new PropertyChangedEventArgs("ColorBrush"));
                //PropertyChanged(this, new PropertyChangedEventArgs("BaseHueColorBrush"));
            }
        }
        public int Luminosity
        {
            get { return _hslColor.Luminosity; }
            set
            {
                _hslColor.Luminosity = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Luminosity"));
                PropertyChanged(this, new PropertyChangedEventArgs("ColorBrush"));
                //PropertyChanged(this, new PropertyChangedEventArgs("BaseHueColorBrush"));
            }
        }
        public LinearGradientBrush BaseHueGradientBrush
        {
            get
            {
                LinearGradientBrush lgb = new LinearGradientBrush();
                GradientStop stop2 = new GradientStop(Colors.White, 0);
                GradientStop stop1 = new GradientStop(_baseHueColor, 1);
                lgb.StartPoint = new System.Windows.Point(0, 0);
                lgb.EndPoint = new System.Windows.Point(1, 0.5);
                lgb.MappingMode = BrushMappingMode.RelativeToBoundingBox;
                lgb.GradientStops.Add(stop1);
                lgb.GradientStops.Add(stop2);
                return lgb;
            }

        }


        public ViewModel()
        {
            _hslColor = HslColor.FromRgbColor(ConvertColor(Colors.Blue));
            UpdateBaseHue();
        }

        private static System.Drawing.Color ConvertColor(System.Windows.Media.Color input)
        {
            return System.Drawing.Color.FromArgb(input.A,input.R,input.G,input.B);
        }
        private static System.Windows.Media.Color ConvertColor(System.Drawing.Color input)
        {
            return System.Windows.Media.Color.FromArgb(input.A, input.R, input.G, input.B);
        }
        private void UpdateBaseHue()
        {
            HslColor h = new HslColor(_hslColor.Hue, 240, 239 / 2);
            System.Drawing.Color c = h.ToRgbColor();
            _baseHueColor.A = c.A;
            _baseHueColor.R = c.R;
            _baseHueColor.G = c.G;
            _baseHueColor.B = c.B;
        }
    }
}
