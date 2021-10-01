using System.Windows;
using System.Windows.Input;

namespace ColorPallete
{
    class MainView : BaseViewModel
    {

        #region Public Properties

        public Pallete myPallete { get; set; }

        public int Hue { get; set; } = 0;
        public float Saturation { get; set; } = 100;
        public float Brightness { get; set; } = 100;
        public byte StatsR { get; set; } = 255;
        public byte StatsG { get; set; } = 255;
        public byte StatsB { get; set; } = 255;

        #endregion


        #region Constructor

        public MainView()
        {
            myPallete = new Pallete();

            // keeping this so I don't forget how to setup commands
            this.DoSomethingCommand = new RelayCommand(DoSomething);

            PropertyChanged += (sender, e) => {

                switch (e.PropertyName)
                {
                    case "Hue":
                        myPallete.ColorHSL.H = Hue;
                        break;
                    case "Saturation":
                        myPallete.ColorHSL.S = Saturation;
                        break;
                    case "Brightness":
                        myPallete.ColorHSL.L = Brightness;
                        break;
                    default:
                        break;
                }

                UpdateStatusBar();
            };
        }

        #endregion


        #region Public Commands

        public ICommand DoSomethingCommand { get; set; }

        #endregion


        #region Private Helpers

        private void UpdateStatusBar()
        {
            StatsR = myPallete.ColorRGB.R;
            StatsG = myPallete.ColorRGB.G;
            StatsB = myPallete.ColorRGB.B;
        }
        private void DoSomething()
        {
            
        }

        #endregion


        #region Public Methods

        public HSL ConvertRGBtoHSL(RGB inputRgb) => Pallete.RGBToHSL(inputRgb);
        public RGB ConvertHSLtoRGB(HSL inputHsl) => Pallete.HSLToRGB(inputHsl);

        #endregion

    }
}
