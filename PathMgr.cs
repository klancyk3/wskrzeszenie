using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class PathMgr
    {
        private const string urlZest = "https://www.maratonypolskie.pl/sylwetki/start_r1.php?code=101";
        private const string urlCalendarMp = "https://www.maratonypolskie.pl/mp_index.php?dzial=3&action=1&grp=13&czasr1={0}&czasm1=Wszystkie&dzienp1=1&dzienk1=31";
        private const string fileCalendarMp = "C:\\Users\\PC\\Desktop\\tmp\\maratonypolskie{0}_.txt";
        private const string fileCalendarResultMp = "C:\\Users\\PC\\Desktop\\tmp\\maratonypolskieRes{0}.txt";

        private const string fileForRunnerMp = "C:\\Users\\PC\\Desktop\\tmp\\maratonypolskieUser{0}_.txt";

        private const string fileSaveDb = "C:\\Users\\PC\\Desktop\\tmp\\{0}_{1}.txt";

        public static string SileSaveDb(string o0, string o1)
        {
            return string.Format(fileSaveDb, o0,  o1);
        }

        public static string UrlForYearMp(int year)
        {
            return string.Format(urlCalendarMp, year);
        }

        public static string FileForYearMp(int year)
        {
            return string.Format(fileCalendarMp, year);
        }

        public static string FileForResultYearMp(int year)
        {
            return string.Format(fileCalendarResultMp, year);
        }

      
        public static string FileForRunnerMp(string path)
        {
            return string.Format(fileForRunnerMp, GetSafePathString( path));
        }

        private static string GetSafePathString(string path)
        {
            return path.Replace(":", "")
                .Replace("/", "")
                .Replace("?", "")
                .Replace("=", "")
                .Replace("&", "")
                .Replace(".", "")
                ;
        }
    }
}
