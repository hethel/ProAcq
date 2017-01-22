using System;
using System.Windows;
using System.IO;



namespace ProAcq
{
    /// <summary>
    /// TimeStamp - absolut time reference
    /// </summary>
 
    public partial class TimeStamp : Window
    {
        string ts_time;         // selected Time Stamp
        string ts_memo;         // add a process description
        string ts_LogName;      // Time Stamp Log name
        string ts_path;         // memo time directory

        DirectoryInfo ts_di;

        public TimeStamp()
        {
            InitializeComponent();

            ts_LogName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_TimeStamp" + ".txt";
            label.Content = DateTime.Now.ToString("HH:mm:ss"); // show a relevant time 
            ts_time = label.Content.ToString();    // set a relevant time
            ts_path = @"c:\ProAcq";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // desription from textbox
            ts_memo = textBox.Text.ToString();
            ts_di = new DirectoryInfo(ts_path);

            try
            {
                 if (ts_di.Exists)
                    {
                       // Set current directory
                       Directory.SetCurrentDirectory(ts_path);
                    }
            }

            catch (Exception ex)
            {
                MessageBox.Show("set ProAcq current directory\n" + ex.Message);

            }

            // save process memo with absolute time
            try
            {
                if (ts_di.Exists)
                {
                    File.AppendAllText(ts_LogName, ts_time + " | " + ts_memo);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("file content writing\n" + ex.Message);
            }
         }
    }
}
