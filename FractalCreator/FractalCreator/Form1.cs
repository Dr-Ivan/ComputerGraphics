using System;
using System.Drawing;
using System.Windows.Forms;

namespace FractalCreator
{
    public partial class Form1 : Form
    {
        private const float MinX = -1f;
        private const float MaxX = 1f;
        private const float MinY = 0f;
        private const float MaxY = 1f;

        private const int PointNumber = 200000;

        private float[] _probability = new float[3]
        {
            0.333333f,
            0.333333f,
            0.333334f
        };

        private float[,] _funcCoef = new float[3, 6]
        {
            // a,    b,    c,    d,     e,     f
            { 0.5f, 0.0f, 0.0f, 0.5f,  0.00f, 0.5f  }, // верхний треугольник
            { 0.5f, 0.0f, 0.0f, 0.5f, -0.25f, 0.0f  }, // левый нижний
            { 0.5f, 0.0f, 0.0f, 0.5f,  0.25f, 0.0f  }  // правый нижний
        };

        private int _width;
        private int _height;
        private Bitmap _canvas;
        private Graphics _graphics;

        public Form1()
        {
            InitializeComponent();

            _width = FernPictureBox.Width;
            _height = FernPictureBox.Height;
            _canvas = new Bitmap(_width, _height);
            _graphics = Graphics.FromImage(_canvas);
            _graphics.Clear(Color.Black);

            DrawFractal();

            FernPictureBox.Image = _canvas;
        }

        private void DrawFractal()
        {
            Random rnd = new Random();
            float x = 0, y = 0;
            int transformIndex = 0;

            for (int i = 0; i < PointNumber; i++)
            {
                double r = rnd.NextDouble();
                double cumulative = 0;

                for (int j = 0; j < _probability.Length; j++)
                {
                    cumulative += _probability[j];
                    if (r <= cumulative)
                    {
                        transformIndex = j;
                        break;
                    }
                }

                float a = _funcCoef[transformIndex, 0];
                float b = _funcCoef[transformIndex, 1];
                float c = _funcCoef[transformIndex, 2];
                float d = _funcCoef[transformIndex, 3];
                float e = _funcCoef[transformIndex, 4];
                float f = _funcCoef[transformIndex, 5];

                float xNew = a * x + b * y + e;
                float yNew = c * x + d * y + f;

                x = xNew;
                y = yNew;

                int px = (int)((x - MinX) / (MaxX - MinX) * _width);
                int py = _height - (int)((y - MinY) / (MaxY - MinY) * _height);

                if (px >= 0 && px < _width && py >= 0 && py < _height)
                    _canvas.SetPixel(px, py, Color.LawnGreen);
            }
        }
    }
}
