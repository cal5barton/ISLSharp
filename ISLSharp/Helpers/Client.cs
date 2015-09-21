using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLOnline.Helpers
{
    public class Client
    {
        public string browser { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string custom_fields { get; set; }
        public string email { get; set; }
        public string first_join_time { get; set; }
        public int first_join_time_t { get; set; }
        public string handled { get; set; }
        public string ip { get; set; }
        public string language { get; set; }
        public string last_leave_time { get; set; }
        public int last_leave_time_t { get; set; }
        public string latitude { get; set; }
        public string location { get; set; }
        public string longitude { get; set; }
        public string nickname { get; set; }
        public string rdns { get; set; }
        public string waiting_for { get; set; }
    }
}
