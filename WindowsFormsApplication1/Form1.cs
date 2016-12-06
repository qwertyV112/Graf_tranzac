using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap mbit;
       
        Graphics k; 
        public Form1()
        {
            InitializeComponent();
        }
        public struct adjacency_matrix
        {
            public int Nambers;
            public char Name;
            public int x, y;
        }
        public class Translate
        {

            public int N = 0;
            public int N2 = 0;
            public char[] Matrix = new char[100];
            public char[] TMatrix = new char[100];
            public adjacency_matrix[] AMarix = new adjacency_matrix[12];
            public int Temp=0;
            public void StringToInt(string[] s)
            {
                try
                {
                    for (; N < s.Length; N++)
                    {
                        Matrix[N] = Convert.ToChar(s[N]);
                        TMatrix[N]=Convert.ToChar(s[N]);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    // return;
                }
                
            }
            public void Smeshnot()
            {
                for (int i=0; i<N; i++)
                {
                    Temp = -1;
                    if (Matrix[i] != '!')
                    {
                        for (int j = 0; j < N; j++)
                        {
                            if (Matrix[i] == Matrix[j] && i != j && Matrix[j] != '!')
                            {
                                AMarix[N2].Nambers++;
                                Temp = j;
                                
                            }
                        }
                        if (Temp != -1)
                        {
                            AMarix[N2].Name = Matrix[Temp];
                            Matrix[Temp] = '!';
                        }
                        else AMarix[N2].Name = Matrix[i];
                        N2++;
                    }
                    else continue;
                }

            }
        }
        Translate t = new Translate();
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Вершины графа (*.txt)|*.txt|All files (*.*)|*.*";



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    using (myStream)
                    {
                        StreamReader file = new StreamReader(openFileDialog1.FileName);
                        while (!file.EndOfStream)
                        {
                            t.StringToInt(file.ReadLine().Split(' '));
                        }
                        file.Close();

                    }
                }
            }
            for (int i = 0; i < t.N; i++)
            {
                listBox1.Items.Add(t.Matrix[i]);
            }
            
        }



        private void button1_Click(object sender, EventArgs e)
        { 
        
        }
        public double Radians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
        public int Ze(int n)
        {
            return Convert.ToInt32(360 / n);
        }
        public void LineGraf()
        {int w=0,v=0;
            for (int j = 0; j < t.N ; j++)
            {
                for (int jj = 0; jj < t.N2 ; jj++)
            {
                if (t.TMatrix[j] == t.AMarix[jj].Name) { w = jj; break;}
                
            }
                for (int jj = 0; jj < t.N2 ; jj++)
                {
                    if (t.TMatrix[j+1] == t.AMarix[jj].Name) { v = jj; break; }

                }
                k.DrawLine(Pens.Red, t.AMarix[w].x, t.AMarix[w].y, t.AMarix[v].x, t.AMarix[v].y);
                
            }
        }
        //     k.DrawLine(Pens.Red, t.AMarix[j].x, t.AMarix[j].y, t.AMarix[j + 1].x, t.AMarix[j + 1].y);
        public void Draws()
        {
             mbit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            k = Graphics.FromImage(mbit);
           // k.DrawLine(Pens.Black, 0,10,2,11);
            int i = 0;
            int r = 70;// *Convert.ToInt32(k / 50);
            int sh = 70;
            int k1 = Ze(t.N2);
            int[,] MatrixXY = new int[t.N2, 2];
            
            String drawString;

            // Create font and brush.
            Font drawFont = new Font("Arial", 14);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            for (int j = 0; j < t.N2; j++)
            {

                MatrixXY[j, 0] = sh + Convert.ToInt32(r * Math.Cos(Radians(i)));
                MatrixXY[j, 1] = sh + Convert.ToInt32(r * Math.Sin(Radians(i)));
                t.AMarix[j].x = MatrixXY[j, 0]+10;
                t.AMarix[j].y = MatrixXY[j, 1]+10;
                drawString = t.AMarix[j].Name.ToString();
              
                k.DrawEllipse(Pens.Black, MatrixXY[j, 0], MatrixXY[j, 1], 20, 20);
                k.DrawString(drawString, drawFont, drawBrush, MatrixXY[j, 0] + 3, MatrixXY[j, 1] - 2);
                i += k1;
            }

                LineGraf();
           
            pictureBox1.Image = mbit;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            t.Smeshnot();
            for (int i=0;i<t.N2;i++)
            {
                listBox2.Items.Add(t.AMarix[i].Name+"   ("+  t.AMarix[i].Nambers.ToString() +")");
            }

           
            Draws();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
