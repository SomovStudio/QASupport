using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QASupport.App
{
    public partial class FormLogs : Form
    {
        public FormLogs()
        {
            InitializeComponent();
        }

        private void FormLogs_Load(object sender, EventArgs e)
        {
            QASupportApp.LogMsg("QASupport", "Открыт журнал логов");
        }

        private void FormLogs_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            QASupportApp.LogMsg("QASupport", "Лог сохранен");
        }
    }
}
