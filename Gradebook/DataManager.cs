using System.IO;
using System.Net;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Gradebook
{
    static class DataManager
    {
        public static JsonObject Cache;

        public enum StatusCode
        {
            SUCCESS = 0,
            FAILURE = 1
        }

        public static async Task<StatusCode> FetchAsync(string username, string password)
        {
            string url = "https://gradebook-web-api.herokuapp.com/?username=" + username + "&password=" + password;
            var response = await GetWebResponse(url);

            if (response.ContainsKey("error"))
            {
                return StatusCode.FAILURE;
            }
            else
            {
                Cache = response;
                return StatusCode.SUCCESS;
            }
        }

        private static async Task<JsonObject> GetWebResponse(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";

            var response = (HttpWebResponse)(await request.GetResponseAsync());
            return JsonObject.Parse(new StreamReader(response.GetResponseStream()).ReadToEnd());
        }
    }
}
