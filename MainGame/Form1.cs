using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MainGame
{
    public class CSora
    {
        public Bitmap im;
    }
    public class CGE// GREEN ENEMY
    {
        public int X, Y;
        public Bitmap []im;
        public Bitmap img;
        public int xDir = 0;
        public int yDir = 0;
    }
    public class CActor
    {
        public int X, Y;
        public Bitmap im;
        public int xDir = 0;
        public int yDir = 0;
        public int W;
        public int H;
    }
    public class CActor2
    {
        public int X, Y;
        public Bitmap im;
        public int xDir = 0;
        public int yDir = 0;
    }

    public class CHeart
    {
        public int X, Y;
        public Bitmap im;
        public int W = 150;
        public int H = 20;
    }
    public class CHero
    {

        public int X, Y;
        public int yDir;
        public int xDir;
        public Bitmap im;
        public int s;
        public int H;
        public int W;
    
    }
    public partial class Form1 : Form
    {
        bool flagpen = false;
        CActor w;
        CActor l;
        string line = "";
        int flagame = 0;
        Bitmap firing;
        Bitmap die;
        Bitmap tile;
        Bitmap la;
        Bitmap slide;
        bool flaglol = false;
        bool flaglol2 = false;
        /*Backgrounds*/
        Bitmap off;
        Bitmap a1;
        Bitmap a2;
        Bitmap a3;
        Bitmap a4;
        Bitmap b1;
        Bitmap b2;
        Bitmap b3;
        Bitmap b4;
        Bitmap c;
        Bitmap co;
        /* Scroll and credit*/
        int credit = 2;
        int XScroll = 0;
        /*Health + score*/
        List<CHeart> H = new List<CHeart>();
        int health = 19;
        int score = 0;
        int highscore = 0;

        /*Hero and status*/
        CHero Hero;
        Bitmap idle;
        List<CSora> Idle = new List<CSora>();
        List<CSora> MovingR = new List<CSora>();
        List<CSora> MovingL = new List<CSora>();
        List<CSora> Jump = new List<CSora>();
        List<CSora> Gravity = new List<CSora>();
        int rc= 0;
        int lc = 0;
        int ic = 0;
        int jc = 0;
        int gc = 0;
        bool flagright = false;
        bool flagleft = false;
        bool flagjump = false;
        bool flagravity = false;
        bool flagladder = false;
        bool flagclimb = false;
        bool flagis = false;
        int cs = 0;

        /* Rocks*/
        List<CHeart> R = new List<CHeart>();
        /* star*/
        List<CSora> ss = new List<CSora>();
        List<CHeart> Sc = new List<CHeart>();
        int sc = 0;
        /* hero bullt*/
        List<CActor> Bullt = new List<CActor>();

        /*Grenn enemy bult and drawing*/
        List<CGE> Ge = new List<CGE>();
        int gehit = 0; 

        /* andgles enemy*/
        List<CSora> As = new List<CSora>();
        List<CActor2> Angles = new List<CActor2>();
        List<CActor2> AnglesFire = new List<CActor2>();
        int ac = 0;


        /* falling objeects*/
        List<CGE> Fall = new List<CGE>();


        /* ladder and fire area*/
        CHero ladder;
        List<CSora> Ls = new List<CSora>();
        int cc = 0;
        List<CSora> Peng = new List<CSora>();
        List<CActor> BF = new List<CActor>();
        List<CActor> BF2 = new List<CActor>();
        bool flagother = false;
        bool flagother2 = false;
        bool flagother3 = false;
        bool flagother4 = false;
        bool flagother5 = false;
        int flagzft = 1;


        /*LAST LVL FIRE*/
        List<CActor> Rocket = new List<CActor>();

        CGE Pig;

        List<CActor> PF = new List<CActor>();
        int pigcount;
      


        /* Laser*/
        int laserflag = 0;
        CGE box;
        CActor grass;
        /* boos fight*/
        CHero plane;

        /* sliding*/
        bool flagslide = false;


        CActor p1, p2;
        int p1count;
        int p2count;


        bool flagplay = true;
        int countick = 0;
        Timer t = new Timer();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\intro.wav");
        System.Media.SoundPlayer player2 = new System.Media.SoundPlayer(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\gamesound.wav");
        System.Media.SoundPlayer player3 = new System.Media.SoundPlayer(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\1.wav");
        System.Media.SoundPlayer player4 = new System.Media.SoundPlayer(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\0.wav");  
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1600, 650);
            StartPosition = FormStartPosition.CenterScreen;
            //this.WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
            t.Tick += t_Tick;
            t.Start();

            t.Interval = 50; 


        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Hero.s = 1;
          //  flagjump = true;
            if (flagright == true)
            {
                flagright = false;
                flagjump = false;
                flagravity = false;
            }
            if (flagleft == true)
            {
                flagleft = false;
                flagjump = false;
                flagravity = false;
            }
            if (flagjump == true)
            {
                flagleft = false;
                flagright = false;
                flagravity = false;
            
            }
            if (flagslide == true)
            {
                flagleft = false;
                flagjump = false;
                flagravity = false;
                flagright = false;
                Hero.s = 0;
            }

            
            DrawDubb(this.CreateGraphics());
        }

        void t_Tick(object sender, EventArgs e)
        {
           //this.Text = " Count" + XScroll;
            if (flagis == true)
            {
                if (cs != 610)
                {
                    Hero.X += 80;
                    flagis = false;
                    cs += 10;
                }
    
            }
            if (p1count == 10)
            {
                p1count = 0;
            }
            if (p2count == 10)
            {
                p2count = 0;
            }
            // Hero status are like the following:   1-> idle  ,   2->movingright,   3->movingleft   ,4->jumping,  5-> gravity, 6-> climbing
            if (sc == 8)
            {
                sc = 0;
            }
            if (cc == 6)
            {
                cc = 0;
            }
            if (ac == 10)
            {
                ac = 0;
            }
            if (ic == 10)
            {
                ic = 0;
            }
            if (rc == 26)
            {
                rc = 0;
            }
            if (lc == 10)
            {
                lc = 0;
            }
            if (jc == 9)
            {
                jc = 0;
                flagjump = false;
                Hero.s = 1;
                flagravity = true;
                gc = 0;
            }
            if (gc == 6)
            {
                gc = 0;
            }
            if (Hero.Y+ 30 >= 520)
            {
                flagravity = false;
                //Hero.s = 1;
            }

            if (Hero.s == 1)
            {
                Hero.im = Idle[ic].im;
            }
            if (Hero.s == 2)
            { 
                Hero.im = MovingR[rc].im;
            }
            if (Hero.s == 3)
            {
                Hero.im = MovingL[lc].im;
            }
            if (flagjump == true)
            {
                Hero.s = 4;
                Hero.Y -= 20;
                Hero.X += 20;
                Hero.im = Jump[jc].im;
            }
            if (flagravity == true)
            {
                Hero.s = 5;
                Hero.Y += 25 ;
                Hero.im = Gravity[gc].im;
            }
            /* tick movement*/
            if (countick % 2 == 0 && Hero.s == 1)
            {
                ic++;
            }
            if (Hero.s == 2)
            {
                rc +=2;
            }
            if (Hero.s == 3)
            {
                lc +=2 ;
            }
            if (Hero.s == 4)
            {
                jc++;
            }
            if (Hero.s == 5)
            {
                gc++;
            }
            if (flagright == true)
            {
                if (XScroll != -3210 && XScroll > -4800)
                {
                  
                    XScroll -= 30;
                    Hero.X += 30;
                }
                else
                {
                    Hero.X += 20;

                }
                if (XScroll > -2010 && XScroll < -1050)
                {
                    XScroll -= 25;
                    Hero.X += 35;
                }
            }
   
            if (flagleft == true)
            {


                if (XScroll != -3200 && XScroll < -6400)
                {
                    XScroll += 30;
                    Hero.X -= 30;
                }
                else
                {

                    Hero.X -= 20;

                }

            }
            // end of hero status

            // check if ther is rock or no

            for (int i = 0; i < R.Count; i++)
            {
                CHeart pnn = R[i];
                if (isHit(Hero.X, Hero.Y + Hero.H + 10, pnn))
                {
                    flagravity = false;
                    Hero.s = 1;
                }



            }
            /* bullt count*/
            for (int i = 0; i < Bullt.Count; i++)
            {
                CActor ptrav = Bullt[i];
                ptrav.X += ptrav.xDir;
                if (ptrav.X> 3210)
                {
                    Bullt.RemoveAt(i);
                }
            }
            /* rocket fires
             */
            for (int i = 0; i < Rocket.Count; i++)
            {
                CActor ptrav = Rocket[i];
                ptrav.Y += ptrav.yDir;
                if (ptrav.Y > this.ClientSize.Height)
                {
                    Rocket.RemoveAt(i);
                }
            }
            /* angles*/


            for (int k = 0; k < Angles.Count; k++)
            {
                CActor2 pnn = Angles[k];
                pnn.im = As[ac].im;              
                    for (int i = 0; i < Bullt.Count; i++)
                    {
                        CActor ptrav = Bullt[i];
                        if (isHit3(ptrav.X, ptrav.Y, pnn))
                        {
                            Angles.RemoveAt(k);
                            Bullt.RemoveAt(i);
                            score++;
                        }

                    }
            }
            for (int q = 0; q < AnglesFire.Count; q++)
            {
                CActor2 pnn = AnglesFire[q];
           
                if (Hero.Y <= pnn.Y)
                {
                    pnn.yDir = 1;
                }
                if (pnn.yDir == 1)
                { pnn.X += pnn.xDir; }

                for (int i = 0; i < Bullt.Count; i++)
                {
                    CActor ptrav = Bullt[i];
                    if (isHit3(ptrav.X, ptrav.Y, pnn))
                    {
                        AnglesFire.RemoveAt(q);
                        Bullt.RemoveAt(i);
                    }

                }
                if (isHit3(Hero.X, Hero.Y, pnn))
                {
                    if (health > -1)
                    {
                        H.RemoveAt(health);
                        health--;
                    }
                    Hero.im = die;
                    Hero.s = 0;
             
                }

            }

            if (Angles.Count == 0)
            { 
                /* green enemy*/
                for (int k = 0; k < Ge.Count; k++)
                {
                    CGE ptrav2 = Ge[k];

                    if (gehit == 0)
                    {
                        ptrav2.img = ptrav2.im[0];
                    }
                    if (gehit == 1)
                    {
                        ptrav2.img = ptrav2.im[1];
                    }

                    if (ptrav2.X<= Hero.X+50 && ptrav2.X>= Hero.X)
                    {
                        if (health > -1)
                        {
                            H.RemoveAt(health);
                            health--;
                        }
                    
                        Hero.im = die;
                        Hero.s = 0;
                   
                    }
                    ptrav2.X += ptrav2.xDir;
                    for (int i = 0; i < Bullt.Count; i++)
                    {
                        CActor ptrav = Bullt[i];
                
                        if (isHit2(ptrav.X+ptrav.im.Width, ptrav.Y, ptrav2))
                        {
                            ptrav2.img = ptrav2.im[2];
                            score++;
                            Ge.RemoveAt(k);
                            Bullt.RemoveAt(i);
                        }

                    }


                }
            }
            if (XScroll > -2010 && XScroll < -1050)
            {
                for (int i = 0; i < Fall.Count; i++)
                { 
                    CGE ptrav = Fall[i];

                    if (ptrav.Y > 1200)
                    {
                        Fall.RemoveAt(i);
                    } 
                    
                    if (ptrav.X < Hero.X)
                    { ptrav.xDir = 1; }
                    if (ptrav.xDir == 1)
                    { 
                        ptrav.Y -= ptrav.yDir;
                    }
                    if (isHit2(Hero.X, Hero.Y, ptrav))
                    {
                        if (health > -1)
                        {
                            H.RemoveAt(health);
                            health--;
                        }
                    }
                    
                }
            }

            /* Ladder */
            if (XScroll > -3600 && XScroll < 2050)
            {
                if (isHit4(Hero.X, Hero.Y, ladder))
                {
                    flagladder = true;
                }
                else
                {
                    flagladder = false;
                  
                }
         
            }

            if (flagclimb == true)
            {
                Hero.im = Ls[cc].im;
                if (Hero.Y > 280)
                {
                    Hero.Y -= 10;
                }
                else
                {
                    flagclimb = false;
                }
                
            }

            if (XScroll >= -4235 && flaglol2 == true && plane.X + XScroll <= 10)
            {
                plane.X += 10;
            }
            else
            {
                if (XScroll <= -4235)
                {
                    flagclimb = false;
                    flagjump = false;
                    flagslide = false;
                   
                    Hero.im = die;
                   plane.X = Hero.X - 230 ;
                }
            }





            if (flaglol == true)
            {
                if (box.Y < 480)
                {
                    box.Y += 10;
                    XScroll = -3815;
                }
                else
                {
                    flaglol2 = true;
                   
                }
            }
            if (flaglol2 == true)
            {
                if(XScroll > -4235)
                {
                    Hero.X+=20;
                    Hero.Y-=20;
                    XScroll -= 20;
                    grass.X += grass.xDir;
                    grass.Y += grass.yDir;
                }
             
            }

            /*PIGGGG*/
            if (XScroll <= -4700)
            {
                if (pigcount != 5)
                {
                    if (Pig.X > Hero.X)
                    {
                        Pig.X -= 5;
                        Pig.img = Pig.im[0];
                    }
                    if (Pig.X < Hero.X)
                    {
                        Pig.X += 5;
                        Pig.img = Pig.im[1];
                    }
                    for (int i = 0; i < Rocket.Count; i++)
                    {
                        CActor lol = Rocket[i];
                        if (isHitP(lol.X, lol.Y + 128, Pig))
                        {

                            pigcount++;
                            score += 1;

                        }
                    }
                    if (countick % 25 == 0)
                    {
                        if (XScroll <= -4700)
                        {
                            player3.Play();
                            CActor pr;
                            pr = new CActor();
                            pr.im = new Bitmap("r.png");
                            pr.W = 50;
                            pr.H = 50;
                            pr.X = Pig.X + 64;
                            pr.Y = Pig.Y;
                            PF.Add(pr);
                        }
                    }
                    if (XScroll <= -4700)
                    {
                        for (int i = 0; i < PF.Count; i++)
                        {
                            CActor pr = PF[i];
                            if (pr.X > Hero.X)
                            {
                                pr.xDir = -12;
                            }
                            else
                            {
                                pr.xDir = 12;
                            }
                            if (pr.Y > Hero.Y)
                            {
                                pr.yDir = -12;
                            }
                            if (isHit0(Hero.X, Hero.Y + Hero.H, pr))
                            {
                                PF.RemoveAt(i);
                                if (health > -1)
                                {
                                    H.RemoveAt(health);
                                    health--;
                                }
                            }
                            pr.X += pr.xDir;
                            pr.Y += pr.yDir;
                        }
                    }

                }
                else
                {
                    Pig.img = new Bitmap ("p3.bmp");
                    Pig.img.MakeTransparent(Color.White);
                }
               
            }



              /* ladder and tile*/
            if (XScroll > -3660 && XScroll < 2050)
            {
                
                if (flagother5 == false)
                {
                    if (BF[0].Y > 350)
                    {
                        if (flagother == false)
                        { BF[0].yDir = -10; }

                    }
                    else
                    {
                        flagother = true;

                        BF[0].yDir = 10;
                    }
                    if (BF[0].Y + BF[0].H > this.ClientSize.Height-10)
                    {
                        flagother = false;
                        flagother5 = true;
                    }




                    if (BF[1].Y + BF[1].H < 350)
                    {
                        if (flagother2 == false)
                        {
                            BF[1].yDir = 10;
                        }
                    }
                    else
                    {
                        flagother2 = true;
                        BF[1].yDir = -10;
                    }

                    if (BF[1].Y == 90)
                    {
                        flagother2 = false;
                    }


                    if (isHit0(Hero.X, Hero.Y+100, BF[0]))
                    {
                        if (health > -1)
                        {
                            H.RemoveAt(health);
                            health--;
                        }
                    }
                    if (isHit0(Hero.X, Hero.Y - 100, BF[1]))
                    {
                        if (health > -1)
                        {
                            H.RemoveAt(health);
                            health--;
                        }
                    }

                    BF[0].Y += BF[0].yDir;
                    BF[1].Y += BF[1].yDir;

                }
                
                ///////////////////////////////////////////////////////////////////
                if (flagother5== true)
                {
                    if (BF2[1].Y > 350)
                    {
                        if (flagother3 == false)
                        { BF2[1].yDir = -10; }

                    }
                    else
                    {
                        flagother3 = true;

                        BF2[1].yDir = 10;
                    }
                    if (BF2[1].Y + BF2[1].H > this.ClientSize.Height-10)
                    {
                        flagother3 = false;
                        flagother5 = false;
                    }




                    if (BF2[0].Y + BF2[0].H < 350)
                    {
                        if (flagother4 == false)
                        {
                            BF2[0].yDir = 10;
                        }
                    }
                    else
                    {
                        flagother4 = true;
                        BF2[0].yDir = -10;
                    }

                    if (BF2[0].Y == 90)
                    {
                        flagother4 = false;
                    }

                    BF2[0].Y += BF2[0].yDir;
                    BF2[1].Y += BF2[1].yDir;
                }


            }

            if (flagzft == 1)
            { 
                if (Hero.X + XScroll >= 3500+XScroll)
                {
                    //Doctor
                   // XScroll -= 1300;
                    flagzft = 0;
                }
            }

            /* score stars*/
            for (int i = 0; i < Sc.Count; i++)
            {
                CHeart ptrav = Sc[i];
                ptrav.im = ss[sc].im;
                if(isHit(Hero.X+Hero.W/2,Hero.Y+Hero.H/2,ptrav))
                {
                    Sc.RemoveAt(i);
                    score++;
                }

            
            }
            if (countick % 3 == 0)
            {
                gehit = 0;
            }
            if (countick % 6 == 0)
            {
                gehit = 1;
            }

            if (health == -1)
            {
               // this.Close();
                flagame = 2;
            }

            p1.im = Peng[p1count].im;
            p2.im = Peng[p2count].im;


            p1count++;
            p2count++;
            cc++;
            ac++;
            sc++;
            countick++;
            DrawDubb(this.CreateGraphics());
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            score++;
            //Angles.Clear();

        }
        bool isHitP(int X, int Y, CGE ptrav)
        {
            if (X > ptrav.X
                && X < ptrav.X +100
                && Y > ptrav.Y
                && Y < ptrav.Y +115
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        bool isHit0(int X, int Y, CActor ptrav)
        {
            if (X > ptrav.X
                && X < ptrav.X + ptrav.W
                && Y > ptrav.Y
                && Y < ptrav.Y + ptrav.H
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        bool isHit(int X, int Y, CHeart ptrav)
        {
            if (X > ptrav.X
                && X < ptrav.X + ptrav.W
                && Y > ptrav.Y
                && Y < ptrav.Y + ptrav.H
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        bool isHit2(int X, int Y, CGE ptrav2)
        {
            if (X > ptrav2.X
                && X < ptrav2.X + ptrav2.img.Width
                && Y > ptrav2.Y
                && Y < ptrav2.Y + ptrav2.img.Height
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        bool isHit3(int X, int Y, CActor2 ptrav2)
        {
            if (X > ptrav2.X
                && X < ptrav2.X + ptrav2.im.Width
                && Y > ptrav2.Y
                && Y < ptrav2.Y + ptrav2.im.Height
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool isHit4(int X, int Y, CHero ptrav2)
        {
            if (X > ptrav2.X
                && X < ptrav2.X + ptrav2.W
                && Y > ptrav2.Y
                && Y < ptrav2.Y + ptrav2.H
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
         
          

            if (e.KeyCode == Keys.NumPad1)
            { 
            
                XScroll-= 30;
            }
            if (e.KeyCode == Keys.NumPad2)
            {

                XScroll += 30;
            }
            if (e.KeyCode == Keys.M)
            {
                if (flagladder == true)
                {
                    flagclimb = true;
                    flagright = false;
                    flagleft = false;
                    flagjump = false;
                    flagravity = false;
                    Hero.s = 6;
                }
            }
            if (e.KeyCode == Keys.L)
            { 
                laserflag = 1;
                flaglol = true;
                Hero.im = la;
                Hero.s = 0;
            
            }
            if (e.KeyCode == Keys.S)
            {
                Hero.s = 0;
                Hero.im = slide;
                flagclimb = false;
                flagright = false;
                flagleft = false;
                flagjump = false;
                flagravity = false;
                flagis = true;

               // XScroll -= 610;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (flagjump == false && flagravity == false && XScroll > -2300)
                {
                            Hero.s = 2;
                            flagright = true;
                            flagclimb = false;
                            flagleft = false;
                            flagjump = false;
                            flagravity = false;
                }
                else if (XScroll > -3000 && XScroll < 2050)
                {
               
                    if (Hero.Y <= 345)
                    {
                        Hero.s = 2;
                        flagright = true;
                        flagclimb = false;
                        flagleft = false;
                        flagjump = false;
                        flagravity = false;
                    }
          
                    
                }
                if (XScroll <-3000)
                {
                    Hero.s = 2;
                    flagright = true;
                    flagclimb = false;
                    flagleft = false;
                    flagjump = false;
                    flagravity = false;

                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (flagjump == false && flagravity == false)
                { 
                    Hero.s = 3;
                    flagleft = true;
                    flagright = false;
                    flagjump = false;
                    flagclimb = false;
                    flagravity = false;
                }

            }
            if (e.KeyCode == Keys.Down)
            {
                Hero.Y += 5;
            }
            if (e.KeyCode == Keys.Up)
            {
                Hero.Y -= 5;
            }
            if (e.KeyCode == Keys.Space)
            {

                Hero.s = 4;
                flagjump = true;
                flagclimb = false;
                flagleft = false;
                flagright = false;
                flagravity = false;

            }
            if (e.KeyCode == Keys.F)
            {
                CActor pnn = new CActor();
                pnn.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\fire.png");
                pnn.im.MakeTransparent(Color.White);
                pnn.X = Hero.X + Hero.W / 2;
                pnn.Y = Hero.Y + 10;
                pnn.xDir = 35;
                Bullt.Add(pnn);
                Hero.im = firing;
                Hero.s = 0;
            }
            if (e.KeyCode == Keys.G)
            {
                CActor pnn = new CActor();
                pnn.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\last\rocket\0.png");
                pnn.im.MakeTransparent(Color.White);
                pnn.X = Hero.X;
                pnn.Y = Hero.Y + 1;
                pnn.yDir = 20;
                Rocket.Add(pnn);
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                flagame = 1;
            }
            if(e.KeyCode == Keys.NumPad8)
            {
                flagame = 2;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            w = new CActor();
            w.im = new Bitmap("w.png");
            w.im.MakeTransparent(Color.White);
            l = new CActor();
            l.im = new Bitmap("l.png");
            l.im.MakeTransparent(Color.White);


            firing = new Bitmap("hf.png");
            firing.MakeTransparent(Color.White);
            la = new Bitmap("3.bmp");
            la.MakeTransparent(Color.White);
            /* read from file*/
             StreamReader st = new StreamReader("file.txt");
             while (st.EndOfStream == false)
             {
                line = st.ReadLine();
                int parsedInt = 0;
                if (int.TryParse(line, out parsedInt))
                {
                     highscore = parsedInt;
                }
        
          
             }
             tile = new Bitmap("t.png");

             die = new Bitmap("2.bmp");
             die.MakeTransparent(Color.White);
             Console.WriteLine("{0}\n", line);
             st.Close();

            a1 = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Backgrounds\back1.png");
            a2 = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Backgrounds\back2.png");
            a3 = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Backgrounds\back1.png");
            a4 = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Backgrounds\back2.png");
            b1 = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Backgrounds\ground.png");
            b2 = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Backgrounds\ground.png");
            b3 = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Backgrounds\ground.png");
            b4 = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Backgrounds\ground.png");
            c = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Backgrounds\1.png");
            co = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Backgrounds\2.png");

            /*heart*/
            int s = 0;
            for (int i = 0; i < 20; i++)
            {
                CHeart pnn = new CHeart();
                pnn.im = new Bitmap("heart.png");
                Color cl = pnn.im.GetPixel(0, 0);
                pnn.im.MakeTransparent(cl);
                pnn.X = 60 + s;
                pnn.Y = 15;
                H.Add(pnn);
                s += 20;
            }

            /*hero*/

            idle = new Bitmap("1.bmp");
            idle.MakeTransparent(Color.White);
            Hero = new CHero();
            Hero.X = 30;
            Hero.Y = 480;
            Hero.W = 50;
            Hero.H = 85;
            Hero.im = idle;


            /* moving right imgs*/
            for (int i =2; i < 29; i++)
            {

                CSora ptrav = new CSora();
                ptrav.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\hero\runright\" + i + ".bmp");
                Color cl2 = ptrav.im.GetPixel(0, 0);
                ptrav.im.MakeTransparent(cl2);
                MovingR.Add(ptrav);
            }

            /*moving left imgs*/
            for (int i = 1; i < 12; i++)
            {
                CSora ptrav = new CSora();
                ptrav.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\hero\runleft\" + i + ".bmp");
                Color cl2 = ptrav.im.GetPixel(0, 0);
                ptrav.im.MakeTransparent(cl2);
                MovingL.Add(ptrav);
            
            }
            /*idle stand*/
            for (int i = 0; i < 10; i++)
            {


                CSora ptrav = new CSora();
                ptrav.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\hero\idle\" + i + ".bmp");
                Color cl2 = ptrav.im.GetPixel(0, 0);
                ptrav.im.MakeTransparent(cl2);
                Idle.Add(ptrav);
            
            }

            /*jump right*/

            for (int i = 0; i < 9; i++)
            {

                CSora ptrav = new CSora();
                ptrav.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\hero\jump\" + i + ".bmp");
                Color cl2 = ptrav.im.GetPixel(0, 0);
                ptrav.im.MakeTransparent(cl2);
                Jump.Add(ptrav);
            
            }
            /* gravity*/

            for (int i = 0; i < 6; i++)
            {


                CSora ptrav = new CSora();
                ptrav.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\hero\gravity\" + i + ".bmp");
                Color cl2 = ptrav.im.GetPixel(0, 0);
                ptrav.im.MakeTransparent(cl2);
                Gravity.Add(ptrav);
            
                
            }


            /*Rocks*/
            int sp = 0;
            int sp2 = 0;

            for (int i = 0; i < 4; i++)
            {

                CHeart ptrav = new CHeart();
                ptrav.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\lol1.png");
                if (i == 3)
                {
                    ptrav.W = 200;
                    ptrav.H = 40;
                }
                else
                {
                    ptrav.W = 150;
                    ptrav.H = 40;
                }
                ptrav.X = 180+sp;
                ptrav.Y = 500+sp2;

                R.Add(ptrav);
                sp += 150;
                sp2 -= 100;
            }

            /*Stars score*/
            for (int i = 0; i < 8; i++)
            {

                CSora ptrav = new CSora();
                ptrav.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\score\"+i+".png");
                Color cl2 = ptrav.im.GetPixel(0, 0);
                ptrav.im.MakeTransparent(Color.Blue);
                ss.Add(ptrav);
            
            }
            /* stars location*/
            sp = 0;
            sp2 = 0;
            for (int i = 0; i < 3; i++)
            {
                CHeart ptrav = new CHeart();
                ptrav.im = ss[0].im;
                ptrav.X = 230 + sp;
                ptrav.Y = 450 + sp2;
                Sc.Add(ptrav);
                sp += 150;
                sp2 -= 100;
            }
            CHeart ptemp = new CHeart();
            ptemp.im = ss[0].im;
            ptemp.X = 950;
            ptemp.Y = 60;
            Sc.Add(ptemp);


            /*green enemy*/
            int spg = 0;
            for (int i = 0; i < 3; i++)
            {
                CGE ptrav = new CGE();
                ptrav.im = new Bitmap[3];
                ptrav.im[0] = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\boss\0.bmp");
                ptrav.im[1] = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\boss\1.bmp");
                ptrav.im[2] = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\boss\2.bmp");
                ptrav.im[0].MakeTransparent(Color.White);
                ptrav.im[1].MakeTransparent(Color.White);
                ptrav.im[2].MakeTransparent(Color.White);
                ptrav.img = ptrav.im[0];
                ptrav.X = 1650+spg;
                ptrav.Y = 485;
                ptrav.xDir = -25;
                Ge.Add(ptrav);
                spg += 300;
            }

            /* Angles Drawing*/
            for (int i = 0; i < 10; i++)
            {
                CSora ptrav = new CSora();
                ptrav.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\angle\" + i + ".bmp");
                ptrav.im.MakeTransparent(Color.White);
                As.Add(ptrav);
            
            
            }
            /* fire and angle draw*/
            int spp = 0;
            for (int i = 0; i < 3; i++)
            {
                CActor2 ptrav = new CActor2();
                ptrav.im = new Bitmap(As[0].im);
                ptrav.im.MakeTransparent(Color.White);
                ptrav.X = 1500;
                ptrav.Y = 300 + spp;
                ptrav.xDir = -2;
                Angles.Add(ptrav);
                spp -= 100 ;
            }
            spp = 0;
            for (int i = 0; i < 3; i++)
            {
                CActor2 ptrav = new CActor2();
                ptrav.im = new Bitmap("gf.png");
                ptrav.im.MakeTransparent(Color.White);
                ptrav.X = 1420;
                ptrav.Y = 300 + spp;
                ptrav.xDir = -40;
                ptrav.yDir = 0;
                AnglesFire.Add(ptrav);
                spp -= 100;
            }     

            /* falling objects*/
            int spr = 0;
            for (int i = 0; i < 9; i++)
            {
                CGE ptrav = new CGE();
                ptrav.im = new Bitmap[3];
                ptrav.im[0] = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\second\b.png");
                ptrav.im[1] = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\second\r.png");
                ptrav.im[2] = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\second\r.png");
                ptrav.im[0].MakeTransparent(Color.Black);
                ptrav.im[1].MakeTransparent(Color.Black);
                ptrav.im[2].MakeTransparent(Color.White);
                ptrav.img = ptrav.im[0];
                ptrav.X = 0 + spr;
                ptrav.Y = 0;
                ptrav.yDir = -65;
                Fall.Add(ptrav);
                spr += 229;
            }

            /* climbing ladder*/

            for (int i = 0; i < 6; i++)
            {
                CSora ptrav = new CSora();
                ptrav.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\hero\climb\" + i + ".bmp");
                ptrav.im.MakeTransparent(Color.White);
                Ls.Add(ptrav);
            }

            /* Ladder*/
            ladder = new CHero();
            ladder.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\second\ladder1.png");
            ladder.X = 2500;
            ladder.Y= 320;
            ladder.W = 80;
            ladder.H = 250;
            ladder.im.MakeTransparent(Color.White);


            /* Box*/
            box = new CGE();
            box.im = new Bitmap[2];
            box.im[0] = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\last\box.png");
            box.im[1] = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\last\wr.png");
            box.im[1].MakeTransparent(Color.White);
            box.img = box.im[0];
            box.X = 4000;
            box.Y = 50;
            box.xDir = 100;
            box.yDir = 100;
            

            /* portal*/
            grass = new CActor();
            grass.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\last\grass.png");
            grass.X = 3950;
            grass.Y = 560;
            grass.xDir = 20;
            grass.yDir = -20;


            /* plane*/
            plane = new CHero();
            plane.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\last\p1.png");
            plane.X = 3600;
            plane.Y = 10;
            plane.im.MakeTransparent(Color.White);

            /* Sliding*/
            slide = new Bitmap("0.bmp");
            slide.MakeTransparent(Color.White);


            /* fire blocks*/
            for (int i = 0; i < 10; i++)
            {
                CSora ptrav = new CSora();
                ptrav.im = new Bitmap(@"D:\STUDY\4th semester\MultiMedia\MainGame\MainGame\bin\Debug\Meky\peng\" + i + ".png");
                ptrav.im.MakeTransparent(Color.White); 
                Peng.Add(ptrav);
            }
            int pp = 0;
            for (int i = 0; i < 2; i++)
            {
                CActor ptrav = new CActor();
                ptrav.im = new Bitmap("t.png");
                ptrav.X = 2600+pp;
                if (i == 1)
                { ptrav.Y = 50; }
                else
                { ptrav.Y = 450; }
                
                ptrav.W = 520;
                ptrav.H = 200;

                if (i == 1)
                { ptrav.yDir = 1; }
                else
                { ptrav.yDir = -1; }
                BF.Add(ptrav);
                pp += 600;
            }
            pp = 0;
            for (int i = 0; i < 2; i++)
            {
                CActor ptrav = new CActor();
                ptrav.im = new Bitmap("t.png");
                ptrav.X = 2600+pp;
                if (i == 1)
                { ptrav.Y = 450; }
                else
                { ptrav.Y = 50; }
               
                ptrav.W = 520;
                ptrav.H = 200;

                if (i == 1)
                { ptrav.yDir = -1; }
                else
                { ptrav.yDir = 1; }
              
                BF2.Add(ptrav);
                pp += 600;
            }

            Pig = new CGE();
            Pig.im = new Bitmap[2];
            Pig.im[0] = new Bitmap("p1.bmp");
            Pig.im[0].MakeTransparent(Color.White);
            Pig.im[1] = new Bitmap("p2.bmp");
            Pig.im[1].MakeTransparent(Color.White);
            Pig.img = Pig.im[1];
            Pig.X = 6200;
            Pig.Y = this.ClientSize.Height - 120;

            p1 = new CActor();
            p1.im = Peng[0].im;
            p1.X = 6100;
            p1.Y = 50;



            p2 = new CActor();
            p2.im = Peng[0].im;
            p2.X = 6100;
            p2.Y = 400;











        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);

            if (credit == 0)
            { 

                /*Backgrounds*/
                if (XScroll > -1600)
                { g.DrawImage(a1, 0 + XScroll, 15, a1.Size.Width, a1.Size.Height);
             //  g.DrawImage(b1, 0 + XScroll, 10, a1.Size.Width, a1.Size.Height);
                }
                if (XScroll > -3200)
                { g.DrawImage(a2, 0 + XScroll + a1.Size.Width, 15, a2.Size.Width, a2.Size.Height);
               // g.DrawImage(b2, 0 + XScroll + a1.Size.Width, 10, a1.Size.Width, a1.Size.Height);
                }

                g.DrawImage(a3, 0 + XScroll + a1.Size.Width+a2.Size.Width, 15, a3.Size.Width, a3.Size.Height);
               // g.DrawImage(b3, 0 + XScroll + a1.Size.Width + a2.Size.Width, 10, a1.Size.Width, a1.Size.Height);
          
                
                    g.DrawImage(a4, 0 + XScroll + a1.Size.Width + a2.Size.Width + a3.Size.Width, 15, a4.Size.Width, a4.Size.Height);
                   // g.DrawImage(b4, 0 + XScroll + a1.Size.Width + a2.Size.Width + a3.Size.Width, 10, a1.Size.Width, a1.Size.Height);
               

                
              
                /*Rocks*/
                if (XScroll > -900)
                {
                    for (int i = 0; i < R.Count; i++)
                    {
                        CHeart ptrav = R[i];
                        g.DrawImage(ptrav.im, ptrav.X + XScroll, ptrav.Y, ptrav.W, ptrav.H);
                    }
                    /* Stare score*/

                    for (int i = 0; i < Sc.Count; i++)
                    {
                        CHeart ptrav = Sc[i];
                        g.DrawImage(ptrav.im, ptrav.X + XScroll, ptrav.Y);

                    }

  
                    // Angles 
                    for (int i = 0; i < Angles.Count; i++)
                    {
                        CActor2 pnn = Angles[i];
                        g.DrawImage(pnn.im, pnn.X, pnn.Y);
                        
                    }
                    
                    for (int i = 0; i < AnglesFire.Count; i++)
                    {
                        CActor2 pnn = AnglesFire[i];
                        if (pnn.yDir == 1)
                        { 
                        g.DrawImage(pnn.im, pnn.X, pnn.Y);
                        }

                    }
                    /* green monster*/
                    if (Angles.Count==0)
                    {
                        for (int i = 0; i < Ge.Count; i++)
                        {
                            CGE ptrav = Ge[i];

                            g.DrawImage(ptrav.img, ptrav.X + XScroll, ptrav.Y);


                        }
                    }



                }
                /* falling objects*/
                if (XScroll > -2010 && XScroll < -1050)
                {
                    for (int i=0; i < Fall.Count; i++)
                    {
                        CGE ptrav = Fall[i];

                     
                         g.DrawImage(ptrav.img, ptrav.X + XScroll, ptrav.Y); 
                    
                    
                    }
                }

                /* ladder and tile*/
               if (XScroll > -3660 && XScroll < 2050)
               {
                 g.DrawImage(ladder.im, ladder.X +XScroll, ladder.Y,ladder.W,ladder.H);
                 g.DrawImage(tile, 2580+XScroll, 365, 1250, 35);



                 /* Blocks with fire*/

                 for (int i = 0; i < 2; i++)
                 {
                     CActor ptrav = BF[i];
                     g.DrawImage(ptrav.im, ptrav.X + XScroll, ptrav.Y, ptrav.W, ptrav.H);
                 }
                 for (int i = 0; i < 2; i++)
                 {
                     CActor ptrav = BF2[i];
                     g.DrawImage(ptrav.im, ptrav.X + XScroll, ptrav.Y, ptrav.W, ptrav.H);
                 }



                 



               }

               if (XScroll < -3000 && XScroll < 4805)
               {
                  
                   if (flaglol == true)
                   {
                       if (flaglol2 == false)
                       {
                           g.DrawImage(box.im[1], box.X + XScroll, box.Y, box.xDir, box.yDir);
                       }
                   }
                   else
                   {
                       if (flaglol2 == false)
                       {
                           g.DrawImage(box.img, box.X + XScroll, box.Y, box.xDir, box.yDir);
                       }
                   }
                   
               }
               if (flaglol2 == true)
               {
                   g.DrawImage(grass.im, grass.X+XScroll, grass.Y,150,50);
               }









               if (pigcount != 5)
               {

                   if (XScroll <= -4700)
                   {
                       g.DrawImage(Pig.img, Pig.X + XScroll, Pig.Y, 100, 115);
                       for (int i = 0; i < PF.Count; i++)
                       {
                           CActor pr = PF[i];
                           g.DrawImage(pr.im, pr.X + XScroll, pr.Y, pr.W, pr.H);
                       }
                   }
               }
               else
               { 
                   if(flagplay == true)
                   {
                     
                       flagame = 1;
                       player4.Play();
                       flagplay = false;
                   }
               }





                   for (int i = 0; i < Bullt.Count; i++)
                   {
                       CActor ptrav = Bullt[i];
                       g.DrawImage(ptrav.im, ptrav.X + XScroll, ptrav.Y);


                   }
                   for (int i = 0; i < Rocket.Count; i++)
                   {
                       CActor ptrav = Rocket[i];
                       g.DrawImage(ptrav.im, ptrav.X + XScroll, ptrav.Y);
                    
                   }


                       /*Hero*/
                       g.DrawImage(Hero.im, Hero.X + XScroll, Hero.Y, Hero.W, Hero.H);

                if (flaglol2 == true)
                { 
                     g.DrawImage(plane.im, plane.X + XScroll, plane.Y, 500, 200);
                }





                /* laser hero*/
                if(laserflag==1)
                {
                    Pen p = new Pen(Color.Yellow,5);
                    g.DrawLine(p, Hero.X + 50+XScroll, Hero.Y+50, Hero.X + 50+XScroll, 0);
                    laserflag = 0;
                }

                if (flagame == 1)
                {
                   
                    g.DrawImage(w.im, 500, 100);
                    g.DrawImage(Pig.img, Pig.X + XScroll, Pig.Y, 100 , 115);

                    g.DrawImage(p1.im, p1.X + XScroll, p1.Y);
                    g.DrawImage(p2.im, p2.X + XScroll, p2.Y);
                  
                }
                if(flagame == 2)
                {
                    g.DrawImage(l.im, 500, 100);
                }
   

                
                /* Health and Score and Level Meter*/
                SolidBrush BB1 = new SolidBrush(Color.White);
                Font f = new Font(FontFamily.GenericSansSerif, 15);
                String s1 = "Health: ";
                g.DrawString(s1, f, BB1, 5, 25);
                for (int i = 0; i < H.Count; i++)
                {
                    CHeart ptrav = H[i];
                    g.DrawImage(ptrav.im, ptrav.X, ptrav.Y);
               
                }

                /* Top info*/
                String s2 = "Game Meter";
                g.DrawString(s2, f, BB1, 550, 25);
                Pen P = new Pen(Color.White, 2);
                SolidBrush BB = new SolidBrush(Color.Black);
                g.DrawRectangle(P, 680, 28, 160, 20);
                g.FillRectangle(BB, 680, 28, 0 + (XScroll/30 *-1)  , 20);

                string s3 = "Score: " + score;
                g.DrawString(s3, f, BB1, 1350, 25);
                string s4 = "HighScore: " + highscore;
                g.DrawString(s4, f, BB1, 1450, 25);




            }
            if (credit == 1)
            {
                g.DrawImage(c, 0, 0, c.Size.Width,c.Size.Height);
               
            }
 
            if (credit == 2)
            {
                g.DrawImage(co, 0, 0, co.Size.Width, co.Size.Height);
        
            }
          
            
        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1582, 610);
            credit = 0;
            StartPosition = FormStartPosition.CenterScreen;
            player.Stop();
            player2.PlayLooping();
            DrawDubb(this.CreateGraphics());
        }
        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1160, 610);
            credit = 1;
            player2.Stop();
            player.Play();

            StartPosition = FormStartPosition.CenterScreen;
            DrawDubb(this.CreateGraphics());
        }
        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1160, 610);
            credit = 2;
            StartPosition = FormStartPosition.CenterParent;
            player.Stop();
            player2.Stop();
            DrawDubb(this.CreateGraphics());
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (score > highscore)
            {

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"file.txt", true))
                {
                    file.WriteLine(score);
                }
            }
            this.Close();
        }



       
    }
}
