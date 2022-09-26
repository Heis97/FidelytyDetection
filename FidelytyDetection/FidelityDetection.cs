using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;

namespace FidelytyDetection
{
    class FidelityDetection
    {
        static Mat pic1;
        static PointF[] ps1;
        public static void load_image(string path, ImageBox imageBox)
        {
            pic1 = new Mat(path);
            imageBox.Image = pic1;
        }

        public static void bin_image(int bin, ImageBox imageBox1, ImageBox imageBox2)
        {
            //var pic = new Mat();
            //CvInvoke.CvtColor(pic1, pic, ColorConversion.Bgr2Gray);
            //CvInvoke.GaussianBlur(pic, pic, new Size(9, 9), 0);
            //CvInvoke.Threshold(pic, pic, bin, 255, ThresholdType.Binary);
            //CvInvoke.AdaptiveThreshold(pic, pic, bin, AdaptiveThresholdType.GaussianC, ThresholdType.Binary, 15, 0);

            //imageBox1.Image = pic;
            //Mat kernel5 = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(5, 5), new Point(1, 1));
            //CvInvoke.MorphologyEx(pic, pic,MorphOp.Dilate,kernel5,new Point(-1,-1),1,BorderType.Default,new Emgu.CV.Structure.MCvScalar(255));

            //imageBox2.Image = sobel_image();
            var pic = new Mat();
            //CvInvoke.Threshold(pic, pic, 120, 255, ThresholdType.Binary);
            CvInvoke.CvtColor(pic1, pic, ColorConversion.Bgr2Gray);
            Console.WriteLine(pic.Depth + " " + pic.NumberOfChannels);
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hier = new Mat();
            CvInvoke.FindContours(pic, contours, hier, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
            Console.WriteLine("contours.Length: " + contours.Length);
            CvInvoke.DrawContours(pic1, contours, -1, new MCvScalar(255, 0, 0), 2, LineType.EightConnected);
            imageBox2.Image = pic1;
        }

        public static void align_image(int bin, ImageBox imageBox1, ImageBox imageBox2)
        {
            var pic = pic1.Clone();

            CvInvoke.GaussianBlur(pic, pic, new Size(3, 3), 0);
            CvInvoke.Threshold(pic, pic, bin, 255, ThresholdType.Binary);
            imageBox2.Image = pic;
        }
        public static void rotate_image(int angle, ImageBox imageBox1, ImageBox imageBox2)
        {
            var pic = pic1.Clone();
            var pc = new PointF(pic.Width / 2, pic.Height / 2);
            var m = new Mat();
            CvInvoke.GetRotationMatrix2D(pc, angle, 1,m);
            CvInvoke.WarpAffine(pic, pic, m, pic.Size);
            imageBox2.Image = pic;
        }
        public static void saveImage(ImageBox imageBox1,string name)
        {
            var pic = (Mat)imageBox1.Image;
            pic.Save(name + ".png");
        }
        static Mat sobel_image()
        {
            var inp = new Mat();
            var sob = new Mat();
            pic1.CopyTo(inp);
            var gray_x = new Mat();
            var gray_y = new Mat();
            CvInvoke.Sobel(inp, gray_x, DepthType.Cv32F, 1, 0);
            CvInvoke.Sobel(inp, gray_y, DepthType.Cv32F, 0, 1);
            
            gray_x.ConvertTo(gray_x, DepthType.Cv8U);
            gray_y.ConvertTo(gray_y, DepthType.Cv8U);
            inp = gray_x + gray_y;
            inp.ConvertTo(sob, DepthType.Cv8U);
            return sob;
            //CvInvoke.CvtColor(sob, sob, ColorConversion.Gray2);
        }
        static Mat sobel(Image<Gray, byte> im)
        {
            var im_sob = new Image<Gray, byte>(im.Size);
            im.CopyTo(im_sob);
            //CvInvoke.Resize(im, im_sob, size_1);
            var gray_x = im_sob.Sobel(1, 0, 3);
            var gray_y = im_sob.Sobel(0, 1, 3);


            for (int x = 0; x < im_sob.Width; x++)
            {
                for (int y = 0; y < im_sob.Height; y++)
                {
                    var sob = (int)(Math.Abs(gray_x.Data[y, x, 0]) + Math.Abs(gray_y.Data[y, x, 0]));
                    if (sob > 255)
                    {
                        im_sob.Data[y, x, 0] = 255;
                    }
                    else
                    {
                        im_sob.Data[y, x, 0] = (byte)sob;
                    }

                }
            }
            return im_sob.Mat;
        }

        static PointF[] trajFromGcode(string path)
        {
            string file1;
            var ps = new List<PointF>();
            using (StreamReader sr = new StreamReader(path))
            {
                file1 = sr.ReadToEnd();
            }
            var lines = file1.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Trim();
               // Console.WriteLine(lines[i]);
                var line = lines[i];
                var param = line.Split(' ');
                if (param.Length > 3)
                {
                    for (int j = 0; j < param.Length; j++)
                    {
                        param[j] = param[j].Trim();
                        var fab = 0;
                        if (param[0][0] == 'N')
                        {
                            fab = 1;
                        }

                        if (param[0 + fab][0] == 'G' && param[1 + fab][0] == 'X' && param[2 + fab][0] == 'Y')
                        {
                            var x = Convert.ToSingle(param[1 + fab].Remove(0, 1));
                            var y = Convert.ToSingle(param[2 + fab].Remove(0, 1));
                            Console.WriteLine(x+" "+y);
                            ps.Add(new PointF(x, y));
                        }
                    }
                }
            }
            return ps.ToArray();
        }


        static PointF[] normalize(PointF[] ps)
        {
            float x_min = float.MaxValue;
            float y_min = float.MaxValue;
            for(int i = 0; i < ps.Length; i++)
            {
                x_min = Math.Min(x_min, ps[i].X);
                y_min = Math.Min(y_min, ps[i].Y);
            }
            for(int i = 0; i < ps.Length; i++)
            {
                ps[i].X -= x_min;
                ps[i].Y -= y_min;
            }
            return ps;
        }
        static PointF[] transf(PointF[] ps,float k, PointF p_st)
        {
            var ps_tr = new PointF[ps.Length];
            for (int i = 0; i < ps.Length; i++)
            {
                var x = k * ps[i].X + p_st.X;
                var y = k * ps[i].Y + p_st.Y;
                ps_tr[i] = new PointF(x, y);
            }
            return ps_tr;
        }

        public static void generate_2d_design(string path, ImageBox imageBox)
        {
            ps1 = normalize( trajFromGcode(path));
            var pic = new Mat(pic1.Size, DepthType.Cv8S, 3);
            drawLines(pic,toPoint(ps1),255,0,0);
            imageBox.Image = pic;
        }


        public static void draw_2d_design(PointF p_st, float k, int size, ImageBox imageBox1)
        {
            var pic = pic1.Clone();
            var ps = transf(ps1,k,p_st);
            drawLines(pic, toPoint(ps), 255, 0, 0, size);
            imageBox1.Image = pic;
        }


        static Mat drawLines(Mat im, Point[] points1, int r, int g, int b, int size = 1)
        {
            int ind = 0;
            var color = new MCvScalar(b, g, r);//bgr
            if (points1 == null)
            {
                return im;
            }
            if (points1.Length != 0)
            {
                for (int i = 0; i < points1.Length - 1; i++)
                {
                    //CvInvoke.Circle(im, points1[i], 2 * size, color, 1);
                    CvInvoke.Line(im, points1[i], points1[i + 1], color, size);
                    ind++;
                }
            }
            return im;
        }
        
        public static void compFidel(ImageBox imageBox)
        {
            var pic = ((Mat)imageBox.Image).ToImage<Bgr,byte>();
            var area = count_pix(pic, 255, 0, 0);
            var err = count_pix(pic, 255, 255, 255);
            Console.WriteLine(area+ " "+ err+" "+((float)err/area));
            imageBox.Image = pic;
        }

        static int count_pix(Image<Bgr, byte> im, int r, int g, int b)
        {
            int cnt = 0;
            for(int i = 0; i < im.Height; i++)
            {
                for (int j = 0; j < im.Width; j++)
                {

                    if(im.Data[i,j,0]==b && im.Data[i, j, 1] == g && im.Data[i, j, 2] == r )
                    {
                        cnt++;
                    }

                }
            }
            return cnt;
        }



        static void drawPointsF(Mat im, PointF[] points, int r, int g, int b, int size = 1)
        {
            drawLines(im, toPoint(points), r, g, b, size);
        }

         static Point[] toPoint(PointF[] ps)
        {
            if (ps == null)
            {
                return null;
            }
            var ret = new Point[ps.Length];
            for (int i = 0; i < ps.Length; i++)
            {
                ret[i] = new Point((int)ps[i].X, (int)ps[i].Y);
            }
            return ret;
        }
    }
}
