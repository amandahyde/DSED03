using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSED03.Guy;

namespace DSED03
{
   public class Tom: Punter
    {
      public Tom()
        {
            Name = "Tom";
            Cash = 50;
        }
    }

    public class Dick : Punter
    {
        public Dick()
        {
            Name = "Dick";
            Cash = 40;

        }
    }

    public class Harry : Punter
    {
        public Harry()
        {
            Name = "Harry";
            Cash = 55;
        }
    }


    
}
