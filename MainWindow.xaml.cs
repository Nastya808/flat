using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Flat
{
    public partial class MainWindow : Window
    {
        private UIElement selectedElement;

        public MainWindow()
        {
            InitializeComponent();

            mapCanvas.MouseLeftButtonDown += MapCanvas_MouseLeftButtonDown;
            mapCanvas.MouseMove += MapCanvas_MouseMove;
            mapCanvas.MouseLeftButtonUp += MapCanvas_MouseLeftButtonUp;
        }

        private void MapCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedElement = e.Source as UIElement;
        }

        private void MapCanvas_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (selectedElement != null && e.LeftButton == MouseButtonState.Pressed)
            {
                double newX = e.GetPosition(mapCanvas).X - selectedElement.RenderSize.Width / 2;
                double newY = e.GetPosition(mapCanvas).Y - selectedElement.RenderSize.Height / 2;

                Canvas.SetLeft(selectedElement, newX);
                Canvas.SetTop(selectedElement, newY);
            }
        }

        private void MapCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            selectedElement = null;
        }
    }
}
