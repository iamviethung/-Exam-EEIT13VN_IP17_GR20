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

namespace ivlab.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {

        public IMvxCommand DisplayCommand { get; set; }

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


        public SecondViewModel()
        {
         RootRefObjects = new ObservableCollection<RefTimestamp>();
         DisplayCommand = new MvxCommand(() =>
         {
             ShowViewModel<FirstViewModel>();
         });           
        }
        

      
    }
}
