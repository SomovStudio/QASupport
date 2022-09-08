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
using QASupport.App;

namespace QASupport
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            label2.Text = "Version: " + Appication.Version + " (" + Appication.LastUpdate + ")";
            Appication.MainForm = this;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Visible = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings settings = new FormSettings();
            settings.Show();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad.exe");
            }
            catch (Exception ex)
            {
                //DataResources.consoleMessage("ОШИБКА: " + ex.Message);
            }
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("mspaint.exe");
            }
            catch (Exception ex)
            {
                //DataResources.consoleMessage("ОШИБКА: " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void calcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("calc.exe");
            }
            catch (Exception ex)
            {
                //DataResources.consoleMessage("ОШИБКА: " + ex.Message);
            }
        }

        private void cmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("cmd.exe");
            }
            catch (Exception ex)
            {
                //DataResources.consoleMessage("ОШИБКА: " + ex.Message);
            }
        }

        private void devicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("devmgmt.msc");
            }
            catch (Exception ex)
            {
                //DataResources.consoleMessage("ОШИБКА: " + ex.Message);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
