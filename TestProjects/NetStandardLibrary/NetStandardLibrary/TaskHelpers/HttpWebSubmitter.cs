using NetStandardLibrary.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NetStandardLibrary.TaskHelpers
{
    public class HttpWebSubmitter
    {
        public static string GetFromHpptWebRequest(HttpWebContent content)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(content.URL);
            webRequest.Method = content.Method;
            webRequest.Accept = content.ResponseAccept;

            if (content.Method.Equals("post", StringComparison.InvariantCultureIgnoreCase))
            {
                webRequest.ContentType = content.ContentType;
                var requestStreamWriter = new System.IO.StreamWriter(webRequest.GetRequestStream());
                requestStreamWriter.Write(content.SendBody);
                requestStreamWriter.Flush();
                requestStreamWriter.Close();
            }

            var response = webRequest.GetResponse();
            var responseStreamReader = new System.IO.StreamReader(response.GetResponseStream());
            string rValue = responseStreamReader.ReadToEnd();
            responseStreamReader.Close();
            response.Close();
            return rValue;
        }

        public async static Task<string> GetFromHttpClientAsync(HttpWebContent content)
        {
            string result = null;

            if (content.Method.Equals("post", StringComparison.InvariantCultureIgnoreCase))
            {
                result = await GetFromPostAsync(content);
            }
            else
            {
                result = await GetFromGetAsync(content);
            }

            return result;
        }

        public static string GetFromHttpClient(HttpWebContent content)
        {
            string result = null;

            if (content.Method.Equals("post", StringComparison.InvariantCultureIgnoreCase))
            {
                result = GetFromPostAvoidDeadLockAsync(content).Result;
            }
            else
            {
                result = GetFromGetAvoidDeadLockAsync(content).Result;
            }

            return result;
        }

        #region avoid dead locks
        private static async Task<string> GetFromPostAvoidDeadLockAsync(HttpWebContent WebContent)
        {
            string result = null;
            HttpContent content = new StringContent(WebContent.SendBody);
            content.Headers.ContentType = new MediaTypeHeaderValue(WebContent.ContentType);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(WebContent.ResponseAccept));
            var resp = await client.PostAsync(WebContent.URL, content).ConfigureAwait(false);

            if (resp.IsSuccessStatusCode)
            {
                result = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
            }

            return result;
        }
        private static async Task<string> GetFromGetAvoidDeadLockAsync(HttpWebContent WebContent)
        {
            string result = null;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(WebContent.ResponseAccept));
            var resp = await client.GetAsync(WebContent.URL).ConfigureAwait(false);

            if (resp.IsSuccessStatusCode)
            {
                result = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
            }

            return result;
        }
        #endregion

        #region Async methods
        private static async Task<string> GetFromPostAsync(HttpWebContent WebContent)
        {
            string result = null;
            HttpContent content = new StringContent(WebContent.SendBody);
            content.Headers.ContentType = new MediaTypeHeaderValue(WebContent.ContentType);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(WebContent.ResponseAccept));
            var resp = await client.PostAsync(WebContent.URL, content);

            if (resp.IsSuccessStatusCode)
            {
                result = await resp.Content.ReadAsStringAsync();
            }

            return result;
        }
        private static async Task<string> GetFromGetAsync(HttpWebContent WebContent)
        {
            string result = null;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(WebContent.ResponseAccept));
            var resp = await client.GetAsync(WebContent.URL);

            if (resp.IsSuccessStatusCode)
            {
                result = await resp.Content.ReadAsStringAsync();
            }

            return result;
        }
        #endregion
    }
}
