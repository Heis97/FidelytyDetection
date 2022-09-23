using System;
using System.Collections.Generic;
using System.Drawing;
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
    }
}
