using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace wpf_angle_detector_4 {
    /// <summary>
    /// Логика взаимодействия для DataViewerControl.xaml
    /// </summary>
    public partial class DataViewerControl : UserControl{
        public DataViewerControl(){
            InitializeComponent();
            //Data = new DataPoint();
            this.SizeChanged += DataViewerControl_SizeChanged;
            Data = (DataPoint) this.DataContext;
            EllipseDictionary = new Dictionary<Ellipse, int>();
        }
        public DataPoint Data { set; get; }
        private Dictionary<Ellipse, int> EllipseDictionary;

        private double XOffset;
        private double ZOffset;

        private void DataViewerControl_SizeChanged(object sender, SizeChangedEventArgs e){
            //Console.WriteLine($"W = {this.Width} -----  H = {this.Height}");
            Console.WriteLine($"W = {this.ActualWidth} -----  H = {this.ActualHeight}\n");

            if (CheckBox_Proporc.IsChecked == true){
                this.Height = this.Width;
                Window w =(Window)((Grid) this.Parent).Parent;
                w.Height = w.Width;
            }

            var t = (ObservableCollection<DataPoint>)this.DataContext;
            Data = (DataPoint)t[0];
            if (Data != null){
                Cnv.Children.Clear();
                DrawCells();
                DrawPoints();
            }

        }

        public void DrawCells(){
           
            //int countX = (int)Math.Abs(Data.Xmin/10) + (int)Math.Abs(Data.Xmax / 10) + 2;
            int countX = 16;
            double stepX = Cnv.ActualWidth/countX;           
            for (int i = 1; i < countX; i++){
                Line l = new Line();
                l.X1 = l.X2 = stepX*i;
                l.Y1 = 0;
                l.Y2 = Cnv.ActualHeight;
                l.Fill = Brushes.MediumSeaGreen;
                l.StrokeThickness = 1;
                l.StrokeDashArray = new DoubleCollection(){2, 2, 3, 2, 2};
                l.Stroke = Brushes.Black;

                TextBlock tb = new TextBlock(){
                    Text = (i*10 - 80).ToString()
                };
                Canvas.SetLeft(tb, stepX*i - 10);
                Canvas.SetTop(tb, Cnv.ActualHeight + 10);
                Cnv.Children.Add(tb);
                Cnv.Children.Add(l);
            }

            int countZ = 27;
            double stepZ = Cnv.ActualHeight/countZ;

            for (int i = 1; i < countZ; i++){
                Line l = new Line();
                l.Y1 = l.Y2 = stepZ*i;
                l.X1 = 0;
                l.X2 = Cnv.ActualWidth;
                l.Fill = Brushes.MediumSeaGreen;
                l.StrokeThickness = 1;
                l.StrokeDashArray = new DoubleCollection(){2, 2, 3, 2, 2};
                l.Stroke = Brushes.Black;

                TextBlock tb = new TextBlock(){
                    Text = (i*10 + 120).ToString()
                };
                Canvas.SetTop(tb, stepZ*i - 10);
                Canvas.SetLeft(tb, Cnv.ActualWidth + 10);
                Cnv.Children.Add(tb);
                Cnv.Children.Add(l);
            }
        }

        public void DrawPoints(){
            EllipseDictionary.Clear();
            XOffset = Cnv.ActualWidth / 160;
            ZOffset = Cnv.ActualHeight / 270;
            for (int i = 0; i < Data.DataCount; i++){
                Ellipse el = new Ellipse(){
                    Height = 2, 
                    Width = 2, 
                    Fill = Brushes.DarkRed
                };
                el.MouseEnter += El_MouseEnter;
                Canvas.SetLeft(el, XOffset * (Data[i].X + 80));
                Canvas.SetTop(el, ZOffset * (Data[i].Z - 120));
                Cnv.Children.Add(el);
                EllipseDictionary.Add(el, i);
            }
        }

        private void El_MouseEnter(object sender, MouseEventArgs e){
            int index = EllipseDictionary[(Ellipse) sender];
            Console.WriteLine($"X = {Data[index].X} -----  Z = {Data[index].Z}");
            
        }

  
    }
}
