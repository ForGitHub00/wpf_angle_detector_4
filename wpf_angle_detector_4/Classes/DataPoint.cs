using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_angle_detector_4{
    public class DataPoint{

        public DataPoint(){
            TempSet();
        }

        public string Name { get; set; }
        public double Xmax { get; set; }
        public double Zmax { get; set; }
        public double Xmin { get; set; }
        public double Zmin { get; set; }
        public int DataCount { get; set; }

        public struct Point{
            public double X { get; set; }
            public double Z { get; set; }
        }

        private IDictionary<int, Point> Data { get; set; }

        public Point this[int index]{
            set { Data[index] = value; }
            get { return Data[index]; }
        }


        //-----------------
        public void TempSet(){
            Helper help = new Helper();
            help.GetDataFromFile("out6.txt");
            SetData(help.DataX(),help.DataZ());
        }
        //-----------------

        public void SetData(double[] x, double[] z, string name = "DefaultName"){                    
            this.Name = name;
            DataCount = x.Length;
            Data = new Dictionary<int, Point>();
            for (int i = 0; i < DataCount; i++){
                Data.Add(i, new Point(){
                    X = x[i],
                    Z = z[i]
                });
            }
            CalcProperties();
        }

        public void Usred(double raz){
            for (int i = 1; i < DataCount - 1; i++){
                if (abs(abs(Data[i - 1].Z) - abs(Data[i + 1].Z) ) < raz){
                    Data[i] = new Point(){
                            X = Data[i].X,
                            Z = (Data[i-1].Z + Data[i + 1].Z) / 2
                        };
                }
            }
        }

        private double abs(double value){
            return Math.Abs(value);
        }
        public void CalcProperties(){
            Xmax = Data[0].X;
            Xmin = Data[0].X;
            Zmax = Data[0].Z;
            Zmin = Data[0].Z;
            for (int i = 1; i < DataCount; i++){
                if (Xmax < Data[i].X)
                    Xmax = Data[i].X;               
                else if(Xmin > Data[i].X)
                    Xmin = Data[i].X;

                if (Zmax < Data[i].Z)
                    Zmax = Data[i].Z;
                else if (Zmin > Data[i].Z)
                    Zmin = Data[i].Z;
            }
        }
    }
}
