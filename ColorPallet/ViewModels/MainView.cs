using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace ColorPallete
{
    class MainView : BaseViewModel
    {

        #region Public Properties

        public Pallete myPallete { get; set; }

        public int Hue { get { return myPallete.Hue; } set { myPallete.Hue = value; UpdateUI(); } }
        public int Saturation { get { return myPallete.Saturation; } set { myPallete.Saturation = value; UpdateUI(); } }
        public int Luminosity { get { return myPallete.Luminosity; } set { myPallete.Luminosity = value; UpdateUI(); } }

        public int R { get => myPallete.ColorRGB.R; set { this.R = value; } }
        public int G { get => myPallete.ColorRGB.G; set { this.G = value; } }
        public int B { get => myPallete.ColorRGB.B; set { this.B = value; } }

        public string RgbHex { get { return myPallete.RgbHex; } set { this.RgbHex = value; } }
        public SolidColorBrush ColorBrush => myPallete.ColorBrush;
        public System.Windows.Media.LinearGradientBrush BaseHueGradientBrush { get => myPallete.BaseHueGradient;  set { this.BaseHueGradientBrush = value; } }

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

        #endregion


        #region Public Methods



        #endregion


        #region Public Commands

        public ICommand testbtn_ClickCommand { get { return new RelayCommand(OnClick); } }
        //public RelayCommand UpdateHueBrushCommand { get; set; }

        #endregion


        #region Private Helpers
        private void OnClick()
        {
            this.RgbHex = "huh?";
        }

        private void UpdateUI()
        {
            //Hue = myPallete.Hue;
            //Saturation = myPallete.Saturation;
            //Luminosity = myPallete.Luminosity;
            //R = myPallete.ColorRGB.R;
            //G = myPallete.ColorRGB.G;
            //B = myPallete.ColorRGB.B;
            RgbHex = myPallete.RgbHex;
            //BaseHueGradientBrush = myPallete.BaseHueGradient;
        }

        #endregion

    }
}
