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

            try
            {
                var results = Call("get/list/1", "POST", data: DictionaryToJson(args));
                return JsonConvert.DeserializeObject<Helpers.ChatList>(results["data"].ToString()).chat.ToList();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Unsuccessful call to web api. USER_ERROR")
                {
                    var results = Call("get/list/tmp", "POST", data: DictionaryToJson(args));
                    return JsonConvert.DeserializeObject<Helpers.ChatList>(results["data"].ToString()).chat.ToList();
                }
                else
                {
                    throw ex;
                }
            }
        }

        public Helpers.Chat GetChatById(string chatId)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();

            args.Add("chat_sid", chatId);

            try
            {
                var results = Call("get/single/1", "POST", data: DictionaryToJson(args));
                return JsonConvert.DeserializeObject<Helpers.Chat>(results["data"]["chat"].ToString());
            }
            catch(Exception ex)
            {
                if (ex.Message == "Unsuccessful call to web api. USER_ERROR")
                {
                    var results = Call("get/single/tmp", "POST", data: DictionaryToJson(args));
                    return JsonConvert.DeserializeObject<Helpers.Chat>(results["data"]["chat"].ToString());
                }
                else
                {
                    throw ex;
                }

            }
            
        }

        public Helpers.ChatContent GetChatByIdWithContent(string chatId)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();

            args.Add("chat_sid", chatId);

            try
            {
                var results = Call("content/get/single/1", "POST", data: DictionaryToJson(args));
                return JsonConvert.DeserializeObject<Helpers.ChatContent>(results["data"].ToString());
            }
            catch(Exception ex)
            {
                if (ex.Message == "Unsuccessful call to web api. USER_ERROR")
                {
                    var results = Call("content/get/single/tmp", "POST", data: DictionaryToJson(args));
                    return JsonConvert.DeserializeObject<Helpers.ChatContent>(results["data"].ToString());
                }
                else
                {
                    throw ex;
                }
            }
            
        }
    }
}
