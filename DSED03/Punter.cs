using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSED03.Guy
{
    public abstract class Punter
    {

        public string Name { get; set; }

        public int Cash { get; set; }

        public int Dragon { get; set; }

        public int BetAmount { get; set; }

        public int WinningDragon { get; set; }

       public  string DragonName { get; set; }

       public bool Busted { get; set; }




    }
}
