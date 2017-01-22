using System;
using System.Windows;
using System.IO;

namespace ProAcq
{
    /// <summary>
    /// Stop Watch Memo on spezific time span
    /// </summary>
    public partial class StWtchMemo : Window
    {
        string sw_memo;     // stop watch memo
        string sw_time;     // stop watch memo time
        string sw_LogName;  // stop watch memo file name
        string sw_path;     // memo time directory

        StopWatch sw = new StopWatch();
        DirectoryInfo sw_di;

        public StWtchMemo()
        {
            InitializeComponent();

            sw_LogName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_StopWatch" + ".txt";
            labelSWM.Content = sw.MemoTime();
            sw_time = labelSWM.Content.ToString();      // set the relevant time span
            sw_path = @"c:\ProAcq\";                    // memo time directory

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sw_di = new DirectoryInfo(sw_path);         // instance of memo time directory
            sw_memo = textBox.Text.ToString();          // desription from textbox

            // set ProAcq directory 
            try
            {
                 if (sw_di.Exists)
                 {
                     Directory.SetCurrentDirectory(sw_path);    // Set current directory
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("set ProAcq current directory\n" + ex.Message);
            }

            // save process memo with absolute time and relative time span
            try
            {
                if (sw_di.Exists)
                {
                    File.AppendAllText(sw_LogName, sw_time + " | " + sw_memo);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("file content writing\n" + ex.Message);
            }

         }
    }
}
