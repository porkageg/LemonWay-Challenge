using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LemonWay_WindowsForm
{
    public partial class Form1 : Form
    {
        lemonway.Service srv;
        Thread task;

        public Form1()
        {
            InitializeComponent();
            srv = new lemonway.Service();
            progressBar1.Style = ProgressBarStyle.Marquee;
            timer1.Tick += timer1_Tick;
            progressBar1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            button1.Enabled = false;

            task = new Thread(() => {
                var res = srv.Fibonacci(10);
                MessageBox.Show("" + res);
            });
            task.Start();

            Cursor.Current = Cursors.WaitCursor;

            timer1.Interval = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (task == null)
            {
                timer1.Stop();
                return;
            }

            if (task.IsAlive)
                return;

            button1.Enabled = true;
            timer1.Stop();
            progressBar1.Visible = false;
            task = null;
        }
    }
}
