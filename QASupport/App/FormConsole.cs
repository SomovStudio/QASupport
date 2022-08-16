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

        private bool _move = false;
        private bool _resize = false;

        private void FormConsole_Load(object sender, EventArgs e)
        {

        }

        private void resize_MouseDown(object sender, MouseEventArgs e)
        {
            _resize = true;
        }

        private void resize_MouseUp(object sender, MouseEventArgs e)
        {
            _resize = false;
        }

        private void resize_MouseMove(object sender, MouseEventArgs e)
        {
            if(_resize == true)
            {
                this.Width += e.X;
                this.Height += e.Y;
            }
        }

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            _move = true;
        }

        private void header_MouseMove(object sender, MouseEventArgs e)
        {
            if (_move == true)
            {
                this.Location = new Point(this.Location.X + e.X - (this.Width / 2), this.Location.Y + e.Y);
            }
        }

        private void header_MouseUp(object sender, MouseEventArgs e)
        {
            _move = false;
        }

        private void title_MouseDown(object sender, MouseEventArgs e)
        {
            _move = true;
        }

        private void title_MouseMove(object sender, MouseEventArgs e)
        {
            if (_move == true)
            {
                this.Location = new Point(this.Location.X + e.X - (this.Width / 2), this.Location.Y + e.Y);
            }
        }

        private void title_MouseUp(object sender, MouseEventArgs e)
        {
            _move = false;
        }
    }
}
