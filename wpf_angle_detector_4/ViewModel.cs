using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace wpf_angle_detector_4 {
    public  class ViewModel : ViewModelBase {
        public ViewModel(){
            Data = new DataPoint();
            //Data.Usred(5);
            Data2 = new ObservableCollection<DataPoint>();
            Data2.Add(Data);
        }
        public DataPoint Data { get; }
        public ObservableCollection<DataPoint> Data2 { get; private set; }
        

        private ICommand _usred;

        public ICommand Usred{
            get { return _usred ?? (_usred = new RelayCommand((() => Data2[0].Usred(20)))); }
        }
    }
}
