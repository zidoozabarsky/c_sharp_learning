﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isWorkingStop = false;

        public MainWindow()
        {
            InitializeComponent();
            ResultsWindow.Text = String.Empty;
        }

        private void ButtonBase_OnClick_Sync(object sender, RoutedEventArgs e)
        {
            _isWorkingStop = false;
            ResultsWindow.Text = String.Empty;
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 5; i++)
            {
                if (_isWorkingStop)
                    return;
                LongWork();
                ProgressBar.Value = i * 25;
            }
            stopwatch.Stop();
            long elapsedMs = stopwatch.ElapsedMilliseconds;
            ResultsWindow.Text += $"Total execution time: { elapsedMs }";
        }

        private async void ButtonBase_OnClick_Async(object sender, RoutedEventArgs e)
        {
            _isWorkingStop = false;
            ResultsWindow.Text = String.Empty;
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 5; i++)
            {
                if (_isWorkingStop)
                    break;
                await Task.Run(LongWork);
                ProgressBar.Value = i * 25;
            }
            stopwatch.Stop();
            long elapsedMs = stopwatch.ElapsedMilliseconds;
            ResultsWindow.Text += $"Total execution time: { elapsedMs }";
        }

        private async void ButtonBase_OnClick_Parallel(object sender, RoutedEventArgs e)
        {
            _isWorkingStop = false;
            ResultsWindow.Text = String.Empty;
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<Task> tasks = new List<Task>();
            
            for (int i = 0; i < 5; i++)
            {
                if (_isWorkingStop)
                    break;
                tasks.Add(Task.Run(LongWork));
                ProgressBar.Value = i * 25;
            }

            await Task.WhenAll(tasks);

            stopwatch.Stop();
            long elapsedMs = stopwatch.ElapsedMilliseconds;
            ResultsWindow.Text += $"Total execution time: { elapsedMs }";
        }

        private void LongWork()
        {
            Thread.Sleep(1000);
            ResultsWindow.Dispatcher.Invoke(()=>ResultsWindow.Text += "working... \n");
        }

        private void ButtonBase_OnClick_Cancel(object sender, RoutedEventArgs e)
        {
            _isWorkingStop = true;
        }
    }
}
