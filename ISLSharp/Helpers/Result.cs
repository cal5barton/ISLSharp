using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLOnline.Helpers
{
    public class Result
    {
        public Args args { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public Errors errors { get; set; }
        public int server { get; set; }
    }

    public class Args
    {
        public string client_address { get; set; }
        public string he { get; set; }
        public string heo { get; set; }
        public string lang { get; set; }
        public string method { get; set; }
        public string session_id { get; set; }
    }

    public class Errors
    {
        public string _ { get; set; }
    }
}