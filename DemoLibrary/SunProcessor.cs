using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace DemoLibrary
{
    public class SunProcessor
    {

        public static async Task<SunModel> LoadSunInformation()
        {
            string url = "http://api.sunrise-sunset.org/json?lat=52.18935&lng=-2.22001&date=today";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResultModel result = await response.Content.ReadAsAsync<SunResultModel>();

                    return result.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
