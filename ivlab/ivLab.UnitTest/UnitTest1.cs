using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ivlab.Core.Models;
using ivlab.Core.Services;
using ivlab.Core.ViewModels;
using ivlab.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ivLab.UnitTest
{
    [TestClass]
    public class TestApi
    {
        [TestMethod]
        public void GetData()
        {
            //HttpService service = new HttpService("");
            //service.GetAsync("http://ivlab.azurewebsites.net/getData");

            SimpleRestService service = new SimpleRestService();
            var result = service.GetDataObject();


            


            //Tank1 tank1 = new Tank1();
            //Tank2 tank2 = new Tank2();
            //Tank3 tank3 = new Tank3();

            //Pumpe1 pumpe1 = new Pumpe1();
            //Pumpe2 pumpe2 = new Pumpe2();
            //Pumpe3 pumpe3 = new Pumpe3();

            //Adg1 adg1 = new Adg1();
            //Adg2 adg2 = new Adg2();
            //Adg3 adg3 = new Adg3();

            //Gas1 gas1 = new Gas1();
            //Gas2 gas2 = new Gas2();

            //// TANK 1
            //tank1.description = result.Result.tank1[0].description;
            //tank1.min = result.Result.tank1[1].min;
            //tank1.minDisplay = result.Result.tank1[2].minDisplay;
            //tank1.max = result.Result.tank1[3].max;
            //tank1.maxDisplay = result.Result.tank1[4].maxDisplay;
            //tank1.actual = result.Result.tank1[5].actual;


            //// TANK 2
            //tank2.description = result.Result.tank2[0].description;
            //tank2.min = result.Result.tank2[1].min;
            //tank2.minDisplay = result.Result.tank2[2].minDisplay;
            //tank2.max = result.Result.tank2[3].max;
            //tank2.maxDisplay = result.Result.tank2[4].maxDisplay;
            //tank2.actual = result.Result.tank2[5].actual;

            //// TANK 3

            //tank3.description = result.Result.tank3[0].description;
            //tank3.min = result.Result.tank3[1].min;
            //tank3.minDisplay = result.Result.tank3[2].minDisplay;
            //tank3.max = result.Result.tank3[3].max;
            //tank3.maxDisplay = result.Result.tank3[4].maxDisplay;
            //tank3.actual = result.Result.tank3[5].actual;

            //// PUMP 1
            //pumpe1.description = result.Result.pumpe1[0].description;
            //pumpe1.min = result.Result.pumpe1[1].min;
            //pumpe1.minDisplay = result.Result.pumpe1[2].minDisplay;
            //pumpe1.max = result.Result.pumpe1[3].max;
            //pumpe1.maxDisplay = result.Result.pumpe1[4].maxDisplay;
            //pumpe1.actual = result.Result.pumpe1[5].actual;

            ////PUMP 2
            //pumpe2.description = result.Result.pumpe2[0].description;
            //pumpe2.min = result.Result.pumpe2[1].min;
            //pumpe2.minDisplay = result.Result.pumpe2[2].minDisplay;
            //pumpe2.max = result.Result.pumpe2[3].max;
            //pumpe2.maxDisplay = result.Result.pumpe2[4].maxDisplay;
            //pumpe2.actual = result.Result.pumpe2[5].actual;


            //// PUMP 3
            //pumpe3.description = result.Result.pumpe3[0].description;
            //pumpe3.min = result.Result.pumpe3[1].min;
            //pumpe3.minDisplay = result.Result.pumpe3[2].minDisplay;
            //pumpe3.max = result.Result.pumpe3[3].max;
            //pumpe3.maxDisplay = result.Result.pumpe3[4].maxDisplay;
            //pumpe3.actual = result.Result.pumpe3[5].actual;

            ////Adg1
            //adg1.description = result.Result.adg1[0].description;
            //adg1.min = result.Result.adg1[1].min;
            //adg1.minDisplay = result.Result.adg1[2].minDisplay;
            //adg1.max = result.Result.adg1[3].max;
            //adg1.maxDisplay = result.Result.adg1[4].maxDisplay;
            //adg1.actual = result.Result.adg1[5].actual;

            //// Adg2
            //adg2.description = result.Result.adg2[0].description;
            //adg2.min = result.Result.adg2[1].min;
            //adg2.minDisplay = result.Result.adg2[2].minDisplay;
            //adg2.max = result.Result.adg2[3].max;
            //adg2.maxDisplay = result.Result.adg2[4].maxDisplay;
            //adg2.actual = result.Result.adg2[5].actual;

            ////Adg3
            //adg3.description = result.Result.adg3[0].description;
            //adg3.min = result.Result.adg3[1].min;
            //adg3.minDisplay = result.Result.adg3[2].minDisplay;
            //adg3.max = result.Result.adg3[3].max;
            //adg3.maxDisplay = result.Result.adg3[4].maxDisplay;
            //adg3.actual = result.Result.adg3[5].actual;

            ////gas1
            //gas1.description = result.Result.gas1[0].description;
            //gas1.min = result.Result.gas1[1].min;
            //gas1.minDisplay = result.Result.gas1[2].minDisplay;
            //gas1.max = result.Result.gas1[3].max;
            //gas1.maxDisplay = result.Result.gas1[4].maxDisplay;
            //gas1.actual = result.Result.gas1[5].actual;


            ////gas 2
            //gas2.description = result.Result.gas2[0].description;
            //gas2.min = result.Result.gas2[1].min;
            //gas2.minDisplay = result.Result.gas2[2].minDisplay;
            //gas2.max = result.Result.gas2[3].max;
            //gas2.maxDisplay = result.Result.gas2[4].maxDisplay;
            //gas2.actual = result.Result.gas2[5].actual;

            service.RefObject(result.Result);


        }


        [TestMethod]
        public void CallExportService()
        {
            ExportToExcel export = new ExportToExcel();

            ObservableCollection<RefTimestamp> a = new ObservableCollection<RefTimestamp>();
            RefTimestamp b = new RefTimestamp();
            b.Timestamp = "12:00";
            b.RootRefObject.tank1.max = 1;
            b.RootRefObject.tank1.min = 2;
            b.RootRefObject.tank1.actual = "3";
            a.Add(b);
            
           // export.ExportData(a, new List<bool> { true,false});
        }





    }
}
