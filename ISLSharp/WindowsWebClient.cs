using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ISLOnline
{
    internal class WindowsWebClient : IWebClient
    {
        public string UploadString(string uri, string method = "GET", string contentType = "application/text",
                                   string data = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = method;
            request.ContentType = contentType;
            request.Timeout = 150000;

            if (data.Length > 0)
            {
                var writer = new StreamWriter(request.GetRequestStream());
                writer.Write(data);
                writer.Close();
            }


            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    var streamReader = new StreamReader(responseStream);
                    return streamReader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                throw e;
            }

            return String.Empty;
        }
    }
}
