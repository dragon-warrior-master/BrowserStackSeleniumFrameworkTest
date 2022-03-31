using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class Flipkart
    {
        public Flipkart()
        {
            HomePage = new FlipkartHomePage();
        }
        public FlipkartHomePage HomePage { get; set; }
    }
}
