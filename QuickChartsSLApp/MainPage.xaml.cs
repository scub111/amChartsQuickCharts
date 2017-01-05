﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace QuickChartsSLApp
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private ObservableCollection<TestDataItem> _data = new ObservableCollection<TestDataItem>()
        {
            new TestDataItem() { cat1 = DateTime.Now + new TimeSpan(1, 0, 0), val1=5, val2=15, val3=12},
            new TestDataItem() { cat1 = DateTime.Now + new TimeSpan(4, 0, 0), val1=15.2, val2=1.5, val3=2.1},
            new TestDataItem() { cat1 = DateTime.Now + new TimeSpan(5, 0, 0), val1=25, val2=5, val3=2},
            new TestDataItem() { cat1 = DateTime.Now + new TimeSpan(7, 0, 0), val1=8.1, val2=1, val3=22},
        };

        public ObservableCollection<TestDataItem> Data { get { return _data; } }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _data.Insert(2, new TestDataItem() { cat1 = DateTime.Now + new TimeSpan(6, 0, 0), val1 = 1, val2 = 2, val3 = 3 });
            _data.Insert(4, new TestDataItem() { cat1 = DateTime.Now + new TimeSpan(7, 0, 0), val1 = 31, val2 = 32, val3 = 33 });
            _data.Add(new TestDataItem() { cat1 = DateTime.Now + new TimeSpan(8, 0, 0), val1 = 12, val2 = 22, val3 = 32 });
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
            _data.Clear();
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                _data.Add(new TestDataItem() { cat1 = DateTime.Now + new TimeSpan(i, 0, 0), val1 = rnd.NextDouble() * 8, val2 = rnd.NextDouble() * 18, val3 = rnd.NextDouble() * 5 + 3 });
            }
            this.DataContext = this;
        }

        Random _rnd;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _rnd = new Random();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            _data.Add(new TestDataItem() { cat1 = DateTime.Now, val1 = _rnd.NextDouble() * 8, val2 = _rnd.NextDouble() * 18, val3 = _rnd.NextDouble() * 5 + 3 });
            _data.RemoveAt(0);
        }

    }

    public class TestDataItem
    {
        public DateTime cat1 { get; set; }
        public double val1 { get; set; }
        public double val2 { get; set; }
        public double val3 { get; set; }
    }
}
