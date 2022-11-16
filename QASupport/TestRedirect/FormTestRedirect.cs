using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QASupport.TestRedirect
{
    public partial class FormTestRedirect : Form
    {
        public FormTestRedirect()
        {
            InitializeComponent();
        }

        private void FormTestRedirect_Load(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(1, true);
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
    }
}
