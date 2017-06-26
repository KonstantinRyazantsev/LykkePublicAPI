﻿using System;
using System.IO;
using System.Net.Http;

namespace AzureRepositories
{
    public static class GeneralSettingsReader
    {
        public static T ReadGeneralSettings<T>(string url)
        {
            var httpClient = new HttpClient {BaseAddress = new Uri(url)};
            var settingsData = httpClient.GetStringAsync("").Result;

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(settingsData);
        }

        public static T ReadGeneralSettingsLocal<T>(string path)
        {
            var content = File.ReadAllText(path);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
        }
    }
}
