
namespace ColorPallete
{
    public class RGB
    {
        #region Public Properties

        public byte R { get; set; } = 0;
        public byte G { get; set; } = 0;
        public byte B { get; set; } = 0;

        #endregion

        #region Constructor

        public RGB() { }
        public RGB(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        #endregion

        #region Public Methods

        public bool Equals(RGB rgb) { return (this.R == rgb.R) && (this.G == rgb.G) && (this.B == rgb.B); }

        #endregion
    }
}
