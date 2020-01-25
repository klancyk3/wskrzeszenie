using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGot
{
    public class Droga
    {
        public string Pasmo { get; set; }
        public string Punkt { get; set; }
        public string Kolor { get; set; }
        public string Zrodlo { get; set; }
        public int PktMax { get; set; }
        public int PktMin { get; set; }
        public string Pkty {  set
            {
                
                string[] z = value.Split(@"/");
                PktMax = int.Parse(z[0]);
                PktMin = int.Parse(z[1]);
                if (PktMax < PktMin)
                {
                    int buf = PktMax;
                    PktMax = PktMin;
                    PktMin = buf;
                }
            } }
        public override string ToString()
        {
            return $"{Pasmo};{Punkt};{PktMax};{PktMin};{Kolor};{Zrodlo}";
        }
    }
}
