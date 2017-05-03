using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace ivlab.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private const string ParameterName = "parameter";

        protected void ShowViewModel<TViewModel>(object parameter)
            where TViewModel : IMvxViewModel
        {
            var text = Mvx.Resolve<IMvxJsonConverter>().SerializeObject(parameter);
            base.ShowViewModel<TViewModel>(new Dictionary<string, string>()
            {
                {ParameterName, text}
            });
        }
    }

    public abstract class BaseViewModel<TInit>
    : MvxViewModel
    {
        public void Init(string parameter)
        {
            var deserialized = Mvx.Resolve<IMvxJsonConverter>().DeserializeObject<TInit>(parameter);
            RealInit(deserialized);
        }

        protected abstract void RealInit(TInit parameter);
    }
}
