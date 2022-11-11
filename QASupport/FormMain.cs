using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using QASupport.App;
using QASupport.JsonFileEditor;
using QASupport.TestSitemap;

namespace QASupport
{
    public partial class FormMain : Form
    {
        // иконки https://icons8.ru/

        public FormMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public FormAbout About;
        public FormSettings Settings;

        private void FormMain_Load(object sender, EventArgs e)
        {
            label2.Text = "Version: " + QASupportApp.Version + " (" + QASupportApp.LastUpdate + ")";
            QASupportApp.MainForm = this;
            QASupportApp.Logs = new RichTextBox();
            QASupportApp.Errors = new RichTextBox();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            QASupportApp.LogMsg("QASupport", "Версия: " + QASupportApp.Version + " | последнее обновление: " + QASupportApp.LastUpdate);
            this.Visible = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings == null) Settings = new FormSettings();
            if (Settings.IsDisposed == true) Settings = new FormSettings();
            Settings.Show();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start("notepad.exe"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start("mspaint.exe"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void calcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try{ Process.Start("calc.exe"); }
            catch (Exception ex){ QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void cmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try{ Process.Start("cmd.exe"); }
            catch (Exception ex){ QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void devicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try{ Process.Start("devmgmt.msc"); }
            catch (Exception ex){ QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (About == null) About = new FormAbout();
            if (About.IsDisposed == true) About = new FormAbout();
            About.Show();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            //contextMenuStrip1.Show(Cursor.Position);
            //contextMenuStrip1.Hide();
        }

        private void errorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QASupportApp.ErrorsForm == null) QASupportApp.ErrorsForm = new FormErrors();
            if (QASupportApp.ErrorsForm.IsDisposed) QASupportApp.ErrorsForm = new FormErrors();
            QASupportApp.ErrorsForm.Errors.Text = QASupportApp.Errors.Text;
            QASupportApp.ErrorsForm.Show();
            QASupportApp.ErrorsForm.Errors.ScrollToCaret();
        }

        private void логиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QASupportApp.LogsForm == null) QASupportApp.LogsForm = new FormLogs();
            if (QASupportApp.LogsForm.IsDisposed) QASupportApp.LogsForm = new FormLogs();
            QASupportApp.LogsForm.Logs.Text = QASupportApp.Logs.Text;
            QASupportApp.LogsForm.Show();
        }

        private void jsonFileEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJsonEditor editor = new FormJsonEditor();
            editor.Show();
        }

        private void edgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start("msedge.exe"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void iE11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WebBrowser webBrowser = new WebBrowser();
                webBrowser.Navigate("https://www.google.com/", "_blank");
                QASupportApp.LogMsg("QASupport", "Открыт браузер Internet Explorer 11");
            }
            catch (Exception ex)
            {
                QASupportApp.ErrorMsg("QASupport", ex.Message);
            }
        }

        private void testSitemapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTestSitemap testsitemap = new FormTestSitemap();
            testsitemap.Show();
        }
    }
}
