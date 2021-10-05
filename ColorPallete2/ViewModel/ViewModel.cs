using Microsoft.VisualStudio.Modeling.Diagrams;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace ColorPallete2
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };


        private HslColor _hslColor = HslColor.FromRgbColor(ConvertColor(Colors.Blue));
        public SolidColorBrush ColorBrush
        {
            get
            {
                return new SolidColorBrush(ConvertColor(_hslColor.ToRgbColor()));
            }
            set { }
        }
        public int Hue
        {
            get { return _hslColor.Hue; }
            set
            {
                _hslColor.Hue = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Hue"));
                PropertyChanged(this, new PropertyChangedEventArgs("ColorBrush"));
            }
        }



        public ViewModel()
        {
            _hslColor = HslColor.FromRgbColor(ConvertColor(Colors.Blue));
        }

        private static System.Drawing.Color ConvertColor(System.Windows.Media.Color input)
        {
            return System.Drawing.Color.FromArgb(input.A,input.R,input.G,input.B);
        }
        private static System.Windows.Media.Color ConvertColor(System.Drawing.Color input)
        {
            return System.Windows.Media.Color.FromArgb(input.A, input.R, input.G, input.B);
        }
    }
}
