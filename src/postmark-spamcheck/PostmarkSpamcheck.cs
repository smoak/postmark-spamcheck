using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;

namespace postmarkspamcheck
{
  public class PostmarkSpamcheck
  {
    private HttpClient client;

    private DataContractJsonSerializer serializer;
    private const string SPAMCHECK_URL = "https://spamcheck.postmarkapp.com/filter";
    public PostmarkSpamcheck(HttpClient client)
    {
      this.client = client;
      this.client.DefaultRequestHeaders.Accept.Clear();
      this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      this.serializer = new DataContractJsonSerializer(typeof(SpamcheckResult), new DataContractJsonSerializerSettings()
      {
        UseSimpleDictionaryFormat = true
      });
    }

    public PostmarkSpamcheck() : this(new HttpClient()) { }
    public async Task<SpamcheckResult> GetScore(string emailBody)
    {
      var json = "{\"email\":\"" + emailBody + "\", \"options\":\"short\"}";
      return await this.MakeRequest(json);
    }

    public async Task<SpamcheckResult> GetReport(string emailBody)
    {
      var json = "{\"email\":\"" + emailBody + "\", \"options\":\"long\"}";
      return await this.MakeRequest(json);
    }

    private async Task<SpamcheckResult> MakeRequest(string json)
    {
      var response = await this.client.PostAsync(SPAMCHECK_URL, new StringContent(json, Encoding.UTF8, "application/json"));
      return serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as SpamcheckResult;
    }
  }
}
