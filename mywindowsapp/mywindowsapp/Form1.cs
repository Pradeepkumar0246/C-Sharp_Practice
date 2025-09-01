using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mywindowsapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yourname = textBoxName.Text;
            string greet= "Hello "+ yourname+"!";
            labelgreeting.Text = greet;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
