using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSED03.Guy;

namespace DSED03
{
    public partial class Form1 : Form
    {

        race raceTime = new race();

        Punter[] myPunter = new Punter[3];
        Punter[] myDragon = new Punter[4];


        public Form1()
        {
            InitializeComponent();

            LoadData();

            this.MaximumSize = new System.Drawing.Size(1030, 750);
            this.MinimumSize = new System.Drawing.Size(1030, 750);

        }

   


        private void LoadData()
        {

            #region Game Load

            //Get Punters
            for (int i = 0; i < 3; i++)
            {
                myPunter[i] = Factory.GetAPunter(i);
            }

            //Get Foxes
            for (int i = 0; i < 4; i++)
            {
                myDragon[i] = Factory.GetADragon(i);
            }

            //Set Punters Cash
            raceTime.TomCash = myPunter[0].Cash;
            raceTime.DickCash = myPunter[1].Cash;
            raceTime.HarryCash = myPunter[2].Cash;

            //Set values
            NudDragonNumber.Minimum = 1;
            NudDragonNumber.Maximum = 4;

            NudDragonNumber.Text = myPunter[raceTime.DragonNum].Dragon.ToString();

      

            btnRace.Enabled = false;
            NudDragonNumber.Enabled = false;
            NudBetAmount.Enabled = false;
            btnBet.Enabled = false;


            //set images to dragon numbers
            PB1.Tag = myDragon[0].DragonName;
            PB2.Tag = myDragon[1].DragonName;
            PB3.Tag = myDragon[2].DragonName;
            PB4.Tag = myDragon[3].DragonName;


        


        }
#endregion

        private void Form1_Load(object sender, EventArgs e)
        {



#region Background Transparency 

            //Makes Backgrounds transparent for pictureboxes
            this.PointToScreen(PB1.Location);
            PB1.Parent = PBMK;
            PB1.BackColor = Color.Transparent;
            this.PointToScreen(PB2.Location);
            PB2.Parent = PBMK;
            PB2.BackColor = Color.Transparent;
            this.PointToScreen(PB3.Location);
            PB3.Parent = PBMK;
            PB3.BackColor = Color.Transparent;
            this.PointToScreen(PB4.Location);
            PB4.Parent = PBMK;
            PB4.BackColor = Color.Transparent;
        }

#endregion

        #region Start Race

        private void btnRace_Click(object sender, EventArgs e)
        {

            btnRace.Enabled = false;

            btnBet.Enabled = false;

            raceTime.TrackLength = Form1.ActiveForm.Width - PB1.Width;

            // set location of foxes

            while (PB1.Location.X < raceTime.TrackLength && PB2.Location.X < raceTime.TrackLength && PB3.Location.X < raceTime.TrackLength && PB4.Location.X < raceTime.TrackLength)


            {
                PB1.Location = new Point(PB1.Location.X + Factory.Number(), PB1.Location.Y);
                PB2.Location = new Point(PB2.Location.X + Factory.Number(), PB2.Location.Y);
                PB3.Location = new Point(PB3.Location.X + Factory.Number(), PB3.Location.Y);
                PB4.Location = new Point(PB4.Location.X + Factory.Number(), PB4.Location.Y);

                Application.DoEvents();
            }

            //determine race winner based on location point

            if (PB1.Location.X >= raceTime.TrackLength)
            {
                MessageBox.Show(myDragon[0].DragonName + " won the race");
                raceTime.WinningDragon = 1;

                
                

            }

            else if (PB2.Location.X >= raceTime.TrackLength)
            {
                MessageBox.Show(myDragon[1].DragonName + " won the race");
                 raceTime.WinningDragon = 2;

            }


           else if (PB3.Location.X >= raceTime.TrackLength)
            {
                MessageBox.Show(myDragon[2].DragonName + " won the race");
               
                raceTime.WinningDragon = 3;

            
            }

           else 
            {
                MessageBox.Show(myDragon[3].DragonName + " won the race");
         
                raceTime.WinningDragon = 4;

            }

            //run method to determine winner
            winner();



            NudBetAmount.Enabled = false;

            RBDick.Checked = false;
            RBHarry.Checked = false;
            RBTom.Checked = false;

            // run new race method
            startnewrace();
        }

#endregion



        #region Radio Button Selector
        private void RbBettors_CheckedChanged(object sender, EventArgs e)
        {
            raceTime.RadioButton = (RadioButton) sender;

            //associate radio buttons with punters

            if (raceTime.RadioButton.Checked == true)
            {
                raceTime.GuyNum = Convert.ToInt16(raceTime.RadioButton.Tag);
          
                this.Text = "The Great Fox Race";

                if (raceTime.GuyNum == 0)
                {
                    NudBetAmount.Text = raceTime.TomCash.ToString();
               
                }

                else if (raceTime.GuyNum == 1)
                {
                    NudBetAmount.Text = raceTime.DickCash.ToString();
                }
                else if (raceTime.GuyNum == 2)
                {
                    NudBetAmount.Text = raceTime.HarryCash.ToString();
                }


                NudBetAmount.Maximum = Convert.ToDecimal(myPunter[raceTime.GuyNum].Cash);

                lblMaxBet.Text = myPunter[raceTime.GuyNum].Cash.ToString();

                NudDragonNumber.Enabled = true;
                NudBetAmount.Enabled = true;

                btnBet.Enabled = true;

            }


#endregion

        }

        #region Place Bet
        private void btnBet_Click(object sender, EventArgs e)
        {
       
          //set bet amounts for the punters

            //display fox number and bet amount relative to punter - outputted to a label

            raceTime.GuyNum = Convert.ToInt16(raceTime.RadioButton.Tag);

            if (raceTime.GuyNum == 0)
            {
                lblTomBet.Text = "Tom has bet $" + NudBetAmount.Text + " on Fox number " + NudDragonNumber.Text;

                lblTomDragon.Text = NudDragonNumber.Text;

                lblTomBetAmount.Text = NudBetAmount.Text;

        

            }

            else if (raceTime.GuyNum == 1)
            {
                lblDickBet.Text = "Dick has bet $" + NudBetAmount.Text + " on Fox number " + NudDragonNumber.Text;


                lblDickDragon.Text = NudDragonNumber.Text;

                lblDickBetAmount.Text = NudBetAmount.Text;


            }

            else if (raceTime.GuyNum == 2)
            {
                lblHarryBet.Text = "Harry has bet $" + NudBetAmount.Text + " on Fox number " + NudDragonNumber.Text;

                lblHarryDragon.Text = NudDragonNumber.Text;

                lblHarryBetAmount.Text = NudBetAmount.Text;
        
            }

            
            btnRace.Enabled = true;

            
        }
#endregion

        #region Winner
        public void winner()



        {


            //determine if the winning dragon matches the dragon chosen by the punter
            if (raceTime.WinningDragon == Convert.ToInt16(lblTomDragon.Text) && raceTime.TomCash >=1)

            {
                //double cash for winner
                raceTime.TomCash = raceTime.TomCash * 2;
                lblTomBet.Text = "Tom has won!!!";
                lblTomBet.ForeColor = Color.GreenYellow;
            }

            else
            {
                raceTime.TomCash = raceTime.TomCash - Convert.ToInt16(lblTomBetAmount.Text);

                if (raceTime.TomCash == 0)

                {
                    RBTom.Enabled = false;
                    lblTomBet.Text = "Tom is Busted";
                    lblTomBet.ForeColor = Color.OrangeRed;
                }
            }

          lblTom.Text = raceTime.TomCash.ToString();



            if (raceTime.WinningDragon == Convert.ToInt16(lblDickDragon.Text) && raceTime.DickCash >=1)
            {
                raceTime.DickCash = raceTime.DickCash * 2;
                lblDickBet.Text = "Dick has won!!!";
                lblDickBet.ForeColor = Color.GreenYellow;
            }

            else
            {
                raceTime.DickCash = raceTime.DickCash - Convert.ToInt16(lblDickBetAmount.Text);

                if (raceTime.DickCash == 0)
                {
                    RBDick.Enabled = false;
                    lblDickBet.Text = "Dick is Busted";
                    lblDickBet.ForeColor = Color.OrangeRed;
                    

                }
            }

            lblDick.Text = raceTime.DickCash.ToString();


            if (raceTime.WinningDragon == Convert.ToInt16(lblHarryDragon.Text) && raceTime.HarryCash >=1)

            {
                raceTime.HarryCash = raceTime.HarryCash * 2;
                lblHarryBet.ForeColor = Color.GreenYellow;
                lblHarryBet.Text = "Harry has won!!!";


            }

            else
            {
                raceTime.HarryCash = raceTime.HarryCash - Convert.ToInt16(lblHarryBetAmount.Text);

                if (raceTime.HarryCash == 0)
                {
                    RBHarry.Enabled = false;
                    lblHarryBet.Text = "Harry is Busted";
                    lblHarryBet.ForeColor = Color.OrangeRed;
                }
            }

            lblHarry.Text = raceTime.HarryCash.ToString();


            if (raceTime.HarryCash >= 0 && raceTime.DickCash >= 0 && raceTime.TomCash >= 0)
            {
                NudBetAmount.Enabled = false;
                //btnNewRace.Enabled = false;
            }
        }
#endregion

        #region Reset Game
        private void btnReset_Click(object sender, EventArgs e)
        {

            //RESTART GAME

            //reset location of the foxes
            PB1.Location = new Point(200, 250);
            PB2.Location = new Point(200, 330);
            PB3.Location = new Point(200, 410);
            PB4.Location = new Point(200, 480);

            //reset label txt
            lblHarryBet.Text = "";
            lblTomBet.Text = "";
            lblDickBet.Text = "";


            //get punters and foxes
            for (int i = 0; i < 3; i++)
            {
                myPunter[i] = Factory.GetAPunter(i);
            }

            for (int i = 0; i < 4; i++)
            {
                myDragon[i] = Factory.GetADragon(i);
            }

            //set cash value for punters
            raceTime.TomCash = myPunter[0].Cash;
            raceTime.DickCash = myPunter[1].Cash;
            raceTime.HarryCash = myPunter[2].Cash;


            NudDragonNumber.Minimum = 1;
            NudDragonNumber.Maximum = 4;

            NudDragonNumber.Text = myPunter[raceTime.DragonNum].Dragon.ToString();

        
            //disable buttons until bets are placed.
            btnRace.Enabled = false;
            NudDragonNumber.Enabled = false;
            NudBetAmount.Enabled = false;
            btnBet.Enabled = false;

            //btnNewRace.Enabled = false;

            //set images to dragon numbers
            PB1.Tag = myDragon[0].DragonName;
            PB2.Tag = myDragon[1].DragonName;
            PB3.Tag = myDragon[2].DragonName;
            PB4.Tag = myDragon[3].DragonName;


    
            //enable radio buttons
            RBTom.Enabled = true;
            RBDick.Enabled = true;
            RBHarry.Enabled = true;

            //set label txet colours
            lblHarryBet.ForeColor = Color.Gold;
            lblTomBet.ForeColor = Color.Gold;
            lblDickBet.ForeColor = Color.Gold;
        }

#endregion


        #region Start New Race
        public void startnewrace()
        {

            //reset location of foxes

            PB1.Location = new Point(200, 250);
            PB2.Location = new Point(200, 330);
            PB3.Location = new Point(200, 410);
            PB4.Location = new Point(200, 480);

            //set punter new cash amount
            myPunter[0].Cash = Convert.ToInt16(lblTom.Text);
            myPunter[1].Cash = Convert.ToInt16(lblDick.Text);
            myPunter[2].Cash = Convert.ToInt16(lblHarry.Text);

            // re enable radio buttons
            RBDick.Checked = true;
            RBHarry.Checked = true;
            RBTom.Checked = true;


            //disable betting if punters have zero cash
            if (RBDick.Enabled == false && RBHarry.Enabled == false && RBTom.Enabled == false)
            {
            
                NudDragonNumber.Enabled = false;
                btnBet.Enabled = false;
                btnRace.Enabled = false;
       

            }

        }

#endregion

        #region TopMenu

        //menu items
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Have a go at Fox Racing but remember when you gamble you always lose in the end ;)");
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select a punter and choose bet value and fox, hit the race button.");
        }

        #endregion
    }
}

