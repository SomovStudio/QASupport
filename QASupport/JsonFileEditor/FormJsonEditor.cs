using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QASupport.JsonFileEditor
{
    public partial class FormJsonEditor : Form
    {
        public FormJsonEditor()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void FormJsonEditor_Load(object sender, EventArgs e)
        {

        }

        private void FormJsonEditor_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
