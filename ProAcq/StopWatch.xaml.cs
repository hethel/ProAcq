using System;
using System.Windows;

namespace ProAcq
{
    /// <summary>
    /// StopWatch - relativ time reference
    /// </summary>
    
    public partial class StopWatch : Window
    {
        private System.Windows.Threading.DispatcherTimer timer;
        private DateTime dateDiff;
        StWtchMemo stWtchMemo;          // memo requests

        // deliver time for memo window
        private static string memoTime = String.Empty;  
        public string MemoTime() { return memoTime; } 

        public bool Stopwatch_active { get; set; }

        public StopWatch()
        {
            InitializeComponent();

            // Stop watch init and set Millisecands
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += new EventHandler(ShowTime);

            btnStop.IsEnabled = false;
            Stopwatch_active = true;    // StopWatch-Window open
        }

        private void ShowTime(object sender, EventArgs e)
        {
            dateDiff = dateDiff.AddMilliseconds(100);
            labelSW.Content = dateDiff.ToString("HH:mm:ss");
            memoTime = dateDiff.ToString("HH:mm:ss:f");
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();

            btnStop.IsEnabled = true;
            btnStart.IsEnabled = false;
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            labelSW.Content = dateDiff.ToString("HH:mm:ss:f");

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();   // stop timer
        }

        private void BtnMemo_Click(object sender, RoutedEventArgs e)
        {
            stWtchMemo = new StWtchMemo();
            stWtchMemo.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            stWtchMemo.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Stopwatch_active = false;   // Window closed
        }

        ~StopWatch()
        {
            GC.Collect(1);
        }
    }
}
