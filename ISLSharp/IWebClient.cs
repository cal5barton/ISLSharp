using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISLOnline
{
    public interface IWebClient
    {
        string UploadString(string uri, string method = "", string contentType = "", string data = "");
    }
}
