using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ColorPallete2
{
    /// <summary>
    /// Interaction logic for CanvasSliderControl.xaml
    /// </summary>
    public partial class CanvasSliderControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public CanvasSliderControl()
        {
            InitializeComponent();
        }

        public static int PuckSize = 20;

        private double _xValue = 0;
        private double _yValue = 0;
        private string _xValString = "";
        private string _yValString = "";

        public double XValue {
            get { return Canvas.GetLeft(this.dragObject); }

            set { _xValue = value;
                XValString = _xValue.ToString("F2");
                PropertyChanged(this, new PropertyChangedEventArgs("XValue"));
                Canvas.SetLeft(DragPuck, ConvertToRange(_xValue, 0, 239, 0, TheCanvas.ActualWidth - PuckSize / 2));
            }
        }
        public double YValue {
            get { return Canvas.GetTop(this.dragObject); }

            set{ _yValue = value;
                YValString = _yValue.ToString("F2");
                PropertyChanged(this, new PropertyChangedEventArgs("YValue"));
                Canvas.SetTop(DragPuck, ConvertToRange(_yValue, 0, 239, 0, TheCanvas.ActualHeight - PuckSize / 2));
            }
        }
        public string XValString { 
            get { return _xValString; }
            set { _xValString = value;
                PropertyChanged(this, new PropertyChangedEventArgs("XValString"));
            }
        }
        public string YValString { 
            get { return _yValString; }
            set { _yValString = value;
                PropertyChanged(this, new PropertyChangedEventArgs("YValString"));
            }
        }

        public double MaxValue { get; set; } = -1;
        public double MinValue { get; set; } = -1;

        public static DependencyProperty XValueProp = DependencyProperty.Register("XValue", typeof(double), typeof(CanvasSliderControl));
        public static DependencyProperty YValueProp = DependencyProperty.Register("YValue", typeof(double), typeof(CanvasSliderControl));
        public static DependencyProperty MaxValueProp = DependencyProperty.Register("MaxValue", typeof(double), typeof(CanvasSliderControl));
        public static DependencyProperty MinValueProp = DependencyProperty.Register("MinValue", typeof(double), typeof(CanvasSliderControl));

        UIElement dragObject = null;
        private Point offset;
        public Point Position { get { return offset; } set { offset = value; } }


        private void DragPuck_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = sender as UIElement;
            this.Position = e.GetPosition(this.TheCanvas);
            this.offset.Y -= Canvas.GetTop(this.dragObject);
            this.offset.X -= Canvas.GetLeft(this.dragObject);
            bool captureSuccess = this.TheCanvas.CaptureMouse();
        }

        private void TheCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (this.dragObject == null)
                return;
            var position = e.GetPosition(sender as IInputElement);
            Canvas.SetTop(this.dragObject, position.Y - this.Position.Y);
            Canvas.SetLeft(this.dragObject, position.X - this.Position.X);
            CheckBounds();
        }

        private void TheCanvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = null;
            this.TheCanvas.ReleaseMouseCapture();
        }

        private void CheckBounds()
        {
            if (dragObject == null)
                return;

            double Left = Canvas.GetLeft(dragObject);
            double Top = Canvas.GetTop(dragObject);

            //check for bounds   

            if (Left < PuckSize / -2)
            {
                Left = PuckSize / -2;
            }
            else if (Left > (TheCanvas.ActualWidth - PuckSize / 2))
            {
                Left = TheCanvas.ActualWidth - PuckSize / 2;
            }

            if (Top < PuckSize / -2)
            {
                Top = PuckSize / -2;
            }
            else if (Top > (TheCanvas.ActualHeight - PuckSize / 2))
            {
                Top = TheCanvas.ActualHeight - PuckSize / 2;
            }

            Canvas.SetLeft(dragObject, Left);
            Canvas.SetTop(dragObject, Top);
            XValue = ConvertToRange(Left + PuckSize / 2, 0, TheCanvas.ActualWidth, 0, 239);
            YValue = ConvertToRange(Top + PuckSize / 2, 0, TheCanvas.ActualHeight, 0, 239);
        }

        private double ConvertToRange(double old_value, double old_min, double old_max, double new_min, double new_max)
        {
            return ((old_value - old_min) / (old_max - old_min) * (new_max - new_min)) + new_min;
        }

        private void DragPuck_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
        }

        private void DragPuck_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Console.WriteLine("I was manipulated");
        }
        //private int i = 0;
        private void DragPuck_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            //Console.WriteLine($"I am moved {i++}");
        }
    }
}
