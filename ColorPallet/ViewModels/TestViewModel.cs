
using System.Windows.Input;

namespace ColorPallete
{
    class TestViewModel : BaseViewModel
    {
        #region Public Properties

        public string Test { get; set; }

        #endregion

        #region Public Commands

        public ICommand DoSomethingCommand { get; set; }

        #endregion

        #region Constructor
        public TestViewModel()
        {
            this.DoSomethingCommand = new RelayCommand(DoSomething);
        }

        #endregion

        #region Helper Methods

        private void DoSomething()
        {

        }

        #endregion
    }
}
