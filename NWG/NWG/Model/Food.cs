 using System;
 using System.Collections.Generic;
 using System.ComponentModel;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;

namespace NWG.Model
{
    public class Food
    {
        public string Name { get; set; }
        public bool IsReviewed { get; set; } = true;

        public string StatusIcon
        {
            get { return IsReviewed ? "Green.png" : "Red.png"; }
        }

    }
}
