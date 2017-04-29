using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crawler
{
    public class Parser
    {
        public static List<string> ReadRowsOfTables(string content)
        {
            var list = new List<string>();
            List<int> indexesBeg = new List<int>();
            List<int> indexesEnd = new List<int>();
            var r = CreateRegexTrBegin();
            foreach (Match z in r.Matches(content))
            {
                indexesBeg.Add(z.Index);
            }

            var r2 = CreateRegexTrEnd();
            foreach (Match z in r2.Matches(content))
            {
                indexesEnd.Add(z.Index);
            }
            
            for (int ib = 0; ib < indexesBeg.Count; ib++)
            {
                int end = FindEnd(indexesBeg, ib, indexesEnd);
                list.Add(content.Substring(indexesBeg[ib], indexesEnd[end] - indexesBeg[ib] + 4));
            }
            
            return list;
        }

        private static int FindEnd(List<int> indexesBeg, int index, List<int> listOfEnds)
        {
            int ResultIndex = index;

            while (ResultIndex >= 0 && ResultIndex < listOfEnds.Count-1 && listOfEnds[ResultIndex] < indexesBeg[index])
                ResultIndex++;
            while (ResultIndex > 0 && ResultIndex < listOfEnds.Count && listOfEnds[ResultIndex - 1] > indexesBeg[index])
                ResultIndex--;
            while (ResultIndex >= listOfEnds.Count)
                ResultIndex--;
            return ResultIndex;             
        }

        private static Regex CreateRegexTrBegin()
        {
            return new Regex("[<]TR[>]", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }
        private static Regex CreateRegexTrEnd()
        {
            return new Regex("[<][/]TR[>]", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }

        private static Regex CreateRegex(string prefix, string suffix)
        {
            return new Regex(prefix + "(.*)" + suffix, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }

        ////////

        public static List<string> ParseCol(string row)
        {
            var list = new List<string>();
            List<int> indexesBeg = new List<int>();
            List<int> indexesEnd = new List<int>();
            var r = CreateRegexTdBegin();
            foreach (Match z in r.Matches(row))
            {
                indexesBeg.Add(z.Index);
            }

            var r2 = CreateRegexTdEnd();
            foreach (Match z2 in r2.Matches(row))
            {
                indexesEnd.Add(z2.Index);
            }

            for (int ib = 0; ib < indexesBeg.Count; ib++)
            {
                int end = FindEnd(indexesBeg, ib, indexesEnd);
                string wholeCol = "";
                if (end < 0)
                {
                    wholeCol = row.Substring(indexesBeg[ib]);
                }
                else
                {
                    wholeCol = row.Substring(indexesBeg[ib],
                       Math.Max(Math.Min(indexesEnd[end] - indexesBeg[ib], row.Length - 1), 0)
                        );
                }
                foreach (var zzz in wholeCol.Split(new string[] { "<BR>" }, StringSplitOptions.None))
                {

                    StringBuilder sb = new StringBuilder();
                    bool write = true;
                    foreach (char c in zzz)
                    {
                        switch (c)
                        {
                            case '<':
                                write = false; break;
                            case '>':
                                write = true; break;
                            default:
                                if (write)
                                    sb.Append(c); break;
                        }
                    }
                    list.Add(sb.ToString());
                }
            }

            return list;
        }
        
        private static Regex CreateRegexTdBegin()
        {
            return new Regex("[<]TD", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }
        private static Regex CreateRegexTdEnd()
        {
            return new Regex("[<][/]TD[>]", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }
    }
}
