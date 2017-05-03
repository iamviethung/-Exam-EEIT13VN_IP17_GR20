using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivlab.Core.Models;
using ivlab.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Threading;

namespace ivlab.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {

        public IMvxCommand SecondViewCommand { get; set; }

        public ObservableCollection<RefTimestamp> RootRefObjects { get; set; }

        
        public void GetData()
        {
            SimpleRestService service = new SimpleRestService();
            var result = service.GetDataObject();
            service.RefObject(result.Result);
            RefTimestamp refTimestamp = new RefTimestamp();
            refTimestamp.RootRefObject = service.RootRefObject;
            refTimestamp.Timestamp = DateTime.Now.ToString();
            RootRefObjects.Add(refTimestamp);
            Debug.WriteLine(RootRefObjects.Count);
        }


        public FirstViewModel()
        {
            RootRefObjects = new MvxObservableCollection<RefTimestamp>();
            SecondViewCommand = new MvxCommand(() =>
            {
                if (RootRefObjects.Count > 0)
                    ShowViewModel<SecondViewModel>(RootRefObjects);
                else
                    ShowViewModel<SecondViewModel>();
            });
            
            
        }

    }
}
