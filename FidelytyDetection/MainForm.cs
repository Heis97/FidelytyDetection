using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FidelytyDetection;

namespace FidelytyDetection
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FidelityDetection.load_image("6.png", imageBox1);
        }

        private void trackBar_bin_Scroll(object sender, EventArgs e)
        {
            FidelityDetection.bin_image(trackBar_bin.Value, imageBox1, imageBox2);
        }
    }
}