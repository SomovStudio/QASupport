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
    public partial class FormTemplate : Form
    {
        public FormTemplate()
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

        private void buttonClose_MouseHover(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.Crimson;
        }

        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.Transparent;
        }

        private void buttonClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void buttonResize_MouseHover(object sender, EventArgs e)
        {
            buttonResize.BackColor = Color.SlateBlue;
        }

        private void buttonResize_MouseLeave(object sender, EventArgs e)
        {
            buttonResize.BackColor = Color.Transparent;
        }

        private void buttonResize_MouseClick(object sender, MouseEventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                buttonResize.ImageIndex = 2;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                buttonResize.ImageIndex = 1;
            }
            
        }

        private void buttonRoll_MouseHover(object sender, EventArgs e)
        {
            buttonRoll.BackColor = Color.SlateBlue;
        }

        private void buttonRoll_MouseLeave(object sender, EventArgs e)
        {
            buttonRoll.BackColor = Color.Transparent;
        }

        private void buttonRoll_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
