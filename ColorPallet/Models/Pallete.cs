using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace ColorPallete
{
    class Pallete
    {

        #region Private Members

        private HslColor _hsl;

        #endregion


        #region Public Properties

        public HslColor ColorHSL { get; set; }
        public System.Drawing.Color ColorRGB 
        {
            get { return this._hsl.ToRgbColor(); }
            set { this._hsl = HslColor.FromRgbColor(value); }
        }

        #endregion


        #region Constructor

        public Pallete()
        {
            _hsl = new HslColor();
            ColorHSL = _hsl;
        }
        public Pallete(System.Drawing.Color input)
        {
            _hsl = HslColor.FromRgbColor(input);
        }
        public Pallete(HslColor input)
        {
            _hsl = input;
        }

        #endregion


        #region Public Methods



        #endregion


        #region Helpers



        #endregion

    }




}
