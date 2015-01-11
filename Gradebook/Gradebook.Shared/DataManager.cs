using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Gradebook
{
    struct Assignment
    {
        public readonly DateTime Date;
        public readonly string Name;
        public readonly Course Course;

        public Assignment(string date, string name, Course course)
        {
            this.Date = Convert.ToDateTime(date);
            this.Name = name;
            this.Course = course;
        }
    }

    struct Course
    {
        public readonly string Name;
        public readonly int Period;
        public readonly Tuple<double, string> Grade;

        public Course(string name, int period, Tuple<double, string> grade)
        {
            this.Name = name;
            this.Period = period;
            this.Grade = grade;
        }
    }

    static class DataManager
    {
        public static JsonObject Cache;

        public enum StatusCode
        {
            SUCCESS = 0,
            FAILURE = 1
        }

        public static void ProcessData(JsonObject data)
        {
            
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
