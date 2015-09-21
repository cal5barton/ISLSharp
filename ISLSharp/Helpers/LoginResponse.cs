using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLOnline.Helpers
{
    [JsonObject("Data") ]
    public class LoginResponse
    {
        public string sid { get; set; }
    }
}
