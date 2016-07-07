using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SoldiersGame
{
    class DrawManager
    {
        public const int BMP_SIZE = 34;
        //public const int BMP_SIZE = 45; // 現在マップサイズに合わせて大きくしている

        public static Bitmap[] fUnitBmps;
        Bitmap fFieldBmp;
        Bitmap[] fNumberBmps;

        Bitmap fEndMarkBMP;
        //Bitmap fRedWindowBMP;
        //Bitmap fBlueWindowBMP;

        // for Filter
        //System.Drawing.Imaging.ImageAttributes fIA_05Alpha;
        //System.Drawing.Imaging.ImageAttributes fIA_Dark;

        // 描画用コントローラ
        Graphics fGraphics;     // 描画ハンドラ (fPictureBoxから取得）
        static Form1 fForm;         // 親フォーム，Refresh用
        PictureBox fPictureBox; // 描画対象

        Map fMap;

        public DrawManager(Form1 form, PictureBox pb)
        {
            fForm = form;
            this.fPictureBox = pb;
            fGraphics = Graphics.FromImage(pb.Image);

            fUnitBmps = new Bitmap[2];
            fNumberBmps = new Bitmap[3];

            fUnitBmps[0] = new Bitmap("./img/Red_infantry.png");
            fUnitBmps[1] = new Bitmap("./img/Blue_infantry.png");

            fNumberBmps[0] = new Bitmap("./img/Number_1.png");
            fNumberBmps[1] = new Bitmap("./img/Number_2.png");
            fNumberBmps[2] = new Bitmap("./img/Number_3.png");

            //fFieldBmp = new Bitmap("./img/Field_road.png");
            fFieldBmp = new Bitmap("./img/frame.png");

            fEndMarkBMP = new Bitmap("./img/Mark_end.png");
            //fRedWindowBMP = new Bitmap("./img/Mark_redselect.png");
            //fBlueWindowBMP = new Bitmap("./img/Mark_blueselect.png");
        }

        public void setMap(Map map)
        {
            this.fMap = map;
        }

        public void drawMap()
        {
            if(this.fMap == null)
            {
                return;
            }

            for(int y = 1; y < fMap.getYsize() - 1; y++)
            {
                for(int x = 1; x < fMap.getXsize() - 1; x++)
                {
                    drawCell(x, y);
                }
            }
        }

        public void drawCell(int x, int y)
        {
            Unit u = fMap.getUnit(x, y);

            fGraphics.DrawImage(fFieldBmp, BMP_SIZE * (x - 1), BMP_SIZE * (y - 1), BMP_SIZE, BMP_SIZE);

            if(u != null)
            {
                fGraphics.DrawImage(fUnitBmps[u.getTeamColor()], BMP_SIZE * (x - 1), BMP_SIZE * (y - 1), BMP_SIZE, BMP_SIZE);
                if (u.isActionFinished())
                {
                    fGraphics.DrawImage(fEndMarkBMP, BMP_SIZE * (x - 1), BMP_SIZE * (y - 1), BMP_SIZE, BMP_SIZE);
                }

                fGraphics.DrawImage(fNumberBmps[u.getHP() - 1], BMP_SIZE * (x - 1), BMP_SIZE * (y - 1), BMP_SIZE, BMP_SIZE);
            }

        }

        public void reDrawMap(Map aMap)
        {
            this.fMap = aMap;
            drawMap();
            fForm.Refresh();
        }

        public void clearMapImage()
        {
            fPictureBox.Image = new Bitmap(fPictureBox.Width, fPictureBox.Height);
            fGraphics = Graphics.FromImage(fPictureBox.Image);
        }
    }
}
