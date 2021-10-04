using System;
using System.Windows;
using System.Windows.Input;

namespace ColorPallete
{
    class MainView : BaseViewModel
    {

        #region Public Properties

        public Pallete myPallete { get; set; }
        public int Hue {
            get { return myPallete.Hue; }
            set { myPallete.Hue = value; }
        }
        public int Saturation
        {
            get { return myPallete.Saturation; }
            set { myPallete.Saturation = value; }
        }
        public int Luminosity
        {
            get { return myPallete.Luminosity ; }
            set { myPallete.Luminosity = value; }
        }
        public int R { get { return myPallete.ColorRGB.R; } }
        public int G { get { return myPallete.ColorRGB.G; } }
        public int B { get { return myPallete.ColorRGB.B; } }
        public string RgbHex
        {
            get { return myPallete.RgbHex; }
            set { myPallete.RgbHex = value; }
        }
        public System.Drawing.Color BaseHue
        {
            get { return myPallete.BaseHueColor; }
            set { }
        }

        public byte StatsR => myPallete.ColorHSL.ToRgbColor().R;
        public byte StatsG => myPallete.ColorHSL.ToRgbColor().G;
        public byte StatsB => myPallete.ColorHSL.ToRgbColor().B;

        #endregion


        #region Constructor

        public MainView()
        {
            myPallete = new Pallete();
            //this.UpdateHueBrushCommand = new RelayCommand(UpdateHueBrush);
        }


        #region Public Methods

        public void SliderMouseUp()
        {
            this.RgbHex = myPallete.RgbHex;
        }

        #endregion


        #endregion


        #region Public Commands

        public ICommand DoSomethingCommand { get; set; }
        //public RelayCommand UpdateHueBrushCommand { get; set; }

        #endregion


        #region Private Helpers

        private void UpdateStatusBar()
        {

        }

        #endregion

    }
}
