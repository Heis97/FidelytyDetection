using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FidelytyDetection
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FidelityDetection.load_image("8.png", imageBox1);
            FidelityDetection.generate_2d_design("code8.txt", imageBox2);
        }

        private void trackBar_bin_Scroll(object sender, EventArgs e)
        {
           // FidelityDetection.bin_image(trackBar_bin.Value, imageBox1, imageBox2);
            FidelityDetection.align_image(trackBar_bin.Value, imageBox1, imageBox2);
        }

        private void but_save_pic_Click(object sender, EventArgs e)
        {
            FidelityDetection.saveImage(imageBox2, textBox_name.Text);
        }

        private void trackBar_rotate_Scroll(object sender, EventArgs e)
        {
            FidelityDetection.rotate_image(trackBar_rotate.Value, imageBox1, imageBox2);
        }

        private void but_2d_design_Click(object sender, EventArgs e)
        {
            var p_st = new PointF(
                Convert.ToSingle(textBox_x_st.Text),
                Convert.ToSingle(textBox_y_st.Text));
            var k = Convert.ToSingle(textBox_k.Text);
            var size = Convert.ToInt32(textBox_size.Text);
            FidelityDetection.draw_2d_design(p_st, k,size, imageBox2);
            FidelityDetection.compFidel(imageBox2);
        }
    }
}