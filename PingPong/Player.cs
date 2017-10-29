using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PingPong
{
    public class Player
    {
        const int movementSpeed = 3;

        public bool isUpPressed, isDownPressed;
        bool? wasGoingUp;
        int numOfTicks;
        int _score;
        public int score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                scoreLabel.Text = score.ToString();
            }
        }
        public PictureBox player;
        Label scoreLabel;

        public Player(PictureBox player1, Label scoreLabel)
        {
            this.player = player1;
            this.scoreLabel = scoreLabel;
        }

        internal void GetMove()
        {
            bool? goingUp = null;

            if (isUpPressed)
            {
                goingUp = true;
            }
            if (isDownPressed)
            {
                if (goingUp.HasValue)
                {
                    goingUp = null;
                }
                else
                {
                    goingUp = false;
                }
            }
            if (wasGoingUp.HasValue)
            {
                if (!goingUp.HasValue)
                {
                    wasGoingUp = null;
                    numOfTicks = 0;
                }
                else if (wasGoingUp.Value == goingUp.Value)
                {
                    numOfTicks++;
                }
                else
                {
                    wasGoingUp = goingUp;
                    numOfTicks = 1;
                }
            }
            else if (goingUp.HasValue)
            {
                wasGoingUp = goingUp;
                numOfTicks = 1;
            }
            DoMove(goingUp);
        }

            private void DoMove(bool? goingUp)
            {
                if (goingUp.HasValue)
                {
                    var speed = movementSpeed * (numOfTicks / 7);
                    if (goingUp.Value)
                    {
                        speed *= -1;
                    }
                    player.Location = new Point(player.Location.X, Math.Max(WorldInfo.topOfScreen, Math.Min((WorldInfo.bottomOfScreen-player.Height), player.Location.Y + speed)));
                }
            }

        }
    }

