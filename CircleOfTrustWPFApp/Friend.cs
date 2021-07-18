using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleOfTrustWPFApp
{
    public class Friend
    {

        public string Name { get; set; }
       
        public bool[] Stars { get; set; } = { false, false, false, false, false };
        public Friend()
        {
            Name = "";
          
        }

        public Friend(string name, int grade)
        {
            Name = name;
           
        }
        public Friend(string name)
        {
            Name = name;
           
        }
    }
}
