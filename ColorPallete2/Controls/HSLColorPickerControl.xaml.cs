using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace ColorPallete2
{
    /// <summary>
    /// Interaction logic for HSLColorPickerControl.xaml
    /// </summary>
    public partial class HSLColorPickerControl : UserControl, INotifyPropertyChanged
    {

        #region Private Members

        private bool _isDown = false;

        private double hue;
        private double saturation;
        private double luminosity;

        #endregion

        #region Public Properties

        public double Hue { get => hue; set { hue = value; PropertyChanged(this, new PropertyChangedEventArgs("Hue")); } }
        public double Saturation { get => saturation; set { saturation = value; PropertyChanged(this, new PropertyChangedEventArgs("Saturation")); } }
        public double Luminosity { get => luminosity; set { luminosity = value; PropertyChanged(this, new PropertyChangedEventArgs("Luminosity")); } }

        public static DependencyProperty HueProp = DependencyProperty.Register("Hue", typeof(double), typeof(HSLColorPickerControl));
        public static DependencyProperty SaturationProp = DependencyProperty.Register("Saturation", typeof(double), typeof(HSLColorPickerControl));
        public static DependencyProperty LuminosityProp = DependencyProperty.Register("Luminosity", typeof(double), typeof(HSLColorPickerControl));

        #endregion
        #region Constructor and Init

        public HSLColorPickerControl()
        {
            InitializeComponent();
            this.DataContext = this;
            int startValue = 240;
            Hue = startValue;
            Saturation = startValue;
            Luminosity = startValue;
            SliderZ.Value = startValue;
            SliderY.Value = startValue;
            SliderX.Value = startValue;
        }
        private void TheCanvas_Loaded(object sender, EventArgs e)
        {
            Canvas.SetLeft(Puck, TheCanvas.ActualWidth - 10);
            Canvas.SetTop(Puck, -10);
        }

        #endregion

        #region Puck Controls

        private void Puck_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _isDown = true;
            bool captureSuccess = Puck.CaptureMouse();
        }
        private void Puck_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                Canvas.SetLeft(Puck, Mouse.GetPosition(TheCanvas).X - 10);
                Canvas.SetTop(Puck, Mouse.GetPosition(TheCanvas).Y - 10);
                CheckBounds();
                SliderX.Value = ConvertToRange(Canvas.GetLeft(Puck) + 10, 0, TheCanvas.ActualWidth, 0, 240);
                SliderY.Value = 240 - ConvertToRange(Canvas.GetTop(Puck) + 10, 0, TheCanvas.ActualHeight, 0, 240);

                Saturation = SliderY.Value;
                Luminosity = SliderX.Value;
            }
        }
        private void Puck_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDown = false;
            Puck.ReleaseMouseCapture();
        }
        private void HueGradient_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _isDown = true;
            bool captureSuccess = Puck.CaptureMouse();
            Canvas.SetLeft(Puck, Mouse.GetPosition(TheCanvas).X - 10);
            Canvas.SetTop(Puck, Mouse.GetPosition(TheCanvas).Y - 10);
        }

        #endregion

        #region Slider Controls

        private void SliderX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_isDown)
            {
                Canvas.SetLeft(Puck, ConvertToRange(e.NewValue, 0, 240, 0, TheCanvas.ActualWidth) - 10);
                Saturation = e.NewValue;
            }
        }
        private void SliderY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_isDown)
            {
                var NewValue = 240 - e.NewValue;
                Canvas.SetTop(Puck, ConvertToRange(NewValue, 0, 240, 0, TheCanvas.ActualHeight) - 10);
                Luminosity = e.NewValue;
            }
        }
        private void SliderZ_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Hue = e.NewValue;

            HslColor h = new HslColor((int)Hue, 240, 239 / 2);
            System.Drawing.Color c = h.ToRgbColor();
            Color hueColor = new Color
            {
                A = c.A,
                R = c.R,
                G = c.G,
                B = c.B
            };

            LinearGradientBrush lgb = new LinearGradientBrush();
            GradientStop stop2 = new GradientStop(Colors.White, 0);
            GradientStop stop1 = new GradientStop(hueColor, 1);
            lgb.StartPoint = new System.Windows.Point(0, 0);
            lgb.EndPoint = new System.Windows.Point(1, 0.5);
            lgb.MappingMode = BrushMappingMode.RelativeToBoundingBox;
            lgb.GradientStops.Add(stop1);
            lgb.GradientStops.Add(stop2);

            HueGradient.Background = lgb;
        }

        #endregion

        #region Helpers

        private double ConvertToRange(double old_value, double old_min, double old_max, double new_min, double new_max)
        {
            return ((old_value - old_min) / (old_max - old_min) * (new_max - new_min)) + new_min;
        }
        private void CheckBounds()
        {
            double Left = Canvas.GetLeft(Puck);
            double Top = Canvas.GetTop(Puck);

            //check for bounds   

            if (Left < -10)
            {
                Left = -10;
            }
            else if (Left > (TheCanvas.ActualWidth - 10))
            {
                Left = TheCanvas.ActualWidth - 10;
            }

            if (Top < -10)
            {
                Top = -10;
            }
            else if (Top > (TheCanvas.ActualHeight - 10))
            {
                Top = TheCanvas.ActualHeight - 10;
            }

            Canvas.SetLeft(Puck, Left);
            Canvas.SetTop(Puck, Top);
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
