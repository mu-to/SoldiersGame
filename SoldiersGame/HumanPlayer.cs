using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoldiersGame
{
    class HumanPlayer : Player
    {
        public const int MOUSESTATE_PANEL_NOTMOUSEDOWN = 0;   // パネルがクリックされていない状態
        public const int MOUSESTATE_UNIT_CLICKED = 1;         // ユニットが一度、クリックされた状態
        public const int MOUSESTATE_UNIT_MOVE_FINISHED = 2;   // ユニットを移動し終わった状態
        public const int MOUSESTATE_SHOW_CAN_ATTACK_UNIT = 3; // ユニットを動かし終わって攻撃可能ユニットが選択できる状態

        Form1 fForm;
        DrawManager fDrawManager;

        int fTeamColor;
        Map fMap;
        Action fNowAction;
        int fMouseState;
        bool actselecting;

        int fromXpos;
        int fromYpos;

        public HumanPlayer(Form1 form, DrawManager drawManager)
        {
            fForm = form;
            fDrawManager = drawManager;
            this.fNowAction = new Action();
        }

        public Action makeAction(Map map, int teamcolor)
        {
            this.fMap = map;
            this.fTeamColor = teamcolor;

            fForm.pictureBox1.MouseDown += new MouseEventHandler(fForm.pictureBox1_MouseDown);

            actselecting = true;
            fMouseState = MOUSESTATE_PANEL_NOTMOUSEDOWN;

            while (actselecting)
            {
                Application.DoEvents();

            }

            fForm.pictureBox1.MouseDown -= new MouseEventHandler(fForm.pictureBox1_MouseDown);

            return fNowAction;
        }


        public void pictureBoxPushed(int selectXpos, int selectYpos)
        {
            if (selectXpos >= fMap.getXsize() || selectYpos >= fMap.getYsize()) return;
            Unit[,] mapUnit = fMap.getMapUnit();
            Unit opUnit;

            switch (fMouseState)
            {
                case MOUSESTATE_PANEL_NOTMOUSEDOWN:
                    if(isClickedOppUnit(selectXpos, selectYpos))
                    {
                        break;
                    }

                    if(mapUnit[selectXpos, selectYpos] != null && !mapUnit[selectXpos, selectYpos].isActionFinished())
                    {
                        //mapUnit[selectXpos, selectYpos].setSelecting(true);
                        fromXpos = selectXpos;
                        fromYpos = selectYpos;
                        fMouseState = MOUSESTATE_UNIT_CLICKED;
                    }
                    break;


                case MOUSESTATE_UNIT_CLICKED:
                    opUnit = mapUnit[fromXpos, fromYpos];
                    fMap.changeUnitLocation(selectXpos, selectYpos, opUnit);
                    fDrawManager.reDrawMap(fMap);
                    actselecting = false;
                    
                    return;


                default:
                    break;
            }
        }

        private Boolean isClickedOppUnit(int xPos, int yPos)
        {
            Unit[,] mapUnit = fMap.getMapUnit();
            if (mapUnit[xPos, yPos] == null) { return false; }

            if (mapUnit[xPos, yPos].getTeamColor() != this.fTeamColor) { return true; }

            return false;
        }


    }
}
