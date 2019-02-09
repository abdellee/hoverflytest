using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebservicesPoster
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string soap =
                  @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                                    xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                                    xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                            <soap:Body>
                                <GetStudent  xmlns=""http://tempuri.org/""/>
                            </soap:Body>
                    </soap:Envelope>";
                HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create("http://localhost/WebApplication1/HoverflyWebService.asmx/GetStudent");

                myRequest.ContentType = "text/xml;charset=\"utf-8\"";
                myRequest.Method = "POST";
                myRequest.Headers.Add("SOAPAction", "");
                myRequest.KeepAlive = true;

                // config
                IWebProxy proxy = myRequest.Proxy;

                if (proxy != null)
                {
                    string proxyuri = proxy.GetProxy(new Uri("http://localhost:8500")).ToString();
                    myRequest.UseDefaultCredentials = true;
                    WebProxy p = new WebProxy(proxyuri, false);
                    p.BypassProxyOnLocal = false;
                    myRequest.Proxy = p;
                    myRequest.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                // end - config

                //// proxy config
                //Uri newUri = new Uri("http://127.0.0.1:8500");
                //var prosyUri = WebRequest.GetSystemWebProxy().GetProxy(newUri);

                ////myProxy.Credentials = CredentialCache.DefaultCredentials;
                //WebProxy p = new WebProxy(prosyUri);
                //p.BypassProxyOnLocal = false;
                //myRequest.Proxy = p;
                //myRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;

                //// end - proxy config

                using (Stream stm = myRequest.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                        stmw.Write(soap);
                    }
                }

                myRequest.Headers["Cookie"] = "TemplateID=4236;WorkOrderID=12914;SchemeNumber=000001;UserID=0";
                String test = String.Empty;
                using (HttpWebResponse response = (HttpWebResponse)myRequest.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    test = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error={0}", ex.Message);
            }
            finally
            {
                // do nothing
            }
        }
    }
}
