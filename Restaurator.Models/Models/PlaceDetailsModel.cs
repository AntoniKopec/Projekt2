using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurator.Models.Models
{
    public class PlaceDetailsModel
    {
        public string Name { get; set; }
        public string Vicinity { get; set; }
        public string Rating { get; set; }
        public string Website { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public List<string> Opening_hours { get; set; }
    }
}
