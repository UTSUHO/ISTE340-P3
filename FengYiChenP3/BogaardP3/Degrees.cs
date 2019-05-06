﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogaardP3
{
    public class Undergraduate
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> concentrations { get; set; }
    }

    public class Graduate
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> concentrations { get; set; }
        public List<string> availableCertificates { get; set; }
    }

    public class Degrees
    {
        public List<Undergraduate> Undergraduate { get; set; }
        public List<Graduate> Graduate { get; set; }
    }
}