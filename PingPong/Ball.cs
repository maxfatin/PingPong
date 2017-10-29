using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PingPong
{
    public class Ball
    {
        private PictureBox ball;
        Random rand = new Random();
        Player LeftSide, RightSide;
        
        int xSpeed, ySpeed;

        public Ball(PictureBox ball, Player LeftSide, Player RightSide)
        {
            this.ball = ball;
            this.LeftSide = LeftSide;
            this.RightSide = RightSide;
            xSpeed = 1;
            ySpeed = 3;
            ResetBall();
        }

        internal void GetMove()
        {
            DoMove();
            var bottom = WorldInfo.bottomOfScreen - ball.Height;
            if (ball.Location.Y >= bottom || ball.Location.Y <= WorldInfo.topOfScreen)
            {
                ySpeed *= -1;
            }
            if (ball.Location.X <= WorldInfo.leftScreen)
            {
                Score(LeftSide);
            }
            else if (ball.Location.X >= WorldInfo.rightScreen - ball.Width)
            {
                Score(RightSide);
            }

            if (LeftSide.player.Bounds.IntersectsWith(ball.Bounds) || RightSide.player.Bounds.IntersectsWith(ball.Bounds))
            {
                xSpeed *= -1;
                if (xSpeed > 0)
                {
                    xSpeed++;
                }
                else
                {
                    xSpeed--;
                }
                //if (ySpeed >0)
                //{
                //    ySpeed++;
                //}
                //else
                //{
                //    ySpeed--;
                //}
                while (LeftSide.player.Bounds.IntersectsWith(ball.Bounds) || RightSide.player.Bounds.IntersectsWith(ball.Bounds))
                {
                    DoMove();
                }
            }
        }

        private int DoMove()
        {
            var bottom = WorldInfo.bottomOfScreen - ball.Height;
            ball.Location = new Point(ball.Location.X + xSpeed, Math.Max(WorldInfo.topOfScreen, Math.Min(bottom, ball.Location.Y + ySpeed)));
            return bottom;
        }

        private void Score(Player winningPlayer)
        {
            winningPlayer.score++;
            ResetBall();
        }

        private void ResetBall()
        {
            ball.Location = new Point((WorldInfo.leftScreen + WorldInfo.rightScreen) / 2, (WorldInfo.bottomOfScreen / 2));
            do
            {
                xSpeed = rand.Next(-3, 3);
                ySpeed = rand.Next(-3, 3);
            } while (Math.Abs(xSpeed) + Math.Abs(ySpeed) <= 3 || Math.Abs(xSpeed) <= 1);
            
        }
    }
}
