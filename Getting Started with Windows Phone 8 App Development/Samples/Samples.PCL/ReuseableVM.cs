using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples.PCL
{
    public class ReuseableVM: ViewModelBase
    {
        private string name;

        public RelayCommand ClickedCommand { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        public ReuseableVM()
        {
            ClickedCommand = new RelayCommand(this.OnClickedCommand);
        }

        private void OnClickedCommand()
        {
            this.Name = "Hello World";
        }
    }
}
