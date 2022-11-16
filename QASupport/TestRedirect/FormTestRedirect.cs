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

namespace QASupport.TestRedirect
{
    public partial class FormTestRedirect : Form
    {
        public FormTestRedirect()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private bool processRun = false;
        private Thread thread;

        private void FormTestRedirect_Load(object sender, EventArgs e)
        {
            QASupportApp.LogMsg("TestRedirect", "Программа загружена");
            checkedListBox1.SetItemChecked(1, true);
            thread = new Thread(TestUrl);
        }

        private void FormTestRedirect_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { thread.Abort(); }
            catch (Exception ex) { QASupportApp.LogMsg("TestRedirect", "Предупреждение: " + ex.Message); }
            QASupportApp.LogMsg("TestRedirect", "Программа закрыта");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = checkedListBox1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = checkedListBox1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = true;
        }

        private void checkBoxUserAgent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUserAgent.Checked == true)
            {
                checkBoxUserAgent.Text = "Включен User-Agent по умолчанию";
                textBoxUserAgent.Text = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";
                textBoxUserAgent.Enabled = false;
                QASupportApp.LogMsg("TestSitemap", "Включен User-Agent по умолчанию");
            }
            else
            {
                checkBoxUserAgent.Text = "Отключен User-Agent по умолчанию";
                textBoxUserAgent.Enabled = true;
                QASupportApp.LogMsg("TestSitemap", "Отключен User-Agent по умолчанию");
            }
        }

        private void запуститьПроверкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestBegin();
        }

        private void остановитьПроверкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestStop();
        }

        private void TestBegin()
        {

        }

        private void TestEnd()
        {

        }

        private void TestStop()
        {
            try
            {
                processRun = false;
                thread.Abort();
                QASupportApp.LogMsg("TestRedirect", "Процесс проверки - остановлен!");
                MessageBox.Show("Процесс проверки - остановлен!");
            }
            catch (Exception ex)
            {
                QASupportApp.LogMsg("TestRedirect", "Предупреждение: " + ex.Message);
            }
        }

        
    }
}
