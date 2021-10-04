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
        public string _rgbHex;

        #endregion


        #region Public Properties

        public HslColor ColorHSL { get; set; }
        public int Hue { get { return _hsl.Hue; } set { _hsl.Hue = value; Update(); } }
        public int Saturation { get { return _hsl.Saturation; } set { _hsl.Saturation = value; Update(); } }
        public int Luminosity { get { return _hsl.Luminosity; } set { _hsl.Luminosity = value; Update(); } }

        public System.Drawing.Color ColorRGB
        {
            get { return this._hsl.ToRgbColor(); }
            set { 
                this._hsl = HslColor.FromRgbColor(value);
                Update();
            }
        }
        public string RgbHex
        {
            get { return _rgbHex; }
            set { _rgbHex = value; }
        }
        public System.Drawing.Color BaseHueColor
        {
            get { return new HslColor(_hsl.Hue, 100, 50).ToRgbColor(); }
            private set { }
        }

        #endregion


        #region Constructor

        public Pallete()
        {
            _hsl = new HslColor(0,100,50);
            ColorHSL = _hsl;
            Update();
        }
        public Pallete(System.Drawing.Color input)
        {
            _hsl = HslColor.FromRgbColor(input);
            Update();
        }
        public Pallete(HslColor input)
        {
            _hsl = input;
            Update();
        }

        #endregion


        #region Public Methods

        public void Update()
        {
            _rgbHex = $"#FF{ColorRGB.R.ToString("X2")}{ColorRGB.G.ToString("X2")}{ColorRGB.B.ToString("X2")}";

        }


        #endregion


        #region Helpers


        #endregion

    }




}
