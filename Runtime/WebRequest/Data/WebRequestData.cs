using System.Collections.Generic;
using UnityEngine.Networking;

namespace Aureola.Accessories
{
    public class WebRequestData
    {
        public string url;
        public WebRequestMethod method = WebRequestMethod.GET;
        public Dictionary<string, string> headers;
        public string payload;

        public WebRequestData(string url)
        {
            this.url = url;
        }

        public WebRequestData(string url, WebRequestMethod method)
        {
            this.url = url;
            this.method = method;
        }

        public WebRequestData(string url, WebRequestMethod method, Dictionary<string, string> headers)
        {
            this.url = url;
            this.method = method;
            this.headers = headers;
        }

        public WebRequestData(string url, WebRequestMethod method, Dictionary<string, string> headers, string payload)
        {
            this.url = url;
            this.method = method;
            this.headers = headers;
            this.payload = payload;
        }

        public string GetMethod()
        {
            switch (method)
            {
                case WebRequestMethod.HEAD:
                    return UnityWebRequest.kHttpVerbHEAD;
                case WebRequestMethod.POST:
                    return UnityWebRequest.kHttpVerbPOST;
                case WebRequestMethod.PUT:
                    return UnityWebRequest.kHttpVerbPUT;
                case WebRequestMethod.DELETE:
                    return UnityWebRequest.kHttpVerbDELETE;
                default:
                    return UnityWebRequest.kHttpVerbGET;
            }
        }
    }
}
