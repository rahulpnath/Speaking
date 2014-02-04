using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Samples.PCL;

namespace Samples
{
    public partial class ReusablePage : PhoneApplicationPage
    {
        public ReusablePage()
        {
            InitializeComponent();
            this.DataContext = new ReuseableVM();
        }
    }
}