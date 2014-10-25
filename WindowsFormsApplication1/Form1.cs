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
        
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public struct adjacency_matrix
        {
            public int Nambers;
            public char Name;
            public int x, y;
        }
        public class Translate
        {
            int i = 0,j=0; 
          public  char[][] Matrix = new char[3][];
          public char[][] TMatrix = new char[3][];
           // char[,] AMatrix = new char[,];
           // int[,] MatrixXY = new int[k, 2];
            adjacency_matrix[] AMarix = new adjacency_matrix[3*5];
            



           public void StringToInt(string[] s)
            {
                
                for (; j < s.Length; j++)
                {
                    Matrix[i][j] = Convert.ToChar(s[j]);
                }
                    i++;
                    j = 0;
            }
           public void zap()
           {
                Matrix[0] = new char[] { 'a', 'd', 's', 'm', 't' };
                Matrix[1] = new char[] { 'n', 't', 'l', 'u', 'o' };
                Matrix[2] = new char[] { 's', 'm', 'q', 't', 'p' };
                TMatrix = Matrix;
               // string[] y;                                                                                                                               
                 //y[0] =   Convert.ToString(Matrix[0]);
               // listBox1.Items.Add(Matrix[0][1]);
           }
            public bool Razbor3(char a,int k)
           {
               for (int t = 0; t<=k;t++ ) {
                   if (AMarix[t].Name == a) { return false; }
               }
               return true;
           }
           public void Razbor2(int t1, int t2)
           {
               int i2=0,j2=0;
               bool trig=false;
               for (int i1 = 0; i1 < Matrix.Length; i1++)
               {
                   for (int j1 = 0; j1 < Matrix[i1].Length; j1++)
                   {
                       if (Matrix[t1][t2] == Matrix[i1][j1] && (t1 != i1 && t2 != j1))
                       {
                           AMarix[i2].Nambers++;
                       }
                       

                   }
                   if (Razbor3(TMatrix[t1][t2], i2))
                   {
                       i2++;
                   }
                       AMarix[i2].Name = Matrix[t1][t2];
                   
                   
                   
                   
               }
                       
           }
            public void Razbor()
           {
               for (int i = 0; i < Matrix.Length; i++)
               {
                   for (int j = 0; j < Matrix[i].Length; j++)
                   {
                       Razbor2(i,j);
                   }
               }
                  

           }
        }
        public class Grafic
        {
            public Translate nex =new Translate();
            public void Start()
            {
                nex.zap();
                nex.Razbor();
            }
                 

        }
        public class Graf
        {



        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Translate t = new Translate();
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Вершины графа (*.txt)|*.txt|All files (*.*)|*.*";
            


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public double Radians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
        public int Ze(int n)
        {
            return Convert.ToInt32(360/n);
        }
        public bool Ysl()
        {

            return true;
        }
        public void relations()
        {
           

            return;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int k = 5;
            int i = 0;
            int r = 70;// *Convert.ToInt32(k / 50);
            int sh = 70;
            int k1 = Ze(k);
            int[,] MatrixXY = new int[k,2];
            Graphics g = e.Graphics;
            String drawString = "G";

            // Create font and brush.
            Font drawFont = new Font("Arial", 14);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            for (int j = 0; j < k; j++)
            {
             
                 MatrixXY[j,0] = sh + Convert.ToInt32(r * Math.Cos(Radians(i)));
                 MatrixXY[j,1] = sh + Convert.ToInt32(r * Math.Sin(Radians(i)));
                 e.Graphics.DrawEllipse(Pens.Black, MatrixXY[j, 0], MatrixXY[j, 1], 20, 20);
                 e.Graphics.DrawString(drawString, drawFont, drawBrush, MatrixXY[j, 0]+3, MatrixXY[j, 1]-2);
                 i += k1;
            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Grafic r = new Grafic();
            r.Start();
           // listBox1.Items.Add(r.nex.Matrix[0].ToString());
        }
    }
}
