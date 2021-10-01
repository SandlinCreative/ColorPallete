
namespace ColorPallete
{
    public class HSL
    {
        #region Public Properties

        public int H { get; set; } = 0;
        public float S { get; set; } = 0;
        public float L { get; set; } = 0;

        #endregion

        #region Constructor

        public HSL() { }
        public HSL(int h, float s, float l)
        {
            H = h;
            S = s;
            L = l;
        }

        #endregion

        #region Public Methods

        public bool Equals(HSL hsl) { return (this.H == hsl.H) && (this.S == hsl.S) && (this.L == hsl.L); }

        #endregion
    }
}
