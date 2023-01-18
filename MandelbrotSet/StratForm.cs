using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MandelbrotSet
{
    public partial class StratForm : Form
    {
        public StratForm()
        {
            InitializeComponent();
        }

        private void StratForm_Load(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void StratForm_Shown(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Visible = false;
            this.Enabled = false;
        }
    }
}
