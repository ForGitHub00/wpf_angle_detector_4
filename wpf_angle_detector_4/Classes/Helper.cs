using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static wpf_angle_detector_4.DataPoint;

namespace wpf_angle_detector_4 {
    public enum WeldingType{
        IWELDING_TYPE_OVERLAP = 0
    }

    public class Helper{
        private List<double> listX;
        private List<double> listZ;

        public void GetDataFromFile(string fileName) {
            listX = new List<double>();
            listZ = new List<double>();
            string line;
            string temp = "";
            int counter = 0;
            double tempX = 0;
            int index = 0;
            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null) {
                if (line != "") {
                    line = line.Substring(1);
                   // line = line.Substring(17);
                    line = line.Substring(3);
                    counter = 0;
                    temp = "";
                    while (line[counter] != ' ') {
                        temp += line[counter];
                        counter++;
                    }
                    temp = temp.Replace('.', ',');
                    tempX = Convert.ToDouble(temp);
                    line = line.Substring(counter);
                    counter = 0;
                    while (line[counter] == ' ') {
                        counter++;
                    }
                    line = line.Substring(counter + 4);
                    line = line.Replace('.', ',');
                    line = line.Remove(line.Length - 1, 1);

                    listX.Add(tempX);
                    listZ.Add(Convert.ToDouble(line));
                    index++;
                }
            }
        }

        public double[] DataX(){
            return listX.ToArray();
        }
        public double[] DataZ() {
            return listZ.ToArray();
        }
    }
}
