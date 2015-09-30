using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ISLOnline.ISLPronto
{
    public class Chat : BaseClass
    {
        public Chat(string sessionId): base(sessionId)
        {

        }

        protected override string GetPath(string method)
        {
            return String.Format("islpronto/chat/{0}", method);
        }

        public List<Helpers.Chat> GetList(string domain, bool activeOnly = false, DateTime? createTimeBefore = null, DateTime? createTimeAfter = null, int? fromRecordNum = null, int? limit = null, string supporter = "")
        {
            Dictionary<string, string> args = new Dictionary<string,string>();

            args.Add("domain", domain != "" ? domain : "default");
            if (activeOnly) args.Add("active", "true");
            if (!activeOnly && createTimeBefore != null) args.Add("created_time_before", createTimeBefore.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            if (!activeOnly && createTimeAfter != null) args.Add("created_time_after", createTimeAfter.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            if (fromRecordNum != null) args.Add("from", fromRecordNum.Value.ToString());
            if (limit != null) args.Add("limit", limit.Value.ToString());
            if (supporter != "") args.Add("supporter", supporter);

            var results = Call("get/list/1", "POST", data: DictionaryToJson(args));
                      
            return JsonConvert.DeserializeObject<Helpers.ChatList>(results["data"].ToString()).chat.ToList();
            
        }

        public Helpers.Chat GetChatById(string chatId)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();

            args.Add("chat_sid", chatId);

            var results = Call("get/single/1", "POST", data: DictionaryToJson(args));

            return JsonConvert.DeserializeObject<Helpers.Chat>(results["data"]["chat"].ToString());
            
        }

        public Helpers.ChatContent GetChatByIdWithContent(string chatId)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();

            args.Add("chat_sid", chatId);
            
            var results = Call("content/get/single/1", "POST", data: DictionaryToJson(args));

            return JsonConvert.DeserializeObject<Helpers.ChatContent>(results["data"].ToString());
            
        }
    }
}
