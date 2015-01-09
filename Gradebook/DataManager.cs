using System.IO;
using System.Net;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Gradebook
{
    class DataManager
    {
        public static JsonObject Cache;

        public enum StatusCode
        {
            SUCCESS = 0,
            FAILURE = 1
        }

        public readonly string Username;
        public readonly string Password;

        public DataManager(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public async Task<StatusCode> Fetch(object sender, object e)
        {
            string url = "https://gradebook-web-api.herokuapp.com/?username=" + this.Username + "&password=" + this.Password;
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

            using (var response = (HttpWebResponse)(await request.GetResponseAsync()))
            {
                return JsonObject.Parse(new StreamReader(response.GetResponseStream()).ReadToEnd());
            }
        }
    }
}
