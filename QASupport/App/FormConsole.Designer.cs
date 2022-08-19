namespace QASupport
{
    partial class FormConsole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsole));
            this.window = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.buttonRoll = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonResize = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Label();
            this.footer = new System.Windows.Forms.Panel();
            this.resize = new System.Windows.Forms.Label();
            this.window.SuspendLayout();
            this.header.SuspendLayout();
            this.footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // window
            // 
            this.window.BackColor = System.Drawing.Color.White;
            this.window.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.window.Controls.Add(this.header);
            this.window.Controls.Add(this.footer);
            this.window.Dock = System.Windows.Forms.DockStyle.Fill;
            this.window.Location = new System.Drawing.Point(0, 0);
            this.window.Name = "window";
            this.window.Size = new System.Drawing.Size(800, 450);
            this.window.TabIndex = 1;
            // 
            // header
            // 
            this.header.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("header.BackgroundImage")));
            this.header.Controls.Add(this.title);
            this.header.Controls.Add(this.buttonRoll);
            this.header.Controls.Add(this.buttonResize);
            this.header.Controls.Add(this.buttonClose);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(798, 25);
            this.header.TabIndex = 2;
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            this.header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.header_MouseMove);
            this.header.MouseUp += new System.Windows.Forms.MouseEventHandler(this.header_MouseUp);
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(678, 25);
            this.title.TabIndex = 4;
            this.title.Text = "Консоль";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_MouseDown);
            this.title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title_MouseMove);
            this.title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.title_MouseUp);
            // 
            // buttonRoll
            // 
            this.buttonRoll.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoll.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRoll.ImageIndex = 3;
            this.buttonRoll.ImageList = this.imageList1;
            this.buttonRoll.Location = new System.Drawing.Point(678, 0);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(40, 25);
            this.buttonRoll.TabIndex = 3;
            this.buttonRoll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonRoll_MouseClick);
            this.buttonRoll.MouseLeave += new System.EventHandler(this.buttonRoll_MouseLeave);
            this.buttonRoll.MouseHover += new System.EventHandler(this.buttonRoll_MouseHover);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "button_close.png");
            this.imageList1.Images.SetKeyName(1, "button_resize_max.png");
            this.imageList1.Images.SetKeyName(2, "button_resize_min.png");
            this.imageList1.Images.SetKeyName(3, "button_roll.png");
            // 
            // buttonResize
            // 
            this.buttonResize.BackColor = System.Drawing.Color.Transparent;
            this.buttonResize.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonResize.ImageIndex = 1;
            this.buttonResize.ImageList = this.imageList1;
            this.buttonResize.Location = new System.Drawing.Point(718, 0);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(40, 25);
            this.buttonResize.TabIndex = 2;
            this.buttonResize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseClick);
            this.buttonResize.MouseLeave += new System.EventHandler(this.buttonResize_MouseLeave);
            this.buttonResize.MouseHover += new System.EventHandler(this.buttonResize_MouseHover);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.ImageIndex = 0;
            this.buttonClose.ImageList = this.imageList1;
            this.buttonClose.Location = new System.Drawing.Point(758, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(40, 25);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonClose_MouseClick);
            this.buttonClose.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            this.buttonClose.MouseHover += new System.EventHandler(this.buttonClose_MouseHover);
            // 
            // footer
            // 
            this.footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.footer.Controls.Add(this.resize);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 426);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(798, 22);
            this.footer.TabIndex = 1;
            // 
            // resize
            // 
            this.resize.BackColor = System.Drawing.Color.Transparent;
            this.resize.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.resize.Dock = System.Windows.Forms.DockStyle.Right;
            this.resize.Image = ((System.Drawing.Image)(resources.GetObject("resize.Image")));
            this.resize.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.resize.Location = new System.Drawing.Point(783, 0);
            this.resize.Name = "resize";
            this.resize.Size = new System.Drawing.Size(15, 22);
            this.resize.TabIndex = 0;
            this.resize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resize_MouseDown);
            this.resize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.resize_MouseMove);
            this.resize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resize_MouseUp);
            // 
            // FormConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.window);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConsole";
            this.Text = "FormConsole";
            this.Load += new System.EventHandler(this.FormConsole_Load);
            this.window.ResumeLayout(false);
            this.header.ResumeLayout(false);
            this.footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel window;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Label resize;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label buttonRoll;
        private System.Windows.Forms.Label buttonResize;
        private System.Windows.Forms.Label buttonClose;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label title;
    }
}