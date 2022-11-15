using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;

namespace QASupport.TestSitemap
{
    public partial class FormTestSitemap : Form
    {
        public FormTestSitemap()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private bool processRun = false;
        private Thread thread;

        private void showProgressTest(double totalPages, double onePercent, double step)
        {
            toolStripProgressBar1.Maximum = Convert.ToInt32(totalPages);
            toolStripProgressBar1.Value = Convert.ToInt32(step);
            double progressPercent = 0;
            if (totalPages < 100 && onePercent > 0) progressPercent = (step * onePercent);
            if (totalPages >= 100) progressPercent = (step / onePercent);
            progressPercent = Math.Round(progressPercent, 0);
            if (progressPercent < 100) toolStripStatusLabel2.Text = Convert.ToString(progressPercent) + "%";
            else toolStripStatusLabel2.Text = "99%";

            double dSec = (totalPages - step) * 1;

            int sec = Convert.ToInt32(dSec);
            int minutes = sec / 60;
            int newSec = sec - minutes * 60;
            int hour = minutes / 60;
            int newMinnutes = minutes - hour * 60;
            TimeSpan time = new TimeSpan(hour, newMinnutes, newSec);
            toolStripStatusLabel5.Text = time.ToString();
        }

        private ArrayList readUrlXML(string filename)
        {
            ArrayList list = new ArrayList();

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                XmlDocument xDoc;
                if (checkBoxUserAgent.Checked == true)
                {
                    xDoc = new XmlDocument();
                    xDoc.Load(filename);
                }
                else
                {
                    WebClient client = new WebClient();
                    client.Headers["User-Agent"] = textBoxUserAgent.Text;
                    client.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    string data = client.DownloadString(filename);

                    xDoc = new XmlDocument();
                    xDoc.LoadXml(data);
                }

                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    for (int j = 0; j <= xnode.ChildNodes.Count; j++)
                    {
                        if (xnode.ChildNodes[j].Name == "loc")
                        {
                            list.Add(xnode.ChildNodes[j].InnerText);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestSitemap", "Ошибка: " + ex.Message);
            }

            return list;
        }

        private ArrayList readXML(string filename)
        {
            ArrayList list = new ArrayList();

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                XmlDataDocument xmldoc = new XmlDataDocument();
                xmldoc.PreserveWhitespace = true;
                xmldoc.XmlResolver = null;
                XmlNodeList xmlnode;
                int i = 0;
                string str = null;
                FileStream fs = new FileStream(@filename, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("url");
                if (xmlnode.Count <= 0) xmlnode = xmldoc.GetElementsByTagName("sitemap");

                for (i = 0; i <= xmlnode.Count - 1; i++)
                {
                    for (int j = 0; j <= xmlnode[i].ChildNodes.Count; j++)
                    {
                        if (xmlnode[i].ChildNodes.Item(j).Name == "loc")
                        {
                            string link = xmlnode[i].ChildNodes.Item(j).InnerText.Trim();
                            list.Add(link);
                            break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestSitemap", "Ошибка: " + ex.Message);
            }

            return list;
        }


        private void FormTestSitemap_Load(object sender, EventArgs e)
        {
            thread = new Thread(TestUrl);
        }

        private void FormTestSitemap_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { thread.Abort(); }
            catch (Exception ex) { QASupportApp.LogMsg("TestSitemap", "Предупреждение: " + ex.Message); }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void сохранитьСписокПроверкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter SW = new StreamWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write));
                SW.Write(textBoxProcess.Text);
                SW.Close();
            }
        }

        private void сохранитьСписокОтветов100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter SW = new StreamWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write));
                SW.Write(textBox100.Text);
                SW.Close();
            }
        }

        private void сохранитьСписокОтветов200ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter SW = new StreamWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write));
                SW.Write(textBox200.Text);
                SW.Close();
            }
        }

        private void сохранитьСписокОтветов300ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter SW = new StreamWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write));
                SW.Write(textBox300.Text);
                SW.Close();
            }
        }

        private void сохранитьСписокОтветов400ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter SW = new StreamWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write));
                SW.Write(textBox400.Text);
                SW.Close();
            }
        }

        private void сохранитьСписокОтветов500ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter SW = new StreamWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write));
                SW.Write(textBox500.Text);
                SW.Close();
            }
        }

        private void сохранитьСписокРазныхОтветовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter SW = new StreamWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write));
                SW.Write(textBoxOther.Text);
                SW.Close();
            }
        }

        private void checkBoxUserAgent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUserAgent.Checked == true)
            {
                checkBoxUserAgent.Text = "Включен User-Agent по умолчанию";
                textBoxUserAgent.Text = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";
                textBoxUserAgent.Enabled = false;
            }
            else
            {
                checkBoxUserAgent.Text = "Отключен User-Agent по умолчанию";
                textBoxUserAgent.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxXML.Text = openFileDialog1.FileName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBoxTXT.Text = openFileDialog2.FileName;
            }
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            TestBegin();
        }

        private void запуститьПроверкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestBegin();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            TestStop();
        }

        private void остановитьПроверкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestStop();
        }

        private void TestEnd()
        {
            processRun = false;
            this.Update();
            QASupportApp.LogMsg("TestSitemap", "Процесс проверки - завершен!");
            MessageBox.Show("Процесс проверки - завершен!");
        }

        private void TestStop()
        {
            try
            {
                processRun = false;
                thread.Abort();
                QASupportApp.LogMsg("TestSitemap", "Процесс проверки - остановлен!");
                MessageBox.Show("Процесс проверки - остановлен!");
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestSitemap", "Предупреждение: " + ex.Message);
            }
        }

        private void TestBegin()
        {
            if (processRun == true)
            {
                QASupportApp.LogMsg("TestSitemap", "Процесс уже запущен");
                MessageBox.Show("Процесс уже запущен", "Сообщение");
                return;
            }

            textBoxProcess.Text = "";
            textBox100.Text = "";
            textBox200.Text = "";
            textBox300.Text = "";
            textBox400.Text = "";
            textBox500.Text = "";
            textBoxOther.Text = "";
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = 0;
            toolStripStatusLabel2.Text = "0%";
            toolStripStatusLabel5.Text = "0:00";

            if (radioButton1.Checked) CheckURL();
            if (radioButton2.Checked) CheckLocal();
            if (radioButton3.Checked) CheckLocal2();
        }

        private void CheckURL()
        {
            thread = new Thread(TestUrl);
            thread.Start();
        }

        private void TestUrl()
        {
            processRun = true;
            try
            {
                ArrayList listLinks = readUrlXML(textBoxURL.Text);
                int count = listLinks.Count;
                int index = 1;
                double totalPages = count;
                double onePercent = 0;
                if (totalPages < 100) onePercent = (100 / totalPages);
                else onePercent = (totalPages / 100);

                HttpClient client;
                HttpResponseMessage response;
                HttpClientHandler handler = new HttpClientHandler();
                handler.AllowAutoRedirect = false;
                foreach (String link in listLinks)
                {
                    try
                    {
                        client = new HttpClient(handler);
                        if (checkBoxUserAgent.Checked == false) client.DefaultRequestHeaders.UserAgent.ParseAdd(textBoxUserAgent.Text);
                        client.BaseAddress = new Uri(link);

                        response = client.GetAsync(link).Result;
                        int statusCode = (int)response.StatusCode;

                        textBoxProcess.AppendText("[" + index.ToString() + "/" + totalPages.ToString() + "] STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine);
                        textBoxProcess.ScrollToCaret();

                        if (statusCode >= 100 && statusCode <= 199)
                        {
                            //textBox100.AppendText("STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine);
                            textBox100.Text = textBox100.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                            //textBox100.ScrollToCaret();
                        }
                        if (statusCode >= 200 && statusCode <= 299)
                        {
                            //textBox200.AppendText("STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine);
                            textBox200.Text = textBox200.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                            //textBox200.ScrollToCaret();
                        }
                        if (statusCode >= 300 && statusCode <= 399)
                        {
                            //textBox300.AppendText("STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine);
                            textBox300.Text = textBox300.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                            //textBox300.ScrollToCaret();
                        }
                        if (statusCode >= 400 && statusCode <= 499)
                        {
                            //textBox400.AppendText("STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine);
                            textBox400.Text = textBox400.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                            //textBox400.ScrollToCaret();
                        }
                        if (statusCode >= 500 && statusCode <= 599)
                        {
                            //textBox500.AppendText("STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine);
                            textBox500.Text = textBox500.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                            //textBox500.ScrollToCaret();
                        }
                        if (statusCode <= 99 || statusCode >= 600)
                        {
                            //textBoxOther.AppendText("STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine);
                            textBoxOther.Text = textBoxOther.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                            //textBoxOther.ScrollToCaret();
                        }
                    }
                    catch (Exception ex)
                    {
                        QASupportApp.LogMsg("TestSitemap", "Ошибка: " + ex.Message);
                        //textBoxOther.AppendText("ERROR [" + ex.Message + "]: " + link + Environment.NewLine);
                        textBoxOther.Text = textBoxOther.Text + "ERROR [" + ex.Message + "]: " + link + Environment.NewLine;
                        //textBoxOther.ScrollToCaret();
                    }

                    showProgressTest(totalPages, onePercent, index);
                    index++;
                }

                toolStripStatusLabel2.Text = "100%";
                toolStripStatusLabel5.Text = "0:00";
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestSitemap", "Ошибка: " + ex.Message);
            }
            TestEnd();
        }

        private void CheckLocal()
        {
            thread = new Thread(TestLocal);
            thread.Start();
        }

        private void TestLocal()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            processRun = true;
            try
            {
                ArrayList listLinks = readXML(textBoxXML.Text);
                int count = listLinks.Count;
                int index = 1;
                double totalPages = count;
                double onePercent = 0;
                if (totalPages < 100) onePercent = (100 / totalPages);
                else onePercent = (totalPages / 100);

                HttpClient client;
                HttpResponseMessage response;
                HttpClientHandler handler = new HttpClientHandler();
                handler.AllowAutoRedirect = false;
                foreach (String link in listLinks)
                {
                    try
                    {
                        client = new HttpClient(handler);
                        if (checkBoxUserAgent.Checked == false) client.DefaultRequestHeaders.UserAgent.ParseAdd(textBoxUserAgent.Text);
                        client.BaseAddress = new Uri(link);

                        response = client.GetAsync(link).Result;
                        int statusCode = (int)response.StatusCode;

                        textBoxProcess.AppendText("[" + index.ToString() + "/" + totalPages.ToString() + "] STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine);
                        textBoxProcess.ScrollToCaret();

                        if (statusCode >= 100 && statusCode <= 199)
                        {
                            textBox100.Text = textBox100.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                        if (statusCode >= 200 && statusCode <= 299)
                        {
                            textBox200.Text = textBox200.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                        if (statusCode >= 300 && statusCode <= 399)
                        {
                            textBox300.Text = textBox300.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                        if (statusCode >= 400 && statusCode <= 499)
                        {
                            textBox400.Text = textBox400.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                        if (statusCode >= 500 && statusCode <= 599)
                        {
                            textBox500.Text = textBox500.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                        if (statusCode <= 99 || statusCode >= 600)
                        {
                            textBoxOther.Text = textBoxOther.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                    }
                    catch (Exception ex)
                    {
                        QASupportApp.LogMsg("TestSitemap", "Ошибка: " + ex.Message);
                        textBoxOther.Text = textBoxOther.Text + "ERROR [" + ex.Message + "]: " + link + Environment.NewLine;
                    }

                    showProgressTest(totalPages, onePercent, index);
                    index++;
                }

                toolStripStatusLabel2.Text = "100%";
                toolStripStatusLabel5.Text = "0:00";
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestSitemap", "Ошибка: " + ex.Message);
            }
            TestEnd();
        }

        private void CheckLocal2()
        {
            thread = new Thread(TestLocal2);
            thread.Start();
        }

        private void TestLocal2()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            processRun = true;
            try
            {
                ArrayList listLinks = new ArrayList();
                string path = @textBoxTXT.Text;
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        listLinks.Add(line.ToString());
                    }
                }

                int count = listLinks.Count;
                int index = 1;
                double totalPages = count;
                double onePercent = 0;
                if (totalPages < 100) onePercent = (100 / totalPages);
                else onePercent = (totalPages / 100);

                HttpClient client;
                HttpResponseMessage response;
                HttpClientHandler handler = new HttpClientHandler();
                handler.AllowAutoRedirect = false;
                foreach (String link in listLinks)
                {
                    try
                    {
                        client = new HttpClient(handler);
                        if (checkBoxUserAgent.Checked == false) client.DefaultRequestHeaders.UserAgent.ParseAdd(textBoxUserAgent.Text);
                        client.BaseAddress = new Uri(link);

                        response = client.GetAsync(link).Result;
                        int statusCode = (int)response.StatusCode;

                        textBoxProcess.AppendText("[" + index.ToString() + "/" + totalPages.ToString() + "] STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine);
                        textBoxProcess.ScrollToCaret();

                        if (statusCode >= 100 && statusCode <= 199)
                        {
                            textBox100.Text = textBox100.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                        if (statusCode >= 200 && statusCode <= 299)
                        {
                            textBox200.Text = textBox200.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                        if (statusCode >= 300 && statusCode <= 399)
                        {
                            textBox300.Text = textBox300.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                        if (statusCode >= 400 && statusCode <= 499)
                        {
                            textBox400.Text = textBox400.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                        if (statusCode >= 500 && statusCode <= 599)
                        {
                            textBox500.Text = textBox500.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                        if (statusCode <= 99 || statusCode >= 600)
                        {
                            textBoxOther.Text = textBoxOther.Text + "STATUS [" + statusCode.ToString() + "]: " + link + Environment.NewLine;
                        }
                    }
                    catch (Exception ex)
                    {
                        QASupportApp.LogMsg("TestSitemap", "Ошибка: " + ex.Message);
                        textBoxOther.Text = textBoxOther.Text + "ERROR [" + ex.Message + "]: " + link + Environment.NewLine;
                    }

                    showProgressTest(totalPages, onePercent, index);
                    index++;
                }

                toolStripStatusLabel2.Text = "100%";
                toolStripStatusLabel5.Text = "0:00";
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestSitemap", "Ошибка: " + ex.Message);
            }
            TestEnd();
        }

        
    }
}
