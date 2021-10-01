using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorPallete
{
    class Pallete
    {

        #region Private Members

        private Color _activeColor;
        private Color _baseHue;

        private RGB _rgb;
        private HSL _hsl;

        #endregion


        #region Public Properties
        public Color ActiveColor {
            get { return this._activeColor; }
            set { this._activeColor = value; }
        }
        public Color BaseHue {
            get { return this._baseHue; }
            set { this._baseHue = value; }
        }
        public RGB ColorRGB {
            get { return this._rgb; }
            set { this._rgb = value; }
        }
        public HSL ColorHSL {
            get { return this._hsl; }
            set { this._hsl = value; }
        }
        #endregion


        #region Constructor

        public Pallete()
        {
            _activeColor = new Color();
            _baseHue = new Color();

            //Task.Run( async () => { while (true) { await Task.Delay(100); 
            //        Console.WriteLine($"BaseHueColor: {BaseHueColor.R} {BaseHueColor.G} {BaseHueColor.B}");
            //    } } );
        }
        public Pallete(RGB input)
        {
            _rgb.R = input.R;
            _rgb.G = input.G;
            _rgb.B = input.B;
            ActiveColor = Color.FromRgb(_rgb.R, _rgb.G, _rgb.B);
            BaseHue = Color.FromRgb(_rgb.R, _rgb.G, _rgb.B);
        }
        public Pallete(HSL input)
        {
            this._hsl.H = input.H;
            this._hsl.S = input.S;
            this._hsl.L = input.L;

        }

        #endregion


        #region Public Methods

        public void UpdateBaseHueColor()
        {
            // not implemented
        }
        public static HSL RGBtoHSL(byte r, byte g, byte b)
        {
            return RGBToHSL(new RGB(r,g,b));
        }
        public static HSL RGBToHSL(RGB rgb)
        {
            HSL hsl = new HSL();

            float r = (rgb.R / 255.0f);
            float g = (rgb.G / 255.0f);
            float b = (rgb.B / 255.0f);

            float min = Math.Min(Math.Min(r, g), b);
            float max = Math.Max(Math.Max(r, g), b);
            float delta = max - min;

            hsl.L = (max + min) / 2;

            if (delta == 0)
            {
                hsl.H = 0;
                hsl.S = 0.0f;
            }
            else
            {
                hsl.S = (hsl.L <= 0.5) ? (delta / (max + min)) : (delta / (2 - max - min));

                float hue;

                if (r == max)
                {
                    hue = ((g - b) / 6) / delta;
                }
                else if (g == max)
                {
                    hue = (1.0f / 3) + ((b - r) / 6) / delta;
                }
                else
                {
                    hue = (2.0f / 3) + ((r - g) / 6) / delta;
                }

                if (hue < 0)
                    hue += 1;
                if (hue > 1)
                    hue -= 1;

                hsl.H = (int)(hue * 360);
            }

            return hsl;
        }
        public static RGB HSLToRGB(int h, float s, float l)
        {
            return HSLToRGB(new HSL(h,s,l));
        }
        public static RGB HSLToRGB(HSL hsl)
        {
            byte r = 0;
            byte g = 0;
            byte b = 0;

            if (hsl.S == 0)
            {
                r = g = b = (byte)(hsl.L * 255);
            }
            else
            {
                float v1, v2;
                float hue = (float)hsl.H / 360;

                v2 = (hsl.L < 0.5) ? (hsl.L * (1 + hsl.S)) : ((hsl.L + hsl.S) - (hsl.L * hsl.S));
                v1 = 2 * hsl.L - v2;

                r = (byte)(255 * HueToRGB(v1, v2, hue + (1.0f / 3)));
                g = (byte)(255 * HueToRGB(v1, v2, hue));
                b = (byte)(255 * HueToRGB(v1, v2, hue - (1.0f / 3)));
            }

            return new RGB(r, g, b);
        }

        #endregion


        #region Helpers

        private static Color GetBaseHue(float mHue)
        {
            return Color.FromRgb(
                (byte)(255 * HueToRGB(2.0f, 1.0f, mHue + (1.0f / 3))),
                (byte)(255 * HueToRGB(2.0f, 1.0f, mHue)),
                (byte)(255 * HueToRGB(2.0f, 1.0f, mHue - (1.0f / 3))));
        }
        private static float HueToRGB(float v1, float v2, float vH)
        {
            if (vH < 0)
                vH += 1;

            if (vH > 1)
                vH -= 1;

            if ((6 * vH) < 1)
                return (v1 + (v2 - v1) * 6 * vH);

            if ((2 * vH) < 1)
                return v2;

            if ((3 * vH) < 2)
                return (v1 + (v2 - v1) * ((2.0f / 3) - vH) * 6);

            return v1;
        }

        #endregion

    }




}
