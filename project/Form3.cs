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
    
    public partial class Form3 : Form
    {
        
         
        int collectedcoins = 0;
        int carSpeed = 5;
        int roadSpeed = 5;
        bool carLeft;
        bool carRight;
        int trafficSpeed = 5;
        int Score = 0;
        Random rnd = new Random();
        SoundPlayer l1 = new SoundPlayer(@"C:\Users\TECHSHOP\Desktop\project\resources\hit.wav");
        SoundPlayer l2 = new SoundPlayer(@"C:\Users\TECHSHOP\Desktop\project\resources\car.wav");
        SoundPlayer p1 = new SoundPlayer(@"C:\Users\TECHSHOP\Desktop\project\resources\bg.wav");
        
        
        public Form3()

        {
            InitializeComponent();
        }
        
        
        private void keyisdown(object sender, KeyEventArgs e)
        {

         
            if (e.KeyCode == Keys.Left && player.Left > 0)
            {
                carLeft = true;
            }

            if (e.KeyCode == Keys.Right && player.Left + player.Width < panel1.Width)
            {
                carRight = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Left && player.Left > 0)
            {
                carLeft = false;
            }

            if (e.KeyCode == Keys.Right && player.Left + player.Width < panel1.Width)
            {
                carRight = false;
            }
        }
        private void moveCar(object sender, KeyEventArgs e)
        {

        }

        private void gametimerevent(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            this.Size = new Size(520, 650);
            roadTrack2.Visible = true;
            label1.Visible = true;
            distance.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            car2.Visible = true;
            carl.Visible = true;
            panel6.Visible = true;
            trophy.Visible = false;
            button1.Enabled = false; 
            player.Visible = true;
            button2.Enabled = false;

            button1.Visible = false;

            button2.Visible = false;

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label2.Visible = false;


            explosion.Visible = false; // hide the explosion image

            trafficSpeed = 5; // set the traffic back to default

            roadSpeed = 8; // set the road speed back to default

            Score = 0; // reset score to 0

            collectedcoins = 0; // reset coins to 0

            player.Left = 161; // reset player left
            player.Top = 286; // reset player top

            carLeft = false; // reset the moving left to false
            carRight = false; // reset the moving right to false



            carl.Left = 66;
            carl.Top = -120;

            car2.Left = 294;
            car2.Top = -185;

        
            roadTrack2.Left = -3;
            roadTrack2.Top = -222;
            roadTrack1.Left = -2;
            roadTrack1.Top = -638;

          
            gametimer.Start();


        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
           
            Score++; 
            
            distance.Text = "" + Score; 
            coinscollection();
            roadTrack1.Top += roadSpeed;  
            roadTrack2.Top += roadSpeed; 
            coin1.Visible =true;
            coin2.Visible = true;
            coin3.Visible = true;
            coin4.Visible = true;
            coin5.Visible = true;
           
            if (roadTrack1.Top > 630)
            {
                roadTrack1.Top = -630;
            }
            if (roadTrack2.Top > 630)
            {
                roadTrack2.Top = -630;
            }
            

            
            
            


            
            carl.Top += trafficSpeed;
            car2.Top += trafficSpeed;
            coin1.Top += roadSpeed;
            coin2.Top += roadSpeed;
            coin3.Top += roadSpeed;
            coin4.Top += roadSpeed;
            coin5.Top += roadSpeed;

            
            if (carl.Top > panel1.Height)
            {
                changecarl();
                carl.Left = rnd.Next(2, 160); 
                carl.Top = rnd.Next(100, 200) * -1; 
            }

            if (coin1.Top > panel1.Height)
            {
                 
                coin1.Left = rnd.Next(10, 160); 
                coin1.Top = rnd.Next(100, 200) * -1; 
            }

            if (coin2.Top > panel1.Height)
            {
    
                coin2.Left = rnd.Next(50, 100); 
                coin2.Top = rnd.Next(100, 200) * -1; 
            }

            if (coin3.Top > panel1.Height)
            {
                
                coin3.Left = rnd.Next(327, 377); 
                coin3.Top = rnd.Next(200, 200) * -1; 
            }

            if (coin4.Top > panel1.Height)
            {
                
                coin4.Left = rnd.Next(200, 250); 
                coin4.Top = rnd.Next(200, 200) * -1; 
            }

            if (coin5.Top > panel1.Height)
            {
                
                coin5.Left = rnd.Next(327, 377); 
                coin5.Top = rnd.Next(170, 200) * -1; 
            }
            
            if (car2.Top > panel1.Height)
            {
                changecar2(); 
                car2.Left = rnd.Next(185, 327); 
                car2.Top = rnd.Next(100, 200) * -1; 
            }

            if (coin1.Bounds.IntersectsWith(coin2.Bounds))
            {
                coin1.Left = rnd.Next(10, 160);
                coin1.Top = rnd.Next(100, 200) * -1;
            }

            if (coin3.Bounds.IntersectsWith(coin5.Bounds))
            {
                coin3.Left = rnd.Next(327, 377);
                coin3.Top = rnd.Next(200, 200) * -1;
            }
            
            if (carl.Bounds.IntersectsWith(coin1.Bounds))
            {
                coin1.Left = rnd.Next(10, 160);
                coin1.Top = rnd.Next(100, 200) * -1;
            }
             if (carl.Bounds.IntersectsWith(coin2.Bounds))
             {
                coin2.Left = rnd.Next(50, 100); 
                coin2.Top = rnd.Next(100, 200) * -1;
             }
                       
             if (car2.Bounds.IntersectsWith(coin3.Bounds))
             {
                coin3.Left = rnd.Next(300, 350); 
                coin3.Top = rnd.Next(200, 200) * -1;
             }
             if (car2.Bounds.IntersectsWith(coin4.Bounds))
             {
                coin4.Left = rnd.Next(200, 250); 
                coin4.Top = rnd.Next(200, 200) * -1;
             }
            if (player.Bounds.IntersectsWith(carl.Bounds) || player.Bounds.IntersectsWith(car2.Bounds))
            {
                gameOver();
                l1.Play();
            }
            if (Score > 100 && Score < 500)
            {
                trafficSpeed = 5;
                roadSpeed = 7;
                carSpeed = 5;
            }
            
            else if (Score > 500 && Score < 1000)
            {
                trafficSpeed = 6;
                roadSpeed = 9;
                carSpeed = 6;
            }
            
            else if (Score > 1200)
            {
                trafficSpeed = 7;
                roadSpeed = 11;
                carSpeed = 7;
            }
            


        }

        void coinscollection()
        {
            if (player.Bounds.IntersectsWith(coin1.Bounds))
            {
                collectedcoins++;
                label5.Text = collectedcoins.ToString();
                coin1.Left = rnd.Next(2, 160); 
                coin1.Top = rnd.Next(100, 200) * -1;

            }
            if (player.Bounds.IntersectsWith(coin2.Bounds))
            {
                collectedcoins++;
                label5.Text = collectedcoins.ToString();
                coin2.Left = rnd.Next(50, 80); 
                coin2.Top = rnd.Next(100, 200) * -1;

            }
            if (player.Bounds.IntersectsWith(coin3.Bounds))
            {
                collectedcoins++;
                label5.Text = collectedcoins.ToString();
                coin3.Left = rnd.Next( 300, 350); 
                coin3.Top = rnd.Next(200, 200) * -1;
            }
            if (player.Bounds.IntersectsWith(coin4.Bounds))
            {
                collectedcoins++;
                label5.Text = collectedcoins.ToString();
                coin4.Left = rnd.Next(200, 250); 
                coin4.Top = rnd.Next(200, 200) * -1;

            }
            if (player.Bounds.IntersectsWith(coin5.Bounds))
            {
                collectedcoins++;
                label5.Text = collectedcoins.ToString();
                coin5.Left = rnd.Next(100, 150); 
                coin5.Top = rnd.Next(170, 200) * -1;
            }
        }
        private void changecarl()
        {
            int num = rnd.Next(1, 8); 
            
            
            switch (num)
            {
                
                case 1:
                    carl.Image = Properties.Resources.carGreen;
                    break;
                
                case 2:
                    carl.Image = Properties.Resources.TruckBlue;
                    break;
                
                case 3:
                    carl.Image = Properties.Resources.ambulance;
                    break;
                
                case 4:
                    carl.Image = Properties.Resources.carPink;
                    break;
                
                case 5:
                    carl.Image = Properties.Resources.carYellow;
                    break;
                
                case 6:
                    carl.Image = Properties.Resources.TruckBlue;
                    break;
                
                case 7:
                    carl.Image = Properties.Resources.TruckWhite;
                    break;
                
                
                case 8:
                    carl.Image = Properties.Resources.ambulance;
                    break;
                default:
                    break;
            }
        }
        private void changecar2()
        {
            int num = rnd.Next(1, 8); 
            
            
            switch (num)
            {
                
                case 1:
                    car2.Image = Properties.Resources.carGreen;
                    break;
                
                case 2:
                    car2.Image = Properties.Resources.carPink;
                    break;
                
                case 3:
                    car2.Image = Properties.Resources.TruckBlue;
                    break;
                
                case 4:
                    car2.Image = Properties.Resources.carPink;
                    break;
                
                case 5:
                    car2.Image = Properties.Resources.carGreen;
                    break;
                
                case 6:
                    car2.Image = Properties.Resources.TruckBlue;
                    break;
                
                case 7:
                    car2.Image = Properties.Resources.TruckWhite;
                    break;
                
                case 8:
                    car2.Image = Properties.Resources.ambulance;
                    break;
                default:
                    break;
            }
        }
        private void gameOver()
        {
            p1.PlayLooping();
            this.Size = new Size(1200, 650);
            trophy.Visible = true; 

            gametimer.Stop(); 

            button1.Enabled = true; 

            button2.Enabled = true;

            button1.Visible = true;
            button1.Text = "Play Again";
            button2.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            label2.Visible = true;


            
            explosion.Visible = true; 
            player.Controls.Add(explosion); 
            explosion.Location = new Point(-8, 5); 
            explosion.BackColor = Color.Transparent; 
            explosion.BringToFront();

            

           
            if (Score < 1000)
            {
                trophy.Image = Properties.Resources.bronze;

            }
            
            if (Score >= 1000)
            {
                trophy.Image = Properties.Resources.silver;
            }

            
            if (Score >= 2000)
            {
                trophy.Image = Properties.Resources.gold;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Reset();
            l2.PlayLooping();
        }
        

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Show();
            this.Hide();
            
        }

        private void roadTrack2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false;
            this.Size = new Size(1200, 650);
            label1.Visible = false;
            distance.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            roadTrack2.Visible = false;
            trophy.Visible = false;
            car2.Visible = false;
            carl.Visible = false;
            player.Visible = false;
            explosion.Visible = false;
            coin1.Visible = false;
            coin2.Visible = false;
            coin3.Visible = false;
            coin4.Visible = false;
            coin5.Visible = false;
            panel6.Visible = false;
                        
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trophy_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

            
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            player.Image = pictureBox1.Image;
            player.BackColor = Color.Transparent;
            player.Size = new Size(50, 99);
            player.Location = new Point(211,413);
            player.Visible = true;
            explosion.Visible = false;
            trophy.Visible = false;
            car2.Visible = false;
            carl.Visible = false;
            coin1.Visible = false;
            coin2.Visible = false;
            coin3.Visible = false;
            coin4.Visible = false;
            coin5.Visible = false;
            roadTrack2.Location = new Point(0, 0);
            roadTrack1.Location = new Point(0, -519);
            distance.Text = "00" ;
            label5.Text = "00";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            player.Image = pictureBox2.Image;
            player.BackColor = Color.Transparent;
            player.Size = new Size(50, 99);
            player.Location = new Point(211, 413);
            player.Visible = true;
            explosion.Visible = false;
            trophy.Visible = false;
            car2.Visible = false;
            carl.Visible = false;
            coin1.Visible = false;
            coin2.Visible = false;
            coin3.Visible = false;
            coin4.Visible = false;
            coin5.Visible = false;
            roadTrack2.Location = new Point(0, 0);
            roadTrack1.Location = new Point(0, -519);
            distance.Text = "00";
            label5.Text = "00";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            player.Image = pictureBox3.Image;
            player.BackColor = Color.Transparent;
            player.Size = new Size(50, 99);
            player.Location = new Point(211, 413);
            player.Visible = true;
            explosion.Visible = false;
            trophy.Visible = false;
            car2.Visible = false;
            carl.Visible = false;
            coin1.Visible = false;
            coin2.Visible = false;
            coin3.Visible = false;
            coin4.Visible = false;
            coin5.Visible = false;
            roadTrack2.Location = new Point(0, 0);
            roadTrack1.Location = new Point(0, -519);
            distance.Text = "00";
            label5.Text = "00";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            player.Image = pictureBox4.Image;
            player.BackColor = Color.Transparent;
            player.Size = new Size(50, 99);
            player.Location = new Point(211, 413);
            player.Visible = true;
            explosion.Visible = false;
            trophy.Visible = false;
            car2.Visible = false;
            carl.Visible = false;
            coin1.Visible = false;
            coin2.Visible = false;
            coin3.Visible = false;
            coin4.Visible = false;
            coin5.Visible = false;
            roadTrack2.Location = new Point(0, 0);
            roadTrack1.Location = new Point(0, -519);
            distance.Text = "00";
            label5.Text = "00";
        }

        

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            roadTrack2.Visible = true;
            roadTrack1.Image = pictureBox5.Image;
            roadTrack2.Image = pictureBox5.Image;
            explosion.Visible = false;
            trophy.Visible = false;
            car2.Visible = false;
            carl.Visible = false;
            coin1.Visible = false;
            coin2.Visible = false;
            coin3.Visible = false;
            coin4.Visible = false;
            coin5.Visible = false;
            roadTrack2.Location = new Point(0, 0);
            roadTrack1.Location = new Point(0, -519);
            distance.Text = "00";
            label5.Text = "00";
        }
        

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            roadTrack2.Visible = true;
            roadTrack1.Image = pictureBox6.Image;
            roadTrack2.Image = pictureBox6.Image;
            explosion.Visible = false;
            trophy.Visible = false;
            car2.Visible = false;
            carl.Visible = false;
            coin1.Visible = false;
            coin2.Visible = false;
            coin3.Visible = false;
            coin4.Visible = false;
            coin5.Visible = false;
            roadTrack2.Location = new Point(0, 0);
            roadTrack1.Location = new Point(0, -519);
            distance.Text = "00";
            label5.Text = "00";
        
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void coin5_Click(object sender, EventArgs e)
        {

        }

       
    }
}



