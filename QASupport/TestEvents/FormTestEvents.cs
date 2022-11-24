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

        private void updateToolStripComboBoxUrl()
        {
            try
            {
                bool thisIsNewUrl = true;
                for (int k = 0; k < toolStripComboBoxUrl.Items.Count; k++)
                {
                    if (toolStripComboBoxUrl.Items[k].ToString() == toolStripComboBoxUrl.Text)
                    {
                        thisIsNewUrl = false;
                        break;
                    }
                }
                if (thisIsNewUrl == true) toolStripComboBoxUrl.Items.Add(toolStripComboBoxUrl.Text);
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
                richTextBoxErrors.AppendText(e.ParameterObjectAsJson + Environment.NewLine);
                richTextBoxErrors.ScrollToCaret();
            }
        }

        private void FormTestEvents_Load(object sender, EventArgs e)
        {
            QASupportApp.LogMsg("TestEvents", "Программа загружена");
            webView21.Source = new Uri(toolStripComboBoxUrl.Text);
        }

        private void webView21_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            richTextBoxErrors.Text = "";
        }

        private void webView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            try
            {
                QASupportApp.LogMsg("TestEvents", "Инициализация WebView завершена");

                webView21.EnsureCoreWebView2Async();
                webView21.CoreWebView2.CallDevToolsProtocolMethodAsync("Network.clearBrowserCache", "{}");
                webView21.CoreWebView2.CallDevToolsProtocolMethodAsync("Network.setCacheDisabled", @"{""cacheDisabled"":true}");
                QASupportApp.LogMsg("TestEvents", "Выполнена очистка кэша WebView");

                webView21.EnsureCoreWebView2Async();
                webView21.CoreWebView2.GetDevToolsProtocolEventReceiver("Log.entryAdded").DevToolsProtocolEventReceived += showMessageConsoleErrors;
                webView21.CoreWebView2.CallDevToolsProtocolMethodAsync("Log.enable", "{}");
                QASupportApp.LogMsg("TestEvents", "Запущен монитор ошибок на страницах");

                webView21.CoreWebView2.CallDevToolsProtocolMethodAsync("Security.setIgnoreCertificateErrors", "{\"ignore\": true}");
                QASupportApp.LogMsg("TestEvents", "Опция Security.setIgnoreCertificateErrors - включен параметр ignore: true");

                if (defaultUserAgent == "") defaultUserAgent = webView21.CoreWebView2.Settings.UserAgent;
                QASupportApp.LogMsg("TestEvents", $"Опция User-Agent по умолчанию {defaultUserAgent}");

                //webView21.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = false;
                //QASupportApp.LogMsg("TestEvents", "Выполнена настройка WebView (отключаны alert, prompt, confirm)");

                webView21.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
                QASupportApp.LogMsg("TestEvents", "Отключено открытие страниц в новых окнах");
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestEvents", "Ошибка: " + ex.Message);
            }
        }

        private void CoreWebView2_NewWindowRequested(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
            try
            {
                e.Handled = true;
                toolStripComboBoxUrl.Text = e.Uri.ToString();
                if (toolStripComboBoxUrl.Text.Contains("https://") == false && toolStripComboBoxUrl.Text.Contains("http://") == false)
                {
                    toolStripComboBoxUrl.Text = "https://" + toolStripComboBoxUrl.Text;
                }
                webView21.CoreWebView2.Navigate(toolStripComboBoxUrl.Text);
                updateToolStripComboBoxUrl();
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestEvents", "Ошибка: " + ex.Message);
            }
        }

        private void webView21_ContentLoading(object sender, CoreWebView2ContentLoadingEventArgs e)
        {
            try
            {
                toolStripComboBoxUrl.Text = webView21.Source.ToString();
                QASupportApp.LogMsg("TestEvents", "Загрузка страницы: " + webView21.Source.ToString());
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestEvents", "Ошибка: " + ex.Message);
            }
        }

        private void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            try
            {
                toolStripComboBoxUrl.Text = webView21.Source.ToString();
                QASupportApp.LogMsg("TestEvents", "Выполнена загрузка страницы: " + webView21.Source.ToString());
                if (webView21.CoreWebView2.Settings.UserAgent != null && defaultUserAgent == "")
                {
                    defaultUserAgent = webView21.CoreWebView2.Settings.UserAgent;
                    textBoxUserAgent.Text = defaultUserAgent;
                }
                if (defaultUserAgent != webView21.CoreWebView2.Settings.UserAgent) QASupportApp.LogMsg("TestEvents", "Текущий User-Agent: " + webView21.CoreWebView2.Settings.UserAgent);
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestEvents", "Ошибка: " + ex.Message);
            }
        }
    }
}
