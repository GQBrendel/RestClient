using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace CSharpRestClien
{
    public enum httpVerb
    {
        GET,
        POST
    }

    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }
        public string MakeRequest()
        {
            string strResponseValue = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
                request.Method = httpMethod.ToString();

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new ApplicationException("Error Code: " + response.StatusCode);
                    }
                    //Process the Response Stream... (could be JSON, XML or HTML, etc...)

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = reader.ReadToEnd();
                            }//End of using StreamReader
                        }
                    }//End orf using responseStream
                }//End of Using Response

            }
            catch (WebException webEx)
            {
                System.Diagnostics.Debug.Write("Exception Message: " + webEx.Message + Environment.NewLine);

                // Console.WriteLine("Exception Message: " + ex.Message);
            }
            catch (FormatException formatEx)
            {
                System.Diagnostics.Debug.Write("Exception Message: " + formatEx.Message + Environment.NewLine);
            }

            return strResponseValue;
        }
    }
}
