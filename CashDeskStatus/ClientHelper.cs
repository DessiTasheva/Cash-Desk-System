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

namespace CashDeskStatus
{
    public class ClientHelper
    {
        public static HttpClient client;
        public static void Initialize()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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

        public static async Task<string> ChangeCashDesk(string path, CashDeskDto cashDesk)
        {
            using (HttpResponseMessage response = await
                client.PutAsync(path, new StringContent(JsonConvert.SerializeObject(cashDesk), Encoding.UTF8, "application/json")))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

    }
}
