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
    public partial class FormErrors : Form
    {
        public FormErrors()
        {
            InitializeComponent();
        }

        private void FormErrors_Load(object sender, EventArgs e)
        {
            QASupportApp.LogMsg("QASupport", "Открыт журнал ошибок");
            Errors.AppendText(""+ Environment.NewLine);
            Errors.ScrollToCaret();
        }

        private void FormErrors_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
