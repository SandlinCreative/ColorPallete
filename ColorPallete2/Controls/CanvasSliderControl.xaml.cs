using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ColorPallete2
{
    /// <summary>
    /// Interaction logic for CanvasSliderControl.xaml
    /// </summary>
    public partial class CanvasSliderControl : UserControl
    {
        public CanvasSliderControl()
        {
            InitializeComponent();
        }

        public static int PuckSize = 20;

        public double XValue {
            get { return XValue; }

            set
            {
                XValue = value;

            }
        }
        public double YValue {
            get { return YValue; }

            set
            {
                YValue = value;
            }
        }
        public int MaxValue { get; set; } = -1;

        public static DependencyProperty XValueProp = DependencyProperty.Register("XValue", typeof(double), typeof(CanvasSliderControl));
        public static DependencyProperty YValueProp = DependencyProperty.Register("YValue", typeof(double), typeof(CanvasSliderControl));
        public static DependencyProperty MaxValueProp = DependencyProperty.Register("MaxValue", typeof(int), typeof(CanvasSliderControl));


        UIElement dragObject = null;
        Point offset;


        private void DragPuck_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = sender as UIElement;
            this.offset = e.GetPosition(this.TheCanvas);
            this.offset.Y -= Canvas.GetTop(this.dragObject);
            this.offset.X -= Canvas.GetLeft(this.dragObject);
            bool captureSuccess = this.TheCanvas.CaptureMouse();
        }

        private void TheCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (this.dragObject == null)
                return;
            var position = e.GetPosition(sender as IInputElement);
            Canvas.SetTop(this.dragObject, position.Y - this.offset.Y);
            Canvas.SetLeft(this.dragObject, position.X - this.offset.X);
            CheckBounds();
        }

        private void TheCanvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //CheckBounds();
            UpdateXY();
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
            else if (Left > (TheCanvas.ActualWidth - PuckSize/2))
            {
                Left = TheCanvas.ActualWidth - PuckSize/2;
            }

            if (Top < PuckSize / -2)
            {
                Top = PuckSize / -2;
            }
            else if (Top > (TheCanvas.ActualHeight - PuckSize/2))
            {
                Top = TheCanvas.ActualHeight - PuckSize/2;
            }

            Canvas.SetLeft(dragObject, Left);
            Canvas.SetTop(dragObject, Top);
        }

        private void UpdateXY()
        {
            if (MaxValue < 0)
            {
                XValue = offset.X;
                YValue = offset.Y;
            }
            else
            {
                XValue = offset.X * MaxValue / TheCanvas.ActualWidth;
                YValue = offset.Y * MaxValue / TheCanvas.ActualWidth;
            }
        }
    }
}
