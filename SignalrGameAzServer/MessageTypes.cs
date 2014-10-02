using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageTypes
{
    public class myPoint
    {
        public float X;
        public float Y;

        public myPoint(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    public class myPlayer
    {
        myPoint pos;

        public myPoint Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        int playerID;

        public int PlayerID
        {
            get { return playerID; }
            set { playerID = value; }
        }

        public myPlayer(int playerid, myPoint p)
        { playerID = playerid; pos = p; }
    }

}
