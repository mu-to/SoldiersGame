using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldiersGame
{
    class GameManager
    {
        public Map fMap;
        public DrawManager fDrawManager;
        private Form1 fForm;
        private Player[] fPlayers = new Player[2]; // AI Player
        private HumanPlayer fHumanPlayer;

        private int fPhase;
        private bool fGameEndFlag;

        public GameManager(Form1 form, DrawManager drawManager, HumanPlayer humanPlayer)
        {
            this.fForm = form;
            this.fMap = new Map();
            this.fDrawManager = drawManager;
            this.fHumanPlayer = humanPlayer;
        }

        public void initGame()
        {
            fPhase = 0;
            fGameEndFlag = false;
            executeGame();
        }

        void executeGame()
        {
            while(true){
                inquirePlayer(fPhase);

                if (fGameEndFlag) return;

                changePhase();
            }
        }

        void inquirePlayer(int teamColor)
        {
            while (true)
            {
                Action act = fHumanPlayer.makeAction(fMap, teamColor);

                //battlePhase(act);

                fDrawManager.reDrawMap(fMap);

            }
        }

        void battlePhase(Action act)
        {

        }

        void changePhase()
        {
            fPhase = 1 - fPhase;
        }
    }
}
