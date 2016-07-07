using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoldiersGame
{
    public partial class Form1 : Form
    {
        private DrawManager fDrawManager;
        private GameManager fGameManager;
        private HumanPlayer fHumanplayer;

        public Form1()
        {
            InitializeComponent();
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            fDrawManager = new DrawManager(this, pictureBox1);

            fDrawManager.setMap(new Map());
            fDrawManager.drawMap();

            fHumanplayer = new HumanPlayer(this, fDrawManager);

            fGameManager = new GameManager(this, fDrawManager, fHumanplayer);
            fGameManager.initGame();
        }

        public void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                fHumanplayer.pictureBoxPushed(e.X / DrawManager.BMP_SIZE + 1, e.Y / DrawManager.BMP_SIZE + 1);
            }
        }

    }
}
