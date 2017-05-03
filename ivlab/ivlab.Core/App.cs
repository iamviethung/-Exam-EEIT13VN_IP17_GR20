using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivlab.Core.ViewModels;
using MvvmCross.Binding.Combiners;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ivlab.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            //TODO: Registration Start VM 
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<FirstViewModel>());
        }
    }
}
