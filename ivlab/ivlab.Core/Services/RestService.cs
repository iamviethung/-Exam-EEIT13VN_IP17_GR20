using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ivlab.Core.Services
{
    public class RestService
    {
        protected readonly HttpService HttpService;
        //TODO: Add host
        public const string DEV_HOST = "http://ivlab.azurewebsites.net/";

        
        public RestService(HttpService httpService)
        {
            HttpService = httpService;
        }


        private readonly JsonSerializerSettings _settings;

        #region BASE
        protected async Task<T> PostAsync<T>(string api, object obj)

        {
            var data = JsonConvert.SerializeObject(obj, _settings);
            Debug.WriteLine($"POST({api}): {data}");
            var response =
                await HttpService.PostAsync(DEV_HOST + api, data, "application/json");
            Debug.WriteLine($"RESPONSE({api}): {response}");
            var temp = JsonConvert.DeserializeObject<ApiResponse<T>>(response);
            if (temp.Successful)
            {
            //    if (temp.Auth != null)
            //    {
            //        App.Data.Profile = temp.Auth;
            //        HttpService.AccessToken = App.Data.Profile.AccessToken;
            //    }

            //    return temp.Data;
            }
            //if (temp.ErrorDesc.Type == Newtonsoft.Json.Linq.JTokenType.String)
            //{
            //    var res = JsonConvert.DeserializeObject<ApiResponse<string>>(response);
            //    throw new ApiException<string>(res);
            //}
            throw new Exception();
        }
        protected async Task<T> GetAsync<T>(string api, bool nocache = false)
        {
            Debug.WriteLine($"GET({api})");

            var response = await HttpService.GetAsync(DEV_HOST + api, nocache);
            Debug.WriteLine($"RESPONSE({api}): {response}");
            var temp = JsonConvert.DeserializeObject<ApiResponse<T>>(response);
            if (temp.Successful)
            {
                //if (temp.Auth != null)
                //{
                //    App.Data.Profile = temp.Auth;
                //    HttpService.AccessToken = App.Data.Profile.AccessToken;
                //}
                return temp.Data;
            }
            throw new Exception();
        }
        #endregion
    }
}
    

