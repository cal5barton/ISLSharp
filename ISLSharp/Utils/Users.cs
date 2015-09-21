using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLOnline.Utils
{
    public class Users : BaseClass
    {
        public Users(string sessionId)
            : base(sessionId)
        {

        }

        protected override string GetPath(string method)
        {
            return String.Format("utils/{0}", method);
        }

        public void Query(string code = "", bool defaultDomain = false, string domain = "", string domainList = "*", string email = "", string nickname = "", string realname = "", string simple = "", string user = "")
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            if(domain != "") args.Add("domain", domain);
            if (code != "") args.Add("code", code);
            if (defaultDomain) args.Add("default_domain", "true");
            if (domainList != "") args.Add("domain_list", domainList);
            if (email != "") args.Add("email", email);
            if (nickname != "") args.Add("nickname", nickname);
            if (realname != "") args.Add("realname", realname);
            if (simple != "") args.Add("simple", simple);
            if (user != "") args.Add("user", user);

            var results = Call("users/query/1", "POST", data: DictionaryToJson(args));
        }
    }
}
