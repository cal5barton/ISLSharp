using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Json;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ISLOnline
{
    public class BaseClass : IBaseClass
    {
        private readonly Dictionary<string, object> _options;
        private readonly string _sessionId;


        public IWebClient UserWebClient { get; set; }

        public BaseClass(string sessionId = null)
        {
            if (sessionId != null) _sessionId = sessionId;
            _options = new Dictionary<string, object>();
            _options["api_base"] = "www.islonline.net/webapi2?method=";
            UserWebClient = new WindowsWebClient();
        }

        protected virtual string GetPath(string subPath)
        {
            throw new NotImplementedException();
        }

        protected string DictionaryToJson(Dictionary<string, string> dict)
        {
            return JsonConvert.SerializeObject(dict).ToString();
        }

        protected JsonObject Call(string subpath, string method = "GET",  string contentType = "application/text",
                                  string data = "")
        {
            string uri;
                        
            uri = String.Format("https://{0}{1}", _options["api_base"],
                                    GetPath(subpath));

            if(_sessionId != null && _sessionId != "")
            {
                uri = String.Format("{0}{1}", uri, String.Format("&hs={0}", _sessionId));
            }
            

            Debug.WriteLine(uri);
            var returnVal = UserWebClient.UploadString(uri, method: method, contentType: contentType, data: data);

            if (returnVal != null)
            {
                if (returnVal.Length > 0)
                {
                    JsonObject o = new JsonObject(JsonValue.Parse(returnVal));
                    if (SuccessfulCall(o))
                    {
                        return o;
                    }
                    else
                    {
                        var response = JsonConvert.DeserializeObject<Helpers.APIResponse>(o.ToString());
                        throw new Exception(String.Format("Unsuccessful call to web api. {0}", response.result.code), new Exception(String.Format("{0}", response.result.description)));
                    }
                }
            }

            return new JsonObject();
        }

        private bool SuccessfulCall(JsonObject response)
        {
            var r = JsonConvert.DeserializeObject<Helpers.APIResponse>(response.ToString());

            if(r.result.code == "OK")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
