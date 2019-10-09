using Core.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Http
{
    public class HttpClientUtility
    {
        private HttpClient _client;

        private HttpHeaders _hearder;

        public HttpClientUtility()
        {
            _client = new HttpClient();

            SetDefaultHeaders();
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

                var responseResult = JsonConvert.DeserializeObject<ResponseResult>(tempResponseString);

                if (responseResult.Success && responseResult.Data != null)
                {
                    t = JsonConvert.DeserializeObject<T>(responseResult.Data.ToString());
                }
            }

            return t;
        }

        /// <summary>
        /// 获取原始的返回信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>

        public T GetOriginalResponse<T>(string url)
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


        public async void PostAsync<T>(string url, T postData)
        {
            HttpContent content = GetHttpContent<T>(postData);

            await _client.PostAsync(url, content);
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


        /// <summary>
        /// 获取httpcontent
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        private HttpContent GetHttpContent<T>(T postData)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(postData));

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";

            return httpContent;
        }


        /// <summary>
        /// 设置默认的请求Token
        /// </summary>
        private void SetDefaultHeaders()
        {
            var tokenContext = TokenContext.CurrentContext;

            var requestId = tokenContext != null ? tokenContext.GetRequestId() : null;

            if (!string.IsNullOrWhiteSpace(requestId))
            {
                _client.DefaultRequestHeaders.Add("RequestId", requestId);
            }
        }
    }
}
