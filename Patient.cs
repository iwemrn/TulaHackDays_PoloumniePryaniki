using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class Patient
    {
        public string Name { get; set; }
        public string Diagnosis { get; set; }
        public List<string> Notes { get; set; }
    }

}
