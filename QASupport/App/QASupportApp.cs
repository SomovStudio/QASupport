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

                if (QASupportApp.LogsForm == null) return;
                if (QASupportApp.LogsForm.IsDisposed) return;
                QASupportApp.LogsForm.Logs.Text = QASupportApp.Logs.Text;
                QASupportApp.LogsForm.Logs.ScrollToCaret();
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

            if (QASupportApp.ErrorsForm == null) QASupportApp.ErrorsForm = new FormErrors();
            if (QASupportApp.ErrorsForm.IsDisposed) QASupportApp.ErrorsForm = new FormErrors();
            QASupportApp.ErrorsForm.Show();
            QASupportApp.ErrorsForm.Errors.Text = QASupportApp.Errors.Text;
            QASupportApp.ErrorsForm.Errors.ScrollToCaret();
        }
    }
}
