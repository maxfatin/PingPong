using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class PinPongBoard : Form
    {
        Player play1, play2;
        Ball ballz;


        public PinPongBoard()
        {
            InitializeComponent();
            play1 = new Player(player1, lblPlayer2);
            play2 = new Player(player2, lblPlayer1);
            ballz = new Ball(ball, play1, play2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            play1.GetMove();
            play2.GetMove();
            ballz.GetMove();

        }


        //player1.Location = new Point(player1.Location.X, Math.Min(bottomOfScreen, player1.Location.Y + movementSpeed));

        private void PinPongBoard_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeys(e, true);

        }
        private void PinPongBoard_KeyUp(object sender, KeyEventArgs e)
        {
            CheckKeys(e, false);
        }

        private void player2_Click(object sender, EventArgs e)
        {

        }

        private void CheckKeys(KeyEventArgs e, bool isDown)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    play1.isUpPressed = isDown;
                    break;
                case Keys.Up:
                    play2.isUpPressed = isDown;
                    break;
                case Keys.S:
                    play1.isDownPressed = isDown;
                    break;
                case Keys.Down:
                    play2.isDownPressed = isDown;
                    break;
            }
        }

    }
}
