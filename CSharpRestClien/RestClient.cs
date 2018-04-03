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

    public enum authenticationType
    {
        Basic,
        NTLM
    }
    public enum authenticationTechnique
    {
        RollYourOwn,
        NetworkCredential
    }

    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public authenticationType authType { get; set; }
        public authenticationTechnique authTech { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }

        public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }
        public string MakeRequest()
        {
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpMethod.ToString();


            if(authTech == authenticationTechnique.RollYourOwn)
            {
                //HArdcoded to Basic
                string authHeader = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(userName + ":" + userPassword));
                request.Headers.Add("Authorization", "Basic " + authHeader);
            }
            else
            {
                NetworkCredential netCred = new NetworkCredential(userName, userPassword);
                request.Credentials = netCred;
            }

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
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
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if(response !=  null)
                {
                    ((IDisposable)response).Dispose();
                }
            }
            return strResponseValue;
        }
    }
}
