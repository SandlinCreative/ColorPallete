using System;
using System.Linq;
using System.Windows.Media;

namespace ColorPallete
{
    class Pallete
    {
        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Pallete()
        {

        }
        public Pallete(RGB input)
        {
            this.R = input.R;
            this.G = input.G;
            this.B = input.B;
            ActiveColor = Color.FromRgb(R, G, B);
        }
        public Pallete(HSL input)
        {
            this.H = input.H;
            this.S = input.S;
            this.L = input.L;

        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Converts RGB to HSL
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns>HSL</returns>
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

        /// <summary>
        /// Converts HSL to RGB
        /// </summary>
        /// <param name="hsl"></param>
        /// <returns>RGB</returns>
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

        #region Public Properties
        public Color ActiveColor { get; set; } = new Color();
        public byte R { get; set; } = 0;
        public byte G { get; set; } = 0;
        public byte B { get; set; } = 0;
        public int H { get; set; } = 0;
        public float S { get; set; } = 0;
        public float L { get; set; } = 0;
        #endregion
    }

    public class RGB
    {
        public RGB(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public bool Equals(RGB rgb)
        {
            return (this.R == rgb.R) && (this.G == rgb.G) && (this.B == rgb.B);
        }
    }

    public class HSL
    {
        public HSL()
        {
            this.H = 0;
            this.S = 0;
            this.L = 0;
        }
        public HSL(int h, float s, float l)
        {
            this.H = h;
            this.S = s;
            this.L = l;
        }

        public int H { get; set; }
        public float S { get; set; }
        public float L { get; set; }
        public bool Equals(HSL hsl)
        {
            return (this.H == hsl.H) && (this.S == hsl.S) && (this.L == hsl.L);
        }
    }
}
