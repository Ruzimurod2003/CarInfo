using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Models
{
    public class CarIndexVM
    {
        public List<Car> Cars { get; set; }
        public List<string> Colors { get; set; }
        public string ColorString { get; set; }
        public string StartPrice { get; set; }
        public string EndPrice { get; set; }
    }
}
