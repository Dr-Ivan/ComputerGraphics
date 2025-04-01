using System;
using System.Drawing;
using System.Windows.Forms;

public class DrawShapesForm : Form
{
    public DrawShapesForm()
    {
        this.Text = "Ћабораторна¤ є 5 - ƒерев¤нко »ван";
        this.Size = new Size(641, 438);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Paint += new PaintEventHandler(this.OnPaint);
    }

    private void OnPaint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        // пр¤моугольник на фоне
        using (SolidBrush greenBrush = new SolidBrush(Color.FromArgb(51, 50, 50)))
        {
            g.FillRectangle(greenBrush, 0, 0, 640, 400);
        }

        // синий круг
        using (SolidBrush blueBrush = new SolidBrush(Color.FromArgb(6, 49, 255)))
        using (Pen pen = new Pen(Color.FromArgb(3, 156, 255), 5))
        {
            g.FillEllipse(blueBrush, 348, 151, 400, 400);
            g.DrawEllipse(pen, 348, 151, 400, 400);
        }


        // вершины многоугольника
        Point[] points1 = {
            new Point(425, 195),
            new Point(452, 177),
            new Point(497, 157),
            new Point(530, 153),
            new Point(518, 232),
            new Point(495, 257),
            new Point(440, 220)
        };

        // вершины многоугольника
        Point[] points2 = {
            new Point(377, 500),
            new Point(377, 398),
            new Point(390, 351),
            new Point(460, 277),
            new Point(504, 309),
            new Point(568, 267),
            new Point(558, 208),
            new Point(611, 208),
            new Point(631, 220),
            new Point(700, 220),
            new Point(750, 300),
            new Point(750, 400),
            new Point(750, 550),
            new Point(600, 600),
        };

        // многоугольник
        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 102, 47)))
        using (Pen pen = new Pen(Color.FromArgb(0, 206, 21), 3))
        {
            g.FillPolygon(brush, points1);
            g.DrawPolygon(pen, points1);

            g.FillPolygon(brush, points2);
            g.DrawPolygon(pen, points2);
        }

        // рисование крупных звезд
        {
            int starUpperPointX = 260;
            int starUpperPointY = 315;

            Point[] star1 = {
            new Point(starUpperPointX, starUpperPointY),
            new Point(starUpperPointX-1, starUpperPointY+13),
            new Point(starUpperPointX+14, starUpperPointY+13),
            new Point(starUpperPointX-4, starUpperPointY+28),
            new Point(starUpperPointX-5, starUpperPointY+49),
            new Point(starUpperPointX-12, starUpperPointY+27),
            new Point(starUpperPointX-32, starUpperPointY+35),
            new Point(starUpperPointX-17, starUpperPointY+19),
            new Point(starUpperPointX-26, starUpperPointY+7),
            new Point(starUpperPointX-12, starUpperPointY+10)
            };

            starUpperPointX = 218;
            starUpperPointY = 180;

            Point[] star2 = {
            new Point(starUpperPointX, starUpperPointY),
            new Point(starUpperPointX-1, starUpperPointY+13),
            new Point(starUpperPointX+14, starUpperPointY+13),
            new Point(starUpperPointX-4, starUpperPointY+28),
            new Point(starUpperPointX-5, starUpperPointY+49),
            new Point(starUpperPointX-12, starUpperPointY+27),
            new Point(starUpperPointX-32, starUpperPointY+35),
            new Point(starUpperPointX-17, starUpperPointY+19),
            new Point(starUpperPointX-26, starUpperPointY+7),
            new Point(starUpperPointX-12, starUpperPointY+10)
            };

            starUpperPointX = 70;
            starUpperPointY = 32;

            Point[] star3 = {
            new Point(starUpperPointX, starUpperPointY),
            new Point(starUpperPointX-1, starUpperPointY+13),
            new Point(starUpperPointX+14, starUpperPointY+13),
            new Point(starUpperPointX-4, starUpperPointY+28),
            new Point(starUpperPointX-5, starUpperPointY+49),
            new Point(starUpperPointX-12, starUpperPointY+27),
            new Point(starUpperPointX-32, starUpperPointY+35),
            new Point(starUpperPointX-17, starUpperPointY+19),
            new Point(starUpperPointX-26, starUpperPointY+7),
            new Point(starUpperPointX-12, starUpperPointY+10)
            };

            starUpperPointX = 274;
            starUpperPointY = 10;

            Point[] star4 = {
            new Point(starUpperPointX, starUpperPointY),
            new Point(starUpperPointX-1, starUpperPointY+13),
            new Point(starUpperPointX+14, starUpperPointY+13),
            new Point(starUpperPointX-4, starUpperPointY+28),
            new Point(starUpperPointX-5, starUpperPointY+49),
            new Point(starUpperPointX-12, starUpperPointY+27),
            new Point(starUpperPointX-32, starUpperPointY+35),
            new Point(starUpperPointX-17, starUpperPointY+19),
            new Point(starUpperPointX-26, starUpperPointY+7),
            new Point(starUpperPointX-12, starUpperPointY+10)
            };

            starUpperPointX = 400;
            starUpperPointY = 111;

            Point[] star5 = {
            new Point(starUpperPointX, starUpperPointY),
            new Point(starUpperPointX-1, starUpperPointY+13),
            new Point(starUpperPointX+14, starUpperPointY+13),
            new Point(starUpperPointX-4, starUpperPointY+28),
            new Point(starUpperPointX-5, starUpperPointY+49),
            new Point(starUpperPointX-12, starUpperPointY+27),
            new Point(starUpperPointX-32, starUpperPointY+35),
            new Point(starUpperPointX-17, starUpperPointY+19),
            new Point(starUpperPointX-26, starUpperPointY+7),
            new Point(starUpperPointX-12, starUpperPointY+10)
            };

            starUpperPointX = 543;
            starUpperPointY = 35;

            Point[] star6 = {
            new Point(starUpperPointX, starUpperPointY),
            new Point(starUpperPointX-1, starUpperPointY+13),
            new Point(starUpperPointX+14, starUpperPointY+13),
            new Point(starUpperPointX-4, starUpperPointY+28),
            new Point(starUpperPointX-5, starUpperPointY+49),
            new Point(starUpperPointX-12, starUpperPointY+27),
            new Point(starUpperPointX-32, starUpperPointY+35),
            new Point(starUpperPointX-17, starUpperPointY+19),
            new Point(starUpperPointX-26, starUpperPointY+7),
            new Point(starUpperPointX-12, starUpperPointY+10)
            };

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255)))
            {
                g.FillPolygon(brush, star1);
                g.FillPolygon(brush, star2);
                g.FillPolygon(brush, star3);
                g.FillPolygon(brush, star4);
                g.FillPolygon(brush, star5);
                g.FillPolygon(brush, star6);
            }
        }

        // рисование ракеты 1
        {
            Point[] triangle = {
            new Point(550, 85),
            new Point(505, 105),
            new Point(505, 68)
            };

            Point[] wings = {
                new Point(206, 64),
                new Point(206, 44),
                new Point(262, 29),
                new Point(335, 39),
                new Point(369, 68),
                new Point(374, 108),
                new Point(340, 136),
                new Point(267, 146),
                new Point(211, 132),
                new Point(211, 111),
                new Point(253, 111),
                new Point(276, 121),
                new Point(310, 107),
                new Point(312, 67),
                new Point(272, 54),
                new Point(250, 64)
            };

            Point[] fire = {
                new Point(303, 100),
                new Point(274, 107),
                new Point(255, 101),
                new Point(239, 98),
                new Point(244, 93),
                new Point(233, 92),
                new Point(243, 83),
                new Point(235, 76),
                new Point(255, 73),
                new Point(273, 66),
                new Point(302, 72)
            };

            Point[] smallFire = {
                new Point(301, 95),
                new Point(290, 96),
                new Point(277, 93),
                new Point(265, 88),
                new Point(268, 84),
                new Point(274, 80),
                new Point(284, 77),
                new Point(300, 75)
            };

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(204, 153, 0)))
            using (Pen pen = new Pen(Color.FromArgb(255, 255, 0), 4))
            {
                g.FillPolygon(brush, fire);
                g.DrawPolygon(pen, fire);
            }

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 0, 0)))
            {
                g.FillPolygon(brush, smallFire);
            }

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 0, 0)))
            using (Pen pen = new Pen(Color.FromArgb(255, 255, 255), 5))
            {
                g.FillRectangle(brush, 420, 73, 28, 28);
                g.DrawRectangle(pen, 420, 73, 28, 28);
            }

            g.FillEllipse(Brushes.White, 429, 80, 2, 2);
            g.FillEllipse(Brushes.White, 437, 78, 2, 2);
            g.FillEllipse(Brushes.White, 432, 84, 2, 2);
            g.FillEllipse(Brushes.White, 440, 82, 2, 2);
            g.FillEllipse(Brushes.White, 428, 88, 2, 2);
            g.FillEllipse(Brushes.White, 437, 88, 2, 2);
            g.FillEllipse(Brushes.White, 440, 92, 2, 2);
            g.FillEllipse(Brushes.White, 430, 97, 2, 2);
            g.FillEllipse(Brushes.White, 435, 97, 2, 2);
            g.FillEllipse(Brushes.White, 440, 99, 2, 2);


            using (SolidBrush brush = new SolidBrush(Color.FromArgb(153, 153, 153)))
            using (Pen pen = new Pen(Color.FromArgb(205, 205, 205), 4))
            {
                g.DrawLine(pen, 590, 85, 550, 85);

                g.FillPolygon(brush, triangle);
                g.DrawPolygon(pen, triangle);

                g.FillPolygon(brush, wings);
                g.DrawPolygon(pen, wings);

                g.FillRectangle(brush, 444, 68, 58, 38);
                g.DrawRectangle(pen, 444, 68, 58, 38);

                g.FillRectangle(brush, 299, 68, 124, 38);
                g.DrawRectangle(pen, 299, 68, 124, 38);

            }

            g.DrawLine(new Pen(Color.White, 3), 304, 74, 365, 74);
            g.DrawLine(new Pen(Color.Blue, 3), 304, 78, 365, 78);
            g.DrawLine(new Pen(Color.Red, 3), 304, 82, 365, 82);

            Font font = new Font("Arial", 7, FontStyle.Bold);
            Brush b = new SolidBrush(Color.FromArgb(219, 220, 219));
            g.DrawString(" ќ—ћќ‘Ћќ“", font, b, 300, 90);


            using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 204, 255)))
            using (Pen pen = new Pen(Color.FromArgb(0, 152, 205), 5))
            {
                g.FillEllipse(brush, 370, 76, 18, 18);
                g.DrawEllipse(pen, 370, 76, 18, 18);

                g.FillEllipse(brush, 397, 76, 18, 18);
                g.DrawEllipse(pen, 397, 76, 18, 18);

                g.FillEllipse(brush, 450, 76, 18, 18);
                g.DrawEllipse(pen, 450, 76, 18, 18);

                g.FillEllipse(brush, 476, 76, 18, 18);
                g.DrawEllipse(pen, 476, 76, 18, 18);
            }

        }


        // рисование ракеты 2
        {
            int offsetX = -190; // —двиг по X
            int offsetY = 180; // —двиг по Y

            Point[] triangle = {
                new Point(550 + offsetX, 85 + offsetY),
                new Point(505 + offsetX, 105 + offsetY),
                new Point(505 + offsetX, 68 + offsetY)
            };

            Point[] wings = {
                new Point(206 + offsetX, 64 + offsetY),
                new Point(206 + offsetX, 44 + offsetY),
                new Point(262 + offsetX, 29 + offsetY),
                new Point(335 + offsetX, 39 + offsetY),
                new Point(369 + offsetX, 68 + offsetY),
                new Point(374 + offsetX, 108 + offsetY),
                new Point(340 + offsetX, 136 + offsetY),
                new Point(267 + offsetX, 146 + offsetY),
                new Point(211 + offsetX, 132 + offsetY),
                new Point(211 + offsetX, 111 + offsetY),
                new Point(253 + offsetX, 111 + offsetY),
                new Point(276 + offsetX, 121 + offsetY),
                new Point(310 + offsetX, 107 + offsetY),
                new Point(312 + offsetX, 67 + offsetY),
                new Point(272 + offsetX, 54 + offsetY),
                new Point(250 + offsetX, 64 + offsetY)
            };

            Point[] fire = {
                new Point(303 + offsetX, 100 + offsetY),
                new Point(274 + offsetX, 107 + offsetY),
                new Point(255 + offsetX, 101 + offsetY),
                new Point(239 + offsetX, 98 + offsetY),
                new Point(244 + offsetX, 93 + offsetY),
                new Point(233 + offsetX, 92 + offsetY),
                new Point(243 + offsetX, 83 + offsetY),
                new Point(235 + offsetX, 76 + offsetY),
                new Point(255 + offsetX, 73 + offsetY),
                new Point(273 + offsetX, 66 + offsetY),
                new Point(302 + offsetX, 72 + offsetY)
            };

            Point[] smallFire = {
                new Point(301 + offsetX, 95 + offsetY),
                new Point(290 + offsetX, 96 + offsetY),
                new Point(277 + offsetX, 93 + offsetY),
                new Point(265 + offsetX, 88 + offsetY),
                new Point(268 + offsetX, 84 + offsetY),
                new Point(274 + offsetX, 80 + offsetY),
                new Point(284 + offsetX, 77 + offsetY),
                new Point(300 + offsetX, 75 + offsetY)
            };

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(204, 153, 0)))
            using (Pen pen = new Pen(Color.FromArgb(255, 255, 0), 4))
            {
                g.FillPolygon(brush, fire);
                g.DrawPolygon(pen, fire);
            }

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 0, 0)))
            {
                g.FillPolygon(brush, smallFire);
            }

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 0, 0)))
            using (Pen pen = new Pen(Color.FromArgb(255, 255, 255), 5))
            {
                g.FillRectangle(brush, 420 + offsetX, 73 + offsetY, 28, 28);
                g.DrawRectangle(pen, 420 + offsetX, 73 + offsetY, 28, 28);
            }


            g.FillEllipse(Brushes.White, 429 + offsetX, 80 + offsetY, 2, 2);
            g.FillEllipse(Brushes.White, 437 + offsetX, 78 + offsetY, 2, 2);
            g.FillEllipse(Brushes.White, 432 + offsetX, 84 + offsetY, 2, 2);
            g.FillEllipse(Brushes.White, 440 + offsetX, 82 + offsetY, 2, 2);
            g.FillEllipse(Brushes.White, 428 + offsetX, 88 + offsetY, 2, 2);
            g.FillEllipse(Brushes.White, 437 + offsetX, 88 + offsetY, 2, 2);
            g.FillEllipse(Brushes.White, 440 + offsetX, 92 + offsetY, 2, 2);
            g.FillEllipse(Brushes.White, 430 + offsetX, 97 + offsetY, 2, 2);
            g.FillEllipse(Brushes.White, 435 + offsetX, 97 + offsetY, 2, 2);
            g.FillEllipse(Brushes.White, 440 + offsetX, 99 + offsetY, 2, 2);

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(153, 153, 153)))
            using (Pen pen = new Pen(Color.FromArgb(205, 205, 205), 4))
            {
                g.DrawLine(pen, 590 + offsetX, 85 + offsetY, 550 + offsetX, 85 + offsetY);
                g.FillPolygon(brush, triangle);
                g.DrawPolygon(pen, triangle);
                g.FillPolygon(brush, wings);
                g.DrawPolygon(pen, wings);
                g.FillRectangle(brush, 444 + offsetX, 68 + offsetY, 58, 38);
                g.DrawRectangle(pen, 444 + offsetX, 68 + offsetY, 58, 38);
                g.FillRectangle(brush, 299 + offsetX, 68 + offsetY, 124, 38);
                g.DrawRectangle(pen, 299 + offsetX, 68 + offsetY, 124, 38);
            }

            g.DrawLine(new Pen(Color.White, 3), 304 + offsetX, 74 + offsetY, 365 + offsetX, 74 + offsetY);
            g.DrawLine(new Pen(Color.Blue, 3), 304 + offsetX, 78 + offsetY, 365 + offsetX, 78 + offsetY);
            g.DrawLine(new Pen(Color.Red, 3), 304 + offsetX, 82 + offsetY, 365 + offsetX, 82 + offsetY);

            Font font = new Font("Arial", 7, FontStyle.Bold);
            Brush b = new SolidBrush(Color.FromArgb(219, 220, 219));
            g.DrawString(" ќ—ћќ‘Ћќ“", font, b, 300 + offsetX, 90 + offsetY);

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 204, 255)))
            using (Pen pen = new Pen(Color.FromArgb(0, 152, 205), 5))
            {
                g.FillEllipse(brush, 370 + offsetX, 76 + offsetY, 18, 18);
                g.DrawEllipse(pen, 370 + offsetX, 76 + offsetY, 18, 18);
                g.FillEllipse(brush, 397 + offsetX, 76 + offsetY, 18, 18);
                g.DrawEllipse(pen, 397 + offsetX, 76 + offsetY, 18, 18);
                g.FillEllipse(brush, 450 + offsetX, 76 + offsetY, 18, 18);
                g.DrawEllipse(pen, 450 + offsetX, 76 + offsetY, 18, 18);
                g.FillEllipse(brush, 476 + offsetX, 76 + offsetY, 18, 18);
                g.DrawEllipse(pen, 476 + offsetX, 76 + offsetY, 18, 18);
            }

        }

        // рисование маленьких звезд
        using (SolidBrush brush = new SolidBrush(Color.White))
        {
            Point[] smallStars = {
                new Point(24, 319),
                new Point(76, 338),
                new Point(141, 326),
                new Point(348, 220),
                new Point(300, 185),
                new Point(167, 178),
                new Point(99, 184),
                new Point(80, 131),
                new Point(14, 142),
                new Point(146, 92),
                new Point(126, 34),
                new Point(195, 36),
                new Point(370, 29),
                new Point(497, 30),
                new Point(597, 29),
                new Point(600, 84),
                new Point(607, 136),
                new Point(523, 137),
                new Point(488, 140)
            };

            foreach (Point p in smallStars)
            {
                g.FillEllipse(brush, p.X - 2, p.Y - 2, 4, 4);
            }
        }
    }


        [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new DrawShapesForm());
    }
}
