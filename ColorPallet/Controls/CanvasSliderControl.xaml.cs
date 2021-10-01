using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ColorPallete
{
    /// <summary>
    /// Interaction logic for CanvasSliderControl.xaml
    /// </summary>
    public partial class CanvasSliderControl : UserControl
    {
        public static int PuckSize = 20;

        public CanvasSliderControl()
        {
            InitializeComponent();
        }

        private void Ellipse_ManipulationDelta(object sender, ManipulationDeltaEventArgs args)
        {
            FrameworkElement Elem = sender as FrameworkElement;
            double Left = Canvas.GetLeft(Elem);
            double Top = Canvas.GetTop(Elem);
            Left += args.DeltaManipulation.Translation.X;//Get x cordinate   
            Top += args.DeltaManipulation.Translation.Y;//Get y cordinate   

            //check for bounds   

            if (Left < 0)
            {
                Left = 0;
            }
            else if (Left > (TheCanvas.ActualWidth - Elem.ActualWidth))
            {
                Left = TheCanvas.ActualWidth - Elem.ActualWidth;
            }

            if (Top < 0)
            {
                Top = 0;
            }
            else if (Top > (TheCanvas.ActualHeight - Elem.ActualHeight))
            {
                Top = TheCanvas.ActualHeight - Elem.ActualHeight;
            }

            Canvas.SetLeft(Elem, Left);
            Canvas.SetTop(Elem, Top);
        }

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
    }
}
