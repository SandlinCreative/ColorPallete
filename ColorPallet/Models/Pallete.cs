using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace ColorPallete
{
    class Pallete
    {

        #region Private Members

        private HslColor _hsl;
        private System.Drawing.Color _rgb;
        private string _rgbHex;
        private System.Windows.Media.Color _wmColor;
        private System.Windows.Media.Color _baseHueWMColor;

        #endregion


        #region Public Properties

        public HslColor ColorHSL { get => _hsl; set { _hsl = value; Update(value); } }
        public int Hue { get { return _hsl.Hue; } set { _hsl.Hue = value; Update(value); } }
        public int Saturation { get { return _hsl.Saturation; } set { _hsl.Saturation = value; Update(value); } }
        public int Luminosity { get { return _hsl.Luminosity; } set { _hsl.Luminosity = value; Update(value); } }
        public System.Drawing.Color ColorRGB { get => _rgb; set { _rgb = value; Update(value); } }
        public string RgbHex => _rgbHex;
        public SolidColorBrush ColorBrush => new SolidColorBrush(_wmColor);
        public System.Windows.Media.Color BaseHueWMColor => _baseHueWMColor;
        public LinearGradientBrush BaseHueGradient
        {
            get
            {
                LinearGradientBrush lgb = new LinearGradientBrush();
                GradientStop stop2 = new GradientStop(Colors.White, 0);
                GradientStop stop1 = new GradientStop(BaseHueWMColor, 1);
                lgb.StartPoint = new System.Windows.Point(0,0);
                lgb.EndPoint = new System.Windows.Point(1, 0.5);
                lgb.MappingMode = BrushMappingMode.RelativeToBoundingBox;
                lgb.GradientStops.Add(stop1);
                lgb.GradientStops.Add(stop2);
                return lgb;
            }
        }

        #endregion


        #region Constructor

        public Pallete()
        {
            ColorHSL = HslColor.FromRgbColor(System.Drawing.Color.FromArgb(255, 0, 0));
        }
        public Pallete(HslColor input)
        {
            ColorHSL = input;
        }
        public Pallete(System.Drawing.Color input)
        {
            ColorRGB = input;
        }

        #endregion


        #region Public Methods


        private void Update(object value)
        {
            if (value is System.Drawing.Color)
            { // update from RGB color
                _hsl = HslColor.FromRgbColor((System.Drawing.Color)value);
            }
            else if (value is HslColor || value is Int32)
            {// update from existing HSL color
                _rgb = _hsl.ToRgbColor();
            }

            UpdateHex();
            UpdateWMColor();
            UpdateBaseHue();
        }



        #endregion


        #region Helpers

        private void UpdateHex() => _rgbHex = $"#FF{ColorRGB.R:X2}{ColorRGB.G:X2}{ColorRGB.B:X2}";
        private void UpdateWMColor()
        {
            _wmColor.A = _rgb.A;
            _wmColor.R = _rgb.R;
            _wmColor.G = _rgb.G;
            _wmColor.B = _rgb.B;
        }
        private void UpdateBaseHue()
        {
            HslColor h = new HslColor(_hsl.Hue, 240, 239/2);
            System.Drawing.Color c = h.ToRgbColor();
            _baseHueWMColor.A = c.A;
            _baseHueWMColor.R = c.R;
            _baseHueWMColor.G = c.G;
            _baseHueWMColor.B = c.B;
        }

        #endregion

    }




}
