using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class RaceBuilder
    {

        public static Race CreateFromStartList(List<string> fields, string source)
        {
            int i = fields.Count() - 5;
            int state = 0;
            var term = new Race();
            term.Link = ParseLink(source);
            term.Source = string.Join("_", fields);
            try
            {
                foreach (var s in fields)
                {
                    switch (state)
                    {
                        case 0:
                            term.DateOfTerm = ParseDate(s);
                            if (term.DateOfTerm.HasValue)
                            {
                                term.StrDateOfTerm = s;
                                state++;
                            }
                            break;
                        case 1:
                            term.City = s;
                            state++;
                            break;
                        case 2:
                            term.StrDistances = s;
                            term.Distances = ParseDistances(s);
                            if (term.Distances != null)
                                state++;
                            break;
                        case 3:
                            term.Name = s;
                            state++;
                            break;
                    }
                }
                if (state > 3)
                    return term;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Race CreateIfCan(List<string> fields, string source)
        {
            int i = fields.Count() -5;
            int state = 0;
            var term = new Race();
            term.Link = ParseLink(source);
            term.Source = string.Join("_", fields);
            try
            {
                foreach (var s in fields)
                {
                    switch (state)
                    {
                        case 0:
                            term.DateOfTerm = ParseDate(s);
                            if (term.DateOfTerm.HasValue)
                            {
                                term.StrDateOfTerm = s;
                                state++;
                            }
                            break;
                        case 1:
                            term.City = s;
                            state++;
                            break;
                        case 2:
                            term.StrDistances = s;
                            term.Distances = ParseDistances(s);
                            if (term.Distances != null)
                              state++;
                            break;
                        case 3:
                            term.Name = s;
                            state++;
                            break;
                    }
                }
                if (state >3)
                  return term;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static string ParseLink(string zzz)
        {
            int z1 = zzz.IndexOf("href");
            if (z1 == -1)
                return "";

            int z2 = zzz.IndexOf("\"", z1);
            if (z2 == -1)
                z2 = zzz.IndexOf("'", z1);

            if (z2 == -1)
                return "";
            int z3 = zzz.IndexOf("\"", z2+1);
            if (z3 == -1)
                z3 = zzz.IndexOf("'", z2+1);
            if (z3 == -1)
                return "";
            return @"https://www.maratonypolskie.pl/" +  zzz.Substring(z2+1, z3 - z2-1);
        } 

        public static DateTime? ParseDate(string z)
        {            
            try
            {
                var q = z.Split(' ');
                var d = q[0].Split('.');
                var w = d[0].Split('-');
                if (d.Length == 3)
                    return new DateTime(int.Parse(d[2]), int.Parse(d[1]), int.Parse(w[0]));
            }
            catch (Exception)
            {}
           
            return null;
        }
        
        public static List<double> ParseDistances(string distances)
        {
            var parsed = new List<double>();
            distances = JoinNumbersWithUnits(distances);
            
            var dz = distances.Split(new string[] { ",","/"," " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var u in dz)
            {
                if (u.Contains("km"))
                {
                    var e = u.Replace("km", "");
                    var r = ParseNumber(e);
                    if (r.HasValue)
                        parsed.Add(r.Value);
                }
                else if (u.Contains("h"))
                {
                    var e = u.Replace("h", "");
                    var r = ParseNumber(e);
                    if (r.HasValue)
                        parsed.Add(r.Value * 9);
                }
                else if (u.Contains("m"))
                {
                    var e = u.Replace("m", "");
                    var r = ParseNumber(e);
                    if (r.HasValue)
                        parsed.Add(r.Value /1000);
                }
            }
            return parsed;
        }

        private static string JoinNumbersWithUnits(string z)
        {
            z = z.Replace(" km", "km");
            z = z.Replace(" m", "m");
            z = z.Replace(" h", "h");
            return z;
        }

        private static double? ParseNumber(string val)
        {
            double res;
            if (double.TryParse(val, out res))
            {
                return res;
            }
            else
            if (double.TryParse(val.Replace(".", ","), out res))
            {
                return res;
            }
            return null;
        }
    }
}
