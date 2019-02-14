using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CashDeskApi.Models;
using CashDeskApi.Repositories;
using Newtonsoft.Json;

namespace CashDeskApi
{
    public class WebApiService
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
                    var jsonresponse = await client.GetStringAsync(path);
                    camerasList = JsonConvert.DeserializeObject<List<CameraDto>>(jsonresponse);
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
            var stringContent = new StringContent(cameraJson, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PutAsync(path, stringContent))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<ObservableCollection<CashDeskDto>> GetCashDesksAsync(string path)
        {
            using (HttpResponseMessage response = await client.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<CashDeskDto> cashDeskList = null;
                    var Jsonresponse = await client.GetStringAsync(path);
                    cashDeskList = JsonConvert.DeserializeObject<List<CashDeskDto>>(Jsonresponse);
                    ObservableCollection<CashDeskDto> cashDesks = new ObservableCollection<CashDeskDto>(cashDeskList);
                    return cashDesks;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        public static async Task<CashDeskDto> GetCashDeskAsync(string path)
        {
            using (HttpResponseMessage response = await client.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {
                    CashDeskDto cashDesk = null;
                    var jsonresponse = await client.GetStringAsync(path);
                    cashDesk = JsonConvert.DeserializeObject<CashDeskDto>(jsonresponse);
                    return cashDesk;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        
        public static async Task<CameraDto> GetCameraAsync(string path)
        {
            using (HttpResponseMessage response = await client.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {
                    CameraDto camera = null;
                    var jsonresponse = await client.GetStringAsync(path);
                    camera = JsonConvert.DeserializeObject<CameraDto>(jsonresponse);
                    return camera;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        public static async Task<string> ChangeCashDesk(string path, CashDeskDto cashDesk)
        {
            using (HttpResponseMessage response = await
                client.PutAsync(path, new StringContent(JsonConvert.SerializeObject(cashDesk), Encoding.UTF8, "application/json")))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<EventDto> GetEventAsync(string path)
        {
            using (HttpResponseMessage response = await client.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {
                    EventDto eventDto = null;
                    var jsonresponse = await client.GetStringAsync(path);
                    eventDto = JsonConvert.DeserializeObject<EventDto>(jsonresponse);
                    return eventDto;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        public static async Task<string> PostEvent(string path, NewPerson newPerson)
        {
            using (HttpResponseMessage response = await
                client.PostAsync(path, new StringContent(JsonConvert.SerializeObject(newPerson), Encoding.UTF8, "application/json")))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
