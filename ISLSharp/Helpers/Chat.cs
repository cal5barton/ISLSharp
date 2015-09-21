using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ISLOnline.Helpers
{


    public class ChatList
    {
        public Chat[] chat { get; set; }
    }

    public class Chat
    {
        public string chat_sid { get; set; }
        public Client client { get; set; }
        public string create_time { get; set; }
        public int create_time_t { get; set; }
        public Customization customization { get; set; }
        public string domain { get; set; }
        public Supporter supporter { get; set; }
        public string[] users { get; set; }
        public string last_leave_time { get; set; }
        public int last_leave_time_t { get; set; }
    }

}
