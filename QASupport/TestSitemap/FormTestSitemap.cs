using System;
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

        private void FormTestSitemap_Load(object sender, EventArgs e)
        {
            //thread = new Thread(TestUrl);
        }

        private void FormTestSitemap_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { thread.Abort(); }
            catch (Exception ex) { QASupportApp.ErrorMsg("TestSitemap", ex.Message); }
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
    }
}
