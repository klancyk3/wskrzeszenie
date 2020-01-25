using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Crawler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int year = 2017; year > 1976; year--)
            {
                inBox.Text = PathMgr.UrlForYearMp(year);
                var siteDownloader = new SiteDownloader { Url = inBox.Text};
                siteDownloader.Download();
                File.WriteAllText(PathMgr.FileForYearMp(year), siteDownloader.Content);
                Log("Year " + year + " has been downloaded");
                Application.DoEvents();

                try
                {
                    var siteContent = File.ReadAllText(PathMgr.FileForYearMp(year));
                    var rows = Parser.ReadRowsOfTables(siteContent);
                    List<Race> competitions = new List<Race>();
                    foreach (var z in rows)
                    {
                        var zzz = Parser.ParseCol(z);
                        var cc = RaceBuilder.CreateIfCan(zzz, z);
                        if (cc != null && cc.IsMaraton)
                            competitions.Add(cc);
                    }

                    printResult(competitions, year);
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
                Log("Year " + year + " has been analyzed");
                Application.DoEvents();
            }
        }

        private void Log(string msg)
        {
            textLog.Text = msg + Environment.NewLine + textLog.Text;
        }
        
        private void printResult(List<Race> res, int year)
        {
            var sb = new StringBuilder();
            foreach (var z in res.Where( z=> z.IsMaraton && !z.Name.StartsWith("#") ))
            {
                sb.Append( 
                      (z.DateOfTerm.HasValue ? z.DateOfTerm.Value.ToShortDateString() : "NODATE!") + "  "
                      + z.City + "  "
                      + z.StrDistances + "  "
                      + z.Name + "  "
                      + "" + System.Web.HttpUtility.HtmlDecode(z.Link)
                      + Environment.NewLine
                      + Environment.NewLine);
            }
            File.WriteAllText(PathMgr.FileForResultYearMp(year), sb.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // var path = textBoxPathRunner.Text;

            //inBox.Text = PathMgr.UrlForYearMp(year);
            // var siteDownloader = new SiteDownloader { Url = path };
            // siteDownloader.Download();
            // File.WriteAllText(PathMgr.FileForRunnerMp(path), siteDownloader.Content);
            // Log("path " + path + " has been downloaded");
            // Application.DoEvents();
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            var paths = openFileDialog1.FileNames;
            foreach (var path in paths)
            {
                try
                {

                    var siteContent = File.ReadAllText(path);// PathMgr.FileForRunnerMp(path));

                    textResults.Text = siteContent;
                    var rows = Parser.ReadRowsOfTables(siteContent);
                    List<Race> competitions = new List<Race>();
                    foreach (var z in rows)
                    {
                        var zzz = Parser.ParseCol(z);
                        var cc = RaceBuilder.CreateFromStartList(zzz, z);
                        if (cc != null && cc.IsMaraton)
                            competitions.Add(cc);
                    }

                    //printResult(zz, year);
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
                Log("Path " + path + " has been analyzed");

                Application.DoEvents();
            }
            
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var siteGot = @"http://ktg.hg.pl/komisja-tg/got/got.html";

            var siteDownloader = new SiteDownloader { Url = siteGot };
            siteDownloader.Download();


        }
    }
}
