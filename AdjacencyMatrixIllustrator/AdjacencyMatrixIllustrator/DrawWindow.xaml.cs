using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdjacencyMatrixIllustrator
{
    /// <summary>
    /// Interaction logic for DrawWindow.xaml
    /// </summary>
    public partial class DrawWindow : Window
    {
        public DrawWindow(Grid grid)
        {
            InitializeComponent();
            DrawCircles(grid);
        }

        void DrawCircles(Grid grid)
        {
            Point center = new Point(Width * 0.5, Height * 0.5);

            DrawCircle(center);

            for (int i = 0; i < 8; i++)
            {
                bool NoEdges = true;

                for (int j = 0; j < 8; j++)
                {
                    //Got close but couldn't figure out how to do this correctly.
                    //What I'm trying to do is determine if the checkbox in the grid's (i, j) coordinate is checked, but I can't figure out how to make it work.
                    //As of now, it auto-draws everything if any box is checked. I know why it does that, but I don't know how to make it work as intended.
                    foreach (var checkBox in grid.Children.OfType<CheckBox>().Where(cb => (bool)cb.IsChecked))
                    {
                        DrawLine(GetPointFromNum(i), GetPointFromNum(j));
                        NoEdges = false;
                    }
                }

                if (NoEdges && i > 2)    //Stop drawing circles under the assumption the user doesn't want to draw more than a certain size. Ignored if under a certain number of loops to keep with the minimum 3 count requirement.
                {
                    break;
                }

                DrawCircle(GetPointFromNum(i));
            }
        }

        Point GetPointFromNum(int num)
        {
            Point center = new Point(Width * 0.5, Height * 0.5);

            switch (num)
            {
                case 0:
                    return new Point(center.X, center.Y - 100.0);
                case 1:
                    return new Point(center.X + 75.0, center.Y - 75.0);
                case 2:
                    return new Point(center.X + 100, center.Y);
                case 3:
                    return new Point(center.X + 75.0, center.Y + 75.0);
                case 4:
                    return new Point(center.X, center.Y + 100.0);
                case 5:
                    return new Point(center.X - 75.0, center.Y + 75.0);
                case 6:
                    return new Point(center.X - 100.0, center.Y);
                case 7:
                    return new Point(center.X - 75.0, center.Y - 75.0);
                default:
                    return center;
            }
        }

        void DrawCircle(Point point)
        {
            Ellipse Circle = new Ellipse();
            Circle.Height = 20;
            Circle.Width = 20;

            SolidColorBrush Brush = new SolidColorBrush();
            Brush.Color = Colors.Black;
            Circle.StrokeThickness = 2;
            Circle.Stroke = Brush;
            Circle.SetValue(Canvas.LeftProperty, point.X - 10);
            Circle.SetValue(Canvas.TopProperty, point.Y - 10);

            Canvas.Children.Add(Circle);
        }

        void DrawLine(Point point1, Point point2)
        {
            Line line = new Line();
            line.X1= point1.X;
            line.Y1 = point1.Y;
            line.X2 = point2.X;
            line.Y2 = point2.Y;

            SolidColorBrush Brush = new SolidColorBrush();
            Brush.Color = Colors.Black;
            line.StrokeThickness = 2;
            line.Stroke = Brush;

            Canvas.Children.Add(line);
        }
    }
}
