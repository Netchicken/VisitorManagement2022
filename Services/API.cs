using Newtonsoft.Json;

using System.Diagnostics;
using System.Net.Http.Headers;

using VisitorManagement.Operations;

namespace VisitorManagement.Services
{
    public class API : IAPI
    {


        //8827252724a06575e5be376a09a53736

        //https://openweathermap.org/api/one-call-3
        //https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude={part}&appid={API key}

        //https://api.openweathermap.org/data/2.5/weather?q=Christchurch&units=metric&appid=8827252724a06575e5be376a09a53736

        //{"coord":{"lon":172.6333,"lat":-43.5333},
        //"weather":[{"id":803,"main":"Clouds",
        //"description":"broken clouds","icon":"04d"}],
        //"base":"stations",
        //"main":{"temp":10.91,"feels_like":10.04,"temp_min":9.11,"temp_max":13.01,"pressure":1027,"humidity":76},
        //"visibility":10000,"wind":{ "speed":4.12,"deg":40},
        //"clouds":{ "all":75},"dt":1663882823,
        //"sys":{ "type":2,"id":2017931,
        //"country":"NZ","sunrise":1663870682,"sunset":1663914370},
        //"timezone":43200,"id":2192362,
        //"name":"Christchurch","cod":200}

        public async Task<Root> WeatherAPI()
        {
            // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
            HttpClient client = new HttpClient();
            string responseBody = null;
            string apiKey = "8827252724a06575e5be376a09a53736";
            string URL = "https://api.openweathermap.org/data/2.5/weather?q=Christchurch&units=metric&appid=" + apiKey;


            /*http://json2csharp.com*/


            responseBody = await client.GetStringAsync(URL);

            Root root = JsonConvert.DeserializeObject<Root>(responseBody);

            Debug.WriteLine(root.main.feels_like);
            

            return root;
        }


        //not used
        public Weather WeatherApiResult()
        {
            Weather weather = null;
            Task t = Task.Factory.StartNew(async () =>
            {
                string city = "London";
                string apiKey = "8827252724a06575e5be376a09a53736";
                string URL = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=" + apiKey;

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("apiKey", $"{apiKey}");

                var httpResponse = await client.GetAsync($"{URL}");
                var response = await httpResponse.Content.ReadAsStringAsync();
                weather = JsonConvert.DeserializeObject<Weather>(response);

            });
            return weather;



        }
    }
}
