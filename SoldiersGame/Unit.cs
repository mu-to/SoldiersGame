using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldiersGame
{
    class Unit
    {
        private int fXpos;
        private int fYpos;
        private int fHP;
        private int fTeamColor;
        private int fId;
        private bool fActionFinished;
        private bool fSelecting;

        public Unit(int x, int y, int id, int team, int HP)
        {
            this.fXpos = x;
            this.fYpos = y;
            this.fId = id;
            this.fHP = HP;
            this.fTeamColor = team;
            this.fActionFinished = false;
            this.fSelecting = false;
        }

        public Unit()
        {
        }

        public bool isActionFinished()
        {
            return fActionFinished;
        }

        public int getTeamColor()
        {
            return fTeamColor;
        }

        public int getXpos()
        {
            return fXpos;
        }

        public int getYpos()
        {
            return fYpos;
        }

        public int getHP()
        {
            return fHP;
        }

        public bool getSelecting()
        {
            return fSelecting;
        }

        public void setSelecting(bool state)
        {
            fSelecting = state;
        }

        public void setPos(int x, int y)
        {
            fXpos = x;
            fYpos = y;
        }
    }
}
