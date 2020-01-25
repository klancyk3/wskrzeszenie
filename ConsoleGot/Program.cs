using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleGot
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("all.xml");
            string pasmo = "";
            string punkt = "";
            string kolor = "";
            string zrodlo = "";
            string pkty = "";
            List<Droga> list = new List<Droga>();
            foreach (XmlNode root in xml.ChildNodes)
            {
                foreach (XmlNode c1 in root.ChildNodes)
                {
                    if (c1.Name == "h4")
                        pasmo = c1.InnerText;
                    else
                    {
                        foreach (XmlNode tr1 in c1.ChildNodes)
                        {
                            foreach (XmlNode td1 in tr1.ChildNodes)
                            {
                                foreach (XmlNode t2 in td1.ChildNodes)
                                {
                                    if (t2.Name == "#text")
                                        punkt = t2.InnerText;
                                    else
                                    {
                                        foreach (XmlNode tr2 in t2.ChildNodes)
                                        {
                                            int i = 0;
                                            foreach (XmlNode td2 in tr2.ChildNodes)
                                            {
                                                switch (i)
                                                {
                                                    case 0: kolor = td2.InnerText; break;
                                                    case 1: zrodlo = td2.InnerText; break;
                                                    case 2:
                                                        pkty = td2.InnerText;
                                                        var droga = new Droga { Kolor = kolor, Pasmo = pasmo, Punkt = punkt, Zrodlo = zrodlo, Pkty = pkty };
                                                        list.Add(droga);

                                                        Console.WriteLine(droga);
                                                        break;
                                                    case 3: throw new Exception("za duzo td");
                                                }
                                                i++;
                                            }
                                        }
                                    }
                                }                                
                            }
                        }
                    }
                }              
            }
            File.WriteAllLines("Drogi.csv", list.Select(x => x.ToString()).ToArray() );
        }


        private void download()
        {
            System.Text.EncodingProvider provider = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(provider);

            var siteGot = @"http://ktg.hg.pl/komisja-tg/got/got.html";

            var siteDownloader = new SiteDownloader { Url = siteGot };
            siteDownloader.Download();

            Regex rx = new Regex(@"<a href=""([a-zA-Z0-9_/-]+[.]html)"">");

            // MatchCollection mc = rx.Matches(siteDownloader.Content);
            //  mc.
            foreach (Match m in rx.Matches(siteDownloader.Content))
            {
                var site = "http://ktg.hg.pl/komisja-tg/got/" + m.Groups[1];
                Console.WriteLine(site);
                var subSiteDownloader = new SiteDownloader { Url = site };
                subSiteDownloader.Download();
                File.WriteAllText(m.Groups[1].Value.Replace(@"/", "_"), subSiteDownloader.Content);
            }

        }
    }
}
