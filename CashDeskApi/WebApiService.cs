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
        private static string baseUrl = "http://localhost:56985/api";
        private static HttpClient client;

        public static void Initialize()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        //Get All Cameras
        public static async Task<ObservableCollection<CameraDto>> GetCamerasAsync()
        {
            using (HttpResponseMessage response = await client.GetAsync($"{baseUrl}/Cameras"))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<CameraDto> camerasList = null;
                    var jsonresponse = await client.GetStringAsync($"{baseUrl}/Cameras");
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


        // Change a given camera
        public static async Task<string> ChangeCamera(CameraDto camera)
        {
            var cameraJson = JsonConvert.SerializeObject(camera);
            var stringContent = new StringContent(cameraJson, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PutAsync($"{baseUrl}/Cameras", stringContent))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        // Get All cash desks
        public static async Task<ObservableCollection<CashDeskDto>> GetCashDesksAsync()
        {
            using (HttpResponseMessage response = await client.GetAsync($"{baseUrl}/CashDesks"))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<CashDeskDto> cashDeskList = null;
                    var Jsonresponse = await client.GetStringAsync($"{baseUrl}/CashDesks");
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

        // Get cash desk by id
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

        // Get camera by id
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

        // Change a given cash desk
        public static async Task<string> ChangeCashDesk( CashDeskDto cashDesk)
        {
            using (HttpResponseMessage response = await
                client.PutAsync($"{baseUrl}/CashDesks", new StringContent(JsonConvert.SerializeObject(cashDesk), Encoding.UTF8, "application/json")))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        //Get all events for the day
        public static async Task<EventDto> GetEventAsync()
        {
            using (HttpResponseMessage response = await client.GetAsync($"{baseUrl}/Report"))
            {
                if (response.IsSuccessStatusCode)
                {
                    EventDto eventDto = null;
                    var jsonresponse = await client.GetStringAsync($"{baseUrl}/Report");
                    eventDto = JsonConvert.DeserializeObject<EventDto>(jsonresponse);
                    return eventDto;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        // Post new event
        public static async Task<string> PostEvent(NewPerson newPerson)
        {
            using (HttpResponseMessage response = await
                client.PostAsync($"{baseUrl}/Report", new StringContent(JsonConvert.SerializeObject(newPerson), Encoding.UTF8, "application/json")))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
