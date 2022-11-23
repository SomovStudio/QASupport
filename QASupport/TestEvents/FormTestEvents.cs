using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QASupport.TestEvents
{
    public partial class FormTestEvents : Form
    {
        public FormTestEvents()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private string defaultUserAgent = "";
        private bool processRun = false;
        private Thread thread;

        public async Task<string> BrowserGetNetworkAsync()
        {
            string events = null;
            try
            {
                string script =
                @"(function(){
                var performance = window.performance || window.mozPerformance || window.msPerformance || window.webkitPerformance || {};
                var network = performance.getEntriesByType('resource') || {};
                var result = JSON.stringify(network);
                return result;
                }());";

                string jsonText = await webView21.CoreWebView2.ExecuteScriptAsync(script);
                dynamic result = JsonConvert.DeserializeObject(jsonText);
                events = result;
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestEvents", "Ошибка: " + ex.Message);
            }
            return events;
        }

        private void FormTestEvents_Load(object sender, EventArgs e)
        {
            QASupportApp.LogMsg("TestEvents", "Программа загружена");
            initWebView()
            webView21.Source = new Uri(toolStripComboBoxUrl.Text);
        }

        /* Инициализация WevView */
        private void initWebView()
        {
            webView21.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            try
            {
                //consoleMsg("Инициализация WebView завершена");
                webView21.EnsureCoreWebView2Async();
                webView21.CoreWebView2.CallDevToolsProtocolMethodAsync("Network.clearBrowserCache", "{}");
                webView21.CoreWebView2.CallDevToolsProtocolMethodAsync("Network.setCacheDisabled", @"{""cacheDisabled"":true}");
                //consoleMsg("Выполнена очистка кэша WebView");
                webView21.EnsureCoreWebView2Async();
                webView21.CoreWebView2.GetDevToolsProtocolEventReceiver("Log.entryAdded").DevToolsProtocolEventReceived += showMessageConsoleErrors;
                webView21.CoreWebView2.CallDevToolsProtocolMethodAsync("Log.enable", "{}");
                //consoleMsg("Запущен монитор ошибок на страницах");
                webView21.CoreWebView2.CallDevToolsProtocolMethodAsync("Security.setIgnoreCertificateErrors", "{\"ignore\": true}");
                //consoleMsg("Опция Security.setIgnoreCertificateErrors - включен параметр ignore: true");
                if (defaultUserAgent == "") defaultUserAgent = webView21.CoreWebView2.Settings.UserAgent;
                //consoleMsg($"Опция User-Agent по умолчанию {Config.defaultUserAgent}");
                webView21.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = false;
                //consoleMsg("Выполнена настройка WebView (отключаны alert, prompt, confirm)");

            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestEvents", "Ошибка: " + ex.Message);
            }
        }

        private void showMessageConsoleErrors(object sender, Microsoft.Web.WebView2.Core.CoreWebView2DevToolsProtocolEventReceivedEventArgs e)
        {
            if (e != null && e.ParameterObjectAsJson != null)
            {
                //richTextBoxErrors.AppendText(e.ParameterObjectAsJson + Environment.NewLine);
                //richTextBoxErrors.ScrollToCaret();
                richTextBoxErrors.Text += e.ParameterObjectAsJson.ToString();   
            }
        }

        private void webView21_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            richTextBoxErrors.Text = "";
        }
    }
}
