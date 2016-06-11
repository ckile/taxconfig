using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace taxprocess
{
    public partial class Form1 : Form
    {
        private delegate void closeInvoke();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var threadstart = new ThreadStart(Proc);

            var thread = new Thread(threadstart);

            thread.Start();

            // thread.Join();

            //  Close();
        }

        private void Proc()
        {
            var taxProc = new TaxProcess();
            taxProc.Process();
            BeginInvoke(new closeInvoke(Close));
        }
    }
}