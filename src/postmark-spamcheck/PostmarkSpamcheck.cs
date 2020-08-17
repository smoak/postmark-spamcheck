using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;

namespace postmarkspamcheck
{
    public class PostmarkSpamcheck
    {
        private HttpClient client;

        private DataContractJsonSerializer requestSerializer;

        private DataContractJsonSerializer responseSerializer;
        private const string SPAMCHECK_URL = "https://spamcheck.postmarkapp.com/filter";
        public PostmarkSpamcheck(HttpClient client)
        {
            this.client = client;
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.responseSerializer = new DataContractJsonSerializer(typeof(SpamcheckResult), new DataContractJsonSerializerSettings()
            {
                UseSimpleDictionaryFormat = true
            });
            this.requestSerializer = new DataContractJsonSerializer(typeof(SpamcheckBody), new DataContractJsonSerializerSettings()
            {
                UseSimpleDictionaryFormat = true
            });
        }

        public PostmarkSpamcheck() : this(new HttpClient()) { }
        public async Task<SpamcheckResult> GetScore(string emailBody)
        {
            var json = SerializeToJson(emailBody, SpamcheckOptions.Short);
            return await this.MakeRequest(json);
        }

        public async Task<SpamcheckResult> GetReport(string emailBody)
        {
            var json = SerializeToJson(emailBody, SpamcheckOptions.Long);
            return await this.MakeRequest(json);
        }

        private async Task<SpamcheckResult> MakeRequest(string json)
        {
            var response = await this.client.PostAsync(SPAMCHECK_URL, new StringContent(json, Encoding.UTF8, "application/json"));
            return responseSerializer.ReadObject(await response.Content.ReadAsStreamAsync()) as SpamcheckResult;
        }

        private string SerializeToJson(string emailBody, SpamcheckOptions options)
        {
            var obj = new SpamcheckBody { email = emailBody, options = options.Value };
            using (MemoryStream ms = new MemoryStream())
            {
                this.requestSerializer.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
