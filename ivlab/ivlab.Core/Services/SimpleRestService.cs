using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ivlab.Core.Models;

namespace ivlab.Core.Services
{
    public class SimpleRestService
    {
        public async Task<RootObject> GetDataObject()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://ivlab.azurewebsites.net/getData");
            var result = await response.Result.Content.ReadAsStringAsync();
           
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(result);
        }


        public RootRefObject RootRefObject { get; set; }

        public SimpleRestService()
        {
            RootRefObject = new RootRefObject();
        }

        public void RefObject(RootObject RootObject)
        {

            // TANK 1
            RootRefObject.tank1.description = RootObject.tank1[0].description;
            RootRefObject.tank1.min = RootObject.tank1[1].min;
            RootRefObject.tank1.minDisplay = RootObject.tank1[2].minDisplay;
            RootRefObject.tank1.max = RootObject.tank1[3].max;
            RootRefObject.tank1.maxDisplay = RootObject.tank1[4].maxDisplay;
            RootRefObject.tank1.actual = RootObject.tank1[5].actual;


            // TANK 2
            RootRefObject.tank2.description = RootObject.tank2[0].description;
            RootRefObject.tank2.min = RootObject.tank2[1].min;
            RootRefObject.tank2.minDisplay = RootObject.tank2[2].minDisplay;
            RootRefObject.tank2.max = RootObject.tank2[3].max;
            RootRefObject.tank2.maxDisplay = RootObject.tank2[4].maxDisplay;
            RootRefObject.tank2.actual = RootObject.tank2[5].actual;


            // TANK 3
            RootRefObject.tank3.description = RootObject.tank3[0].description;
            RootRefObject.tank3.min = RootObject.tank3[1].min;
            RootRefObject.tank3.minDisplay = RootObject.tank3[2].minDisplay;
            RootRefObject.tank3.max = RootObject.tank3[3].max;
            RootRefObject.tank3.maxDisplay = RootObject.tank3[4].maxDisplay;
            RootRefObject.tank3.actual = RootObject.tank3[5].actual;

            // PUMP 1
            RootRefObject.pumpe1.description = RootObject.pumpe1[0].description;
            RootRefObject.pumpe1.min = RootObject.pumpe1[1].min;
            RootRefObject.pumpe1.minDisplay = RootObject.pumpe1[2].minDisplay;
            RootRefObject.pumpe1.max = RootObject.pumpe1[3].max;
            RootRefObject.pumpe1.maxDisplay = RootObject.pumpe1[4].maxDisplay;
            RootRefObject.pumpe1.actual = RootObject.pumpe1[5].actual;


            //PUMP 2
            RootRefObject.pumpe2.description = RootObject.pumpe2[0].description;
            RootRefObject.pumpe2.min = RootObject.pumpe2[1].min;
            RootRefObject.pumpe2.minDisplay = RootObject.pumpe2[2].minDisplay;
            RootRefObject.pumpe2.max = RootObject.pumpe2[3].max;
            RootRefObject.pumpe2.maxDisplay = RootObject.pumpe2[4].maxDisplay;
            RootRefObject.pumpe2.actual = RootObject.pumpe2[5].actual;

            // PUMP 3
            RootRefObject.pumpe3.description = RootObject.pumpe3[0].description;
            RootRefObject.pumpe3.min = RootObject.pumpe3[1].min;
            RootRefObject.pumpe3.minDisplay = RootObject.pumpe3[2].minDisplay;
            RootRefObject.pumpe3.max = RootObject.pumpe3[3].max;
            RootRefObject.pumpe3.maxDisplay = RootObject.pumpe3[4].maxDisplay;
            RootRefObject.pumpe3.actual = RootObject.pumpe3[5].actual;

            //Adg1
            RootRefObject.adg1.description = RootObject.adg1[0].description;
            RootRefObject.adg1.min = RootObject.adg1[1].min;
            RootRefObject.adg1.minDisplay = RootObject.adg1[2].minDisplay;
            RootRefObject.adg1.max = RootObject.adg1[3].max;
            RootRefObject.adg1.maxDisplay = RootObject.adg1[4].maxDisplay;
            RootRefObject.adg1.actual = RootObject.adg1[5].actual;


            // Adg2
            RootRefObject.adg2.description = RootObject.adg2[0].description;
            RootRefObject.adg2.min = RootObject.adg2[1].min;
            RootRefObject.adg2.minDisplay = RootObject.adg2[2].minDisplay;
            RootRefObject.adg2.max = RootObject.adg2[3].max;
            RootRefObject.adg2.maxDisplay = RootObject.adg2[4].maxDisplay;
            RootRefObject.adg2.actual = RootObject.adg2[5].actual;

            //Adg3
            RootRefObject.adg3.description = RootObject.adg3[0].description;
            RootRefObject.adg3.min = RootObject.adg3[1].min;
            RootRefObject.adg3.minDisplay = RootObject.adg3[2].minDisplay;
            RootRefObject.adg3.max = RootObject.adg3[3].max;
            RootRefObject.adg3.maxDisplay = RootObject.adg3[4].maxDisplay;
            RootRefObject.adg3.actual = RootObject.adg3[5].actual;

            //gas1
            RootRefObject.gas1.description = RootObject.gas1[0].description;
            RootRefObject.gas1.min = RootObject.gas1[1].min;
            RootRefObject.gas1.minDisplay = RootObject.gas1[2].minDisplay;
            RootRefObject.gas1.max = RootObject.gas1[3].max;
            RootRefObject.gas1.maxDisplay = RootObject.gas1[4].maxDisplay;
            RootRefObject.gas1.actual = RootObject.gas1[5].actual;

            //gas 2
            RootRefObject.gas2.description = RootObject.gas2[0].description;
            RootRefObject.gas2.min = RootObject.gas2[1].min;
            RootRefObject.gas2.minDisplay = RootObject.gas2[2].minDisplay;
            RootRefObject.gas2.max = RootObject.gas2[3].max;
            RootRefObject.gas2.maxDisplay = RootObject.gas2[4].maxDisplay;
            RootRefObject.gas2.actual = RootObject.gas2[5].actual;


        }
    }
}
