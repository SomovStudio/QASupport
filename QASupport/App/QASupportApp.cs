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
        public const string LastUpdate = "22.12.2022";

        public static FormMain MainForm { get; set; }
        public static FormErrors ErrorsForm { get; set; }
        public static FormLogs LogsForm { get; set; }

        public static RichTextBox Logs;
        public static RichTextBox Errors;

        public static void LogMsg(string appName, string message)
        {
            try
            {
                if(QASupportApp.LogsForm != null)
                {
                    if (QASupportApp.LogsForm.IsDisposed == false)
                    {
                        if(QASupportApp.LogsForm.Logs.Lines.Count() != QASupportApp.Logs.Lines.Count())
                        {
                            QASupportApp.LogsForm.Logs.Text = QASupportApp.Logs.Text;
                        }                        
                        QASupportApp.LogsForm.Logs.AppendText("[" + DateTime.Now.ToString() + "][" + appName + "]: " + message + Environment.NewLine);
                        QASupportApp.LogsForm.Logs.ScrollToCaret();
                    }
                }
                Logs.AppendText("[" + DateTime.Now.ToString() + "][" + appName + "]: " + message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                //ErrorMsg(appName, ex.ToString());
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public static void ErrorMsg(string appName, string message)
        {
            if (QASupportApp.ErrorsForm == null)
            {
                QASupportApp.ErrorsForm = new FormErrors();
                QASupportApp.ErrorsForm.Show();
            }
            if (QASupportApp.ErrorsForm.IsDisposed)
            {
                QASupportApp.ErrorsForm = new FormErrors();
                QASupportApp.ErrorsForm.Show();
            }            
            if (QASupportApp.ErrorsForm.Errors.Lines.Count() != QASupportApp.Errors.Lines.Count())
            {
                QASupportApp.ErrorsForm.Errors.Text = QASupportApp.Errors.Text;
            }
            QASupportApp.ErrorsForm.Errors.AppendText("[" + DateTime.Now.ToString() + "][" + appName + "] ОШИБКА: " + message + Environment.NewLine);
            QASupportApp.ErrorsForm.Errors.ScrollToCaret();

            Errors.AppendText("[" + DateTime.Now.ToString() + "][" + appName + "] ОШИБКА: " + message + Environment.NewLine);
        }
    }
}
