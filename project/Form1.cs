using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        SoundPlayer p1 = new SoundPlayer(@"C:\Users\TECHSHOP\Desktop\project\resources\bg.wav");
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 log = new Form3();
            log.Show();
            this.Hide();
           
            p1.PlayLooping();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 log = new Form2();
            log.Show();
            this.Hide();          
            
            p1.PlayLooping();            
                        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
           
            
           
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false;
            p1.PlayLooping();
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 log = new Form4();
            log.Show();
            this.Hide();

            p1.PlayLooping();            
            
        }

       
    }
}
