using System.Windows;
using System.Windows.Input;

namespace ColorPallete
{
    class MainView : BaseViewModel
    {

        #region Public Properties

        public Pallete myPallete = new Pallete();

        public int Hue {
            get { return myPallete.ColorHSL.Hue; }
            set { myPallete.ColorHSL.Hue = value; } 
        }
        public int Saturation
        {
            get { return myPallete.ColorHSL.Saturation; }
            set { myPallete.ColorHSL.Saturation = value; }
        }
        public int Brightness
        {
            get { return myPallete.ColorHSL.Luminosity ; }
            set { myPallete.ColorHSL.Luminosity = value; }
        }
        public byte StatsR => myPallete.ColorHSL.ToRgbColor().R;
        public byte StatsG => myPallete.ColorHSL.ToRgbColor().G;
        public byte StatsB => myPallete.ColorHSL.ToRgbColor().B;

        #endregion


        #region Constructor

        public MainView()
        {
            // keeping this so I don't forget how to setup commands
            this.DoSomethingCommand = new RelayCommand(DoSomething);

            //PropertyChanged += (sender, e) => {

            //    switch (e.PropertyName)
            //    {
            //        case "Hue":
            //            myPallete.ColorHSL.Hue = Hue;
            //            break;
            //        case "Saturation":
            //            myPallete.ColorHSL.Saturation = Saturation;
            //            break;
            //        case "Brightness":
            //            myPallete.ColorHSL.Luminosity = Brightness;
            //            break;
            //        default:
            //            break;
            //    }

            //    UpdateStatusBar();
            //};
        }

        #endregion


        #region Public Commands

        public ICommand DoSomethingCommand { get; set; }

        #endregion


        #region Private Helpers

        private void UpdateStatusBar()
        {

        }
        private void DoSomething()
        {
            
        }

        #endregion


        #region Public Methods



        #endregion

    }
}
