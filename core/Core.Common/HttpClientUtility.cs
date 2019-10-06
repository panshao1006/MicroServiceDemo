using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class HttpClientUtility
    {
        private HttpClient _client;

        private HttpHeaders _hearder;

        public HttpClientUtility()
        {
            _client = new HttpClient();
        }


        /// <summary>
        /// 设置请求头
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetRequestHeaders(string name , string value)
        {
            if (_client.DefaultRequestHeaders.Contains(name))
            {
                return;
            }

            _client.DefaultRequestHeaders.Add(name, value);
        }


        /// <summary>
        /// get方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public T Get<T>(string url)
        {
            T t = default(T);

            var response = _client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                Task<string> responseString = response.Content.ReadAsStringAsync();
                string tempResponseString = responseString.Result;

                t = JsonConvert.DeserializeObject<T>(tempResponseString);
            }

            return t;
        }

        /// <summary>
        /// post方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="formData"></param>
        /// <returns></returns>
        public T Post<T>(string url, Dictionary<string, string> formData = null)
        {
            HttpContent content = GetHttpContent(formData);

            var response = _client.PostAsync(url, content).Result;

            T result = default(T);

            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;

                result = JsonConvert.DeserializeObject<T>(s);
            }

            return result;
        }


        /// <summary>
        /// 获取httpcontent
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        private HttpContent GetHttpContent(Dictionary<string, string> formData = null)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(formData));

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";

            return httpContent;
        }
    }
}
