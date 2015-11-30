using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using ICS.Models.Com;

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
            var a = new Timer(_object =>
            {
                var statevalue = new ADAM4017(new ComSettingModel());
                if (statevalue.CheckSerialPort(statevalue).Status != RunStatus.Failure)
                {
                    statevalue.SetData();
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
                }
            },null,100,1000);
            //不要再定时器线程中获取以外的变量。
        }

        }
    }

