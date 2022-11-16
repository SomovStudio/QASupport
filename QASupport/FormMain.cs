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
using QASupport.TestRedirect;

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

        private void панельУправленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start("control"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            //contextMenuStrip1.Show(Cursor.Position);
            //contextMenuStrip1.Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (QASupportApp.LogsForm == null) QASupportApp.LogsForm = new FormLogs();
            if (QASupportApp.LogsForm.IsDisposed) QASupportApp.LogsForm = new FormLogs();
            QASupportApp.LogsForm.Logs.Text = QASupportApp.Logs.Text;
            QASupportApp.LogsForm.Show();
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

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (About == null) About = new FormAbout();
            if (About.IsDisposed == true) About = new FormAbout();
            About.Show();
        }

        private void w3CMarupValidationServiceпроверкаРазметкиHTMLXHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://validator.w3.org/"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void w3CCSSValidationServiceпроверкаCSSСтилейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://jigsaw.w3.org/css-validator/"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void xMLValidatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://codebeautify.org/xmlvalidator"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void jSONValidatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://jsonformatter.curiousconcept.com/"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void мастерСоставленияРегулярногоВыраженияДляPHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://uvsoftium.ru/php/regexp.php"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void декодированиеURLАдресовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://konstantinbulgakov.com/tools/decode"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void конвертерUnixвремениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://time.is/ru/Unix_time_converter"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void переводЧиселИзОднойСистемыСчисленияВЛюбуюДругуюОнлайнToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://calculatori.ru/perevod-chisel.html"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void яндексМастерПроверкаОтветаСервераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://webmaster.yandex.ru/tools/server-response/"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void просмортHTMLЗаголовковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://bertal.ru/"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void подробнееОЗаголовкеLastModifiedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://last-modified.com/ru/last-modified-header"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void проверитьСтатус304NotModifiedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Process.Start(@"https://last-modified.com/ru"); }
            catch (Exception ex) { QASupportApp.ErrorMsg("QASupport", ex.Message); }
        }

        private void journalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QASupportApp.LogsForm == null) QASupportApp.LogsForm = new FormLogs();
            if (QASupportApp.LogsForm.IsDisposed) QASupportApp.LogsForm = new FormLogs();
            QASupportApp.LogsForm.Logs.Text = QASupportApp.Logs.Text;
            QASupportApp.LogsForm.Show();
        }

        private void testRedirectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTestRedirect testredirect = new FormTestRedirect();
            testredirect.Show();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (About == null) About = new FormAbout();
            if (About.IsDisposed == true) About = new FormAbout();
            About.Show();
        }

        
    }
}
