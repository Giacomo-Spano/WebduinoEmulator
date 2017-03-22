using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class HttpHelper
    {
        public String sendPost(String serverurl, int port, String path, String body)
        {

            byte[] data = Encoding.ASCII.GetBytes(body);

            //String url = "http://192.168.1.5:8080/webduino" + path;
            String url = "http://" +  serverurl + ":" + port + "/" + path;

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            string responseContent = null;

            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr99 = new StreamReader(stream))
                    {
                        responseContent = sr99.ReadToEnd();
                    }
                }
            }

            return responseContent;
        }
    }
}
