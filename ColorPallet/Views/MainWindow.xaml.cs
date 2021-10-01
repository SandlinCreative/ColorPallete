using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualStudio.Modeling.Diagrams;


namespace ColorPallete
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainView();
        }

        private void btnToHSL_Click(object sender, RoutedEventArgs e)
        {
            System.Drawing.Color rgbColor = System.Drawing.Color.FromArgb(Int32.Parse(txtR.Text), Int32.Parse(txtG.Text), Int32.Parse(txtB.Text));
            HslColor hslColor = HslColor.FromRgbColor(rgbColor);
            txtH.Text = hslColor.Hue.ToString();
            txtS.Text = hslColor.Saturation.ToString();
            txtL.Text = hslColor.Luminosity.ToString();

        }

        private void btnToRGB_Click(object sender, RoutedEventArgs e)
        {
            HslColor hslColor = new HslColor(Int32.Parse(txtH.Text), Int32.Parse(txtS.Text), Int32.Parse(txtL.Text));
            System.Drawing.Color rgbColor = hslColor.ToRgbColor();
            txtR.Text = rgbColor.R.ToString();
            txtG.Text = rgbColor.G.ToString();
            txtB.Text = rgbColor.B.ToString();
        }
    }
}
