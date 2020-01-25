using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGot
{
    public class SiteDownloader
    {
        public string Url { get; set; }
        public string Content { get; set; }

        public void Download() {
            System.Net.WebClient client = new System.Net.WebClient();
            var bytes = client.DownloadData(Url);
            var bytes2 = Encoding.Convert(//Encoding.GetEncoding("windows-1250")
                  Encoding.GetEncoding("ISO-8859-2"), Encoding.UTF8, bytes);
            Content = Encoding.UTF8.GetString(bytes2);     
        }
    }
}
