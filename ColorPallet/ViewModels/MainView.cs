using System;
using System.Windows.Input;

namespace ColorPallete
{
    /// <summary>
    /// The view model for the application's main window view
    /// </summary>
    class MainView : BaseViewModel
    {

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainView()
        {
            this.DoSomethingCommand = new RelayCommand(DoSomething);

            PropertyChanged += (sender, e) => {
                if (e.PropertyName == "Hue")
                {
                    myPallete.H = Hue;
                    myPallete.UpdateBaseHueColor();
                }
                else if (e.PropertyName == "Saturation")
                {
                    myPallete.S = Saturation;
                }
                else if (e.PropertyName == "Brightness")
                {
                    myPallete.L = Brightness;
                }
                else if (e.PropertyName == "R" || e.PropertyName == "G" || e.PropertyName == "B")
                {

                }
            };
        }

        #endregion

        #region Public Commands

        public ICommand DoSomethingCommand { get; set; }

        #endregion

        #region Helpers


        private void DoSomething()
        {
            
        }

        #endregion

        #region Public Properties

        public Pallete myPallete { get; set; } = new Pallete();

        public int Hue { get; set; } = 0;
        public float Saturation { get; set; } = 100;
        public float Brightness { get; set; } = 100;

        #endregion
    }
}
