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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsole));
            this.title = new System.Windows.Forms.Label();
            this.window = new System.Windows.Forms.Panel();
            this.footer = new System.Windows.Forms.Panel();
            this.resize = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Panel();
            this.window.SuspendLayout();
            this.footer.SuspendLayout();
            this.header.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Dock = System.Windows.Forms.DockStyle.Right;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(25, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(773, 25);
            this.title.TabIndex = 0;
            this.title.Text = "Консоль";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
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
            // footer
            // 
            this.footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.footer.Controls.Add(this.resize);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 428);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(798, 20);
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
            this.resize.Size = new System.Drawing.Size(15, 20);
            this.resize.TabIndex = 0;
            this.resize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resize_MouseDown);
            this.resize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.resize_MouseMove);
            this.resize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resize_MouseUp);
            // 
            // header
            // 
            this.header.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("header.BackgroundImage")));
            this.header.Controls.Add(this.title);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(798, 25);
            this.header.TabIndex = 2;
            // 
            // FormConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.window);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConsole";
            this.Text = "FormConsole";
            this.Load += new System.EventHandler(this.FormConsole_Load);
            this.window.ResumeLayout(false);
            this.footer.ResumeLayout(false);
            this.header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel window;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Label resize;
        private System.Windows.Forms.Panel header;
    }
}