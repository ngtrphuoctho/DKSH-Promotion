using DKSH_Promotion.Objects;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Json;

using System.Net;
using System.IO;
using DKSH_Promotion.Database;

namespace DKSH_Promotion.Helper
{
    public class ApiHelper
    {

        public async Task<bool> insertDataFromAPI()
        {
            bool checkPromo = await checkPromoAPI();
            if (checkPromo)
            {
                JsonValue json = await getPromotionAPI();
                DPDatabase db = new DPDatabase();
                db.addRecord(json);
                return true;
            }
            return false;
        }


        private async Task<JsonValue> getPromotionAPI()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://dksh.somee.com/api/getpromo"));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {

                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    return jsonDoc;


                }
            }
        }

        private async Task<bool> checkPromoAPI()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://dksh.somee.com/api/checkpromo"));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    return bool.Parse(jsonDoc.ToString());


                }
            }
        }
    }
}
