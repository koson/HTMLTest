using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Text;
 
namespace htmlTest
{
    [Activity(Label = "htmlTest", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };




            //doc.Load("http://ewafs.com/gettime.php?id=705");

            string answer = "http://vocmontoyo.com/readcurrents.ashx?s1=001";


            string str = LoadHTML(answer);

            var doc = new HtmlDocument();
            doc.LoadHtml(str);

            TextView tv = FindViewById<TextView>(Resource.Id.textView1);
            tv.Text = str;
        }


        string LoadHTML(string filePath)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(filePath);
            request.Method = "GET";
            request.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response != null)
            {
                var strReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var responseToString = strReader.ReadToEnd();
                return responseToString;
            }
            return null;
        }
    }
}

