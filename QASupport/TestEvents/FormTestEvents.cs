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

                string jsonText = await BrowserView.CoreWebView2.ExecuteScriptAsync(script);
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

        }
    }
}
