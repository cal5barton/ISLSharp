using ISLOnline.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLOnline.Utils
{
    public class Login : BaseClass
    {
        public Login()
            : base()
        {

        }

        protected override string GetPath(string method)
        {
            return String.Format("utils/{0}", method);
        }

        public LoginResponse Authenticate(string user, string password, string domain, string timezone = "", string timezoneAddress = "")
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("user", user);
            args.Add("pwd", password);
            args.Add("domain", domain != "" ? domain : "default");
            if (timezone != "") args.Add("tz", timezone);
            if (timezoneAddress != "") args.Add("tz_addr", timezoneAddress);
            
            var results = Call("login/1", "POST", data: DictionaryToJson(args));

            
            return JsonConvert.DeserializeObject<Helpers.LoginResponse>(results["data"].ToString());
        }
    }
}
