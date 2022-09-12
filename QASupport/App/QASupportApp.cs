using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QASupport.App;

namespace QASupport
{
    public static class QASupportApp
    {
        public const string Version = "1.0.0";
        public const string LastUpdate = "09.09.2022";

        public static FormMain MainForm { get; set; }
        public static FormErrors ErrorsForm { get; set; }
        public static FormLogs LogsForm { get; set; }

        public static RichTextBox Logs;
        public static RichTextBox Errors;

        public static void LogMsg(string appName, string message)
        {
            try
            {
                Logs.AppendText("[" + DateTime.Now.ToString() + "][" + appName + "]: " + message + Environment.NewLine);
                Logs.ScrollToCaret();
                if (LogsForm.IsDisposed == false)
                {
                    LogsForm.Logs.Text = Logs.Text;
                    LogsForm.Logs.ScrollToCaret();
                }
            }
            catch (Exception ex)
            {
                ErrorMsg(appName, ex.ToString());
            }
        }

        public static void ErrorMsg(string appName, string message)
        {
            Errors.AppendText("[" + DateTime.Now.ToString() + "][" + appName + "] ОШИБКА: " + message + Environment.NewLine);
            Errors.ScrollToCaret();
            if (ErrorsForm.IsDisposed == true)
            {
                ErrorsForm = new FormErrors();
                ErrorsForm.Show();
            }
            if (LogsForm.IsDisposed == false)
            {
                ErrorsForm.Errors.Text = Errors.Text;
                ErrorsForm.Errors.ScrollToCaret();
            }
        }
    }
}
