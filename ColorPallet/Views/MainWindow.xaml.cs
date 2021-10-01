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
            HSL result = ((MainView)this.DataContext).ConvertRGBtoHSL(new RGB((byte)Int32.Parse(txtR.Text), (byte)Int32.Parse(txtG.Text), (byte)Int32.Parse(txtB.Text)));
            txtH.Text = result.H.ToString();
            txtS.Text = result.S.ToString();
            txtL.Text = result.L.ToString();

        }

        private void btnToRGB_Click(object sender, RoutedEventArgs e)
        {
            RGB result = ((MainView)this.DataContext).ConvertHSLtoRGB(new HSL(Int32.Parse(txtR.Text), (float)Int32.Parse(txtG.Text), (float)Int32.Parse(txtB.Text)));
            txtR.Text = result.R.ToString();
            txtG.Text = result.G.ToString();
            txtB.Text = result.B.ToString();
        }
    }
}
