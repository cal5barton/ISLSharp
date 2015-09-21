using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLOnline.Helpers
{
    
    [JsonObject("Data")]
    public class ChatContent
    {
        public Content[] content { get; set; }
    }

    public class Content
    {
        public int email_nc { get; set; }
        public Message message { get; set; }
        public string sent { get; set; }
        public int sent_t { get; set; }
        public Type type { get; set; }
        public string email { get; set; }
        public string from { get; set; }
        public string nick { get; set; }
    }

    public class Message
    {
        public string text { get; set; }
        public string format { get; set; }
    }

    public class Type
    {
        public int action { get; set; }
        public string source { get; set; }
        public int supporter { get; set; }
    }
}
