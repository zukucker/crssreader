using System;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace crssreader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reader startet...");
            string url = "https://www.shopware.com/de/changelog-sw5/?sRss=1";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach(SyndicationItem item in feed.Items)
            {
              String version = item.Title.Text;
              String summary = item.Summary.Text;
              var changes = Regex.Replace(summary, "SW-", "\n \n \t✔️ SW-");
              Console.WriteLine("🆕Version:" + version);
              Console.WriteLine("\n \t" + "Änderungen: " + changes);
              Console.WriteLine("\n");
            }
        }
    }
}
