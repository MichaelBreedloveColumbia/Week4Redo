using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdjacencyMatrixIllustrator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateBoxesAndBlocks();
        }

        void CreateBoxesAndBlocks()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 0 && j > 0 || j == 0 && i > 0)
                    {
                        System.Windows.Controls.TextBlock txt = new System.Windows.Controls.TextBlock();
                        txt.Name = i > 0 ? "HorizontalText" + i : "VerticalText" + j;
                        txt.Text = "V" + (i > 0 ? i - 1 : j - 1);
                        txt.HorizontalAlignment = HorizontalAlignment.Center;
                        txt.VerticalAlignment = VerticalAlignment.Center;
                        Grid.SetColumn(txt, i);
                        Grid.SetRow(txt, j);
                        Grid.Children.Add(txt);
                    }
                    else if (i != 0 && j != 0)
                    {
                        System.Windows.Controls.CheckBox check = new System.Windows.Controls.CheckBox();
                        check.Name = i > 0 ? "HorizontalInput" + i : "VerticalInput" + j;
                        Grid.SetColumn(check, i);
                        Grid.SetRow(check, j);
                        Grid.Children.Add(check);
                    }
                }
            }
        }

        private void DrawClicked(object sender, RoutedEventArgs e)
        {
            DrawWindow GraphWindow = new DrawWindow(Grid);
            GraphWindow.Show();
        }
    }
}
