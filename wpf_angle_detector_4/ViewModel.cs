using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace wpf_angle_detector_4 {
    public  class ViewModel : ViewModelBase {
        public ViewModel(){
            Data = new DataPoint();
            //Data.Usred(5);
            //Data2 = new ObservableCollection<DataPoint>();
            //Data2.Add(Data);
            DataForCanvas = new ObservableCollection<ItemsForCanvas>();
            for (int i = 0; i < Data.DataCount; i++){
                DataForCanvas.Add(new ItemsForCanvas(Data[i].Z, Data[i].X));
            }
      

        }


        public double H { get; set; }
        public double W { get; set; }
        public DataPoint Data { get; }
        public ObservableCollection<DataPoint> Data2 { get; private set; }

        public ObservableCollection<ItemsForCanvas> DataForCanvas { get; set; }

        private ICommand _usred;

        public ICommand Usred{
            get{
                return _usred ?? (_usred = new RelayCommand((() =>{
                           Data.Usred(20);
                           DataForCanvas.Add(new ItemsForCanvas(100, 100));
                       })));
            }
        }

        public void SizeCh(object sender, SizeChangedEventArgs e){
            
        }
    }
}
