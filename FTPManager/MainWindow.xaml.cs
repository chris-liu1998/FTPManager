using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace FTPManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        private double _trend;
        private double[] temp = { 1, 3, 2, 4, 0, 5, 2, 1 };

        public MainWindow()
        {
            InitializeComponent();


            ////实例化一条折线图
            //LineSeries mylineseries = new LineSeries();
            ////设置折线的标题
            //mylineseries.Title = "Temp";
            ////折线图直线形式
            //mylineseries.LineSmoothness = 0;
            ////折线图的无点样式
            //mylineseries.PointGeometry = null;
            //添加横坐标
            Labels = new List<string> {""};
            ////添加折线图的数据
            //mylineseries.Values = new ChartValues<double>(temp);
            SeriesCollection = new SeriesCollection { 
                new LineSeries
                {
                   Title = "Download",
                   LineSmoothness = 0,
                   PointGeometry = null,
                   Values = new ChartValues<double>(temp),
                   
                 } ,

                new LineSeries
                {
                   Title = "Upload",
                   LineSmoothness = 0,
                   PointGeometry = null,
                   Values = new ChartValues<double>(temp),
                   
                }
            };
            
            _trend = 8;
            linestart();
            DataContext = this;


        }

        //连续折线图的方法
        public void linestart()
        {
            Task.Run(() =>
            {
                var r = new Random();
                while (true)
                {
                    Thread.Sleep(1000);
                    _trend = r.Next(0, 30);
                    double _trend1 = r.Next(0, 30);
                    //通过Dispatcher在工作线程中更新窗体的UI元素
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        //更新横坐标时间
                        //Labels.Add("1");
                        //Labels.RemoveAt(0);
                        //更新纵坐标数据
                        SeriesCollection[0].Values.Add(_trend);
                        SeriesCollection[0].Values.RemoveAt(0);
                        SeriesCollection[1].Values.Add(_trend1);
                        SeriesCollection[1].Values.RemoveAt(0);
                    });
                }
            });
        }
    

        public ConnectionState login = new ConnectionState()
        {
            IsConnecting = false
        };
        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            login.IsConnecting = true;
            BtnConnect.Content = "Connecting...";
            Log("   Connecting...", (int)LogInfo.LogType.Info);
        }

        private void Log(string content, int type)
        {
            LogTextBox.Text = LogInfo.GenerateInfo(content, type);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BtnConnect.DataContext = login;
        }
    }
}
