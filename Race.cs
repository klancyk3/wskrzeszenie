using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class Race
    {
        public string StrDateOfTerm { get; set; }
        public string StrDistances { get; set; }
        public DateTime? DateOfTerm { get; set; }

        private List<double> dis;
        public List<double> Distances {
            get { return dis; }
            set {
                dis = value;
               // foreach (var z in value)
                   // if (z > 42)
                        IsMaraton = dis.Any( z => z >= 42);
            }
        }
        public string City { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public bool IsMaraton { get; set; }
        public string Source { get; set; }


    }
}
