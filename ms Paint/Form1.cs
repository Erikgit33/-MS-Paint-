using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ms_Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int drawtype = 0;
        int size = 20;
        Pen pen = new Pen(Brushes.Black);
        Bitmap bitmap;
        Graphics graphics;

        void draw(int x, int y)
        {
            if (drawtype == 0)
            {
                graphics.FillEllipse(pen.Brush, x - size/2, y - size/2, size, size);
                pictureBox1.Image = bitmap;
            }
            else if (drawtype == 1)
            {
                graphics.DrawEllipse(pen, x - size/2, y - size/2, size, size);
                pictureBox1.Image = bitmap;
            }
            else if (drawtype == 2)
            {
                graphics.FillRectangle(pen.Brush, x - size/2, y - size/2, size, size);
                pictureBox1.Image = bitmap;
            }
            else if (drawtype == 3)
            {
                graphics.DrawRectangle(pen, x - size/2, y - size/2, size, size);
                pictureBox1.Image = bitmap;
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;

            toolStripTextBox1.Text = size.ToString();
            menuStrip1.BackColor = Color.Orange;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = pictureBox1.Height - 1; y >= 0; y--)
            {
                for (int x = pictureBox1.Width - 1; x >= 0; x--)
                {
                    Color pixelcolor = bitmap.GetPixel(x, y);
                    Color newColor = Color.White;
                    bitmap.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = bitmap;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                draw(e.X, e.Y);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draw(e.X, e.Y);
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                Int32.TryParse(toolStripTextBox1.Text, out size);
            }
        }

        private void filledElpiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawtype = 0;
        }

        private void elipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawtype = 1;
        }

        private void filledRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawtype = 2;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawtype = 3;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK) 
            { 
                pen.Color = colorDialog1.Color; 
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = pictureBox1.Height - 1; y >= 0; y--)
            {
                for (int x = pictureBox1.Width - 1; x >= 0; x--)
                {
                    Color pixelcolor = bitmap.GetPixel(x, y);
                    Color newColor = colorDialog1.Color;
                    bitmap.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = bitmap;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
