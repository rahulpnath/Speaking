using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleNew.Model
{
    public class PhotoStream
    {
        public string feature { get; set; }
        public Filters filters { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }
        public int total_items { get; set; }
        public List<Photo> photos { get; set; }
    }
}
