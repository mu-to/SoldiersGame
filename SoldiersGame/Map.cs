using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldiersGame
{
    class Map
    {
        private const int XSIZE = 22;
        private const int YSIZE = 22;
        //private const int XSIZE = 17; // 現在見易いようにスケールを小さくしてる
        //private const int YSIZE = 17;

        private bool[,] fMovable;
        private Unit[,] fMapUnit;
        private Unit[] fUnits;
        private int[] fNumOfAliveUnits = new int[2];

        public int getXsize()
        {
            return XSIZE;
        }

        public int getYsize()
        {
            return YSIZE;
        }

        public Unit[,] getMapUnit()
        {
            return fMapUnit;
        }

        public Map()
        {
            fMovable = new bool[XSIZE, YSIZE];
            for(int y = 0; y < YSIZE; y++)
            {
                for(int x = 0; x < XSIZE; x++)
                {
                    if(x == 0 || y == 0 || x == (XSIZE - 1) || y == (YSIZE - 1))
                    {
                        fMovable[x, y] = false;
                    }
                    else
                    {
                        fMovable[x, y] = true;
                    }
                }
            }


            fMapUnit = new Unit[XSIZE, YSIZE];
            fUnits = new Unit[36 * 2];

            addUnits();
        }


        private void addUnits()
        {
            int counter;

            // red team
            fNumOfAliveUnits[0] = 36;
            counter = 0;
            for(int y = YSIZE - 7; y < YSIZE - 1; y++)
            {
                for(int x = 1; x < 7; x++)
                {
                    Unit u = new Unit(x, y, counter, 0, 3);
                    fMapUnit[x, y] = u;
                    fUnits[counter] = u;
                    counter++;
                }
            }

            // blue team
            fNumOfAliveUnits[1] = 36;
            counter = 0;
            for (int y = 1; y < 7; y++)
            {
                for (int x = XSIZE - 7; x < XSIZE - 1; x++)
                {
                    Unit u = new Unit(x, y, counter, 1, 3);
                    fMapUnit[x, y] = u;
                    fUnits[counter + 36] = u;
                    counter++;
                }
            }

        }

        public Unit getUnit(int x, int y)
        {
            return fMapUnit[x, y];
        }

        public void changeUnitLocation(int x, int y, Unit selectedUnit)
        {
            int tempXpos = selectedUnit.getXpos();// 移動前の位置
            int tempYpos = selectedUnit.getYpos();

            if (tempXpos == x && tempYpos == y) return;

            this.fMapUnit[x, y] = selectedUnit;
            this.fMapUnit[tempXpos, tempYpos] = null;
            selectedUnit.setPos(x, y);
        }
    }
}