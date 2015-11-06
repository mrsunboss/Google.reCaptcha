using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Google.reCaptcha.WEB.Models
{
    public class GoogleReCaptcha
    {
        public bool Success { get; set; }
        public bool GetCaptchaResponse(string message)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("secret", "{YourSecretKey}"),
                    new KeyValuePair<string, string>("response", message),
                });

                    var result = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content).Result;
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<GoogleReCaptcha>(resultContent);
                    return data.Success;
                }
            }
            catch { return false; }
        }
    }
}