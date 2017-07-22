using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace a1.Models
{
    public class ProductsDownloadManager
    {
        static CookieCollection coll;
        static HtmlDocument doc;
        static HtmlNodeCollection names;
        static HtmlNodeCollection prices;
        public static List<string> namesList = new List<string>();
        public static List<string> srcList = new List<string>();
        public static List<string> pricesList = new List<string>();

        public static void Get()
        {
            var client = new MyWebClient();
            for (int k = 1; k <= 2; k++)
            {
                Console.WriteLine(k);
                doc = client.GetPage("https://szopi.pl/catalogue/?page=" + k.ToString());
                GetNamesAndImgSrc();
                GetPrices();
            }
        }

        static void GetPrices()
        {
            prices = doc.DocumentNode.SelectNodes("//ol[@class='row']//article[@class='product_pod main-product-catalog product_pod_touch']//div[@class='product_price']");
            foreach (HtmlNode node in prices)
            {
                pricesList.Add(node.InnerText);
            }
        }

        static void GetNamesAndImgSrc()
        {
            names = doc.DocumentNode.SelectNodes("//ol[@class='row']//article[@class='product_pod main-product-catalog product_pod_touch']//div[@class='image_container']");
            foreach (HtmlNode node in names)
            {
                string s = node.InnerHtml.Substring(10);
                string name = "";
                string src = "";
                int i = 0;

                foreach (char c in s)
                {
                    if (c != '"')
                    {
                        name += c;
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }
                i += 25;
                while (s[i] != '"')
                {
                    src += s[i];
                    i++;
                }
                namesList.Add(name);
                srcList.Add(src);
            }
        }

        static CookieContainer GetCookieCollection()
        {
            CookieContainer c = new CookieContainer();
            Cookie __zlcmid = new Cookie()
            {
                Name = "__zlcmid",
                Value = "gLgQ0yyYK2as2W",
                Domain = ".szopi.pl",
                Path = "/"
            };
            c.Add(__zlcmid);
            Cookie clientinfo = new Cookie()
            {
                Name = "clientinfo",
                Value = "1366:768:1",
                Domain = "szopi.pl",
                Path = "/"
            };
            c.Add(clientinfo);
            Cookie cookielaw_accepted = new Cookie()
            {
                Name = "cookielaw_accepted",
                Value = "1",
                Domain = "szopi.pl",
                Path = "/"
            };
            c.Add(cookielaw_accepted);
            Cookie csrftoken = new Cookie()
            {
                Name = "csrftoken",
                Value = "XJ4IDOAoljgTO4x792i96QKZntqP71A4",
                Domain = "szopi.pl",
                Path = "/"
            };
            c.Add(csrftoken);
            Cookie rate_reminder_off = new Cookie()
            {
                Name = "rate_reminder_off",
                Value = "7758",
                Domain = "szopi.pl",
                Path = "/"
            };
            c.Add(rate_reminder_off);
            Cookie referral_modal_seen = new Cookie()
            {
                Name = "referral-modal_seen",
                Value = "1",
                Domain = "szopi.pl",
                Path = "/"
            };
            c.Add(referral_modal_seen);
            Cookie screenWidth = new Cookie()
            {
                Name = "screenWidth",
                Value = "1349",
                Domain = "szopi.pl",
                Path = "/"
            };
            c.Add(screenWidth);
            Cookie sessionid = new Cookie()
            {
                Name = "sessionid",
                Value = "xlqvjmcax5zt37zqryk2o5kgtd47np46",
                Domain = "szopi.pl",
                Path = "/"
            };
            c.Add(sessionid);
            return c;
        }

        public class MyWebClient
        {
            //The cookies will be here.
            private CookieContainer _cookies;

            //In case you need to clear the cookies
            public void ClearCookies()
            {
                _cookies = new CookieContainer();
            }

            public HtmlDocument GetPage(string url)
            {
                _cookies = GetCookieCollection();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                //Set more parameters here...
                //...

                //This is the important part.
                request.CookieContainer = _cookies;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();

                //When you get the response from the website, the cookies will be stored
                //automatically in "_cookies".

                using (var reader = new StreamReader(stream))
                {
                    string html = reader.ReadToEnd();
                    var doc = new HtmlDocument();
                    doc.LoadHtml(html);
                    return doc;
                }
            }
        }
    }
}