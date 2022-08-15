using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QASupport
{
    public partial class FormConsole : Form
    {
        public FormConsole()
        {
            InitializeComponent();
        }

        private bool move = false;

        private void FormConsole_Load(object sender, EventArgs e)
        {

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.Location = new Point(this.Location.X + e.X, this.Location.Y + e.Y);

            }
        }

        
    }
}
