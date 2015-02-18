using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageEditor__
{
    public partial class Form1 : Form
    {
        //Image rawimage;

        public Form1()
        {
            InitializeComponent();
        }


        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileopen = new OpenFileDialog();
            fileopen.Filter = "Image Files|*.jpg"; //file type filtering.
            fileopen.Title = "Select a Image File"; //open dialogue-box title.
            //rawimage = Image.FromFile(fileopen.FileName.ToString());

            if (fileopen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Loading the image into the picture box.
                pictureBox1.Image = Image.FromFile(fileopen.FileName);
            }
        }

        private void closeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void pixelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap rawbitmap = new Bitmap(pictureBox1.Image);
            Bitmap generate = new Bitmap((rawbitmap.Width) * 2, (rawbitmap.Height) * 2);
            //generate pixels along y-axis.
            for (int i = 0; i < generate.Width; i++)
            {
                for (int j = 0; j < generate.Height-1; j++)
                {
                    if (j % 2 == 1)
                    {
                        Color lowerpix = rawbitmap.GetPixel((i / 2), ((j - 1) / 2));
                        Color higherpix = rawbitmap.GetPixel((i / 2), ((j + 1) / 2));
                        Color avgcolor = Color.FromArgb((lowerpix.A + higherpix.A) / 2, (lowerpix.R + higherpix.R) / 2, (lowerpix.G + higherpix.G) / 2, (lowerpix.B + higherpix.B) / 2);
                        generate.SetPixel(i, j, avgcolor);
                    }
                    else
                    {
                        generate.SetPixel(i,j,rawbitmap.GetPixel(i/2,j/2));
                    }
                }
            }
            //generate pixels along x-axis.
            for (int i = 0; i < generate.Height; i++)
            {
                for (int j = 0; j < generate.Width-1; j++)
                {
                    if (j % 2 == 1)
                    {
                        Color lowerpix = rawbitmap.GetPixel(((j-1) / 2), (i / 2));
                        Color higherpix = rawbitmap.GetPixel(((j+1) / 2), (i / 2));
                        Color avgcolor = Color.FromArgb((lowerpix.A + higherpix.A) / 2, (lowerpix.R + higherpix.R) / 2, (lowerpix.G + higherpix.G) / 2, (lowerpix.B + higherpix.B) / 2);
                        generate.SetPixel(j, i, avgcolor);
                    }
                    else
                    {
                        generate.SetPixel(j, i, rawbitmap.GetPixel(j / 2, i / 2));
                    }
                }
            }
            //save the generate bitmap.
            //pictureBox1.Image = generate;
            generate.Save(Application.StartupPath + "\\atanu001.jpg");
        }

        

        

        
    }
}
