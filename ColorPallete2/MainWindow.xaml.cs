﻿using System;
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

namespace ColorPallete2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = new ViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private int i = 0;

        private void TheColorPicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            HexBox.Text = $"{TheColorPicker.Hue.ToString("F2")}, {TheColorPicker.Saturation.ToString("F2")}, {TheColorPicker.Luminosity.ToString("F2")}";
        }
    }
}
