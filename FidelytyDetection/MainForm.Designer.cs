namespace FidelytyDetection
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.trackBar_bin = new System.Windows.Forms.TrackBar();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.trackBar_rotate = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.but_save_pic = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_k = new System.Windows.Forms.TextBox();
            this.textBox_x_st = new System.Windows.Forms.TextBox();
            this.textBox_y_st = new System.Windows.Forms.TextBox();
            this.but_2d_design = new System.Windows.Forms.Button();
            this.textBox_size = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_bin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(12, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(690, 581);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // trackBar_bin
            // 
            this.trackBar_bin.Location = new System.Drawing.Point(12, 611);
            this.trackBar_bin.Maximum = 255;
            this.trackBar_bin.Name = "trackBar_bin";
            this.trackBar_bin.Size = new System.Drawing.Size(690, 45);
            this.trackBar_bin.TabIndex = 3;
            this.trackBar_bin.Scroll += new System.EventHandler(this.trackBar_bin_Scroll);
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(708, 12);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(690, 581);
            this.imageBox2.TabIndex = 4;
            this.imageBox2.TabStop = false;
            // 
            // trackBar_rotate
            // 
            this.trackBar_rotate.Location = new System.Drawing.Point(12, 662);
            this.trackBar_rotate.Maximum = 90;
            this.trackBar_rotate.Name = "trackBar_rotate";
            this.trackBar_rotate.Size = new System.Drawing.Size(690, 45);
            this.trackBar_rotate.TabIndex = 5;
            this.trackBar_rotate.Scroll += new System.EventHandler(this.trackBar_rotate_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(12, 713);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(690, 45);
            this.trackBar2.TabIndex = 6;
            // 
            // but_save_pic
            // 
            this.but_save_pic.Location = new System.Drawing.Point(1282, 599);
            this.but_save_pic.Name = "but_save_pic";
            this.but_save_pic.Size = new System.Drawing.Size(116, 30);
            this.but_save_pic.TabIndex = 7;
            this.but_save_pic.Text = "Сохранить";
            this.but_save_pic.UseVisualStyleBackColor = true;
            this.but_save_pic.Click += new System.EventHandler(this.but_save_pic_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(1135, 605);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(141, 20);
            this.textBox_name.TabIndex = 8;
            // 
            // textBox_k
            // 
            this.textBox_k.Location = new System.Drawing.Point(104, 794);
            this.textBox_k.Name = "textBox_k";
            this.textBox_k.Size = new System.Drawing.Size(141, 20);
            this.textBox_k.TabIndex = 9;
            this.textBox_k.Text = "34.5";
            // 
            // textBox_x_st
            // 
            this.textBox_x_st.Location = new System.Drawing.Point(104, 820);
            this.textBox_x_st.Name = "textBox_x_st";
            this.textBox_x_st.Size = new System.Drawing.Size(141, 20);
            this.textBox_x_st.TabIndex = 10;
            this.textBox_x_st.Text = "38";
            // 
            // textBox_y_st
            // 
            this.textBox_y_st.Location = new System.Drawing.Point(104, 846);
            this.textBox_y_st.Name = "textBox_y_st";
            this.textBox_y_st.Size = new System.Drawing.Size(141, 20);
            this.textBox_y_st.TabIndex = 11;
            this.textBox_y_st.Text = "38";
            // 
            // but_2d_design
            // 
            this.but_2d_design.Location = new System.Drawing.Point(129, 872);
            this.but_2d_design.Name = "but_2d_design";
            this.but_2d_design.Size = new System.Drawing.Size(116, 30);
            this.but_2d_design.TabIndex = 12;
            this.but_2d_design.Text = "Дизайн";
            this.but_2d_design.UseVisualStyleBackColor = true;
            this.but_2d_design.Click += new System.EventHandler(this.but_2d_design_Click);
            // 
            // textBox_size
            // 
            this.textBox_size.Location = new System.Drawing.Point(104, 768);
            this.textBox_size.Name = "textBox_size";
            this.textBox_size.Size = new System.Drawing.Size(141, 20);
            this.textBox_size.TabIndex = 13;
            this.textBox_size.Text = "25";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 771);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "line_size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 797);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "scale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 823);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "x_st";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 849);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "y_st";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1918, 1014);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_size);
            this.Controls.Add(this.but_2d_design);
            this.Controls.Add(this.textBox_y_st);
            this.Controls.Add(this.textBox_x_st);
            this.Controls.Add(this.textBox_k);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.but_save_pic);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar_rotate);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.trackBar_bin);
            this.Controls.Add(this.imageBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_bin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.TrackBar trackBar_bin;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.TrackBar trackBar_rotate;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button but_save_pic;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_k;
        private System.Windows.Forms.TextBox textBox_x_st;
        private System.Windows.Forms.TextBox textBox_y_st;
        private System.Windows.Forms.Button but_2d_design;
        private System.Windows.Forms.TextBox textBox_size;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

