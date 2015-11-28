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

using ICS.Acquisition;
using ICS.Models;
using  ICS.Common;

namespace ICS.Air
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void closewindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void minwindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Global.ADAM4017Provider.CheckSerialPort(Global.ADAM4017Provider).Status == RunStatus.Success)
            {
                var timer = new LazyTimer(_sender =>
                {
                    var t = (LazyTimer) _sender[0];
                    var statevalue = Global.ADAM4017Provider;
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        temperature.Text = statevalue.temperatureValue;
                        humidity.Text = statevalue.humidityValue;
                        light.Text = statevalue.lightValue;
                        wind.Text = statevalue.windValue;
                        co2.Text = statevalue.co2Value;
                        airQ.Text = statevalue.airQualityValue;
                        airp.Text = statevalue.airPressureValue;
                    });
                    t.Reset();
                },100,1000);
            }
        }
    }
}
