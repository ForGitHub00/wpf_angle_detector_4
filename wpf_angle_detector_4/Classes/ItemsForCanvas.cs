using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace wpf_angle_detector_4 {
    public class ItemsForCanvas {

        public ItemsForCanvas(double z, double x){
            Z = z;
            X = x;
            Random rnd = new Random();
            /*Rec = new Rectangle(){
                Height = 2,
                Width = 2,
                Fill = Brushes.Red
            };
            X = rnd.Next(1, 500)*rnd.NextDouble() * a;
            Z = rnd.Next(1, 500)*rnd.NextDouble();*/
            Tit = rnd.Next(0, 1000).ToString();
        }
        public string Tit { get; set; }
        public double X { get; set; }
        public double Z { get; set; }
        public Rectangle Rec { get; set; }
    }
}
