using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pricelist_Portal_Khantil_Anton_43650.Parser
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.Prefix}/";
        }

        //public async Task<string> GetSourceByPageId(int id)
        //{
        //    var currentUrl = url.Replace("{CurrentId}", id.ToString());
        //    var response = await client.GetAsync(currentUrl);
        //    
        //    string source = null;

        //    if (response != null && response.StatusCode == HttpStatusCode.OK)
        //    {
        //        source = await response.Content.ReadAsStringAsync();
        //    }

        //    return source;
        //}

        public string GetSourceByPageId(int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(currentUrl);
            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    var encoding = Encoding.GetEncoding(response.CharacterSet);

                    using (var responseStream = response.GetResponseStream())
                    using (var reader = new StreamReader(responseStream, encoding))
                        return reader.ReadToEnd();
                }
            }
            return null;
        }

    }
}