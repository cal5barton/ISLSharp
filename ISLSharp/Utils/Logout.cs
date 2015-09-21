using ISLOnline.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLOnline.Utils
{
    public class Logout : BaseClass
    {
        public Logout(string sessionId)
            : base(sessionId)
        {

        }

        protected override string GetPath(string method)
        {
            return String.Format("utils/{0}", method);
        }

        public LogoutResponse EndSession()
        {
            var results = Call("logout/1", "POST", data: "{}");
            
            return JsonConvert.DeserializeObject<Helpers.LogoutResponse>(results["data"].ToString());
        }
    }
}
