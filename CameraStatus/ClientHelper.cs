using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using CashDeskApi.Models;
using Newtonsoft.Json;

namespace CameraStatus
{
    public static class ClientHelper
    {
        private static HttpClient client;

        public static void Initialize()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static async Task<ObservableCollection<CameraDto>> GetCamerasAsync(string path)
        {
            using (HttpResponseMessage response = await client.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<CameraDto> camerasList = null;
                    var Jsonresponse = await client.GetStringAsync(path);
                    camerasList = JsonConvert.DeserializeObject<List<CameraDto>>(Jsonresponse);
                    ObservableCollection<CameraDto> cameras = new ObservableCollection<CameraDto>(camerasList);
                    return cameras;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        public static async Task<string> ChangeCamera(string path, CameraDto camera)
        {
            var cameraJson = JsonConvert.SerializeObject(camera);
            var stringContent = new StringContent(cameraJson, UnicodeEncoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PutAsync(path, stringContent))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }

        
    
}
