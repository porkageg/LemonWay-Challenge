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
        Form waitingForm;

        public event EventHandler MyLongRunningTaskEvent;

        public Form1()
        {
            InitializeComponent();
            srv = new lemonway.Service();
        }

        private void fibbonacciEvent(object sender, EventArgs arg)
        {
            button1.Enabled = true;
            timer1.Stop();
            waitingForm.Close();
        }

        private void fibbonacciCall()
        {
            int res = 0;
            try
            {
                res = srv.Fibonacci(10);
            }
            finally
            {
                this.BeginInvoke(MyLongRunningTaskEvent, this, EventArgs.Empty);
                MessageBox.Show("" + res);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            waitingForm = new WaitingForm();
            waitingForm.Show();
            button1.Enabled = false;

            MyLongRunningTaskEvent += fibbonacciEvent;
            Thread thread = new Thread(fibbonacciCall) { IsBackground = true };
            thread.Start();
        }
    }
}
