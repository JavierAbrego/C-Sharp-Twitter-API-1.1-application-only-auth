using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace TwiitterApi
{
    public class APIv1_1
    {
        public static string _bearerToken = null;
        public static string _api_key = null;
        public static string _api_secret = null;

        public void setApiCredentials(String api_key, String api_secret) {
            _api_key = api_key;
            _api_secret = api_secret;
        }

        public String retrieveBearerToken(String api_key, String api_secret)
        {
                //Token URL
                var oauth_url = "https://api.twitter.com/oauth2/token";

                var headerFormat = "Basic {0}";
                var authHeader = string.Format(headerFormat,
                Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(api_key) + ":" +
                                       Uri.EscapeDataString((api_secret)))));

                var postBody = "grant_type=client_credentials";
                ServicePointManager.Expect100Continue = false;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(oauth_url);
                request.Headers.Add("Authorization", authHeader);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

                using (Stream stream = request.GetRequestStream())
                {
                    byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                    stream.Write(content, 0, content.Length);
                }

                request.Headers.Add("Accept-Encoding", "utf8");
                WebResponse response = request.GetResponse();
                String responseString;
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                     responseString= reader.ReadToEnd();
                    
                }
                return JsonConvert.DeserializeObject<Token>(responseString).access_token;
           
                
            
            }

        public String getTwitterDataBearerRequest(String URL) {
            try
            {
                if (_bearerToken == null)
                {
                    _bearerToken = retrieveBearerToken(_api_key, _api_secret);
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                var headerFormat = "Bearer {0}";
                var authHeader = string.Format(headerFormat, _bearerToken);
                request.Headers.Add("Authorization", authHeader);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                WebResponse response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var objText = reader.ReadToEnd();
                return objText;
            }
            catch (Exception e) {
                System.Console.Out.WriteLine(e.Message + e.Source+ e.InnerException);
                return null;
            }
        }

        public TwitterUserInfo getUserInfo(String screenName) {
            string url = String.Format("https://api.twitter.com/1.1/users/show.json?screen_name={0}", screenName);
            String response = getTwitterDataBearerRequest(url);
            if (response != null)
            {
                TwitterUserInfo userInfo = JsonConvert.DeserializeObject<TwitterUserInfo>(response);
                return userInfo;
            }
            return null;
        }

    }
}
