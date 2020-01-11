using System;

namespace Core.Context
{
    public class TokenContext : IDisposable
    {

        private string _token;

        private string _organizationId;

        private string _userId;

        private string _requestId;

        private string _langId;
       
        protected TokenContext(string token , string organizationId , string userId)
        {
            this._token = token;
            this._organizationId = organizationId;
            this._userId = userId;
        }

        protected TokenContext(string token, string organizationId, string userId, string requestId , string langId)
        {
            this._token = token;
            this._organizationId = organizationId;
            this._userId = userId;
            this._requestId = requestId;
            this._langId = langId;
        }


        [ThreadStatic]
        private static TokenContext _currentContext;
        /// <summary>
        /// 获取当前上下文运行时对象.
        /// </summary>
        public static TokenContext CurrentContext
        {
            get { return _currentContext; }
        }

        public string GetToken()
        {
            return _token;
        }

        public string GetUserId()
        {
            return _userId;
        }

        public string GetOrganizationId()
        {
            return _organizationId;
        }

        public string GetRequestId()
        {
            return _requestId;
        }

        public string GetLangId()
        {
            _langId = string.IsNullOrWhiteSpace(_langId) ? "0x0009" : _langId;
            return _langId;
        }

        public static TokenContext BeginContextRuntime(string token, string organizationId, string userId)
        {
            //可以通过配置文件配置上下文运行时环境的参数。这里只是实现简单的模拟。
            _currentContext = new TokenContext(token , organizationId , userId);
            return _currentContext;
        }

        public static TokenContext BeginContextRuntime(string token, string organizationId, string userId , string requestId , string langId)
        {
            //可以通过配置文件配置上下文运行时环境的参数。这里只是实现简单的模拟。
            _currentContext = new TokenContext(token, organizationId, userId , requestId , langId);
            return _currentContext;
        }

        public void Dispose()
        {
            _currentContext = null;
        }

    }
}
